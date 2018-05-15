﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
using System.Data;

public partial class AdminForms_ClientRegistrationForm : System.Web.UI.Page
{
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    CommanClass _objComman = new CommanClass();
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
            }
            if (strPreviousPage == "")
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            if (!IsPostBack)
            {
                _objComman.GetProvince(ddlProvince);
                _objComman.GetCity(ddlCity);
            }
        }
        catch
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            int res = newClientRegistrationBL.CheckClient(txtEmailId.Text, txtSAID.Text);
            if (res == 1)
            {
                lblMessage.Text = "Client already exists with the same Email ID or SAID!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
            else
            {
                clientRegEntity.FirstName = txtFirstName.Text;
                clientRegEntity.LastName = txtLastName.Text;
                clientRegEntity.MobileNumber = txtMobile.Text;
                clientRegEntity.SAID = txtSAID.Text;
                clientRegEntity.Title = ddlTitle.SelectedItem.Text;
                clientRegEntity.EmailID = txtEmailId.Text;
                clientRegEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
                clientRegEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
               

                int result = newClientRegistrationBL.CUDclientinfo(clientRegEntity, 'i');
                if (result == 1)
                {
                    SendMail(txtEmailId.Text.Trim());  
                    lblMessage.Text = "Client Registered Successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Clear();
                }
                else
                {

                    Clear();
                }
            }
        }
        catch 
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    public void SendMail(string ToMail)
    {
        DataSet ds = newClientRegistrationBL.get_config_mst();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string SmtpServer = ds.Tables[0].Rows[0]["con_smtp_host"].ToString();
            int SmtpPort = Convert.ToInt32(ds.Tables[0].Rows[0]["con_smtp_port"].ToString());
            string MailFrom = ds.Tables[0].Rows[0]["con_mail_from"].ToString();
            string DisplayNameFrom = ds.Tables[0].Rows[0]["con_from_name"].ToString();
            string FromPassword = ds.Tables[0].Rows[0]["con_from_pwd"].ToString();
            string MailTo = ToMail;
            string DisplayNameTo = "";
            string MailCc = "";
            string DisplayNameCc = "";
            string MailBcc = "";
            string Subject = "Activ8 Group";
            string MailText;
            string Attachment = "";

            MailCc = "";

            MailText = "Hi, <br/><br/> Thanks for Registering with Activ8 group:<br/></b> <br/><br/> Thank you, <br/><br/> Activ8 System Admin.<br/>";

            CommanClass.UpdateMail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, "", "", "", DisplayNameCc, MailBcc, Subject, MailText, Attachment);
        }
    }
    public void Clear()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobile.Text = "";
        txtSAID.Text = "";
        txtEmailId.Text = "";
        ddlTitle.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
        ddlCity.SelectedValue = "-1";
    }
    protected void btnegistrationCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}