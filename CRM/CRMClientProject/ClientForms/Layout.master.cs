using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientForms_Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                if(Session["SAID"]==null || Session["SAID"].ToString()=="")
                {
                    Response.Redirect("../Login.aspx", false);
                }
            }
            catch
            {
                Response.Redirect("../Login.aspx", false);
            }
        }
    }
}
