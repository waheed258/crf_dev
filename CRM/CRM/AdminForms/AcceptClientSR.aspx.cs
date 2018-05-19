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

                        BindAdvisors();
                        AdvisorSection.Visible = false;
                        _objComman.getRecordsPerPage(DropPage);
                        GetGridData();
                    }
                }
            }
        }
        catch
        {

        }
    }

    protected void GetGridData()
    {
        try
        {
            dataset = serviceRequestBL.GetClientSRList();
            gvClientSR.DataSource = dataset;
            gvClientSR.DataBind();
            gvClientSR.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvClientSR.DataBind();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
            // ddlAdvisors.Items.Insert(0, new ListItem("--Select Advisor Type --", "0"));
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    protected void gvClientSR_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["ClientServiceID"] = ((Label)row.FindControl("lblClientServiceID")).Text.ToString();
                ViewState["ServiceName"] = ((Label)row.FindControl("lblServiceName")).Text.ToString();
                ViewState["AdvisorID"] = ((Label)row.FindControl("lblAdvisorID")).Text.ToString();

                if (ViewState["AdvisorID"].ToString() == "")
                {
                    ddlAdvisors.SelectedValue = "-1";
                }
                else
                {
                    ddlAdvisors.SelectedValue = ViewState["AdvisorID"].ToString();
                }
                ViewState["ClientName"] = ((Label)row.FindControl("lblName")).Text.ToString();
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["Name"] = ((Label)row.FindControl("lblAdvisorName")).Text.ToString();
                int clientServiceID = Convert.ToInt32(((Label)row.FindControl("lblClientServiceID")).Text.ToString());
                if (e.CommandName == "AllocatedTo")
                {
                    //BindAdvisors();
                    sectionRequestList.Visible = false;
                    AdvisorSection.Visible = true;

                    if (ddlAdvisors.SelectedValue == "-1")
                        ddlAdvisors.SelectedValue = "-1";
                    else
                        ddlAdvisors.SelectedValue = ViewState["AdvisorID"].ToString();


                }

                else if (e.CommandName == "Validate")
                {
                    if (ddlAdvisors.SelectedValue == "-1")
                    {
                        message.Text = "Please assign Advisor to this SR";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                    else
                    {

                        sectionRequestList.Visible = true;
                        AdvisorSection.Visible = false;
                        lbldeletemessage.Text = "Are you sure, you want to Activate SR?";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openActiveModal();", true);

                    }
                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnAdvisorSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            clientserviceMasterEntity.AdvisorID = ddlAdvisors.SelectedValue;
            clientserviceMasterEntity.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);

            int result = serviceRequestBL.CUDUServiceRequest(clientserviceMasterEntity, 'a');
            if (result > 0)
            {
                message.Text = "Updated Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    protected void btnAdvisorCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("AcceptClientSR.aspx");
    }

    protected void gvClientSR_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(ViewState["ClientServiceID"]);
            int result = serviceRequestBL.UpdateClientServiceRequest(id);
            if (result == 1)
            {
                message.Text = "Service Request Activated Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                GetGridData();

            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvClientSR_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvClientSR.PageIndex = e.NewPageIndex;
            GetGridData();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}