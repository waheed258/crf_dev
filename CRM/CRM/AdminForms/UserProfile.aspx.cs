using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
using System.IO;
public partial class AdminForms_UserProfile : System.Web.UI.Page
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
                        ddlAdvisorType.Visible = false;
                        lblAdvisorType.Visible = false;
                        GetAdvisor();
                        GetDesignation();
                        GetBranch();
                        //GetAdvisorType();
                        GetStatus();
                        //GetRole();
                       
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void GetAdvisor()
    {
        try
        {
            DataSet ds = new DataSet();
            int AdvisorId = Convert.ToInt32(Session["AdvisorID"]);
            ds = newAdvisorBL.GetAdvisor(AdvisorId);
            if (ds.Tables.Count > 0)
            {
                txtSAId.Text = ds.Tables[0].Rows[0]["AdvisorSAID"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtMobileNum.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhoneNum.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtEmailId.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtLoginId.Text = ds.Tables[0].Rows[0]["LoginId"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                ddlBranch.SelectedValue = ds.Tables[0].Rows[0]["Branch"].ToString();
                ddlStatus.SelectedValue = ds.Tables[0].Rows[0]["Status"].ToString();
                ddlDesignation.SelectedValue = ds.Tables[0].Rows[0]["Designation"].ToString();
                if (ds.Tables[0].Rows[0]["Designation"].ToString() == "1")
                {
                    ddlAdvisorType.Items.Clear();
                    lblAdvisorType.Visible = true;
                    ddlAdvisorType.Visible = true;
                    GetAdvisorType(1);
                    
                }
                else if (ds.Tables[0].Rows[0]["Designation"].ToString() == "2")
                {
                    ddlAdvisorType.Items.Clear();
                    GetAdvisorType(2);
                    lblAdvisorType.Visible = true;
                    ddlAdvisorType.Visible = true;
                    lblAdvisorType.Text = "Consultant Type";
                }
                ddlAdvisorType.SelectedValue = ds.Tables[0].Rows[0]["AdvisorType"].ToString();

                // ddlRole.SelectedValue = ds.Tables[0].Rows[0]["AdvisorRole"].ToString();
                hfImage.Value = ds.Tables[0].Rows[0]["Image"].ToString();




            }
        }
        catch 
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = string.Empty;
            string fileNamemain = string.Empty;
            if (fuImageUpload.HasFile)
            {
                fuImageUpload.SaveAs(Server.MapPath("~/AdvisorImages/" + txtSAId.Text + this.fuImageUpload.FileName));
                fileName = Path.GetFileName(this.fuImageUpload.PostedFile.FileName);
                advisorentity.Image = "~/AdvisorImages/" + txtSAId.Text + fileName;
                Session["Image"] = "~/AdvisorImages/" + txtSAId.Text + fileName;
            }
            else
            {
                advisorentity.Image = Session["Image"].ToString();
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
          //  advisorentity.AdvisorRole = Convert.ToInt32(ddlRole.SelectedValue);
            //advisorentity.Image = hfImage.Value;
            //need to initialize with login advisor id

            advisorentity.UpdatedBy = 0;
            int result = newAdvisorBL.CUDAdvisor(advisorentity, 'u');
            if (result == 1)
            {
                if (Session["Image"].ToString() != "")
                {
                    Image lblImg = (Image)Page.Master.FindControl("imgProfilePic");
                    lblImg.ImageUrl = Session["Image"].ToString();
                }
                else
                {
                    Image lblImg = (Image)Page.Master.FindControl("imgProfilePic");
                    lblImg.ImageUrl = "~/AdvisorImages/7346837424333avatar5.png";
                }
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Advisor Updated Successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch 
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashBoard.aspx");
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}