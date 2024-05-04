using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTLWEB.DTO
{
    public class Category
    {

        private int categoryid;
        private string categoryname;

        public int Categoryid { get => categoryid; set => categoryid = value; }
        public string Categoryname { get => categoryname; set => categoryname = value; }

        public Category(int categoryid,string categoryname)
        {
            this.Categoryid  = categoryid;
            this.Categoryname=categoryname;
           
        }

        public Category(DataRow row)
        {
            this.Categoryid = Convert.ToInt32(row["categoryid"]);
            this.Categoryname = row["categoryname"].ToString();
    

        }
    }
}