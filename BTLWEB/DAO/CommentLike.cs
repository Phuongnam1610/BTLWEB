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
    public class CommentLikeDAO
    {
        private static CommentLikeDAO instance;

        public static CommentLikeDAO Instance
        {
            get { if (instance == null) instance = new CommentLikeDAO(); return instance; }
            private set { instance = value; }
        }

        private CommentLikeDAO() { }

        
        public void UnlikeComment(string commentID, string userID)
        {
            DataProvider.Instance.ExecuteNoneQuery("exec UnlikeComment @commentID , @userID", new object[] { commentID, userID });

        }
        public void likeComment(string postID, string userID)
        {
            DataProvider.Instance.ExecuteNoneQuery("exec likeComment @postID , @userID", new object[] { postID, userID });

        }

        public bool checkCommentLike(string commentID, string userID) {
            DataTable datatable = DataProvider.Instance.ExecuteQuery("exec checkCommentLike @commentID , @userID", new object[] { commentID, userID });
            if(datatable.Rows.Count > 0) {
                return true;
            }
            return false;
        }


        public List<Post> GetListPost()
        {
            List<Post> list = new List<Post>();
            string query = "select * from Posts";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Post post = new Post(item);
                list.Add(post);
            }
            return list;
        }

        public Post GetPostByID(string id)
        {
            Post p = null;
            string query = "select * from Posts where PostID= '" + id + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                p = new Post(item);
                return p;
            }
            return p;


        }
    }
}
