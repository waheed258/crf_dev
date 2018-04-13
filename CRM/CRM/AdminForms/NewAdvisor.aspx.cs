using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using EntityManager;

public partial class AdminForms_NewAdvisor : System.Web.UI.Page
{
    DataSet dataset = new DataSet();
    NewAdvisorBL newAdvisorBL = new NewAdvisorBL();
    AdvisorEntity advisorentity = new AdvisorEntity();
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
                        GetDesignation();
                        GetBranch();
                        GetStatus();
                      //  GetRole();
                        ddlAdvisorType.Visible = false;
                        lblAdvisorType.Visible = false;
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
    protected void GetAdvisorType(int Designation)
    {
        try
        {
            dataset = newAdvisorBL.GetAdvisorType(Designation);
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
    //protected void GetRole()
    //{
    //    try
    //    {
    //        dataset = newAdvisorBL.GetRole();
    //        ddlRole.DataSource = dataset;
    //        ddlRole.DataTextField = "Role";
    //        ddlRole.DataValueField = "RoleID";
    //        ddlRole.DataBind();
    //        ddlRole.Items.Insert(0, new ListItem("--Select Role --", "-1"));
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
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
         //   advisorentity.AdvisorRole = Convert.ToInt32(ddlRole.SelectedValue);
            advisorentity.AdvisorSAID = txtSAId.Text.Trim();


            int result = newAdvisorBL.CUDAdvisor(advisorentity, 'i');
            if (result == 1)
            {
                message.Text = "Advisor Added Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
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
    //    ddlRole.SelectedValue = "-1";
        ddlStatus.SelectedValue = "-1";
        txtLoginId.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtSAId.Text = "";

    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlAdvisorType.Items.Clear();
            lblAdvisorType.Visible = true;
            ddlAdvisorType.Visible = true;
            GetAdvisorType(ddlDesignation.SelectedIndex);
            if (ddlDesignation.SelectedIndex==1)
            {
               
                lblAdvisorType.Text = "Advisor Type";
            }
            else if (ddlDesignation.SelectedIndex==2)
            {
                lblAdvisorType.Text = "Consultant Type";
            }
            else
            {
                lblAdvisorType.Visible = false;
                ddlAdvisorType.Visible = false;
            }
        }
        catch
        {

        }
      
    }
}