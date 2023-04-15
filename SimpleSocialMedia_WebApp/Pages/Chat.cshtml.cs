using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_WebApp.Pages
{
	public class ChatModel : PageModel
    {
        private readonly AccountServices _accountServices;

        public ChatModel(AccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        public IActionResult OnGet()
        {
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            Account login = _accountServices.GetAccount_Login(username, password);
            if (login == null)
            {
                return Redirect("/index");
            }
            return Page();
        }
    }
}
