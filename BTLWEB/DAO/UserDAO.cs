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
    public class UserDAO
    {
        private static UserDAO instance;

        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return instance; }
            private set { instance = value; }
        }

        private UserDAO() { }

        public List<User> GetListUser()
        {
            List<User> list = new List<User>();
            string query = "select * from Users";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                User user = new User(item);
                list.Add(user);
            }
            return list;
        }

        public User getUserData(string email, string passWord)
        {
            User u = null;
            string query = "exec check_login @email , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { email, passWord });
            foreach (DataRow item in data.Rows)
            {
                u = new User(item);
                return u;
            }
            return u;
        }

        public bool CheckEmailExists(string email)
        {
            string query = "Exec CheckEmailExists @email";
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query, new object[] { email}));
            return result > 0;
        }

        public void Register(string email, string username, string password)
        {
            string query= "Exec SignUp @email , @username , @password";
            DataProvider.Instance.ExecuteNoneQuery(query,new object[] { email, username,password });
        }

        public User GetUserByID(string id)
        {
            User u = null;
            string query = "exec getuserbyid @userID";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {id});
            foreach (DataRow item in data.Rows)
            {
                u = new User(item);
                return u;
            }
            return u;


        }
    }
}
