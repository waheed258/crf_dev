using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
using System.Data;

public partial class AdminForms_ClientService : System.Web.UI.Page
{
    ClientServiceEntity clientServiceEntity = new ClientServiceEntity();
    ClientServiceBL clientServiceBL = new ClientServiceBL();
    DataSet dataset = new DataSet();
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
                        _objComman.getRecordsPerPage(DropPage);
                        btnSubmit.Visible = true;
                        btnUpdate.Visible = false;                      
                        BindClientService();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            clientServiceEntity.ServiceName = txtServiceName.Text;
            int result = clientServiceBL.CURDClientService(clientServiceEntity, 'i');
            if (result == 1)
            {
                message.Text = "Service saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                txtServiceName.Text = "";
            }
            else
            {

                txtServiceName.Text = "";
            }
        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtServiceName.Text = "";
    }

    protected void gvClientService_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvClientService_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvClientService_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["ServiceID"] = ((Label)row.FindControl("lblServiceID")).Text.ToString();
                if (e.CommandName == "Edit")
                {
                    btnSubmit.Visible = false;
                    btnUpdate.Visible = true;
                    txtServiceName.Text = ((Label)row.FindControl("lblServiceName")).Text.ToString();
                }
                else if (e.CommandName == "Delete")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Service?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }
            }
        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void BindClientService()
    {
        try
        {
            dataset = clientServiceBL.GetClientService();
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {                 
                gvClientService.DataSource = dataset;
                gvClientService.PageSize = Convert.ToInt32(DropPage.SelectedValue);
                gvClientService.DataBind();
                ServiceList.Visible = true;
                search.Visible = true;
            }
            else
            {
                gvClientService.DataSource = null;
                search.Visible = false;
                ServiceList.Visible = false;
                search.Visible = false;
            }
            
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void gvClientService_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvClientService.PageIndex = e.NewPageIndex;
            BindClientService();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            clientServiceEntity.ServiceID = Convert.ToInt32(ViewState["ServiceID"]);
            clientServiceEntity.ServiceName = txtServiceName.Text;

            int result = clientServiceBL.CURDClientService(clientServiceEntity, 'u');
            if (result == 1)
            {
                message.Text = "Service updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

                txtServiceName.Text = "";
                BindClientService();
                btnUpdate.Visible = false;
                btnSubmit.Visible = true;
            }
            else
            {
                message.Text = "Please try again!";
                txtServiceName.Text = "";
                BindClientService();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {

                int result = clientServiceBL.DeleteClientService(Convert.ToInt32(ViewState["ServiceID"].ToString()));
                if (result == 1)
                {
                    BindClientService();
                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
 

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindClientService();
    }
}