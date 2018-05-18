using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;
using System.Data;
using System.Text;
using System.IO;

public partial class ClientForms_ServiceRequest : System.Web.UI.Page
{

    ClientServiceEntity clientserviceentity = new ClientServiceEntity();
    ClientServiceMasterEntity clientserviceentitym = new ClientServiceMasterEntity();
    DataSet ds = new DataSet();
    ServiceRequestBL _objServiceRequestBL = new ServiceRequestBL();
    CommanClass _objComman = new CommanClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

                if (Session["SAID"] == null || Session["SAID"].ToString() == "")
                {
                    Response.Redirect("../ClientLogin.aspx", false);
                }
                else
                {

                    if (!IsPostBack)
                    {
                        _objComman.getRecordsPerPage(DropPage);
                        GetServiceRequest();
                        GetServiceRequestdetails();
                        BindPriority();
                        btnUpdateSR.Visible = false;
                    }

                }
            }

            if (strPreviousPage == "")
            {
                Response.Redirect("~/ClientLogin.aspx");
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    public void GetServiceRequest()
    {
        try
        {
            ds = _objServiceRequestBL.GetServiceRequestmaster();
            ddlService.DataSource = ds;
            ddlService.DataTextField = "ServiceName";
            ddlService.DataValueField = "ServiceID";
            ddlService.DataBind();
            ddlService.Items.Insert(0, new ListItem("--Select Services--", "-1"));
        }
        catch
        {

        }
    }

    protected void btnUpdateSR_Click(object sender, EventArgs e)
    {
        clientserviceentitym.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);
        clientserviceentitym.SAID = Session["SAID"].ToString();
        clientserviceentitym.ClientService = Convert.ToInt32(ddlService.SelectedValue);
        clientserviceentitym.DetailInformation = txtDetails.Text.Trim();
        clientserviceentitym.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
        clientserviceentitym.Status = 1;
        int res;
        res = _objServiceRequestBL.CUDUServiceRequest(clientserviceentitym, 'u');
        if (res == 1)
        {
            message.Text = "ServiceRequest updated Successfully!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            SendMail(Session["email"].ToString());
            InsertDocument();
            ClearService();
            GetServiceRequestdetails();
            btnSubmitServiceRequest.Visible = true;
            btnUpdateSR.Visible = false;
        }
        else
        {
            lblMessage.Text = "Please try again!";
        }


    }

    protected void btnSubmitServiceRequest_Click(object sender, EventArgs e)
    {
        try
        {
            clientserviceentitym.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);
            clientserviceentitym.SAID = Session["SAID"].ToString();
            clientserviceentitym.ClientService = Convert.ToInt32(ddlService.SelectedValue);
            clientserviceentitym.DetailInformation = txtDetails.Text.Trim();
            clientserviceentitym.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
            clientserviceentitym.Status = 1;
            int result;
            result = _objServiceRequestBL.CUDUServiceRequest(clientserviceentitym, 'i');
            message.Text = "New Service Request created Successfully!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            if (result == 1)
            {
                ClearService();
                GetServiceRequestdetails();
                SendMail(Session["email"].ToString());
                InsertDocument();

            }
            else
            {
                lblMessage.Text = "Please try again!";
            }

        }
        catch
        {

        }
    }


    public void SendMail(string ToMail)
    {
        DataSet ds = _objServiceRequestBL.get_config_mst();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            string SmtpServer = ds.Tables[0].Rows[0]["con_smtp_host"].ToString();
            int SmtpPort = Convert.ToInt32(ds.Tables[0].Rows[0]["con_smtp_port"].ToString());
            string MailFrom = ds.Tables[0].Rows[0]["con_mail_from"].ToString();
            string DisplayNameFrom = ds.Tables[0].Rows[0]["con_from_name"].ToString();
            string FromPassword = ds.Tables[0].Rows[0]["con_from_pwd"].ToString();
            string MailTo = ToMail;
            string DisplayNameTo = "";
            string MailCc = ds.Tables[0].Rows[0]["con_mail_cc"].ToString();
            string mailCc2 = ds.Tables[0].Rows[0]["con_mail_cc1"].ToString();
            string DisplayNameCc = "";
            string MailBcc = "";
            string Subject = "Activ8 Group";
            string MailText;
            string Attachment = "";


            MailText = "Hi, <br/><br/> Thanks for making contact, Mr.Tony will reply to your Query.<br/></b> <br/><br/> Thank you, <br/><br/><strong> Activ8 System Admin.</strong><br/>";

            CommanClass.UpdateMail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, mailCc2, "", "", DisplayNameCc, MailBcc, Subject, MailText, Attachment);
        }


    }


    private void InsertDocument()
    {
        DocumentBL _objDocBL = new DocumentBL();

        if (fuServiceDocument.HasFile)
        {
            List<HttpPostedFile> lst = fuServiceDocument.PostedFiles.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                //HttpPostedFile uploadfile = lst[i];
                string inFilename = fuServiceDocument.PostedFiles[i].FileName;
                string strfile = Path.GetExtension(inFilename);
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var folder = Server.MapPath("~/ClientDocuments/" + Session["SAID"].ToString() + "/" + "ServiceRequest");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string fileName = date + strfile;
                fuServiceDocument.SaveAs(Path.Combine(folder, fileName));
                DocumentBO DocumentEntity = new DocumentBO
                {
                    DocId = 0,
                    ReferenceSAID = Session["SAID"].ToString(),
                    SAID = Session["SAID"].ToString(),
                    UIC = "0",
                    Document = fileName,
                    DocumentName = inFilename,
                    DocType = 0,
                    AdvisorID = 0,
                    Status = 1,
                };
                int res = _objDocBL.DocumentManager(DocumentEntity, 'i');
            }
        }

    }

    private void ClearService()
    {

        ddlService.SelectedValue = "-1";
        ddlPriority.SelectedValue = "-1";
        txtDetails.Text = "";
    }


    protected void GetServiceRequestdetails()
    {
        try
        {
            ds = _objServiceRequestBL.GetServiceRequest(Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvServiceDetails.DataSource = ds;
                gvServiceDetails.PageSize = Convert.ToInt32(DropPage.SelectedValue);
                gvServiceDetails.DataBind();
            }
            else
            {
                gvServiceDetails.DataSource = null;
                gvServiceDetails.DataBind();
            }
        }
        catch { }
    }

    protected void gvServiceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["ClientServiceID"] = ((Label)row.FindControl("lblClientServiceID")).Text.ToString();

            if (e.CommandName == "EditServices")
            {

                ddlService.SelectedValue = ((Label)row.FindControl("lblClientServiceIDFK")).Text.ToString();
                txtDetails.Text = ((Label)row.FindControl("lblDetailInformation")).Text.ToString();
                ddlPriority.SelectedValue = ((Label)row.FindControl("lblPriorityID")).Text.ToString();
                //ViewState["Serviceflag"] = 1;
                btnSubmitServiceRequest.Visible = false;
                btnUpdateSR.Visible = true;
            }
            else if (e.CommandName == "Delete")
            {
                ViewState["flag"] = 1;
                lbldeletemessage.Text = "Are you sure, you want to delete Services Request Details?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
            }
        }
        catch { }
    }

    private void BindPriority()
    {
        try
        {
            DataSet dataset = new DataSet();
            dataset = _objServiceRequestBL.GetPriority();
            ddlPriority.DataSource = dataset;
            ddlPriority.DataTextField = "Priority";
            ddlPriority.DataValueField = "PriorityID";
            ddlPriority.DataBind();
            ddlPriority.Items.Insert(0, new ListItem("--Select Priority --", "-1"));
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvServiceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvServiceDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void btnSure_Click(object sender, EventArgs e)
    {

        if (Convert.ToInt32(ViewState["flag"]) == 1)
        {
            int result = _objServiceRequestBL.DeleteServicesDetails(ViewState["ClientServiceID"].ToString());
            if (result == 1)
            {
                GetServiceRequestdetails();
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearService();
    }

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetServiceRequestdetails();
    }
    protected void gvServiceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvServiceDetails.PageIndex = e.NewPageIndex;
            GetServiceRequestdetails();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}