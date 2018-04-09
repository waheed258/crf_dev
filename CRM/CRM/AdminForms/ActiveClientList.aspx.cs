using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
public partial class AdminForms_ActiveClientList : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    FeedbackEntity feedbackEntity = new FeedbackEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGridData();
            sectionClientList.Visible = true;
            editSection.Visible = false;

        }
    }

    protected void GetGridData()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = newClientRegistrationBL.GetActiveClientList();
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
        txtCompany.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblCompanyName")).Text.ToString();
        txtCompanyRegNo.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblCompanyRegNo")).Text.ToString();
        txtTrust.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblTrustName")).Text.ToString();
        txtTrustRegNo.Text = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblTrustRegNo")).Text.ToString();
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
            clientRegEntity.CompanyName = txtCompany.Text;
            clientRegEntity.CompanyRegNo = txtCompanyRegNo.Text;
            clientRegEntity.TrustName = txtTrust.Text;
            clientRegEntity.TrustRegNo = txtTrustRegNo.Text;

            int result = newClientRegistrationBL.CUDclientinfo(clientRegEntity, 'u');
            if (result == 1)
            {
                message.Text = "Client Updated Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionClientList.Visible = true;

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
        txtCompany.Text = "";
        txtCompanyRegNo.Text = "";
        txtTrust.Text = "";
        txtTrustRegNo.Text = "";
    }
    protected void Button_Close_Click(object sender, EventArgs e)
    {
        sectionClientList.Visible = true;
        editSection.Visible = false;

    }

    protected void gvClientsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "SaveClient")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                Session["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                string url = "../ClientProfile/ClientPersonal.aspx";
                string s = "window.open('" + url + "', '_blank');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);                
            }
        }
        catch { }
    }
}