using Microsoft.Data.SqlClient.DataClassification;
using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class ChatServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal ChatServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }

        public void CreateChat(int firstAccount, int secondAccount)
        {
            Chat chat = new();
            _context.Chats.Add(chat);
            _context.SaveChanges();
        }

        public List<Chat> GetChat_Account(int accountID)
        {
            return _context.Chats.Where(x => x.Account1ID == accountID || x.Account2ID == accountID).ToList();
        }
    }
}