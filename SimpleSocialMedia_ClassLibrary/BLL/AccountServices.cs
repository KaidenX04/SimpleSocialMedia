using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class AccountServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal AccountServices(SimpleSocialMediaContext context) 
        { 
            _context = context;
        }

        public Account GetAccount_Login(string username, string password)
        {
            Account account = _context.Accounts.Where(x => x.Username == username && x.Password == password).First();
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            string token;
            Account tokenExists = null;

            do
            {
                token = GenerateToken();
                tokenExists = _context.Accounts.Where(x => x.AuthToken == token).FirstOrDefault();
            } while (tokenExists != null);

            account.AuthToken = token;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }

        public Account GetAccount_ID(int id)
        {
            return _context.Accounts.Where(x => x.AccountID == id).First();
        }

        public Account GetAccount_Token(string token) 
        {
            return _context.Accounts.Where(x => x.AuthToken == token).FirstOrDefault();
        }

        public void CreateAccount(string username, string password) 
        {
            Account account = new();
            account.Username = username;
            account.Password = password;
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void ChangePassword(int accountID, string password)
        {
            Account account = _context.Accounts.Where(x => x.AccountID == accountID).FirstOrDefault();

            if (account != null)
            {
                account.Password = password;
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
        }

        public string GenerateToken()
        {
            const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
            string token = "";
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                token += AllowedChars[random.Next(0, AllowedChars.Length)];
            }
            return token;
        }
    }
}
