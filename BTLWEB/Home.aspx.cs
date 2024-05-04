using BTLWEB.DAO;
using BTLWEB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTLWEB
{
    public partial class Home : System.Web.UI.Page
    {
        List<Post> listPosts;
        List<Category> listCategories;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["RefreshData"] != null && (bool)Session["RefreshData"])
            //{
            //    listPosts= PostDAO.Instance.GetListPost();
            //    rpthome.DataSource = listPosts;
            //    rpthome.DataBind();

            //    listCategories = CategoryDAO.Instance.GetListCategory();
            //    selectcate.DataSource= listCategories;
            //    selectcate.DataBind();
            //    // Làm mới dữ liệu ở đây
            //    Session["RefreshData"] = false; // Đặt lại giá trị để không làm mới lại mỗi lần load trang
            //}
            listPosts= PostDAO.Instance.GetListPost();
            listCategories = CategoryDAO.Instance.GetListCategory();
            rpthome.DataSource = listPosts;
            rpthome.DataBind();

            selectcate.DataSource= listCategories;
            selectcate.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //Session["RefreshData"] = true;
        }


    }
}