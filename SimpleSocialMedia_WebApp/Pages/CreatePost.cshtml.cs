using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class CreatePostModel : PageModel
    {
        private readonly AccountServices _accountServices;

        private readonly PostServices _postServices;

        public Account Login { get; set; }

        [BindProperty]
        public string PostText { get; set; }

        public CreatePostModel(AccountServices accountServices, PostServices postServices)
        {
            _accountServices = accountServices;
            _postServices = postServices;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostCreatePost()
        {
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            Login = _accountServices.GetAccount_Login(username, password);
            if (Login == null)
            {
                return Redirect("/Index");
            }
            Post post = new();
            post.AccountID = Login.AccountID;
            post.Text = PostText;
            post.Likes = 0;
            _postServices.CreatePost(post);
            return Redirect($"/Main");
        }
    }
}
