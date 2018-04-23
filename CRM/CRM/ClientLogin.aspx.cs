using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    EncryptDecrypt encryptdecrypt = new EncryptDecrypt();
    ClientLoginBL loginBL = new ClientLoginBL();
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
            DataSet ds = loginBL.ValidateClient(txtUserName.Text);
            string passowrd = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Status"].ToString() == "1")
                {
                    passowrd = ds.Tables[0].Rows[0]["GenaratePassword"].ToString();
                    Session["GenaratePassword"] = passowrd;
                    Session["email"] = ds.Tables[0].Rows[0]["EmailID"].ToString();
                    Session["SAID"] = ds.Tables[0].Rows[0]["SAID"].ToString();
                    if (passowrd == txtPassword.Text)
                    {
                        Response.Redirect("ChangePassword.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Password is incorrect!";
                    }
                }
                else
                {
                    passowrd = ds.Tables[0].Rows[0]["Password"].ToString();
                    if (passowrd == txtPassword.Text)
                    {
                        Session["ClientName"] = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
                        Session["SAID"] = ds.Tables[0].Rows[0]["SAID"].ToString();
                        Session["email"] = ds.Tables[0].Rows[0]["EmailID"].ToString();
                        Session["Image"] = ds.Tables[0].Rows[0]["Image"].ToString();
                        Response.Redirect("ClientForms/Dashboard.aspx", false);
                    }
                    else
                    {
                        lblError.Text = "Password is incorrect!";
                    }
                }
            }
            else
            {
                lblError.Text = "User Name is incorrect!";
            }

        }
        catch (Exception ex)
        {
            lblError.Text = "Please check credentials";
        }
    }
}