using BTLWEB.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;

namespace BTLWEB.DTO
{
    public class User
    {
        private int userid;
        private string username;
        private string email;
        private string password;
        private string profilepicture;
        private int isadmin;

        public int Userid { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Profilepicture { get => profilepicture; set => profilepicture=value; }
        public int Isadmin { get => isadmin; set => isadmin=value; }

        public User( int userId, string username,string email, string password,string profilepicture)
        {
            this.Userid = userId;
            this.Username=username;
            this.Email=email;
            this.Password=password;
            this.Profilepicture=profilepicture;
        }

        public User(DataRow row)
        {
            this.Userid = Convert.ToInt32(row["userid"]);
            this.Username = row["username"].ToString();
            this.isadmin=Convert.ToInt32(row["isadmin"]);
            this.Email = row["email"].ToString();
            this.Password = row["password"].ToString();
            string appPath = HttpRuntime.AppDomainAppPath;
            string imagePath = "";
            if (File.Exists(imagePath))
            {
                this.profilepicture = userid+".jpg";
            }
            else
            {
                // Ảnh không tồn tại, có thể thiết lập một ảnh mặc định
                this.profilepicture = "default.jpg";
            }
            

        }
        


    }
}