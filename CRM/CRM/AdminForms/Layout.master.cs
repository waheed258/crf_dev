using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminForms_Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Name"] == null || Session["Name"].ToString() == "")
            {
                Response.Redirect("../AdminLogin.aspx", false);
            }
            else
            {               
                    lblUserName.Text = Session["Name"].ToString().ToUpper();
                    if (Session["Image"].ToString() == "")
                    {
                        imgProfilePic.ImageUrl = "../assets/dist/img/avatar5.png";
                    }
                    else
                    {
                        imgProfilePic.ImageUrl = Session["Image"].ToString();
                    }
                
            }
        }
        catch
        {
            Response.Redirect("../AdminLogin.aspx", false);
        }
    }
}
