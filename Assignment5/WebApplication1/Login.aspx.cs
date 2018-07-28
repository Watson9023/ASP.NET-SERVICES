using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        // check if there are elements in session
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count > 0)
            {
                // display name at the top of the screen
                Label1.Text = "Logged in as: " + Session["Username"].ToString();
            }
        }
        // login 
        protected void Button1_Click(object sender, EventArgs e)
        {
            // save user input and open xml doc using the below filepath
            string filepath = HttpRuntime.AppDomainAppPath + @"App_Data\login_db.xml";
            string user = TextBox1.Text;
            string password = TextBox2.Text;
            // encryption stuff to be added
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            HttpCookie myCookie = new HttpCookie("key");
            XmlElement rootElement = doc.DocumentElement;
            // for each member contained in the staff and admin xml db..
            foreach (XmlNode node in rootElement.ChildNodes)
            {
                // if the name and password match, check to see if they are admin or staff and redirect accordingly
                if (node["name"].InnerText == user)
                {
                    if (node["pwd"].InnerText == password)
                    {
                        if(node["role"].InnerText == "Staff")
                        {
                            // save session and cookie details
                            Label1.Text = "Success";
                            FormsAuthentication.RedirectFromLoginPage("Staff", false);
                            Session["Username"] = user;
                            Session["Password"] = password;
                            myCookie["Username"] = user;
                            myCookie["Password"] = password;
                            myCookie.Expires = DateTime.Now.AddDays(1);
                            // redirect
                            Response.Cookies.Add(myCookie);
                            return;
                        }
                        else
                        {
                            // save session and cookie details

                            Label1.Text = "Success";
                            FormsAuthentication.RedirectFromLoginPage("Admin", false);
                            Session["Username"] = user;
                            Session["Password"] = password;
                            myCookie["Username"] = user;
                            myCookie["Password"] = password;
                            myCookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(myCookie);
                            // redirect
                            Response.Redirect("Protected/Admin.aspx");
                            return;
                        }
                    }

                }
            }
            Label1.Text = "Invalid Username or Password. Please try again.";
        }
        // redirect home
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}