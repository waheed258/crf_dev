using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientForms_Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Session["SAID"] == null || Session["SAID"].ToString() == "")
            {
                Response.Redirect("../ClientLogin.aspx", false);
            }
            else
            {
              
                    lblUserName.Text = Session["ClientName"].ToString().ToUpper();
                    if (Session["Image"].ToString() == "" || Session["Image"].ToString() == null)
                    {
                        imgProfilePic.ImageUrl = "../assets/dist/img/avatar5.png";
                    }
                    else
                    {
                        if (File.Exists(Server.MapPath(Session["Image"].ToString())))
                        {
                            imgProfilePic.ImageUrl = Session["Image"].ToString();
                        }
                        else {
                            imgProfilePic.ImageUrl = "../assets/dist/img/avatar5.png";
                        }
                    }
                }
            
        }
        catch
        {
            Response.Redirect("../ClientLogin.aspx", false);
        }

    }
}
