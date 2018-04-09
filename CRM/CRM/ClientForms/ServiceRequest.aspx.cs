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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetServiceRequest();
            GetServiceRequestdetails();

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



    protected void btnSubmitServiceRequest_Click(object sender, EventArgs e)
    {
        try
        {
            clientserviceentitym.ClientServiceID =Convert.ToInt32(ViewState["ClientServiceID"]);
            clientserviceentitym.SAID = Session["SAID"].ToString();
            clientserviceentitym.ClientService = Convert.ToInt32(ddlService.SelectedValue);
            clientserviceentitym.DetailInformation = txtDetails.Text.Trim();
            clientserviceentitym.Status = 1;

            //int result = _objServiceRequestBL.CUDUServiceRequest(clientserviceentitym, 'i'); 
            //if (result == 1)
            //{
            //    lblMessage.Text = "New ServiceRequest Created Successfully!";
                
            //}
            //else
            //{
            //    lblMessage.Text = "Please try again!";
               
            //}



            int result;
            if (Convert.ToInt32(ViewState["Serviceflag"]) == 1)
            {
               
                result = _objServiceRequestBL.CUDUServiceRequest(clientserviceentitym, 'u');
                lblMessage.Text = "ServiceRequest Updated Successfully";
            }
            else
            {
                result = _objServiceRequestBL.CUDUServiceRequest(clientserviceentitym, 'i');
                lblMessage.Text = "New ServiceRequest Created Successfully!";
            }
            if (result == 1)
            {
                ClearService();
                GetServiceRequestdetails();
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

    private void ClearService() 
    {
        
        ddlService.SelectedValue = "-1";
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
                
                ddlService.SelectedValue = ((Label)row.FindControl("lblClientService")).Text.ToString();
                txtDetails.Text = ((Label)row.FindControl("lblDetailInformation")).Text.ToString();                  
                           
                ViewState["Serviceflag"] = 1;
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


}