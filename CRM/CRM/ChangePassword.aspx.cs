using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;
using System.Data;
public partial class ChangePassword : System.Web.UI.Page
{
    EncryptDecrypt encryptdecrypt = new EncryptDecrypt();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

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
            if (strPreviousPage == "")
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
        }
        catch
        {
            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCreatePassword.Text == txtConfirmPassword.Text)
            {
                int result = ManageCredentials();
                if (result == 1)
                {
                    Session.Remove("email");
                    Response.Redirect("Login.aspx", false);
                }
            }
            else
            {
                lblError.Text = "Both Passwords should match";
            }
        }
        catch { }
    }

    protected int ManageCredentials()
    {

        CredentialsBO _objCre = new CredentialsBO
        {
            EmailID = Session["email"].ToString(),
            Password = txtCreatePassword.Text,
            FirstName = "",
            LastName = "",
            Image = ""
        };
        return new CredentialsBL().ManageCredentials(_objCre, 'C');

    }
}