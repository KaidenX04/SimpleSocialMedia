using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_WebApp.Pages
{
	public class MessageModel : PageModel
    {
        private AccountServices _accountServices;

        private MessageServices _messageServices;

        private ChatServices _chatServices;

        [BindProperty]
        public string MessageText { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ChatAccountID { get; set; }

        public List<Message> messages { get; set; }

        public MessageModel(AccountServices accountServices, MessageServices messageServices, ChatServices chatServices)
        {
            _accountServices = accountServices;
            _messageServices = messageServices;
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
            Chat chat = _chatServices.GetChat_BothAccount(login.AccountID, ChatAccountID);
            messages = _messageServices.GetMessage_ChatID(chat.ChatID);
            messages.Reverse();
            return Page();
        }

        public string GetUsername_AccountID(int accountID)
        {
            Account account = _accountServices.GetAccount_ID(accountID);
            return account.Username;
        }

        public IActionResult OnPostSendMessage()
        {
            Chat chat;
            string username = Request.Cookies["Username"];
            string password = Request.Cookies["Password"];
            Account login = _accountServices.GetAccount_Login(username, password);
            if (login == null)
            {
                return Redirect("/index");
            }
            if (string.IsNullOrWhiteSpace(MessageText))
            {
                chat = _chatServices.GetChat_BothAccount(login.AccountID, ChatAccountID);
                messages = _messageServices.GetMessage_ChatID(chat.ChatID);
                messages.Reverse();
                return Page();
            }
            chat = _chatServices.GetChat_BothAccount(login.AccountID, ChatAccountID);
            _messageServices.CreateMessage(chat.ChatID, login.AccountID, MessageText);
            messages = _messageServices.GetMessage_ChatID(chat.ChatID);
            messages.Reverse();
            ModelState.Clear();
            MessageText = "";
            return Page();
        }
    }
}
