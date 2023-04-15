using Microsoft.Data.SqlClient.DataClassification;
using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class PostServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal PostServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }
        
        public List<Post> GetPosts_All() 
        {
            return _context.Posts.OrderByDescending(x => x.PostID).ToList();
        }

        public List<Post> GetPosts_Account(int accountID) 
        {
            return _context.Posts.Where(x => x.AccountID == accountID).ToList();
        }

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void LikePost(int postID)
        {
            Post post = _context.Posts.Where(x => x.PostID == postID).FirstOrDefault();
            post.Likes += 1;
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public int GetPostCount_Account(int accountID)
        {
            return _context.Posts.Where(x => x.AccountID == accountID).Count();
        }

        public int GetLikeCount_Account(int accountID)
        {
            int count = 0;
            List<Post> posts = _context.Posts.Where(x => x.AccountID == accountID).ToList();
            foreach (Post post in posts) 
            { 
                count += post.Likes;
            }
            return count;
        }
    }
}
