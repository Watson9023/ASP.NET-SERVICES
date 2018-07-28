using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // send to registration page
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
        // send to member login page
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin.aspx");
        }
        // send to staff page
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Protected/Staff.aspx");
        }
        // send to login page
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}