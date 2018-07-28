using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class imageVerifier : System.Web.UI.Page
    {
        //at load of page, call image verifier service
        // hardcode length of 5 for image verrification
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            ImageVerifier.ServiceClient client = new ImageVerifier.ServiceClient();
            string myStr, userLen;
            if (Session["generatedString"] == null)
            {
                if (Session["userLength"] == null)
                {
                    userLen = "5";
                }
                else
                {
                    userLen = Session["userLength"].ToString();
                }
                // generated string is saved to session
                myStr = client.GetVerifierString(userLen);
                Session["generatedString"] = myStr;
            }
            else
            {
                // if there already is a string in this session
                myStr = Session["generatedString"].ToString();
            }
            //draw image
            Stream myStream = client.GetImage(myStr);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(myStream);
            Response.ContentType = "image/jpeg";
            myImage.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}