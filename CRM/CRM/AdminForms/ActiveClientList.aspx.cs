using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
using System.Web.Services;
public partial class AdminForms_ActiveClientList : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewClientRegistrationBL newClientRegistrationBL = new NewClientRegistrationBL();
    ClientRegistrationEntity clientRegEntity = new ClientRegistrationEntity();
    FeedbackEntity feedbackEntity = new FeedbackEntity();
    CommanClass _objComman = new CommanClass();
    static string FLowSAID = "";
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
                        GetGridData();
                        sectionClientList.Visible = true;
                        editSection.Visible = false;
                       
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
            dataset = newClientRegistrationBL.GetActiveClientList();
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
    protected void gvClientsList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
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
            ViewState["AssignTo"] = ((Label)gvClientsList.Rows[RowIndex].FindControl("lblAssignTo")).Text.ToString();
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

    }

    protected void gvClientsList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {            
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                if (e.CommandName == "SaveClient")
                {                   
                    Session["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    Session["email"] = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                    string url = "../ClientProfile/ClientPersonal.aspx";
                    string s = "window.open('" + url + "', '_blank');";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                }
                if (e.CommandName == "FlowChart")
                {
                    FLowSAID = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    string url = "../AdminForms/WealthFlowChart.html";
                    string s = "window.open('" + url + "', '_blank');";
                    ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                }
                if (e.CommandName == "Document")
                {
                    EncryptDecrypt ObjEn = new EncryptDecrypt();
                    Response.Redirect("AdminDocument.aspx?x="+ObjEn.Encrypt(e.CommandArgument.ToString()), false);
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

    [WebMethod]
    public static string GetData()
    {               
        try
        {           
            NewClientRegistrationBL newCl = new NewClientRegistrationBL();
            DataSet ds = new DataSet();
            ds = newCl.GetFlowChart(FLowSAID);
            return Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]);
        }
        catch (Exception ex)
        {
            return "error";
        }

    }

    protected void gvClientsList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text == "&nbsp;" || e.Row.Cells[i].Text == null)
                {
                    e.Row.Cells[i].Text = "not available";
                }
            }
        }
    }
}