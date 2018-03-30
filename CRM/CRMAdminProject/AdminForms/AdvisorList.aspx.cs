using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;

public partial class AdminForms_AdvisorList : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewAdvisorBL newAdvisorBL = new NewAdvisorBL();
    EncryptDecrypt encryptdecrypt = new EncryptDecrypt();
    AdvisorEntity advisorentity = new AdvisorEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGridData();
            editSection.Visible = false;
        }
    }
    protected void GetGridData()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = newAdvisorBL.GetAdvisorList();
            gvAdvisor.DataSource = dataset;
            ViewState["dt"] = dataset.Tables[0];
            gvAdvisor.DataBind();
        }
        catch { }
    }
    protected void gvAdvisor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GetDesignation();
            GetBranch();
            GetAdvisorType();
            GetStatus();
            GetRole();
            int RowIndex = e.NewEditIndex;
            ViewState["AdvisorID"] = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAdvisorID")).Text.ToString();
            txtFirstName.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblFirstName")).Text.ToString();
            editSection.Visible = true;
            sectionAdvisorList.Visible = false;
            txtLastName.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblLastName")).Text.ToString();
            txtMobileNum.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblMobile")).Text.ToString();
            txtPhoneNum.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblPhone")).Text.ToString();
            txtEmailId.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblEmailID")).Text.ToString();
            txtLoginId.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblLoginId")).Text.ToString();
            txtPassword.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblPassword")).Text.ToString();
            string designation = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblDesig")).Text.ToString();
            ddlDesignation.SelectedValue = designation;
            string branch = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblBranch")).Text.ToString();
            ddlBranch.SelectedValue = branch;
            string AType = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAType")).Text.ToString();
            ddlAdvisorType.SelectedValue = AType;
            string Status = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAStatus")).Text.ToString();
            ddlStatus.SelectedValue = Status;
            string Role = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblRole")).Text.ToString();
            ddlRole.SelectedValue = Role;

        }
        catch { }
    }
    protected void GetDesignation()
    {
        try
        {
            dataset = newAdvisorBL.GetDesignation();
            ddlDesignation.DataSource = dataset;
            ddlDesignation.DataTextField = "Designation";
            ddlDesignation.DataValueField = "DesignationID";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("--Select Designation --", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void GetBranch()
    {
        try
        {
            dataset = newAdvisorBL.GetBranch();
            ddlBranch.DataSource = dataset;
            ddlBranch.DataTextField = "BranchName";
            ddlBranch.DataValueField = "BranchID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("--Select Branch --", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void GetAdvisorType()
    {
        try
        {
            dataset = newAdvisorBL.GetAdvisorType();
            ddlAdvisorType.DataSource = dataset;
            ddlAdvisorType.DataTextField = "AdvisorType";
            ddlAdvisorType.DataValueField = "AdvisorTypeID";
            ddlAdvisorType.DataBind();
            ddlAdvisorType.Items.Insert(0, new ListItem("--Select Type --", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void GetStatus()
    {
        try
        {
            dataset = newAdvisorBL.GetStatus();
            ddlStatus.DataSource = dataset;
            ddlStatus.DataTextField = "AdvisorStatus";
            ddlStatus.DataValueField = "AdvisorStatusID";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--Select Status --", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void GetRole()
    {
        try
        {
            dataset = newAdvisorBL.GetRole();
            ddlRole.DataSource = dataset;
            ddlRole.DataTextField = "Role";
            ddlRole.DataValueField = "RoleID";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("--Select Role --", "-1"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            advisorentity.AdvisorID = Convert.ToInt32(ViewState["AdvisorID"]);
            advisorentity.FirstName = txtFirstName.Text;
            advisorentity.LastName = txtLastName.Text;
            advisorentity.Mobile = txtMobileNum.Text;
            advisorentity.Phone = txtPhoneNum.Text;
            advisorentity.EmailID = txtEmailId.Text;
            advisorentity.LoginId = txtLoginId.Text;
            advisorentity.Password = txtPassword.Text.Trim();
            advisorentity.Designation = Convert.ToInt32(ddlDesignation.SelectedValue);
            advisorentity.Branch = Convert.ToInt32(ddlBranch.SelectedValue);
            advisorentity.AdvisorType = Convert.ToInt32(ddlAdvisorType.SelectedValue);
            advisorentity.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            advisorentity.AdvisorRole = Convert.ToInt32(ddlRole.SelectedValue);
            //need to initialize with login advisor id
            advisorentity.UpdatedBy = 0;
            int result = newAdvisorBL.CUDAdvisor(advisorentity, 'u');
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                sectionAdvisorList.Visible = true;
                editSection.Visible = false;
                GetGridData();
            }
            else
            {

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
        txtMobileNum.Text = "";
        txtPhoneNum.Text = "";
        txtEmailId.Text = "";
        ddlAdvisorType.SelectedValue = "-1";
        ddlBranch.SelectedValue = "-1";
        ddlDesignation.SelectedValue = "-1";
        ddlRole.SelectedValue = "-1";
        ddlStatus.SelectedValue = "-1";
        txtLoginId.Text = "";
        txtPassword.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        sectionAdvisorList.Visible = true;
        editSection.Visible = false;
    }    
}