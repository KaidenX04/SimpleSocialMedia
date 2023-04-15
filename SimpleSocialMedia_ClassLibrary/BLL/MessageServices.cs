using Microsoft.Data.SqlClient.DataClassification;
using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class MessageServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal MessageServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }

        public void CreateMessage(int chatID, int accountID, string text)
        {
            Message message = new();
            message.AccountID = accountID;
            message.ChatID = chatID;
            message.Text = text;
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public List<Message> GetMessage_ChatID(int chatId)
        {
            return _context.Messages.Where(x => x.ChatID == chatId).ToList();
        }

        public List<Message> GetMessage_ChatAndAccountID(int chatId, int accountId)
        {
            List<Message> messages = _context.Messages.Where(x => x.ChatID == chatId && x.AccountID == accountId).ToList();
            return messages;
        }
    }
}