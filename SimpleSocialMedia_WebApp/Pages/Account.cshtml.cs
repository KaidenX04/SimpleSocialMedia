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

        public Account Login { get; set; }

        private string LoginToken { get; set; }

        public AccountModel(AccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        public void OnGet()
        {
            LoginToken = Request.Cookies["LoginToken"];
            Login = _accountServices.GetAccount_Token(LoginToken);
        }
    }
}
