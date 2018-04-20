using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
using System.IO;
using System.Text;

public partial class AdminForms_WorkInProcess : System.Web.UI.Page
{
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    DataSet dataset = new DataSet();
    InvoiceBL invoiceBL = new InvoiceBL();
    InvoiceEntity invoiceEntity = new InvoiceEntity();
    FollowUpBL followBL = new FollowUpBL();
    FollowUpEntity followupEntity = new FollowUpEntity();
    CommanClass _objComman = new CommanClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {           
            _objComman.getRecordsPerPage(DropPage);
            GetGridData();
            FollowUpSection.Visible = false;
            InvoiceSection.Visible = false;
            BindActivityType();         
        }
    }
    protected void gvWorkInProcess_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                ImageButton InvoiceButton = (ImageButton)row.FindControl("btnGenerateInvoice");
                ImageButton PDFButton = (ImageButton)row.FindControl("btnPDF");
                int RowIndex = row.RowIndex;
                ViewState["ClientServiceID"] = ((Label)row.FindControl("lblClientServiceID")).Text.ToString();
                ViewState["ServiceName"] = ((Label)row.FindControl("lblServiceName")).Text.ToString();
                ViewState["AdvisorID"] = ((Label)row.FindControl("lblAdvisorID")).Text.ToString();
                ViewState["ClientName"] = ((Label)row.FindControl("lblClientName")).Text.ToString();
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["Name"] = ((Label)row.FindControl("lblAdvisorName")).Text.ToString();
                int clientServiceID = Convert.ToInt32(((Label)row.FindControl("lblClientServiceID")).Text.ToString());
                int cServiceID = Convert.ToInt32((((Label)row.FindControl("lblClientServiceID")).Text.ToString()));
                if (e.CommandName == "FollowUp")
                {

                    FollowUpSection.Visible = true;
                    sectionRequestList.Visible = false;
                    InvoiceSection.Visible = false;
                    txtFollowTime.Text = DateTime.Now.ToShortTimeString();
                    txtServiceRequest.Text = ViewState["ServiceName"].ToString();
                    txtClientSAID.Text = ViewState["SAID"].ToString();
                    txtClientName.Text = ViewState["ClientName"].ToString();
                    txtAssignedTo.Text = ViewState["Name"].ToString();
                    BindFollowUp(clientServiceID);

                }
                else if (e.CommandName == "GenerateInvoice")
                {
                    InvoiceSection.Visible = true;
                    FollowUpSection.Visible = false;
                    sectionRequestList.Visible = false;
                }

                
            }
        }
        catch
        {

        }
    }

    protected void FollowUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            followupEntity.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);
            followupEntity.ServiceRequest = txtServiceRequest.Text;
            followupEntity.ClientSAID = txtClientSAID.Text;
            followupEntity.ClientName = txtClientName.Text;
            followupEntity.AssignedTo = txtAssignedTo.Text;
            followupEntity.FollowUpDate = string.IsNullOrEmpty(txtFollowDate.Text) ? null : txtFollowDate.Text;
            followupEntity.FollowUpTime = string.IsNullOrEmpty(txtFollowTime.Text) ? null : txtFollowTime.Text;
            followupEntity.DueDate = string.IsNullOrEmpty(txtDueDate.Text) ? null : txtDueDate.Text;
            followupEntity.DueTime = string.IsNullOrEmpty(txtDueTime.Text) ? null : txtDueTime.Text;           
            followupEntity.ActivityType = Convert.ToInt32(dropActivityType.SelectedValue);
            int Result = followBL.FollowUpCRUD(followupEntity, 'i');
            if (Result > 0)
            {
                Clear();
                TabName.Value = "tab2";
                BindFollowUp(Convert.ToInt32(ViewState["ClientServiceID"]));
            }


        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void FollowClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }

    private void Clear()
    {
        txtFollowDate.Text = "";
        txtFollowTime.Text = "";
        txtDueDate.Text = "";
        txtDueTime.Text = "";       
        dropActivityType.SelectedValue = "-1";
    }

    private void BindActivityType()
    {
        try
        {
            dataset = serviceRequestBL.GetActivityType();
            dropActivityType.DataSource = dataset;
            dropActivityType.DataTextField = "ActivityType";
            dropActivityType.DataValueField = "ActivityID";
            dropActivityType.DataBind();
            dropActivityType.Items.Insert(0, new ListItem("--Select Activity Type --", "-1"));
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void BindFollowUp(int clientServiceID)
    {
        try
        {
            dataset = followBL.GetFollowupUpdates(clientServiceID);
            gdvUpdatesList.DataSource = dataset;
            gdvUpdatesList.DataBind();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnFollowListCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }
    protected void GetGridData()
    {
        try
        {
            DataSet dataset = new DataSet();
            dataset = serviceRequestBL.GetWorkInProcess();
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvWorkInProcess.DataSource = dataset;
                gvWorkInProcess.PageSize = Convert.ToInt32(DropPage.SelectedValue);
                gvWorkInProcess.DataBind();
            }
            else
            {
                gvWorkInProcess.DataSource = null;
                gvWorkInProcess.DataBind();
            }
        }
        catch
        {

        }
    }

    protected void btnInvoiceSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            invoiceEntity.Description = txtDescription.Text;
            invoiceEntity.Amount = Convert.ToDecimal(txtAmount.Text);
            invoiceEntity.InvoiceDate = System.DateTime.Now.ToShortDateString();
            int Result = invoiceBL.InsertInvoice(invoiceEntity);
            if (Result > 0)
            {
                message.Text = "Invoice Generated Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
              
            }
        }
        catch
        {

        }
    }
    protected void btnInvoiceCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }

  
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvWorkInProcess_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvWorkInProcess.PageIndex = e.NewPageIndex;
            GetGridData();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
   
}