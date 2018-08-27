using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using BusinessLogic;
using System.Web.UI.HtmlControls;

public partial class ClientForms_DirectorDetails : System.Web.UI.Page
{
    DirectorBL directorBL = new DirectorBL();

    CommanClass _objComman = new CommanClass();
    BankBL bankBL = new BankBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressBL addressBL = new AddressBL();
    AddressEntity addressEntity = new AddressEntity();
    EncryptDecrypt ObjEn = new EncryptDecrypt();
    ValidateSAIDBL validateSAIDBL = new ValidateSAIDBL();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();
    DocumentBL _objDocumentBL = new DocumentBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

                if (Session["SAID"] == null || Session["SAID"].ToString() == "")
                {
                    Response.Redirect("../ClientLogin.aspx", false);
                }
                else
                {

                    if (!IsPostBack)
                    {
                        message.ForeColor = System.Drawing.Color.Green;
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                      
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(dropAddress);
                        _objComman.getRecordsPerPage(dropBank);
                        _objComman.getRecordsPerPage(DropPageDocuments);
                        txtUIC.Text = Session["CompanyUIC"].ToString();
                        GetDirectorGrid(txtUIC.Text.Trim());
                        BindBankDetails();
                        BindAddressDetails();
                        BindDocumentList();
                        Disable();

                    }
                }

