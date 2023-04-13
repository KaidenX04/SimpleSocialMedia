using Microsoft.Data.SqlClient.DataClassification;
using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    internal class PostServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal PostServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }
        
        public List<Post> GetPosts_All() 
        {
            return _context.Posts.ToList();
        }

        public List<Post> GetPosts_Account(int accountID) 
        {
            return _context.Posts.Where(x => x.AccountID == accountID).ToList();
        }
    }
}
