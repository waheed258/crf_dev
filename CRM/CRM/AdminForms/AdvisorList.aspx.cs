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
                        GetGridData();
                        editSection.Visible = false;
                        GetDesignation();
                        GetBranch();                     
                       // GetAdvisorType();
                        GetStatus();
                       // GetRole();
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
            dataset = newAdvisorBL.GetAdvisorList();
            gvAdvisor.DataSource = dataset;
            ViewState["dt"] = dataset.Tables[0];
            gvAdvisor.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvAdvisor.DataBind();
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
    protected void gvAdvisor_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

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
            txtSAId.Text = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAdvisorSAID")).Text.ToString();
            string designation = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblDesig")).Text.ToString();
            ddlDesignation.SelectedValue = designation;
            if (designation == "1")
            {
                ddlAdvisorType.Items.Clear();
                GetAdvisorType(1);
                lblAdvisorType.Visible = true;
                ddlAdvisorType.Visible = true;
            }
            else if(designation == "2")
            {
                ddlAdvisorType.Items.Clear();
                GetAdvisorType(2);
                lblAdvisorType.Visible = true;
                ddlAdvisorType.Visible = true;
                lblAdvisorType.Text = "Consultant Type";
                
            }
            string AType = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAType")).Text.ToString();
            ddlAdvisorType.SelectedValue = AType;
            string branch = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblBranch")).Text.ToString();
            ddlBranch.SelectedValue = branch;
            //string AType = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAType")).Text.ToString();
            //ddlAdvisorType.SelectedValue = AType;
            string Status = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblAStatus")).Text.ToString();
            ddlStatus.SelectedValue = Status;
           // string Role = ((Label)gvAdvisor.Rows[RowIndex].FindControl("lblRole")).Text.ToString();
            //ddlRole.SelectedValue = Role;

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
        catch 
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
        catch 
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
        catch {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
            advisorentity.AdvisorID = Convert.ToInt32(ViewState["AdvisorID"]);
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
            // advisorentity.AdvisorRole = Convert.ToInt32(ddlRole.SelectedValue);
            //need to initialize with login advisor id
            advisorentity.UpdatedBy = 0;
            int result = newAdvisorBL.CUDAdvisor(advisorentity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Advisor Updated Successfully!";
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
        txtMobileNum.Text = "";
        txtPhoneNum.Text = "";
        txtEmailId.Text = "";
        ddlAdvisorType.SelectedValue = "-1";
        ddlBranch.SelectedValue = "-1";
        ddlDesignation.SelectedValue = "-1";
        //ddlRole.SelectedValue = "-1";
        ddlStatus.SelectedValue = "-1";
        txtLoginId.Text = "";
        txtPassword.Text = "";
        txtSAId.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        sectionAdvisorList.Visible = true;
        editSection.Visible = false;
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            ddlAdvisorType.Items.Clear();
            lblAdvisorType.Visible = true;
            ddlAdvisorType.Visible = true;
            GetAdvisorType(ddlDesignation.SelectedIndex);
            if (ddlDesignation.SelectedIndex == 1)
            {

                lblAdvisorType.Text = "Advisor Type";
            }
            else if (ddlDesignation.SelectedIndex == 2)
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
    protected void gvAdvisor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAdvisor.PageIndex = e.NewPageIndex;
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
}