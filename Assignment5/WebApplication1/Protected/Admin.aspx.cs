using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Protected
{
    public partial class administrator : System.Web.UI.Page
    {
        // when page loads
        protected void Page_Load(object sender, EventArgs e)
        {
            // if there are cookies, display username at the top of the page
            HttpCookie myCookie = Request.Cookies["key"];
            if (myCookie != null)
            {
                Session["Username"] = myCookie["Username"];
                Label1.Text = Session["Username"].ToString();
            }
            // displays contents of staff and admin db file in grid view
            DataSet ds = new DataSet();
            ds.ReadXml(HttpRuntime.AppDomainAppPath + @"App_Data\login_db.xml");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        //sign out, clears session and sets cookie to expire, redirects to default
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            HttpCookie myCookie = Request.Cookies["key"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            FormsAuthentication.SignOut();
            Response.Redirect("/Default.aspx");
        }
        // return home button
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}