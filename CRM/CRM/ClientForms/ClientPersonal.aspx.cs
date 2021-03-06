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
using System.Web.UI.HtmlControls;
public partial class ClientProfile_ClientPersonal : System.Web.UI.Page
{
    ClientProfileBL _ObjClientProfileBL = new ClientProfileBL();
    BankInfoEntity BankInfoEntity = new BankInfoEntity();
    AddressEntity AddressEntity = new AddressEntity();
    ClientPersonalInfoEntity ClientPersonalInfoEntity = new ClientPersonalInfoEntity();
    DataSet ds = new DataSet();
    BankBL bankbl = new BankBL();
    AddressBL addressbl = new AddressBL();
    CommanClass _objComman = new CommanClass();
    CredentialsBL credentialsBL = new CredentialsBL();
    DocumentBL _objDocumentBL = new DocumentBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

                if (Session["SAID"].ToString() == null || Session["SAID"].ToString() == "")
                {
                    Response.Redirect("../ClientLogin.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPageBank);
                        _objComman.getRecordsPerPage(DropPageAddress);
                        _objComman.getRecordsPerPage(DropPageDocuments);
                        GetClientPersonal();
                        GetBankDetails();
                        GetAddressDetails();
                        BindDocumentList();
                    }
                }

                if (this.IsPostBack)
                {
                    if (Request.Form[TabName.UniqueID].Contains("gvAddressDetails"))
                    {
                        TabName.Value = "tabAddress";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gvBankDetails"))
                    {
                        TabName.Value = "tabBank";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gvDocumentsList"))
                    {
                        TabName.Value = "tabDocumentsList";
                    }
                    else
                    {
                        TabName.Value = Request.Form[TabName.UniqueID];
                    }
                }

            }
            if (strPreviousPage == "")
            {
                Response.Redirect("~/ClientLogin.aspx");
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
    private void GetClientRegistartion()
    {
        try
        {
            DataSet ds = _ObjClientProfileBL.GetClientRegistartion(Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSAId.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
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


    private void GetClientPersonal()
    {
        try
        {
            DataSet ds = _ObjClientProfileBL.GetClientPersonal(Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSAId.ReadOnly = true;
                ddlTitle.Enabled = false;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtPhoneNo.ReadOnly = true;
                txtMobileNo.ReadOnly = true;
                txtDateofBirth.ReadOnly = true;
                //txtDateofBirth.Attributes.Add("disabled", "disabled");
                txtTaxRefNo.ReadOnly = true;
                fuImageUpload.Enabled = false;
                ViewState["flag"] = 1;
                txtSAId.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhoneNo.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                if (ds.Tables[0].Rows[0]["DateOfBirth"].ToString() != "")
                {
                    txtDateofBirth.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()).Date.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtDateofBirth.Text = "";
                }

                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                btnSubmitClientPersonal.Text = "Edit";
                DivAddBank.Visible = true;
            }
            else
            {
                txtSAId.ReadOnly = true;
                ddlTitle.Enabled = false;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = false;
                txtEmail.ReadOnly = true;
                txtPhoneNo.ReadOnly = false;
                txtMobileNo.ReadOnly = false;
                txtDateofBirth.ReadOnly = false;
                //txtDateofBirth.Attributes.Add("disabled", "disabled");
                txtTaxRefNo.ReadOnly = false;
                ViewState["flag"] = 2;
                btnSubmitClientPersonal.Text = "Submit";
                GetClientRegistartion();
                DivAddBank.Visible = false;
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



    protected void btnSubmitClientPersonal_Click(object sender, EventArgs e)
    {
        string img = "";
        try
        {
            if (btnSubmitClientPersonal.Text == "Edit")
            {
                btnSubmitClientPersonal.Text = "Update";
                txtSAId.ReadOnly = true;
                ddlTitle.Enabled = false;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = false;
                txtEmail.ReadOnly = true;
                txtPhoneNo.ReadOnly = false;
                txtMobileNo.ReadOnly = false;
                txtDateofBirth.ReadOnly = false;
                //txtDateofBirth.Attributes.Remove("disabled");
                txtTaxRefNo.ReadOnly = false;
                fuImageUpload.Enabled = true;
            }
            else
            {
                string fileName = string.Empty;
                string fileNamemain = string.Empty;
                if (fuImageUpload.HasFile)
                {
                    fuImageUpload.SaveAs(Server.MapPath("~/ClientImages/" + txtSAId.Text + this.fuImageUpload.FileName));
                    fileName = Path.GetFileName(this.fuImageUpload.PostedFile.FileName);
                    ClientPersonalInfoEntity.Image = "~/ClientImages/" + txtSAId.Text + fileName;
                    img = "~/ClientImages/" + txtSAId.Text + fileName;
                    ClientPersonalInfoEntity.Image = img;
                    Session["Image"] = img;
                }
                else
                {
                    ClientPersonalInfoEntity.Image = "";
                    ClientPersonalInfoEntity.Image = Session["Image"].ToString();
                }
                ClientPersonalInfoEntity.SAID = txtSAId.Text;
                ClientPersonalInfoEntity.Title = ddlTitle.SelectedValue;
                ClientPersonalInfoEntity.FirstName = txtFirstName.Text;
                ClientPersonalInfoEntity.LastName = txtLastName.Text;
                ClientPersonalInfoEntity.EmailID = txtEmail.Text;
                ClientPersonalInfoEntity.Phone = txtPhoneNo.Text;
                ClientPersonalInfoEntity.Mobile = txtMobileNo.Text;
                if (txtDateofBirth.Text == "")
                    ClientPersonalInfoEntity.DateOfBirth = null;
                else
                    ClientPersonalInfoEntity.DateOfBirth = txtDateofBirth.Text;                
                ClientPersonalInfoEntity.TaxRefNo = txtTaxRefNo.Text;
                ClientPersonalInfoEntity.AdvisorID = 0;
                ClientPersonalInfoEntity.UpdatedBy = Session["SAID"].ToString();
                int result;
                if (Convert.ToInt32(ViewState["flag"]) == 1)
                {
                    result = _ObjClientProfileBL.CURDClientPersonalInfo(ClientPersonalInfoEntity, 'u');
                    Label lblUserName = (Label)this.Master.FindControl("lblUserName");
                    lblUserName.Text = txtFirstName.Text.ToUpper() + " " + txtLastName.Text.ToUpper();
                    int res = credentialsBL.InsImage(img, txtSAId.Text);
                    lblTitle.Text = "Thank You!";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Client details updated successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    GetBankDetails();
                    GetAddressDetails();
                }
                else
                {
                    result = _ObjClientProfileBL.CURDClientPersonalInfo(ClientPersonalInfoEntity, 'i');
                    int res = credentialsBL.InsImage(img, txtSAId.Text);
                    lblTitle.Text = "Thank You!";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Client created successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    DivAddBank.Visible = true;
                    ViewState["flag"] = 1;
                }
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
                        lblImg.ImageUrl = "~/assets/dist/img/avatar5.png";
                    }
                    txtSAId.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtPhoneNo.ReadOnly = true;
                    txtMobileNo.ReadOnly = true;
                    txtDateofBirth.ReadOnly = true;
                    txtTaxRefNo.ReadOnly = true;
                    btnSubmitClientPersonal.Text = "Edit";
                    fuImageUpload.Enabled = false;
                }
                else
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, Please try again!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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

    protected void btnCancleClientPersonal_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    protected void btnCancelAddress_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    private void clearAddresscontrols()
    {
        txtHouseNo.Text = "";
        txtBulding.Text = "";
        txtFloor.Text = "";
        txtFlatNo.Text = "";
        txtRoadName.Text = "";
        txtRoadNo.Text = "";
        txtSuburbName.Text = "";
        txtCity.Text = "";
        txtComplex.Text = "";
        txtPostalCode.Text = "";
        ddlProvince.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
    }



    #region Bank Details

    private void ClearBank()
    {
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        ddlAccountType.SelectedValue = "-1";
        txtCurrency.Text = "";
        txtSwift.Text = "";
    }


    protected void btnCancelBank_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }

    protected void GetBankDetails()
    {
        try
        {
            ds = bankbl.GetBankList(Session["SAID"].ToString(), 1,"");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvBankDetails.DataSource = ds.Tables[0];
                searchbank.Visible = true;
            }
            else
            {
                gvBankDetails.DataSource = null;
                searchbank.Visible = false;
            }
            gvBankDetails.PageSize = Convert.ToInt32(DropPageBank.SelectedValue);
            gvBankDetails.DataBind();

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



    protected void gvBankDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["BankDetailID"] = ((Label)row.FindControl("lblBankDetailID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "EditBank")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                    txtSAIDBank.Text = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                    txtBankName.Text = ((Label)row.FindControl("lblBankName")).Text.ToString();
                    txtBranchNumber.Text = ((Label)row.FindControl("lblBranchNumber")).Text.ToString();
                    txtAccountNumber.Text = ((Label)row.FindControl("lblAccountNumber")).Text.ToString();
                    txtCurrency.Text = ((Label)row.FindControl("lblCurrency")).Text.ToString();
                    txtSwift.Text = ((Label)row.FindControl("lblSWIFT")).Text.ToString();
                    txtClientNameBank.Text = ((Label)row.FindControl("lblFullName")).Text.ToString();
                    ddlAccountType.SelectedValue = ((Label)row.FindControl("lblAccountType")).Text.ToString();
                    ViewState["Bankflag"] = 1;
                }
                else if (e.CommandName == "Delete")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Bank Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
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

    protected void gvBankDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvBankDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    #endregion

    #region Address Details


    protected void GetAddressDetails()
    {
        try
        {
            ds = addressbl.GetAddressDetails(Session["SAID"].ToString(), 1,"");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddressDetails.DataSource = ds;
                searchaddress.Visible = true;
            }
            else
            {
                gvAddressDetails.DataSource = null;
                searchaddress.Visible = false;
            }
            gvAddressDetails.PageSize = Convert.ToInt32(DropPageAddress.SelectedValue);
            gvAddressDetails.DataBind();

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

    protected void gvAddressDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["AddressDetailID"] = ((Label)row.FindControl("lblAddressDetailID")).Text.ToString();
                // ViewState["AddressSAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "EditAddress")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);

                    txtHouseNo.Text = ((Label)row.FindControl("lblHouseNo")).Text.ToString();
                    txtBulding.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                    txtFloor.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                    txtFlatNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                    txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                    txtRoadNo.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                    txtAddressClientName.Text = ((Label)row.FindControl("lblFullName")).Text.ToString();
                    txtIDNo.Text = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                    txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                    txtCity.Text = ((Label)row.FindControl("lblCity")).Text.ToString();
                    txtComplex.Text = ((Label)row.FindControl("lblComplex")).Text.ToString();
                    txtPostalCode.Text = ((Label)row.FindControl("lblPostalCode")).Text.ToString();
                    ddlProvince.SelectedValue = ((Label)row.FindControl("lblProvince")).Text.ToString();
                    ddlCountry.SelectedValue = ((Label)row.FindControl("lblCountry")).Text.ToString();
                    ViewState["Addressflag"] = 1;
                }
                else if (e.CommandName == "Delete")
                {
                    ViewState["flag"] = 2;
                    lbldeletemessage.Text = "Are you sure, you want to delete Address Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
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

    protected void gvAddressDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gvAddressDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    #endregion


    protected void btnSure_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (Convert.ToInt32(ViewState["flag"]) == 1)
        //    {
        //        int result = bankbl.DeleteBankDetails(ViewState["BankDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["ReferenceSAID"].ToString(), Session["Name"].ToString());
        //        if (result == 2)
        //        {
        //            GetBankDetails();
        //        }
        //    }
        //    else if (Convert.ToInt32(ViewState["flag"]) == 2)
        //    {
        //        int result = addressbl.DeleteAddressDetails(ViewState["AddressDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["AddressReferenceSAID"].ToString(), Session["Name"].ToString());
        //        if (result == 2)
        //        {
        //            GetAddressDetails();
        //        }
        //    }
        //}
        //catch
        //{
        //    lblTitle.Text = "Warning!";
        //    lblTitle.ForeColor = System.Drawing.Color.Red;
        //    message.ForeColor = System.Drawing.Color.Red;
        //    message.Text = "Sorry, Something went wrong, please contact administrator";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //}


    }
    //Bank Button
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            txtSAIDBank.Text = txtSAId.Text;
            txtClientNameBank.Text = txtFirstName.Text + " " + txtLastName.Text;
            bankmessage.InnerText = "Save Bank Details";
            btnBankSubmit.Visible = true;
            btnUpdateBank.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
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

    //Address Button
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            txtIDNo.Text = txtSAId.Text;
            txtAddressClientName.Text = txtFirstName.Text + " " + txtLastName.Text;
            btnUpdateAddress.Visible = false;
            btnAddressSubmit.Visible = true;
            addressmessage.InnerText = "Save Address Details";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
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

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            EncryptDecrypt ObjEn = new EncryptDecrypt();
            Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("1") + "&x=" + ObjEn.Encrypt(txtSAId.Text.ToString()), false);
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

    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            AddressEntity.SAID = txtSAId.Text;
            AddressEntity.Type = 1;
            AddressEntity.UIC = "0";
            AddressEntity.ReferenceSAID = Session["SAID"].ToString();
            AddressEntity.HouseNo = txtHouseNo.Text;
            AddressEntity.BuildingName = txtBulding.Text;
            AddressEntity.Floor = txtFloor.Text;
            AddressEntity.FlatNo = txtFlatNo.Text;
            AddressEntity.RoadName = txtRoadName.Text;
            AddressEntity.RoadNo = txtRoadNo.Text.Trim();
            AddressEntity.SuburbName = txtRoadNo.Text;
            AddressEntity.City = txtCity.Text;
            AddressEntity.Complex = txtComplex.Text;
            AddressEntity.PostalCode = txtPostalCode.Text;
            AddressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            AddressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);

            AddressEntity.AdvisorId = 0;

            AddressEntity.Status = 1;
            AddressEntity.CreatedBy = 0;

            int result;
            if (Convert.ToInt32(ViewState["Addressflag"]) == 1)
            {
                AddressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
                result = new AddressBL().InsertUpdateAddress(AddressEntity, 'u');
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else
            {
                result = new AddressBL().InsertUpdateAddress(AddressEntity, 'i');
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details saved successfully!";
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                clearAddresscontrols();
            }
            if (result == 1)
            {
                clearAddresscontrols();
                GetAddressDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                clearAddresscontrols();
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
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            AddressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            AddressEntity.Type = 1;
            AddressEntity.UIC = "0";
            AddressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            AddressEntity.SAID = ViewState["AddressReferenceSAID"].ToString();

            AddressEntity.HouseNo = txtHouseNo.Text;
            AddressEntity.BuildingName = txtBulding.Text;
            AddressEntity.Floor = txtFloor.Text;
            AddressEntity.FlatNo = txtFlatNo.Text;
            AddressEntity.RoadName = txtRoadName.Text;
            AddressEntity.RoadNo = txtRoadNo.Text;
            AddressEntity.SuburbName = txtSuburbName.Text;
            AddressEntity.City = txtCity.Text;
            AddressEntity.Complex = txtComplex.Text;
            AddressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            AddressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            AddressEntity.PostalCode = txtPostalCode.Text;
            AddressEntity.AdvisorId = 0;
            AddressEntity.Status = 1;
            AddressEntity.CreatedBy = 0;
            AddressEntity.UpdatedBy = "0";


            int result = addressbl.InsertUpdateAddress(AddressEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details updated successfully!";
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                clearAddresscontrols();
                GetAddressDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                clearAddresscontrols();
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
    protected void btnBankSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            BankInfoEntity.SAID = txtSAId.Text;
            BankInfoEntity.Type = 1;
            BankInfoEntity.UIC = "0";
            BankInfoEntity.ReferenceID = Session["SAID"].ToString();
            BankInfoEntity.BankName = txtBankName.Text;
            BankInfoEntity.BranchNumber = txtBranchNumber.Text;
            BankInfoEntity.AccountNumber = txtAccountNumber.Text;
            BankInfoEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            BankInfoEntity.Currency = txtCurrency.Text;
            BankInfoEntity.SWIFT = txtSwift.Text;
            BankInfoEntity.CreatedBy = 0;
            BankInfoEntity.AdvisorID = 0;
            BankInfoEntity.UpdatedBy = 0;

            int result;
            if (Convert.ToInt32(ViewState["Bankflag"]) == 1)
            {
                BankInfoEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
                result = new BankBL().CURDBankInfo(BankInfoEntity, 'u');
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else
            {
                result = new BankBL().CURDBankInfo(BankInfoEntity, 'i');
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            if (result == 1)
            {
                ClearBank();
                GetBankDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
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
    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            BankInfoEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            BankInfoEntity.Type = 1;
            BankInfoEntity.SAID = ViewState["ReferenceSAID"].ToString();
            BankInfoEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            BankInfoEntity.UIC = "0";
            BankInfoEntity.BankName = txtBankName.Text;
            BankInfoEntity.BranchNumber = txtBranchNumber.Text;
            BankInfoEntity.AccountNumber = txtAccountNumber.Text;
            BankInfoEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            BankInfoEntity.Currency = txtCurrency.Text;
            BankInfoEntity.SWIFT = txtSwift.Text;
            BankInfoEntity.CreatedBy = 0;
            BankInfoEntity.AdvisorID = 0;
            BankInfoEntity.UpdatedBy = 0;
            int result = bankbl.CURDBankInfo(BankInfoEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details updated successfully!";
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
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

    //protected void txtAccountNumber_TextChanged(object sender, EventArgs e) 
    //{
    //    try
    //    { string accountNum = txtAccountNumber.Text; 
    //        ds = bankbl.CheckAccountNum(accountNum); 
    //        if (ds.Tables[0].Rows.Count > 0) 
    //        { lblBankMsg.Text = "Already Exists"; 
    //            txtAccountNumber.Text = "";
    //        } else { lblBankMsg.Text = ""; 
    //        }
    //    } 
    //    catch 
    //    {
    //        message.ForeColor = System.Drawing.Color.Red; message.Text = "Something went wrong, please contact administrator"; ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); 
    //    }
    //}
    protected void DropPageAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAddressDetails();
    }
    protected void DropPageBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBankDetails();
    }
    protected void gvAddressDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAddressDetails.PageIndex = e.NewPageIndex;
            GetAddressDetails();
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
    protected void gvBankDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBankDetails.PageIndex = e.NewPageIndex;
            GetBankDetails();
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
    private void BindDocumentList()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objDocumentBL.GetDocumentList(Session["SAID"].ToString(), 1, "0");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDocumentsList.DataSource = ds.Tables[0];
                divDocument.Visible = true;
            }
            else
            {
                gvDocumentsList.DataSource = null;
                divDocument.Visible = false;
            }
            gvDocumentsList.PageSize = Convert.ToInt32(DropPageDocuments.SelectedValue);
            gvDocumentsList.DataBind();
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

    protected void DropPageDocuments_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDocumentList();
    }
    protected void gvDocumentsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDocumentsList.PageIndex = e.NewPageIndex;
            BindDocumentList();
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
    protected void gvDocumentsList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblDoc = (Label)e.Row.FindControl("lblDoc");
                HtmlAnchor AnchorDoc = (HtmlAnchor)e.Row.FindControl("anchorId");
                string url = HttpContext.Current.Request.Url.Authority;
                AnchorDoc.HRef = "http://" + url + "/ClientDocuments/" + Session["SAID"].ToString() + "/" + "Client" + "/" + txtSAId.Text.Trim() + "/" + LblDoc.Text;
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