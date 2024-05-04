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
    public class PostDAO
    {
        private static PostDAO instance;

        public static PostDAO Instance
        {
            get { if (instance == null) instance = new PostDAO(); return instance; }
            private set { instance = value; }
        }

        private PostDAO() { }

        public DataTable GetListPostInfo()
        {
            return DataProvider.Instance.ExecuteQuery("exec GetListPostInfo");

        }

        public List<Post> GetListPost()
        {
            List<Post> list = new List<Post>();
            string query = "select * from Posts where IsApproved = 1";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Post post = new Post(item);
                list.Add(post);
            }
            return list;
        }

        public List<Post> GetListPostAdmin()
        {
            List<Post> list = new List<Post>();
            string query = "exec GetAllPostsAdmin";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Post post = new Post(item);
                list.Add(post);
            }
            return list;
        }

        public List<Post> GetListPostByUserID(string userid)
        {
            List<Post> list = new List<Post>();
            string query = "exec GetPostsByUserID @userid";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] { userid });
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




        public void InsertNewPost( string userid, string title, string content,string categoryid,string isapproved="0")
        {
            string query = "exec addnewpost @userid , @title , @content , @categoryid , @isapproved";
            DataProvider.Instance.ExecuteNoneQuery(query, new object[] {userid, title, content,categoryid,isapproved});
        }
        
        public void UpdatePostApproval(string postid)
        {
            string query = "exec UpdatePostApproval @postid";
            DataProvider.Instance.ExecuteNoneQuery(query, new object[] { postid });
        }


    }
}
