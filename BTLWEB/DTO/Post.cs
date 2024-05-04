using BTLWEB.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTLWEB.DTO
{
    public class Post
    {
        private int postid;
        private int userid;
        private int categoryid;
        private string title;
        private string content;
        private User user;

        private DateTime datetime;
        private int likeCount;
        private  int isapproved;

        private int commentCount;
        public Post(int postId, int categoryid, int userId, string title, string content, DateTime datetime, int like, int dislike, int view)
        {
            this.Categoryid= categoryid;
            this.postid = postId;
            this.userid = userId;
            this.title = title;
            this.content = content;
            this.datetime = datetime;

        }

        public Post(DataRow row)
        {


            this.Categoryid=Convert.ToInt32(row["categoryid"]);

            this.postid = Convert.ToInt32(row["postid"]);
            this.userid = Convert.ToInt32(row["userid"]);
            this.User=UserDAO.Instance.GetUserByID(userid.ToString());
            this.title = row["title"].ToString();
            this.content = row["content"].ToString();
            this.datetime = Convert.ToDateTime(row["DateTimePosted"]);
            this.likeCount=Convert.ToInt32(DataProvider.Instance.ExecuteScalar("exec LikeCountByPostID @posid", new object[] { postid }));
            this.Isapproved=Convert.ToInt32(row["IsApproved"]);
            this.CommentCount=Convert.ToInt32(DataProvider.Instance.ExecuteScalar("exec GetCommentCountByPostID @posid", new object[] { postid }));
        }


        public int Postid { get => postid; set => postid = value; }
        public int Userid { get => userid; set => userid = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }

        public int Categoryid { get => categoryid; set => categoryid=value; }
        public int LikeCount { get => likeCount; set => likeCount=value; }
        public int Isapproved { get => isapproved; set => isapproved=value; }
        public User User { get => user; set => user=value; }
        public int CommentCount { get => commentCount; set => commentCount=value; }
    }
}