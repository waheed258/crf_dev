using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
public partial class AdminForms_UserProfile : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewAdvisorBL newAdvisorBL = new NewAdvisorBL();   
    AdvisorEntity advisorentity = new AdvisorEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetAdvisor();
            GetDesignation();
            GetBranch();
            GetAdvisorType();
            GetStatus();
            GetRole();
        }
    }

    private void GetAdvisor()
    {
        try
        {
            int AdvisorId = Convert.ToInt32(Session["AdvisorID"]);
            dataset = newAdvisorBL.GetAdvisor(AdvisorId);
            if(dataset.Tables.Count >0)
            {
                txtSAId.Text = dataset.Tables[0].Rows[0]["AdvisorSAID"].ToString();
                txtFirstName.Text = dataset.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = dataset.Tables[0].Rows[0]["LastName"].ToString();
                txtMobileNum.Text = dataset.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhoneNum.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                txtEmailId.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
                txtLoginId.Text = dataset.Tables[0].Rows[0]["LoginId"].ToString();
                txtPassword.Text = dataset.Tables[0].Rows[0]["Password"].ToString();
                ddlDesignation.SelectedValue = dataset.Tables[0].Rows[0]["Designation"].ToString();
                ddlBranch.SelectedValue = dataset.Tables[0].Rows[0]["Branch"].ToString();
                ddlAdvisorType.SelectedValue = dataset.Tables[0].Rows[0]["AdvisorType"].ToString();
                ddlStatus.SelectedValue = dataset.Tables[0].Rows[0]["Status"].ToString();
                ddlRole.SelectedValue = dataset.Tables[0].Rows[0]["AdvisorRole"].ToString();
                hfImage.Value = dataset.Tables[0].Rows[0]["Image"].ToString();
                lblImage.Text = hfImage.Value;
            }
        }
        catch(Exception ex)
        {

        }
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string fileNamemain = string.Empty;
            if (fuImageUpload.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fuImageUpload.PostedFile.FileName);
                fileNamemain = txtLoginId.Text + extension;
                fuImageUpload.SaveAs(Server.MapPath("/AdvisorImages/") + fileNamemain);
                hfImage.Value = fileNamemain;
            }
            advisorentity.AdvisorID = Convert.ToInt32(Session["AdvisorID"]);
            advisorentity.FirstName = txtFirstName.Text;
            advisorentity.LastName = txtLastName.Text;
            advisorentity.Mobile = txtMobileNum.Text;
            advisorentity.Phone = txtPhoneNum.Text;
            advisorentity.EmailID = txtEmailId.Text;
            advisorentity.LoginId = txtLoginId.Text;
            advisorentity.Password = txtPassword.Text.Trim();
            advisorentity.AdvisorSAID = txtSAId.Text.Trim();
            advisorentity.Designation = Convert.ToInt32(ddlDesignation.SelectedValue);
            advisorentity.Branch = Convert.ToInt32(ddlBranch.SelectedValue);
            advisorentity.AdvisorType = Convert.ToInt32(ddlAdvisorType.SelectedValue);
            advisorentity.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            advisorentity.AdvisorRole = Convert.ToInt32(ddlRole.SelectedValue);
            advisorentity.Image = hfImage.Value;
            //need to initialize with login advisor id
            advisorentity.UpdatedBy = 0;
            int result = newAdvisorBL.CUDAdvisor(advisorentity, 'u');
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}