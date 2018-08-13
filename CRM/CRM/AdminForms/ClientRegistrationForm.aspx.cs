using System;
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            int res = newClientRegistrationBL.CheckClient(txtSAID.Text);
            if (res == 1)
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Client already exists with the SAID!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
            else if (res == 2)
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Client already Registered,Please contact one of our Advisors";
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
                    lblTitle.Text = "Thank You!";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Client Registered Successfully!";
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
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

            //MailText = "Hi, <br/><br/> Thanks for Registering with Activ8 group:<br/></b> <br/><br/> Thank you, <br/><br/> Activ8 System Admin.<br/>";

            MailText = "<table align='center' border='0' cellpadding='0' cellspacing='0' style='border-collapse: collapse; width: 100%; max-width: 600px;' class='content'>"
               + "<tr>"
               + "<td style='padding: 15px 10px 15px 10px;'>"
               + "<table border='0' cellpadding='0' cellspacing='0' width='100%'>"
                   + " </table>"
                + "</td>"
            + "</tr>"
            + "<tr>"
              + "  <td align='center' bgcolor='#bd1f2d' style='padding: 25px 20px 25px 20px; color: #ffffff; back font-family: Arial, sans-serif; font-size: 36px; font-weight: bold;height:113px !important;'>"
                 + "   <img src='http://fincrm.askswg.co.za/assets/dist/img/logo.jpg' alt='Activ8 Group' width='260' height='110' style='display:block;' />"
               + " </td>"
          + "  </tr>"
          + "  <tr>"
               + " <td align='center' bgcolor='#ffffff' style='padding: 75px 20px 40px 20px; color: #555555; font-family: Arial, sans-serif; font-size: 20px; line-height: 30px; border-bottom: 1px solid #f6f6f6;'>"
              + "     <b>Thank you for registering with Activ8 Group...</b><br/>"
                 + "    and one of the advisor will contact to you soon."
               + " </td>"
            + "</tr>"
           + " <tr>"
              + "  <td align='center' bgcolor='#f9f9f9' style='padding: 30px 20px 30px 20px; font-family: Arial, sans-serif;'>"
               + "     <table bgcolor='#1ABC9C' border='0' cellspacing='0' cellpadding='0' class='buttonwrapper'>"
                     + "   <tr>"
                       + "     <td align='center' height='50' style=' padding: 0 25px 0 25px; font-family: Arial, sans-serif; font-size: 16px; font-weight: bold; background-color: #bd1f2d;' class='button'>"
                            + "  <a href='https://activ8group.co.za' style='color: #ffffff; text-align: center; text-decoration: none;'>ACTIV8 GROUP</a>"
                         + "   </td>"
                     + "   </tr>"
                  + "  </table>"
              + "  </td>"
          + "  </tr>"
          + "   <tr>"
            + "     <td align='center' bgcolor='#dddddd' style='padding: 15px 10px 15px 10px; color: #555555; font-family: Arial, sans-serif; font-size: 12px; line-height: 18px;'>"
              + "       <b>ACTIV8 CAPITAL MANAGEMENT.</b><br/>33 Martin  &bull; Hammerschlag Way Foreshore &bull; Cape Town, South Africa"
             + "    </td>"
          + "   </tr>"
       + " </table>";
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