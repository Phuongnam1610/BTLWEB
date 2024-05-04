using BTLWEB.DAO;
using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BTLWEB.DAO
{
    public class CommentDAO
    {
        private static CommentDAO instance;

        public static CommentDAO Instance
        {
            get { if (instance == null) instance = new CommentDAO(); return instance; }
            private set { instance = value; }
        }

        private CommentDAO() { }

        public List<Comment> GetListCommentByPostID(string id)
        {
            List<Comment> list = new List<Comment>();
            string query = "EXEC GetCommentsByPostID @PostID";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            foreach (DataRow item in data.Rows)
            {
                Comment c = new Comment(item);
                list.Add(c);
            }
            return list;
        }


        public Comment GetCommentByCommentID(string commentid)
        {
            Comment c = null;
            string query = "exec GetCommentByCommentID @commentid";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { commentid });
            foreach (DataRow item in data.Rows)
            {
                c = new Comment(item);
                return c;
            }
            return c;
        }

        public bool InsertCommentPost(int postID, int userID, string commentText)
        {
            string query = "exec InsertComment @userID , @postID , @commentText";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { userID, postID    , commentText });
            return result > 0;
        }

        public bool InsertCommentReply(int postID, int userID, string commentText,string commentidreply)
        {
            string query = "exec InsertComment @userID , @postID , @commentText , @commentidreply";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { postID, userID, commentText,commentidreply  });
            return result > 0;

        }

        public bool DeleteComment(string commentid)
        {
            string query = "exec DeleteComment @commentid";
            int result = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { commentid });
            return result > 0;
        }

    }
}
