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
        public int AccountID { get; set; }

        private readonly AccountServices _accountServices;

        private readonly PostServices _postServices;

        private readonly CommentServices _commentServices;

        public Account Login { get; set; }

        public int PostsCount { get; set; }

        public int CommentsCount { get; set; }

        public int LikeCount { get; set; }

        public AccountModel(AccountServices accountServices, PostServices postServices, CommentServices commentServices)
        {
            _accountServices = accountServices;
            _postServices = postServices;
            _commentServices = commentServices;
        }

        public IActionResult OnGet()
        {
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            Login = _accountServices.GetAccount_Login(username, password);
            if (Login == null)
            {
                return Redirect("/Index");
            }
            PostsCount = _postServices.GetPostCount_Account(Login.AccountID);
            CommentsCount = _commentServices.GetCommentCount_Account(Login.AccountID);
            LikeCount = _postServices.GetLikeCount_Account(Login.AccountID);
            return Page();
        }
    }
}
