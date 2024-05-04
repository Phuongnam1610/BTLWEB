using BTLWEB.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTLWEB.DTO
{
    public class Comment
    {
        private int userid;
        private int commentid;
        private int commentidreply;
        private User user;
        private DateTime datetime;
        private  int likecount;
        private string commenttext;
        private string profilepicture;
        private int postid;
        private Comment commentreply;

        public Comment( int userId, int commentid, string commenttext, DateTime datetime, int like, int dislike)
        {
            this.Commentid=commentid;
            this.Commenttext=commenttext;
            this.userid = userId;
            this.datetime = datetime;
         
        }

        public Comment(DataRow row)
        {   this.Commentid=Convert.ToInt32(row["commentid"]);
            this.userid = Convert.ToInt32(row["userid"]);
            this.Postid=Convert.ToInt32(row["postid"]);
            this.User=UserDAO.Instance.GetUserByID(userid.ToString());
            this.datetime = Convert.ToDateTime(row["DateTimeCommented"]);
            this.commenttext=row["commenttext"].ToString();
            try { this.Commentidreply=Convert.ToInt32(row["commentidreply"]);
                this.Commentreply=CommentDAO.Instance.GetCommentByCommentID(commentidreply.ToString());
            }
            catch { 
            
            }
            this.Likecount=Convert.ToInt32(DataProvider.Instance.ExecuteScalar("exec LikeCountByCommentID @commentid", new object[] { commentid }));

        }


        public int Userid { get => userid; set => userid = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }

        public int Commentid { get => commentid; set => commentid=value; }
        public string Commenttext { get => commenttext; set => commenttext=value; }
        public int Commentidreply { get => commentidreply; set => commentidreply=value; }
        public int Likecount { get => likecount; set => likecount=value; }
        public string Profilepicture { get => profilepicture; set => profilepicture=value; }
        public User User { get => user; set => user=value; }
        public int Postid { get => postid; set => postid=value; }
        public Comment Commentreply { get => commentreply; set => commentreply=value; }
    }
}