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
	public class CreateChatModel : PageModel
    {
        private readonly AccountServices _accountServices;

        private readonly ChatServices _chatServices;

        [BindProperty]
        public int AccountID { get; set; }

        [BindProperty]
        public string Username { get; set; }

        public CreateChatModel(AccountServices accountServices, ChatServices chatServices)
        {
            _accountServices = accountServices;
            _chatServices = chatServices;
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
            AccountID = login.AccountID;
            return Page();
        }

        public IActionResult OnPostCreateChat()
        {
            int account2ID = -1;
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            Account login = _accountServices.GetAccount_Login(username, password);
            if (login == null)
            {
                return Redirect("/index");
            }
            account2ID = _accountServices.GetAccountId_Username(Username);
            if (account2ID == -1)
            {
                ModelState.AddModelError("User", "Cannot find username");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _chatServices.CreateChat(account2ID, login.AccountID);
                    return RedirectToPage("Chat");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Chat", "Chat already exists");
                }
            }
            return Page();
        }
    }
}
