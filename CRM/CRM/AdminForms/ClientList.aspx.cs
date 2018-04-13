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
                        GetGridData();
                        sectionClientList.Visible = true;
                        editSection.Visible = false;
                        statusSection.Visible = false;
                        validateSection.Visible = false;
                        ClientFeedbackSection.Visible = false;
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            gvClientsList.DataBind();
        }
        catch { }
    }
    protected void gvClientsList_RowEditing(object sender, GridViewEditEventArgs e)
    {
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
        ddlTitle.SelectedItem.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblTitle")).Text.ToString();
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
                message.Text = "Client Updated Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;
                statusSection.Visible = false;
                editSection.Visible = false;
                GetGridData();
            }
            else
            {
                message.Text = "Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
        }
        catch (Exception ex)
        {

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
            if (ddlClientStatus.SelectedItem.Text == "Active")
            {
                int Status = Convert.ToInt32(ddlClientStatus.SelectedValue);
                clientRegEntity.Status = Status;
                clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);

                int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'S');
                if (result > 0)
                {
                    int res = ManageCredentials(ViewState["SAID"].ToString(), ViewState["Email"].ToString(), ViewState["FirstName"].ToString(), ViewState["LastName"].ToString());
                    SendMail(ViewState["Email"].ToString());
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
                    message.Text = "Something went wron please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
            }
            else
            {
                int Status = Convert.ToInt32(ddlClientStatus.SelectedValue);
                clientRegEntity.Status = Status;
                clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);

                int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'S');
                if (result > 0)
                {
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
                    message.Text = "Something went wron please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Clear();
                }
            }

        }
        catch { }
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
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["Status"] = ((Label)row.FindControl("lblCStatus")).Text.ToString();
            ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["ClientRegID"] = ((Label)row.FindControl("lblRegID")).Text.ToString();
            ViewState["Email"] = ((Label)row.FindControl("lblEmailID")).Text.ToString();
            ViewState["FirstName"] = ((Label)row.FindControl("lblFirstName")).Text.ToString();
            ViewState["LastName"] = ((Label)row.FindControl("lblLastName")).Text.ToString();
            if (e.CommandName == "Status")
            {
                GetClientStatus();
                sectionClientList.Visible = false;
                editSection.Visible = false;
                statusSection.Visible = true;
                ddlClientStatus.SelectedValue = ViewState["Status"].ToString();

            }
            else if (e.CommandName == "Validate")
            {
                sectionClientList.Visible = false;
                editSection.Visible = false;
                statusSection.Visible = false;
                validateSection.Visible = true;
            }
            else if (e.CommandName == "Feedback")
            {
                ClientFeedbackSection.Visible = true;
                sectionClientList.Visible = false;
                editSection.Visible = false;
                statusSection.Visible = false;
                validateSection.Visible = false;
            }
        }
        catch { }
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
            Password= ""
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

        MailText = "Hi, <br/><br/> Thanks for Registering with Activ8 group:<br/>User Id : <b>" + ViewState["Email"] + "</b> <br/>Password : <b>" + ViewState["RandomPwd"].ToString() + "</b>" +
            "</b> <br/><br/> Thank you, <br/><br/> Activ8 System Admin.<br/>";

        CommanClass.UpdateMail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, "", "", "", DisplayNameCc, MailBcc, Subject, MailText, Attachment);


    }


    #endregion
    protected void ButtonValidate_Click(object sender, EventArgs e)
    {
        try
        {
            clientRegEntity.Status = Convert.ToInt32(ViewState["Status"]);
            clientRegEntity.ClientRegistartionID = Convert.ToInt32(ViewState["ClientRegID"]);
            clientRegEntity.SAID = ViewState["SAID"].ToString();
            clientRegEntity.VerifiedThough = ddlVerifiedThrough.SelectedItem.Text;
            clientRegEntity.VerifiedOn = txtVerifiedOn.Text;
            feedbackEntity.AdvisorFeedBack = txtAdvisorFeedback.Text;
            int result = newClientRegistrationBL.ChangeClientActions(clientRegEntity, feedbackEntity, 'V');

            if (result > 0)
            {
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
                GetGridData();
            }
            else
            {
                message.Text = "Something went wron please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch { }
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
                message.Text = "Feedback saved Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;
                statusSection.Visible = false;
                editSection.Visible = false;
                ClientFeedbackSection.Visible = false;
                validateSection.Visible = false;
                txtClientFeedback.Text = "";
                GetGridData();
            }
            else
            {
                message.Text = "Something went wron please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch { }
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
}