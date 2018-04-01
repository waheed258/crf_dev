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
        if (!IsPostBack)
        {
            try
            {
                if (Session["Name"] == null || Session["Name"].ToString() == "")
                {
                    Response.Redirect("../Login.aspx", false);
                }
                else
                {
                    lblUserName.Text = Session["Name"].ToString().ToUpper();
                }
            }
            catch
            {
                Response.Redirect("../Login.aspx", false);
            }
        }
    }
}
