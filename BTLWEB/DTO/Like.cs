using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTLWEB.DTO
{
    public class Like
    {
        private int likeid;
        private int postid;
        private int userid;
        private int commentid;


        public Like(int postId, int categoryid, int userId, string title, string content, DateTime datetime, int like, int dislike, int view)
        {
            this.postid = postId;
            this.userid = userId;
       
          
        }

        public Like(DataRow row)
        {
           
           
           this.Likeid=Convert.ToInt32(row["likeid"]);
            this.postid = Convert.ToInt32(row["postid"]);
            this.userid = Convert.ToInt32(row["userid"]);
          this.Commentid = Convert.ToInt32(row["commentid"]);

        }


        public int Postid { get => postid; set => postid = value; }
        public int Userid { get => userid; set => userid = value; }
        public int Likeid { get => likeid; set => likeid=value; }
        public int Commentid { get => commentid; set => commentid=value; }
    }
}