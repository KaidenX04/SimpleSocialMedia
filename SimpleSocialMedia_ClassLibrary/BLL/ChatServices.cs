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
            Chat exists = _context.Chats.Where(x => (x.Account1ID == firstAccount && x.Account2ID == secondAccount) || (x.Account2ID == firstAccount && x.Account1ID == secondAccount)).FirstOrDefault();
            if (exists != null)
            {
                throw new Exception("Chat already exists");
            }

            Chat chat = new();
            chat.Account1ID = firstAccount;
            chat.Account2ID = secondAccount;
            _context.Chats.Add(chat);
            _context.SaveChanges();
        }

        public List<Chat> GetChat_Account(int accountID)
        {
            return _context.Chats.Where(x => x.Account1ID == accountID || x.Account2ID == accountID).ToList();
        }

        public Chat GetChat_BothAccount(int accountID, int account2ID)
        {
            return _context.Chats.Where(x => (x.Account1ID == accountID && x.Account2ID == account2ID) || (x.Account2ID == accountID && x.Account1ID == account2ID)).FirstOrDefault();
        }
    }
}