                if (this.IsPostBack)
                {
                    if (Request.Form[TabName.UniqueID].Contains("gvDirector"))
                    {
                        TabName.Value = "tabDirector";
                    }

                    else if (Request.Form[TabName.UniqueID].Contains("gvAddress"))
                    {
                        TabName.Value = "tabAddress";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gdvBankList"))
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

    private int DirectorInsertUpdate()
    {
        int Result;
        DirectorEntity directorEntity = new DirectorEntity
       {
           DirectorID = Convert.ToInt32(hfDirectorId.Value.Trim()),
           ReferenceSAID = Session["SAID"].ToString(),
           UIC = txtUIC.Text.Trim(),
           SAID = txtSAID.Text.Trim(),
           Title = ddlTitle.SelectedValue,
           FirstName = txtFirstName.Text.Trim(),
           LastName = txtLastName.Text.Trim(),
           EmailID = txtEmail.Text.Trim(),
           Mobile = txtMobile.Text.Trim(),
           Phone = txtPhone.Text.Trim(),
           DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text,
           TaxRefNo = txtTaxRefNo.Text.Trim(),
           ShareHolderPercentage = string.IsNullOrEmpty(txtSharePerc.Text) ? null : txtSharePerc.Text,
           ShareValue = txtShareValue.Text.Trim(),
           Status = 1,
           AdvisorID = 0,
       };
        if (btnDirectorSubmit.Text == "Update")
        {
            Result = directorBL.DirectorCRUD(directorEntity, 'u');
        }
        else
        {
            Result = directorBL.DirectorCRUD(directorEntity, 'i');
        }
        return Result;
    }
    protected void btnDirectorSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int res = DirectorInsertUpdate();
            if (res > 0)
            {
                if (btnDirectorSubmit.Text == "Update")
                    message.Text = "Director details updated successfully!";
                else
                    message.Text = "Director details saved successfully!";
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearDirectorControls();
                GetDirectorGrid(txtUIC.Text.Trim());
                Disable();
                ClearAddressControls();
                ClearBankControls();
                BindBankDetails();
                BindAddressDetails();

            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry, Director Information not Saved, please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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

    private void GetDirectorGrid(string UIC)
    {

        DataSet ds = new DataSet();
        ds = directorBL.GetDirector(0, UIC);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvDirector.DataSource = ds.Tables[0];
            divDirectorlist.Visible = true;
        }
        else
        {
            gvDirector.DataSource = null;
            divDirectorlist.Visible = false;
        }
        gvDirector.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        gvDirector.DataBind();
    }

    private void BindDirector(int DirectorID)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = directorBL.GetDirector(DirectorID, txtUIC.Text.Trim());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hfDirectorID1.Value = ds.Tables[0].Rows[0]["DirectorID"].ToString();
                txtValidCompanyRegNum.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
                txtValidSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                dropvalidTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
                txtvalidFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtvalidLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtvalidEmailId.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtvalidMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtvalidPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtvalidDOB.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
                txtvalidRefNum.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                txtvalidSharePerc.Text = ds.Tables[0].Rows[0]["ShareHolderPercentage"].ToString();
                txtvalidShareValue.Text = ds.Tables[0].Rows[0]["ShareValue"].ToString();
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

    private void ClearDirectorControls()
    {
        btnDirectorSubmit.Text = "Save";
        hfDirectorId.Value = "0";
        txtSAID.Text = "";
        ddlTitle.SelectedValue = "";
        txtDateOfBirth.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtPhone.Text = "";
        txtTaxRefNo.Text = "";
        txtSharePerc.Text = "";
        txtShareValue.Text = "";
    }
    protected void btnDirectorCancel_Click(object sender, EventArgs e)
    {
        ClearDirectorControls();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyDetails.aspx", false);
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDirectorGrid(txtUIC.Text.Trim());
    }
    private void GetClientRegistartion()
    {
        try
        {
            ClientProfileBL _ObjClientProfileBL = new ClientProfileBL();
            DataSet ds = new DataSet();
            ds = _ObjClientProfileBL.GetClientPersonal(txtSAID.Text.Trim());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                // txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                txtSharePerc.Text = ds.Tables[0].Rows[0]["ShareHolderPercentage"].ToString();
                txtShareValue.Text = ds.Tables[0].Rows[0]["ShareValue"].ToString();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtPhone.Text = "";
                txtTaxRefNo.Text = "";
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




    protected void gvDirector_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDirector.PageIndex = e.NewPageIndex;
            GetDirectorGrid(txtUIC.Text.Trim());
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
    protected void gvDirector_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["DirectorID"] = ((Label)row.FindControl("lblDirectorID")).Text.ToString();
                ViewState["UIC"] = ((Label)row.FindControl("lblReferenceUIC")).Text.ToString();
                string UIC = ((Label)row.FindControl("lblReferenceUIC")).Text.ToString();
                string DirectorName = ((Label)row.FindControl("lblFirstName")).Text.ToString() + " " + ((Label)row.FindControl("lblLastName")).Text.ToString();
                txtDirectorNameBank.Text = DirectorName;
                txtSAIDBank.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();

                txtSAIDDirector.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                txtDirectorNameAddress.Text = DirectorName;


                //if (e.CommandName == "EditDirector")
                //{
                //    Enable();
                //    int directorId = Convert.ToInt32(e.CommandArgument);
                //    BindDirector(directorId);
                //}
                if (e.CommandName == "Document")
                {
                    Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("9") + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                }
                //else if (e.CommandName == "DeleteDirector")
                //{
                //    ViewState["flag"] = 1;
                //    lbldeletemessage.Text = "Are you sure, you want to delete Director Details?";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                //}
                else if (e.CommandName == "Address")
                {
                    DataSet dsAddress = addressbankBL.GetAddressDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                    if (dsAddress.Tables[0].Rows.Count > 0)
                    {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "9")
                        {
                            ClearAddressControls();
                        }
                        else
                        {
                            txtHouseNo.Text = dsAddress.Tables[0].Rows[0]["HouseNo"].ToString();
                            txtBulding.Text = dsAddress.Tables[0].Rows[0]["BuildingName"].ToString();
                            txtFloor.Text = dsAddress.Tables[0].Rows[0]["FloorNo"].ToString();
                            txtFlatNo.Text = dsAddress.Tables[0].Rows[0]["FlatNo"].ToString();
                            txtRoadName.Text = dsAddress.Tables[0].Rows[0]["RoadName"].ToString();
                            txtRoadNo.Text = dsAddress.Tables[0].Rows[0]["RoadNo"].ToString();
                            txtSuburbName.Text = dsAddress.Tables[0].Rows[0]["SuburbName"].ToString();
                            txtCity.Text = dsAddress.Tables[0].Rows[0]["City"].ToString();
                            txtComplex.Text = dsAddress.Tables[0].Rows[0]["Complex"].ToString();
                            txtPostalCode.Text = dsAddress.Tables[0].Rows[0]["PostalCode"].ToString();
                            ddlProvince.SelectedValue = dsAddress.Tables[0].Rows[0]["Province"].ToString();
                            ddlCountry.SelectedValue = dsAddress.Tables[0].Rows[0]["Country"].ToString();
                        }
                    }
                    // btnUpdateAddress.Visible = false;
                    btnAddressSubmit.Visible = true;
                    addressmessage.InnerText = "Save Address Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                }
                else if (e.CommandName == "Bank")
                {
                    DataSet dsBank = addressbankBL.GetBankDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                    if (dsBank.Tables[0].Rows.Count > 0)
                    {
                        if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "9")
                        {
                            ClearBankControls();
                        }
                        else
                        {
                            txtBankName.Text = dsBank.Tables[0].Rows[0]["BankName"].ToString();
                            txtBranchNumber.Text = dsBank.Tables[0].Rows[0]["BranchNumber"].ToString();
                            txtAccountNumber.Text = dsBank.Tables[0].Rows[0]["AccountNumber"].ToString();
                            txtCurrency.Text = dsBank.Tables[0].Rows[0]["Currency"].ToString();
                            txtSwift.Text = dsBank.Tables[0].Rows[0]["SWIFT"].ToString();
                            ddlAccountType.SelectedValue = dsBank.Tables[0].Rows[0]["AccountType"].ToString();
                        }
                    }
                    bankmessage.InnerText = "Save Bank Details";
                    btnBankSubmit.Visible = true;
                    // btnUpdateBank.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                }
                else if (e.CommandName == "Validate")
                {
                    int directorId = Convert.ToInt32(ViewState["DirectorID"].ToString());
                    BindDirector(directorId);
                    validatemessage.InnerText = "Director Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openValidateModal();", true);

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
    protected void dropAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAddressDetails();
    }
    protected void BindAddressDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 9, txtUIC.Text);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddress.DataSource = ds.Tables[0];
                searchaddress.Visible = true;
            }
            else
            {
                gvAddress.DataSource = null;
                searchaddress.Visible = false;
            }
            gvAddress.PageSize = Convert.ToInt32(dropAddress.SelectedValue);
            gvAddress.DataBind();
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
    private void ClearAddressControls()
    {
        txtHouseNo.Text = "";
        txtPostalCode.Text = "";
        txtRoadName.Text = "";
        txtRoadNo.Text = "";
        txtSuburbName.Text = "";
        txtFlatNo.Text = "";
        txtBulding.Text = "";
        txtFloor.Text = "";
        txtCity.Text = "";
        txtComplex.Text = "";
        ddlCountry.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
    }

    protected void gvAddress_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["AddressDetailID"] = ((Label)row.FindControl("lblAddressDetailID")).Text.ToString();
                ViewState["AddressSAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                //if (e.CommandName == "EditAddress")
                //{
                //    addressmessage.InnerText = "Update Address Details";
                //    btnAddressSubmit.Visible = false;
                //    btnUpdateAddress.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                //    txtSAIDDirector.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                //    txtDirectorNameAddress.Text = ((Label)row.FindControl("lblDirectorName")).Text.ToString();
                //    txtHouseNo.Text = ((Label)row.FindControl("lblHouseNo")).Text.ToString();
                //    txtBulding.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                //    txtFloor.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                //    txtFlatNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                //    txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                //    txtRoadNo.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                //    txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                //    ddlCity.SelectedValue = ((Label)row.FindControl("lblCity")).Text.ToString();
                //    txtPostalCode.Text = ((Label)row.FindControl("lblPostalCode")).Text.ToString();
                //    ddlProvince.SelectedValue = ((Label)row.FindControl("lblProvince")).Text.ToString();
                //    ddlCountry.SelectedValue = ((Label)row.FindControl("lblCountry")).Text.ToString();
                //}
                //else if (e.CommandName == "DeleteAddress")
                //{
                //    ViewState["flag"] = 3;
                //    lbldeletemessage.Text = "Are you sure, you want to delete Address Details?";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                //}
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
    protected void gvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAddress.PageIndex = e.NewPageIndex;
            BindAddressDetails();
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
    protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBankDetails();
    }
    protected void gdvBankList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["BankDetailID"] = ((Label)row.FindControl("lblBankDetailID")).Text.ToString();
                ViewState["BankSAID"] = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                //if (e.CommandName == "EditBank")
                //{
                //    bankmessage.InnerText = "Update Bank Details";
                //    btnBankSubmit.Visible = false;
                //    btnUpdateBank.Visible = true;
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                //    txtSAIDBank.Text = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                //    txtDirectorNameBank.Text = ((Label)row.FindControl("lblDirectorName")).Text.ToString();
                //    txtBankName.Text = ((Label)row.FindControl("lblBankName")).Text.ToString();
                //    txtBranchNumber.Text = ((Label)row.FindControl("lblBranchNumber")).Text.ToString();
                //    txtAccountNumber.Text = ((Label)row.FindControl("lblAccountNumber")).Text.ToString();
                //    txtCurrency.Text = ((Label)row.FindControl("lblCurrency")).Text.ToString();
                //    txtSwift.Text = ((Label)row.FindControl("lblSWIFT")).Text.ToString();
                //    ddlAccountType.SelectedValue = ((Label)row.FindControl("lblAccountType")).Text.ToString();
                //}
                //else if (e.CommandName == "DeleteBank")
                //{
                //    ViewState["flag"] = 2;
                //    lbldeletemessage.Text = "Are you sure, you want to delete Bank Details?";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);

                //}
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
    protected void gdvBankList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvBankList.PageIndex = e.NewPageIndex;
            BindBankDetails();
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
            bankEntity.Type = 9;
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            bankEntity.SAID = ViewState["SAID"].ToString();
            bankEntity.ReferenceID = Session["SAID"].ToString();
            bankEntity.UIC = txtUIC.Text.Trim();
            bankEntity.CreatedBy = 0;
            bankEntity.AdvisorID = 0;
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBankControls();
                BindBankDetails();
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
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    //protected void btnUpdateBank_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        bankEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
    //        bankEntity.Type = 9;
    //        bankEntity.SAID = ViewState["BankSAID"].ToString();
    //        bankEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
    //        bankEntity.UIC = txtUIC.Text.Trim();
    //        bankEntity.BankName = txtBankName.Text;
    //        bankEntity.BranchNumber = txtBranchNumber.Text;
    //        bankEntity.AccountNumber = txtAccountNumber.Text;
    //        bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
    //        bankEntity.Currency = txtCurrency.Text;
    //        bankEntity.SWIFT = txtSwift.Text;
    //        bankEntity.CreatedBy = 0;
    //        bankEntity.AdvisorID = 0;
    //        bankEntity.UpdatedBy = 0;

    //        int result = bankBL.CURDBankInfo(bankEntity, 'u');
    //        if (result == 1)
    //        {
    //            lblTitle.Text = "Thank You!";
    //            lblTitle.ForeColor = System.Drawing.Color.Green;
    //            message.ForeColor = System.Drawing.Color.Green;
    //            message.Text = "Bank details updated successfully!";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //            ClearBankControls();
    //            BindBankDetails();
    //        }
    //        else
    //        {
    //            lblTitle.Text = "Warning!";
    //            lblTitle.ForeColor = System.Drawing.Color.Red;
    //            message.ForeColor = System.Drawing.Color.Red;
    //            message.Text = "Sorry, Please try again!";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //            BindBankDetails();
    //        }
    //    }
    //    catch
    //    {
    //        lblTitle.Text = "Warning!";
    //        lblTitle.ForeColor = System.Drawing.Color.Red;
    //        message.ForeColor = System.Drawing.Color.Red;
    //        message.Text = "Sorry, Something went wrong, please contact administrator";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //    }
    //}
    protected void btnBankCancel_Click(object sender, EventArgs e)
    {
        ClearBankControls();
    }

    private void ClearBankControls()
    {
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        ddlAccountType.SelectedIndex = 0;
        txtCurrency.Text = "";
        txtSwift.Text = "";
    }

    protected void BindBankDetails()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = bankBL.GetBankList(Session["SAID"].ToString(), 9, txtUIC.Text);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gdvBankList.DataSource = ds.Tables[0];
                searchbank.Visible = true;
            }
            else
            {
                gdvBankList.DataSource = null;
                searchbank.Visible = false;
            }
            gdvBankList.PageSize = Convert.ToInt32(dropBank.SelectedValue);
            gdvBankList.DataBind();
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
            addressEntity.Type = 9;
            addressEntity.UIC = txtUIC.Text.Trim();
            addressEntity.City = txtCity.Text;
            addressEntity.Complex = txtComplex.Text;
            addressEntity.BuildingName = txtBulding.Text;
            addressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            addressEntity.FlatNo = txtFlatNo.Text;
            addressEntity.HouseNo = txtHouseNo.Text;
            addressEntity.Floor = txtFloor.Text;
            addressEntity.PostalCode = txtPostalCode.Text;
            addressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            addressEntity.ReferenceSAID = Session["SAID"].ToString();
            addressEntity.SAID = ViewState["SAID"].ToString();
            addressEntity.SuburbName = txtSuburbName.Text;
            addressEntity.RoadNo = txtRoadNo.Text;
            addressEntity.RoadName = txtRoadName.Text;
            addressEntity.Status = 1;
            addressEntity.AdvisorId = 0;
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";

            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddressControls();
                BindAddressDetails();

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
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry, Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    //protected void btnUpdateAddress_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
    //        addressEntity.Type = 9;
    //        addressEntity.SAID = ViewState["AddressSAID"].ToString();
    //        addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
    //        addressEntity.UIC = txtUIC.Text.Trim();
    //        addressEntity.HouseNo = txtHouseNo.Text;
    //        addressEntity.BuildingName = txtBulding.Text;
    //        addressEntity.Floor = txtFloor.Text;
    //        addressEntity.FlatNo = txtFlatNo.Text;
    //        addressEntity.RoadName = txtRoadName.Text;
    //        addressEntity.RoadNo = txtRoadNo.Text;
    //        addressEntity.SuburbName = txtSuburbName.Text;
    //        addressEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
    //        addressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
    //        addressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
    //        addressEntity.PostalCode = txtPostalCode.Text;
    //        addressEntity.AdvisorId = 0;
    //        addressEntity.Status = 1;
    //        addressEntity.CreatedBy = 0;
    //        addressEntity.UpdatedBy = "0";


