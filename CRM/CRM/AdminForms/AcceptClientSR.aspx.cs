using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;

public partial class AdminForms_AcceptClientSR : System.Web.UI.Page
{
    NewAdvisorBL newAdvisorBL = new NewAdvisorBL();
    DataSet dataset = new DataSet();
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    ClientServiceMasterEntity clientserviceMasterEntity = new ClientServiceMasterEntity();
    FollowUpBL followBL = new FollowUpBL();
    FollowUpEntity followupEntity = new FollowUpEntity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            AdvisorSection.Visible = false;
            FollowUpSection.Visible = false;
            BindAdvisors();
            BindPriority();
            BindActivityType();
            GetGridData();
            
        }
    }

    protected void GetGridData()
    {
        try
        {           
            dataset = serviceRequestBL.GetServiceRequest("0");
            gvClientSR.DataSource = dataset;      
            gvClientSR.DataBind();
        }
        catch {

        }
    }

    private void BindAdvisors()
    {
        try
        {
            dataset = serviceRequestBL.GetAdvisors();
            ddlAdvisors.DataSource = dataset;
            ddlAdvisors.DataTextField = "Name";
            ddlAdvisors.DataValueField = "AdvisorID";
            ddlAdvisors.DataBind();
            ddlAdvisors.Items.Insert(0, new ListItem("--Select Advisor --", "-1"));
        }
        catch
        {

        }
    }

  
    protected void gvClientSR_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["ClientServiceID"] = ((Label)row.FindControl("lblClientServiceID")).Text.ToString();
            ViewState["ServiceName"] = ((Label)row.FindControl("lblServiceName")).Text.ToString();
            ViewState["AdvisorID"] = ((Label)row.FindControl("lblAdvisorID")).Text.ToString();
            ViewState["ClientName"] = ((Label)row.FindControl("lblName")).Text.ToString();
            ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["Name"] = ((Label)row.FindControl("lblAdvisorName")).Text.ToString();
          
            if (e.CommandName == "AllocatedTo")
            {
                BindAdvisors();
                sectionRequestList.Visible = false;
                AdvisorSection.Visible = true;
                ddlAdvisors.SelectedValue = ViewState["AdvisorID"].ToString();

            }
            else if(e.CommandName == "FollowUp")
            {
               
                FollowUpSection.Visible = true;
                sectionRequestList.Visible = false;
                AdvisorSection.Visible = false;
                txtFollowTime.Text = DateTime.Now.ToShortTimeString();
                txtServiceRequest.Text = ViewState["ServiceName"].ToString();
                txtClientSAID.Text = ViewState["SAID"].ToString();
                txtClientName.Text = ViewState["ClientName"].ToString();
                txtAssignedTo.Text = ViewState["Name"].ToString();
            }
        }
        catch { }
    }
    
    protected void btnAdvisorSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            
            clientserviceMasterEntity.AdvisorID = ddlAdvisors.SelectedValue;
            clientserviceMasterEntity.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);
            
            int result = serviceRequestBL.CUDUServiceRequest(clientserviceMasterEntity,'a');
             if (result > 0)
             {
                 lblmessage.Text = "Updated Successfully";
                
             }
        }
        catch
        { }
    }

    private void BindPriority()
    {
        try
        {
            dataset = serviceRequestBL.GetPriority();
            dropPriority.DataSource = dataset;
            dropPriority.DataTextField = "Priority";
            dropPriority.DataValueField = "PriorityID";
            dropPriority.DataBind();
            dropPriority.Items.Insert(0, new ListItem("--Select Priority --", "-1"));
        }
        catch
        {

        }
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

        }
    }
    protected void btnAdvisorCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AcceptClientSR.aspx");
    }

    protected void gvClientSR_RowEditing(object sender, GridViewEditEventArgs e)
    {

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
            followupEntity.Priority = Convert.ToInt32(dropPriority.SelectedValue);
            followupEntity.ActivityType = Convert.ToInt32(dropActivityType.SelectedValue);
            int Result = followBL.FollowUpCRUD(followupEntity,'i');
            if(Result > 0)
            {
                lblFollowmsg.Text = "Inserted Successfully";
                Clear();
            }


        }
        catch
        {

        }
    }
    protected void FollowClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("AcceptClientSR.aspx");
    }

    private void Clear()
    {
        txtFollowDate.Text = "";
        txtFollowTime.Text = "";
        txtDueDate.Text = "";
        dropPriority.SelectedValue = "-1";
        dropActivityType.SelectedValue = "-1";
    }
}