using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class CreatePostModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int AccountID { get; set; }

        private readonly AccountServices _accountServices;

        private readonly PostServices _postServices;

        public Account Login;

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
            Post post = new();
            post.AccountID = AccountID;
            post.Text = PostText;
            post.Likes = 0;
            _postServices.CreatePost(post);
            return Redirect($"/Main/{AccountID}");
        }
    }
}
