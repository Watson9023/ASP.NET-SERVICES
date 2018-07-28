using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        // clear label at load
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }
        // get new image for image verification
        protected void Button1_Click(object sender, EventArgs e)
        {
            ImageVerifier.ServiceClient client = new ImageVerifier.ServiceClient();
            string myStr = client.GetVerifierString("5");
            Session["generatedString"] = myStr;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // only if image verifier is working
            if (Session["generatedString"].Equals(TextBox3.Text))
            {
                // get path
                string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\members.xml";
                // save info
                string user = TextBox1.Text;
                string password = TextBox2.Text;
                // ensures textboxes are filled
                if (!String.IsNullOrWhiteSpace(user) && !String.IsNullOrWhiteSpace(password))
                {
                    // encrypt password before written to xml doc
                    Cryption.ServiceClient client = new Cryption.ServiceClient();
                    string en_pass = client.Encrypt(password);
                    // new xml doc
                    XmlDocument doc = new XmlDocument();
                    // open file
                    doc.Load(filepath);
                    // get root node
                    XmlElement rootElement = doc.DocumentElement;
                    // for each self-registered member
                    foreach (XmlNode node in rootElement.ChildNodes)
                    {
                        // if name matches, do not re-register
                        if (node["name"].InnerText == user)
                        {
                            Label1.Text = String.Format("The username {0} already exists, please try again", TextBox1.Text);
                            return;
                        }
                    }
                    // add a new member
                    XmlElement myMember = doc.CreateElement("member", rootElement.NamespaceURI);
                    rootElement.AppendChild(myMember);
                    XmlElement myUser = doc.CreateElement("name", rootElement.NamespaceURI);
                    myMember.AppendChild(myUser);
                    myUser.InnerText = user;
                    // pasword
                    XmlElement myPwd = doc.CreateElement("pwd", rootElement.NamespaceURI);
                    myMember.AppendChild(myPwd);
                    myPwd.InnerText = en_pass;
                    // save changes
                    doc.Save(filepath);
                    Response.Redirect("Default.aspx");
                }
                // error handling
                else
                {
                    Label1.Text = "Please enter username/password";
                }

            }
            else
            {
                // error message
                Label1.Text = "The string entered does not match the image. Please Try again!";
            }
        }
    }
}