using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class AccountModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? viewAccountID { get; set; }

        private readonly AccountServices _accountServices;

        private readonly PostServices _postServices;

        private readonly CommentServices _commentServices;

        private readonly ChatServices _chatServices;

        public Account Login { get; set; }

        public Account OtherAccount { get; set; }

        public int PostsCount { get; set; }

        public int CommentsCount { get; set; }

        public int LikeCount { get; set; }

        public string Username { get; set; }

        public AccountModel(AccountServices accountServices, PostServices postServices, CommentServices commentServices, ChatServices chatServices)
        {
            _accountServices = accountServices;
            _postServices = postServices;
            _commentServices = commentServices;
            _chatServices = chatServices;
        }

        public IActionResult OnGet()
        {
            Account login;
            if (!ValidLogin(out login))
            {
                return Redirect("/Index");
            }
            Login = login;

            if (viewAccountID != null)
            {
                OtherAccount = _accountServices.GetAccount_ID((int)viewAccountID);
                if (OtherAccount == null)
                {
                    return Redirect("/Main");
                }
            }

            if (OtherAccount != null)
            {
                PostsCount = _postServices.GetPostCount_Account(OtherAccount.AccountID);
                CommentsCount = _commentServices.GetCommentCount_Account(OtherAccount.AccountID);
                LikeCount = _postServices.GetLikeCount_Account(OtherAccount.AccountID);
                Username = OtherAccount.Username;
            }
            else
            {
                PostsCount = _postServices.GetPostCount_Account(Login.AccountID);
                CommentsCount = _commentServices.GetCommentCount_Account(Login.AccountID);
                LikeCount = _postServices.GetLikeCount_Account(Login.AccountID);
                Username = Login.Username;
            }

            return Page();
        }

        public IActionResult OnPostCreateChat()
        {
            Account login;
            if (!ValidLogin(out login))
            {
                return Redirect("/index");
            }

            try
            {
                _chatServices.CreateChat((int)viewAccountID, login.AccountID);
            }
            catch (Exception ex)
            {
            }

            return RedirectToPage("Chat");
        }

        public bool ValidLogin(out Account? account)
        {
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            account = _accountServices.GetAccount_Login(username, password);
            if (account == null)
            {
                return false;
            }
            return true;
        }
    }
}
