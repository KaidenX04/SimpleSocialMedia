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

        private readonly ChatServices _chatServices;

        private Account account { get; set; }

        [BindProperty]
        public int ChatAccount { get; set; }

        public List<Chat> chats { get; set; }

        public ChatModel(AccountServices accountServices, ChatServices chatServices)
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
            account = login;
            chats = _chatServices.GetChat_Account(login.AccountID);
            return Page();
        }

        public string GetUsername_AccountID(int accountID)
        {
            Account account = _accountServices.GetAccount_ID(accountID);
            return account.Username;
        }

        public int CorrectAccountId(int account1ID, int account2ID)
        {
            if (account1ID == account.AccountID)
            {
                return account2ID;
            }
            if (account2ID == account.AccountID)
            {
                return account1ID;
            }
            return -1;
        }

        public IActionResult OnPostMessage()
        {
            return Redirect($"Message/{ChatAccount}");
        }
    }
}
