using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
public partial class AdminForms_ClientList : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    FeedbackEntity feedbackEntity = new FeedbackEntity();
    CommanClass _objComman = new CommanClass();
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    string status = String.Empty;
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
                        _objComman.GetProvince(ddlProvince);
                        _objComman.GetCity(ddlCity);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(DropPageValidate);
                        _objComman.getRecordsPerPage(DropPageFeedback);
                        GetGridData();
                        BindAdvisors();
                        //ValidateGridData();
                        //FeedbackGridData();
                        sectionClientList.Visible = true;
                        editSection.Visible = false;
                        statusSection.Visible = false;
                        validateSection.Visible = false;
                        ClientFeedbackSection.Visible = false;
                        lblResignedDate.Visible = false;
                        txtResignedDate.Visible = false;
                        rfvResignedDate.Enabled = false;
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void GetGridData()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = newClientRegistrationBL.GetClientRegisteredList();
            gvClientsList.DataSource = dataset;
            ViewState["dt"] = dataset.Tables[0];
            gvClientsList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvClientsList.DataBind();
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
    private void BindAdvisors()
    {
        try
        {
            dataset = serviceRequestBL.GetAdvisors();
            ddlAssignTo.DataSource = dataset;
            ddlAssignTo.DataTextField = "Name";
            ddlAssignTo.DataValueField = "AdvisorID";
            ddlAssignTo.DataBind();
            // ddlAdvisors.Items.Insert(0, new ListItem("--Select Advisor Type --", "0"));
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
    protected void gvClientsList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            txtSAID.ReadOnly = true;
            txtEmail.ReadOnly = true;
            int RowIndex = e.NewEditIndex;
            sectionClientList.Visible = false;
            editSection.Visible = true;
            txtSAID.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblSAID")).Text.ToString();
            ViewState["SAID"] = txtSAID.Text;
            ViewState["RegID"] = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblRegID")).Text.ToString();
            ViewState["Status"] = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblCStatus")).Text.ToString();
            txtFirstName.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblFirstName")).Text.ToString();
            txtLastName.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblLastName")).Text.ToString();
            txtEmail.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblEmailID")).Text.ToString();
            txtMobile.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblMobileNumber")).Text.ToString();
            ddlProvince.SelectedValue = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblProvince")).Text.ToString();
            ddlCity.SelectedValue = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblCity")).Text.ToString();
            ddlTitle.SelectedValue = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblTitle")).Text.ToString();
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
    protected void Button_Update_Click(object sender, EventArgs e)
    {
        try
        {
            clientRegEntity.Status = Convert.ToInt32(ViewState["Status"]);
            clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["RegID"]);
            clientRegEntity.SAID = ViewState["SAID"].ToString();
            clientRegEntity.FirstName = txtFirstName.Text;
            clientRegEntity.LastName = txtLastName.Text;
            clientRegEntity.MobileNumber = txtMobile.Text;
            clientRegEntity.SAID = txtSAID.Text;
            clientRegEntity.Title = ddlTitle.SelectedItem.Text;
            clientRegEntity.EmailID = txtEmail.Text;
            clientRegEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            clientRegEntity.City = Convert.ToInt32(ddlCity.SelectedValue);


            int result = newClientRegistrationBL.CUDclientinfo(clientRegEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Client Updated Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;
                statusSection.Visible = false;
                editSection.Visible = false;
                GetGridData();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
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
    public void Clear()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobile.Text = "";
        txtSAID.Text = "";
        txtEmail.Text = "";
        ddlTitle.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
        ddlCity.SelectedValue = "-1";
    }
    protected void Button_Close_Click(object sender, EventArgs e)
    {
        sectionClientList.Visible = true;
        editSection.Visible = false;
        statusSection.Visible = false;
        ClientFeedbackSection.Visible = false;
        validateSection.Visible = false;
    }
    protected void btnStatusSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlClientStatus.SelectedItem.Text == "Client Active" || ddlClientStatus.SelectedItem.Text == "Resigned")
            {
                int Status = Convert.ToInt32(ddlClientStatus.SelectedValue);
                clientRegEntity.Status = Status;
                if (ddlClientStatus.SelectedItem.Text == "Client Active")
                    clientRegEntity.ResignedDate = null;
                else
                {
                    rfvResignedDate.Enabled = true;
                    clientRegEntity.ResignedDate = txtResignedDate.Text;
                }
                                                  
                clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);

                int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'S');
                if (result > 0)
                {
                    int res = ManageCredentials(ViewState["SAID"].ToString(), ViewState["Email"].ToString(), ViewState["FirstName"].ToString(), ViewState["LastName"].ToString());
                    SendMail(ViewState["Email"].ToString());
                    lblTitle.Text = "Thank You!";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Status Updated Successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    sectionClientList.Visible = true;
                    statusSection.Visible = false;
                    editSection.Visible = false;
                    ClientFeedbackSection.Visible = false;
                    validateSection.Visible = false;
                    GetGridData();
                }
                else
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, Please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
            }
            else
            {
                int Status = Convert.ToInt32(ddlClientStatus.SelectedValue);
                clientRegEntity.Status = Status;
                clientRegEntity.ResignedDate = txtResignedDate.Text;
                clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);

                int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'S');
                if (result > 0)
                {
                    lblTitle.Text = "Thank You!";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Status Updated Successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    sectionClientList.Visible = true;
                    statusSection.Visible = false;
                    editSection.Visible = false;
                    ClientFeedbackSection.Visible = false;
                    validateSection.Visible = false;
                    GetGridData();
                }
                else
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, Please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
    protected void btnStatusCancel_Click(object sender, EventArgs e)
    {
        sectionClientList.Visible = true;
        editSection.Visible = false;
        statusSection.Visible = false;
    }
    protected void gvClientsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["Status"] = ((Label)row.FindControl("lblCStatus")).Text.ToString();
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["ClientRegID"] = ((Label)row.FindControl("lblRegID")).Text.ToString();
                ViewState["Email"] = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                ViewState["FirstName"] = ((Label)row.FindControl("lblFirstName")).Text.ToString();
                ViewState["LastName"] = ((Label)row.FindControl("lblLastName")).Text.ToString();
                ViewState["Advisor"] = ((Label)row.FindControl("lblAdvisor")).Text.ToString();
                if (e.CommandName == "Status")
                {
                    if (ViewState["Advisor"].ToString() == "")
                    {
                        lblTitle.Text = "Warning!";
                        lblTitle.ForeColor = System.Drawing.Color.Red;
                        message.ForeColor = System.Drawing.Color.Red;
                        message.Text = "Please fill the validation and assign Advisor to the Client";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                    else
                    {
                        GetClientStatus();
                        sectionClientList.Visible = false;
                        editSection.Visible = false;
                        statusSection.Visible = true;
                        ddlClientStatus.SelectedValue = ViewState["Status"].ToString();
                    }
                }
                else if (e.CommandName == "Validate")
                {
                    ValidateGridData();
                    sectionClientList.Visible = false;
                    editSection.Visible = false;
                    statusSection.Visible = false;
                    validateSection.Visible = true;
                }
                else if (e.CommandName == "Feedback")
                {
                    FeedbackGridData();
                    ClientFeedbackSection.Visible = true;
                    sectionClientList.Visible = false;
                    editSection.Visible = false;
                    statusSection.Visible = false;
                    validateSection.Visible = false;
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
    protected void GetClientStatus()
    {
        try
        {
            dataset = newClientRegistrationBL.GetClientStatus();
            ddlClientStatus.DataSource = dataset;
            ddlClientStatus.DataTextField = "Status";
            ddlClientStatus.DataValueField = "StatusID";
            ddlClientStatus.DataBind();
            ddlClientStatus.Items.Insert(0, new ListItem("--Select Status --", "-1"));
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


    //Mail Code
    #region


    protected int ManageCredentials(string SA_Id, string Email, string FirstName, string LastName)
    {
        CredentialsBO _objCre = new CredentialsBO
        {
            SAID = SA_Id,
            EmailID = Email,
            FirstName = FirstName,
            LastName = LastName,
            GenaratePassword = GenarateDynamicPassword(),
            Password = ""
        };
        return new CredentialsBL().ManageCredentials(_objCre, 'A');
    }


    private string GenarateDynamicPassword()
    {
        string allowedChars = "";

        allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

        allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";

        allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

        char[] sep = { ',' };

        string[] arr = allowedChars.Split(sep);

        string passwordString = "";

        string temp = "";

        Random rand = new Random();

        for (int i = 0; i < 6; i++)
        {

            temp = arr[rand.Next(0, arr.Length)];

            passwordString += temp;

        }
        ViewState["RandomPwd"] = passwordString;

        return passwordString;
    }

    public void SendMail(string ToMail)
    {
        string SmtpServer = "smtp.gmail.com"; ;
        int SmtpPort = 587;
        string MailFrom = "active8crm.sa@gmail.com";
        string DisplayNameFrom = "Active8 CRM";
        string FromPassword = "Active@321#";
        string MailTo = ToMail;
        string DisplayNameTo = "";
        string MailCc = "";
        string DisplayNameCc = "";
        string MailBcc = "";
        string Subject = "Your Login Credentials";
        string MailText;
        string Attachment = "";


        MailCc = "";

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
              + "Thanks for Registering with Activ8 group <br/><br/>"
              + "Your LogIn Credentials <br/>"
              + "<table><tr><td style='text-align:right;'>User Id :</td><td><b> " + "Your User ID is your SAID" + "</b></td> </tr><tr><td style='text-align:right;'>Password :</td><td><b>" + ViewState["RandomPwd"].ToString() + "</b></td></tr></table>"

              + " </td>"
           + "</tr>"
          + " <tr>"
             + "  <td align='center' bgcolor='#f9f9f9' style='padding: 30px 20px 30px 20px; font-family: Arial, sans-serif;'>"
              + "     <table bgcolor='#1ABC9C' border='0' cellspacing='0' cellpadding='0' class='buttonwrapper'>"
                    + "   <tr>"
                      + "     <td align='center' height='50' style=' padding: 0 25px 0 25px; font-family: Arial, sans-serif; font-size: 16px; font-weight: bold; background-color: #bd1f2d;' class='button'>"
                           + "  <a href='http://fincrm.askswg.co.za' style='color: #ffffff; text-align: center; text-decoration: none;'>Login</a>"
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


    #endregion
    protected void ButtonValidate_Click(object sender, EventArgs e)
    {
        try
        {
            Retrieve();
            string assign = status.Trim(',');
            clientRegEntity.Status = Convert.ToInt32(ViewState["Status"]);
            clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);
            clientRegEntity.SAID = ViewState["SAID"].ToString();
            clientRegEntity.VerifiedThough = ddlVerifiedThrough.SelectedItem.Text;
            clientRegEntity.VerifiedOn = txtVerifiedOn.Text;
            clientRegEntity.AssignTo = assign;
            feedbackEntity.AdvisorFeedBack = txtAdvisorFeedback.Text;
            int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'V');

            if (result > 0)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Client Validated Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;
                statusSection.Visible = false;
                editSection.Visible = false;
                ClientFeedbackSection.Visible = false;
                validateSection.Visible = false;
                txtVerifiedOn.Text = "";
                txtAdvisorFeedback.Text = "";
                ddlVerifiedThrough.SelectedValue = "-1";
               // ddlAssignTo.SelectedValue = "-1";
                ValidateGridData();
                GetGridData();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        sectionClientList.Visible = true;
        editSection.Visible = false;
        statusSection.Visible = false;
        ClientFeedbackSection.Visible = false;
        validateSection.Visible = false;
    }
    protected void btnSaveFeedback_Click(object sender, EventArgs e)
    {
        try
        {
            clientRegEntity.SAID = ViewState["SAID"].ToString();
            feedbackEntity.ClientFeedBack = txtClientFeedback.Text;
            int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'C');
            if (result > 0)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Feedback saved Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;
                statusSection.Visible = false;
                editSection.Visible = false;
                ClientFeedbackSection.Visible = false;
                validateSection.Visible = false;
                txtClientFeedback.Text = "";
                FeedbackGridData();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
    protected void btnCancelFeedback_Click(object sender, EventArgs e)
    {
        txtClientFeedback.Text = "";
        sectionClientList.Visible = true;
        editSection.Visible = false;
        statusSection.Visible = false;
        ClientFeedbackSection.Visible = false;
        validateSection.Visible = false;
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvClientsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvClientsList.PageIndex = e.NewPageIndex;
            GetGridData();
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

    protected void ValidateGridData()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = newClientRegistrationBL.GetValidateList(ViewState["SAID"].ToString());
            gvValidate.DataSource = dataset;
            ViewState["dt"] = dataset.Tables[0];
            gvValidate.PageSize = Convert.ToInt32(DropPageValidate.SelectedValue);
            gvValidate.DataBind();
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
    protected void gvValidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvValidate.PageIndex = e.NewPageIndex;
            ValidateGridData();
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
    protected void FeedbackGridData()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = newClientRegistrationBL.GetFeedbackList(ViewState["SAID"].ToString());
            if (dataset.Tables.Count > 0 || dataset.Tables[0].Rows[0]["ClientFeedBack"] != "")
            {
                gvFeedBack.DataSource = dataset;
                ViewState["dt"] = dataset.Tables[0];
                gvFeedBack.PageSize = Convert.ToInt32(DropPageFeedback.SelectedValue);
                gvFeedBack.DataBind();
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
    protected void gvFeedBack_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvFeedBack.PageIndex = e.NewPageIndex;
            FeedbackGridData();
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
    protected void DropPageValidate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidateGridData();
    }
    protected void DropPageFeedback_SelectedIndexChanged(object sender, EventArgs e)
    {
        FeedbackGridData();
    }
    protected void ddlClientStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClientStatus.SelectedItem.Text == "Resigned")
        {
            lblResignedDate.Visible = true;
            txtResignedDate.Visible = true;
        }
        else
        {
            lblResignedDate.Visible = false;
            txtResignedDate.Visible = false;
        }
    }
    public void Retrieve()
    {
        try
        {
            status = string.Empty;
            foreach (ListItem item in this.ddlAssignTo.Items)
                if (item.Selected)
                    status += item + ",";
        }
        catch { }
    }
}