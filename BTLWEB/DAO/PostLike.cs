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
    public class PostLikeDAO
    {
        private static PostLikeDAO instance;

        public static PostLikeDAO Instance
        {
            get { if (instance == null) instance = new PostLikeDAO(); return instance; }
            private set { instance = value; }
        }

        private PostLikeDAO() { }

        
        public void likePost(string postID, string userID)
        {
            DataProvider.Instance.ExecuteNoneQuery("exec likePost @postID , @userID", new object[] { postID, userID });

        }

        public bool checkPostLike(string postID, string userID)
        {
            DataTable datatable = DataProvider.Instance.ExecuteQuery("exec checkPostLike @postID , @userID", new object[] { postID, userID });
            if (datatable.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void UnlikePost(string postID, string userID)
        {
            DataProvider.Instance.ExecuteNoneQuery("exec UnlikePost @postID , @userID", new object[] { postID, userID });

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
