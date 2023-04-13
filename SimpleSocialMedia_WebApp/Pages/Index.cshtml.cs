using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleSocialMedia_ClassLibrary.BLL;

namespace SimpleSocialMedia_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AccountServices _accountServices;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(AccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        public void OnGet()
        {

        }

        public void OnPostSignUp()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                ModelState.AddModelError(nameof(Username), "Username cannot be blank!");
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError(nameof(Password), "Password cannot be blank!");
            }
            if (ModelState.IsValid) 
            {
                _accountServices.CreateAccount(Username, Password);
            }
        }
    }
}