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
    public partial class Staff : System.Web.UI.Page
    {
        // @ page load, display username at the top of the page
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["key"];
            if (myCookie != null)
            {
                Session["Username"] = myCookie["Username"];
                Label1.Text = Session["Username"].ToString();
            }
            // display gridview of self registered members
            DataSet ds = new DataSet();
            ds.ReadXml(HttpRuntime.AppDomainAppPath + @"App_Data\members.xml");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        // sign out, clear cookies and session
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
        // return home
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}