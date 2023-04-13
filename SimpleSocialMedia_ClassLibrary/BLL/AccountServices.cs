﻿using SimpleSocialMedia_ClassLibrary.DAL;
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
            return _context.Accounts.Where(x => x.Username == username && x.Password == password).First();
        }

        public Account GetAccount_ID(int id)
        {
            return _context.Accounts.Where(x => x.AccountID == id).First();
        }

        public void CreateAccount(string username, string password) 
        {
            Account account = new();
            account.Username = username;
            account.Password = password;
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}