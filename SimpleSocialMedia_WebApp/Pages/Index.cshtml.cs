using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

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

        public IActionResult OnGet()
        {
            Account account = null;
            string loginToken = Request.Cookies["LoginToken"];

            if (loginToken != null) 
            {
                account = _accountServices.GetAccount_Token(loginToken);
            }

            if (account != null) 
            {
                return Redirect("/Main");
            }
            return Page();
        }

        public IActionResult OnPostSignUp()
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
                Account login = _accountServices.GetAccount_Login(Username, Password);
                Response.Cookies.Append("LoginToken", $"{login.AuthToken}");
                return RedirectToPage("Main");
            }
            return Page();
        }

        public IActionResult OnPostLogIn()
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
                try
                {
                    Account login = _accountServices.GetAccount_Login(Username, Password);
                    Response.Cookies.Append("LoginToken", $"{login.AuthToken}");
                    return RedirectToPage("Main");
                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError("Account", "Account not found with these credentials");
                }
            }
            return Page();
        }
    }
}