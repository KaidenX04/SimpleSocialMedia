using SimpleSocialMedia_ClassLibrary.DAL;
using SimpleSocialMedia_ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialMedia_ClassLibrary.BLL
{
    public class CommentServices
    {
        private readonly SimpleSocialMediaContext _context;

        internal CommentServices(SimpleSocialMediaContext context)
        {
            _context = context;
        }

        public List<Comment> GetComment_Post(int postId)
        {
            return _context.Comments.Where(x => x.PostID == postId).OrderBy(x => x.PostID).ToList();
        }

        public int GetCommentCount_Account(int accountID)
        {
            return _context.Comments.Where(x => x.AccountID == accountID).Count();
        }

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}