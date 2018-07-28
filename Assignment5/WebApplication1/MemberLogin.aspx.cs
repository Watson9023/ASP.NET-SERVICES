using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1.Account
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count > 0)
            {
                Label1.Text = "Logged in as: " + Session["Username"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // cookies saved to 'key'
            HttpCookie myCookie = new HttpCookie("key");
            // create filepath
            string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\members.xml";
            // get user input
            string user = TextBox1.Text;
            string password = TextBox2.Text;
            // error handling, checking if user input empty
            if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(password))
            {
                // client for encryption service
                Cryption.ServiceClient client = new Cryption.ServiceClient();
                // open xml doc and load from filepath
                XmlDocument doc = new XmlDocument();
                doc.Load(filepath);
                XmlElement rootElement = doc.DocumentElement;
                // for each member in members.xml
                foreach (XmlNode node in rootElement.ChildNodes)
                {
                    // name matches
                    if (node["name"].InnerText == user)
                    {
                        string temp = node["pwd"].InnerText;
                        temp = client.Decrypt(temp);
                        // encrypted password matches user password
                        if (temp == password)
                        {
                            Label1.Text = String.Format("Success", TextBox1.Text);
                            FormsAuthentication.RedirectFromLoginPage(user, false);
                            Session["Username"] = user;
                            Session["Password"] = password;
                            myCookie["Username"] = user;
                            myCookie["Password"] = password;
                            myCookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(myCookie);
                            Response.Redirect("Account/Members.aspx");
                            return;
                        }

                    }
                }
            }
            Label1.Text = "Invalid Username or Password. Please Try Again.";
        }
        //redirect home
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}