    //        int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
    //        if (result == 1)
    //        {
    //            lblTitle.Text = "Thank You!";
    //            lblTitle.ForeColor = System.Drawing.Color.Green;
    //            message.ForeColor = System.Drawing.Color.Green;
    //            message.Text = "Address details updated successfully!";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //            ClearAddressControls();
    //            BindAddressDetails();
    //        }
    //        else
    //        {
    //            lblTitle.Text = "Warning!";
    //            lblTitle.ForeColor = System.Drawing.Color.Red;
    //            message.ForeColor = System.Drawing.Color.Red;
    //            message.Text = "Sorry, Please try again!";
    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //            BindAddressDetails();
    //        }
    //    }
    //    catch
    //    {
    //        lblTitle.Text = "Warning!";
    //        lblTitle.ForeColor = System.Drawing.Color.Red;
    //        message.ForeColor = System.Drawing.Color.Red;
    //        message.Text = "Sorry, Something went wrong, please contact administrator";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //    }
    //}
    protected void btnAddressCancel_Click(object sender, EventArgs e)
    {
        ClearAddressControls();
    }

    //protected void btnSure_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (Convert.ToInt32(ViewState["flag"]) == 1)
    //        {
    //            int res = directorBL.DeleteDirector(Convert.ToInt32(ViewState["DirectorID"]), ViewState["SAID"].ToString(), txtUIC.Text.Trim());
    //            if (res > 0)
    //            {
    //                GetDirectorGrid(txtUIC.Text.Trim());
    //                BindAddressDetails();
    //                BindBankDetails();

