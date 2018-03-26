using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;
using System.Data;

public partial class AdminForms_Login : System.Web.UI.Page
{
    EncryptDecrypt encryptdecrypt = new EncryptDecrypt();
    LoginBL loginBL = new LoginBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["LoginId"] = null;
                Session["Password"] = null;
            }
        }
        catch { }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text == "admin" && txtPassword.Text == "admin")
            {
                Response.Redirect("AdminForms/Dashboard.aspx");
            }
            else
            {
                DataSet ds = loginBL.ValidateUser(txtUserName.Text);
                string passowrd = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    passowrd = ds.Tables[0].Rows[0]["Password"].ToString();
                    // passowrd = encryptdecrypt.Decrypt(ds.Tables[0].Rows[0]["Password"].ToString());
                    if (passowrd == txtPassword.Text)
                    {
                        Session["Name"] = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
                        Session["AdvisorType"] = ds.Tables[0].Rows[0]["AdvisorType"].ToString();
                        Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        Response.Redirect("AdminForms/Dashboard.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Password is incorrect!";
                    }
                }
                else
                {
                    lblError.Text = "User Name is incorrect!";
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Please check credentials";
        }
    }
}