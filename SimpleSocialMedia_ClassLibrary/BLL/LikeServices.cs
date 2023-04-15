using Microsoft.Data.SqlClient.DataClassification;
using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class LikeServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal LikeServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }

        public bool IsLiked(int accountID, int postID)
        {
            Like like = _context.Likes.Where(x => x.AccountID == accountID && x.PostID == postID).FirstOrDefault();
            if (like == null) 
            {
                return false;
            }
            return true;
        }

        public int GetLikes_Account(int accountID) 
        {
            return _context.Likes.Where(x => x.AccountID == accountID).Count();
        }

        public void CreateLike(int accountID, int postID)
        {
            Like like = new();
            like.AccountID = accountID;
            like.PostID = postID;
            like.Liked = true;
            _context.Likes.Add(like);
            _context.SaveChanges();
        }
    }
}
