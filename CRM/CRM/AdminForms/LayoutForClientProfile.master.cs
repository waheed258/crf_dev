using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminForms_LayoutForClientProfile : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["AdvisorID"] == null || Session["AdvisorID"].ToString() == "")
            {
                Response.Redirect("../AdminLogin.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    
                }
            }
        }
        catch
        {
            Response.Redirect("../AdminLogin.aspx", false);
        }
    }
}