    //                ClearDirectorControls();
    //                ClearBankControls();
    //                ClearAddressControls();
    //            }
    //        }
    //        else if (Convert.ToInt32(ViewState["flag"]) == 2)
    //        {
    //            int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
    //            if (result == 1)
    //            {
    //                ClearBankControls();
    //                BindBankDetails();
    //            }
    //        }
    //        else if (Convert.ToInt32(ViewState["flag"]) == 3)
    //        {
    //            int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
    //            if (result == 1)
    //            {
    //                ClearAddressControls();
    //                BindAddressDetails();
    //            }
    //        }
    //    }
    //    catch
    //    {
    //        lblTitle.Text = "Warning!";
    //        lblTitle.ForeColor = System.Drawing.Color.Red;
    //        message.ForeColor = System.Drawing.Color.Red;
    //        message.Text = "Sorry, Something went wrong, please contact administrator";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //    }
    //}
    protected void Disable()
    {
        ddlTitle.Enabled = false;
        txtFirstName.ReadOnly = true;
        txtLastName.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtMobile.ReadOnly = true;
        txtPhone.ReadOnly = true;
        txtTaxRefNo.ReadOnly = true;
        //txtDateOfBirth.ReadOnly = true;
        txtSharePerc.ReadOnly = true;
        txtShareValue.ReadOnly = true;
        rfvtxtFirstName.Enabled = false;
        //rfvtxtLastName.Enabled = false;
        //rfvtxtTaxRefNo.Enabled = false;
        //rfvtxtEmail.Enabled = false;
        //rfvtxtMobile.Enabled=false;
        //rfvPhone.Enabled=false;
        //rfvTitle.Enabled = false;
        btnDirectorSubmit.Enabled = false;
    }
    protected void Enable()
    {
        ddlTitle.Enabled = true;
        txtFirstName.ReadOnly = false;
        txtLastName.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtMobile.ReadOnly = false;
        txtPhone.ReadOnly = false;
        txtTaxRefNo.ReadOnly = false;
        // txtDateOfBirth.ReadOnly = false;
        txtDateOfBirth.Attributes.Remove("disabled");
        txtSharePerc.ReadOnly = false;
        txtShareValue.ReadOnly = false;
        //rfvTitle.Enabled = true;
        rfvtxtFirstName.Enabled = true;
        //rfvtxtLastName.Enabled = true;
        //rfvtxtTaxRefNo.Enabled = true;
        //rfvtxtEmail.Enabled = true;
        //rfvtxtMobile.Enabled=true;
        //rfvPhone.Enabled=true;
        btnDirectorSubmit.Enabled = true;
    }
    protected void imgSearchsaid_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataSet dataset = validateSAIDBL.ValidateSAID(txtSAID.Text, Session["SAID"].ToString(), txtUIC.Text);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    if (dataset.Tables[0].Rows[i]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[i]["MEMBERTYPE"].ToString() == "6")
                    {
                        count = count + 1;
                        lblTitle.Text = "Warning!";
                        lblTitle.ForeColor = System.Drawing.Color.Red;
                        message.ForeColor = System.Drawing.Color.Red;
                        message.Text = "Sorry, The member already exists as Director!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                }
                if (count == 0)
                {
                    if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS SPOUSE OR CHILD" || dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH SAME ORG BUT WITH OTHER CLIENT" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG AND THER CLIENT" || dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS INDIVIDUAL")
                    {
                        Disable();
                        btnDirectorSubmit.Enabled = true;
                        ddlTitle.SelectedValue = dataset.Tables[0].Rows[0]["TITLE"].ToString();
                        txtFirstName.Text = dataset.Tables[0].Rows[0]["FIRSTNAME"].ToString();
                        txtLastName.Text = dataset.Tables[0].Rows[0]["LASTNAME"].ToString();
                        txtEmail.Text = dataset.Tables[0].Rows[0]["EMAILID"].ToString();
                        txtMobile.Text = dataset.Tables[0].Rows[0]["MOBILE"].ToString();
                        txtPhone.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                        txtTaxRefNo.Text = dataset.Tables[0].Rows[0]["TAXREFNO"].ToString();
                        // txtDateOfBirth.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString()).ToString("yyyy-MM-dd");
                        if (dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString() == "")
                        {
                            txtDateOfBirth.Text = "";
                        }
                        else
                        {
                            txtDateOfBirth.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString()).ToString("yyyy-MM-dd");
                        }
                        txtSharePerc.ReadOnly = false;
                        txtShareValue.ReadOnly = false;
                    }
                    else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
                    {
                        ddlTitle.SelectedValue = "";
                        txtDateOfBirth.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtEmail.Text = "";
                        txtMobile.Text = "";
                        txtPhone.Text = "";
                        txtTaxRefNo.Text = "";
                        txtSharePerc.Text = "";
                        txtShareValue.Text = "";
                        Enable();
                    }
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
    protected void btnValidOK_Click(object sender, EventArgs e)
    {
        try
        {
            int result = validateSAIDBL.UpdateValidation(Session["SAID"].ToString(), txtValidSAID.Text, ViewState["UIC"].ToString(), "", 9);
            if (result > 0)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Details Validated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                GetDirectorGrid(txtUIC.Text.Trim());
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
    protected void btnValidCancel_Click(object sender, EventArgs e)
    {

    }
    protected void gvDirector_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Flag"].ToString().Equals("0") && drv["AdvisorID"].ToString() != "0")
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    ((Image)e.Row.FindControl("imgbtnValidate")).Visible = true;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    ((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;
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
    private void BindDocumentList()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objDocumentBL.GetDocumentList(Session["SAID"].ToString(),9, txtUIC.Text);
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
                Label lblSAID = (Label)e.Row.FindControl("lblSAID");
                HtmlAnchor AnchorDoc = (HtmlAnchor)e.Row.FindControl("anchorId");
                string url = HttpContext.Current.Request.Url.Authority;
                AnchorDoc.HRef = "http://" + url + "/ClientDocuments/" + Session["SAID"].ToString() + "/" + "Director" + "/" + lblSAID.Text + "/" + LblDoc.Text;
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