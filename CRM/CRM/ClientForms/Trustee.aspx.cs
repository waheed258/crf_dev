using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;

public partial class ClientForms_Trustee : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    TrusteeBL _objTrusteeBL = new TrusteeBL();
    DataSet ds = new DataSet();
    BankBL bankBL = new BankBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressBL addressBL = new AddressBL();
    AddressEntity addressEntity = new AddressEntity();
    ValidateSAIDBL validateSAID = new ValidateSAIDBL();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();
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
                        _objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(dropAddress);
                        _objComman.getRecordsPerPage(dropBank);
                        txtUIC.Text = Session["TrustUIC"].ToString();
                        GetTrusteeGrid(txtUIC.Text);
                        BindBankDetails();
                        BindAddressDetails();
                        Disable();

                    }
                }
                if (this.IsPostBack)
                {
                    if (Request.Form[TabName.UniqueID].Contains("gvTrust"))
                    {
                        TabName.Value = "tabTrust";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gvAddress"))
                    {
                        TabName.Value = "tabAddress";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gdvBankList"))
                    {
                        TabName.Value = "tabBank";
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

    }

    protected void Disable()
    {
        ddlTitle.Enabled = false;
        txtFirstName.ReadOnly = true;
        txtLastName.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtMobile.ReadOnly = true;
        txtPhoneNum.ReadOnly = true;
        txtTaxRefNo.ReadOnly = true;
        txtDateOfBirth.ReadOnly = true;
        rfvtxtFirstName.Enabled = false;
        rfvtxtLastName.Enabled = false;
        rfvtxtMobile.Enabled = false;
        rfvEmail.Enabled = false;
        btnSubmit.Enabled = false;
    }

    protected void Enable()
    {
        ddlTitle.Enabled = true;
        txtFirstName.ReadOnly = false;
        txtLastName.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtMobile.ReadOnly = false;
        txtPhoneNum.ReadOnly = false;
        txtTaxRefNo.ReadOnly = false;
        txtDateOfBirth.ReadOnly = false;
        rfvtxtFirstName.Enabled = true;
        rfvtxtLastName.Enabled = true;
        rfvtxtMobile.Enabled = true;
        rfvEmail.Enabled = true;
        btnSubmit.Enabled = true;
    }

    /// <summary>
    /// Trustee Methhods,Events 
    /// Trestee Gridview 
    /// </summary>
    /// <param name="ReferenceSAId"></param>
    /// <param name="UIC"></param>
    #region Trustee Details

    protected void gvTrustee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrustee.PageIndex = e.NewPageIndex;
        GetTrusteeGrid(txtUIC.Text.Trim());
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTrusteeGrid(txtUIC.Text.Trim());
    }
    private void GetTrusteeGrid(string ReferenceUIC)
    {
        ds = _objTrusteeBL.GetTrustee(0, ReferenceUIC);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvTrustee.DataSource = ds.Tables[0];
            divTrusteelist.Visible = true;
        }
        else
        {
            gvTrustee.DataSource = null;
            divTrusteelist.Visible = false;
        }
        gvTrustee.PageSize = Convert.ToInt32(DropPage.SelectedValue);
        gvTrustee.DataBind();
    }

    private void BindTrustee(int TrusteeId)
    {

        ds = _objTrusteeBL.GetTrustee(TrusteeId, txtUIC.Text.Trim());
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hfTrusteeId.Value = ds.Tables[0].Rows[0]["TrusteeID"].ToString();
            txtUIC.Text = ds.Tables[0].Rows[0]["ReferenceUIC"].ToString();
            txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
            txtDateOfBirth.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
            txtPhoneNum.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            btnSubmit.Text = "Update";
        }
    }

    private int TrusteeInsertUpdate()
    {
        TrusteeEntity _objTrusteeEntity = new TrusteeEntity
        {
            TrusteeId = Convert.ToInt32(hfTrusteeId.Value),
            ReferenceSAID = Session["SAID"].ToString(),
            ReferenceUIC = txtUIC.Text.Trim(),
            SAID = txtSAID.Text.Trim(),
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            EmailID = txtEmail.Text.Trim(),
            Mobile = txtMobile.Text.Trim(),
            TaxRefNo = txtTaxRefNo.Text.Trim(),
            Status = 1,
            AdvisorID = 0,
            Title = ddlTitle.SelectedValue,
            DateOfBirth = txtDateOfBirth.Text,
            Phone = txtPhoneNum.Text
        };
        int result;
        if (btnSubmit.Text == "Update")
            result = _objTrusteeBL.TrusteeInsertUpdate(_objTrusteeEntity, 'U');
        else
            result = _objTrusteeBL.TrusteeInsertUpdate(_objTrusteeEntity, 'I');

        return result;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int res = TrusteeInsertUpdate();
            if (res > 0)
            {
                if (btnSubmit.Text == "Update")
                    message.Text = "Trustee updated successfully !";
                else
                    message.Text = "Trustee saved successfully !";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                GetTrusteeGrid(txtUIC.Text);
                ClearTrusteeControls();
                ClearAddressControls();
                ClearBankControls();
                BindBankDetails();
                BindAddressDetails();
                Disable();
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Trustee information not saved please check the details !";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }

        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearTrusteeControls();
    }

    private void ClearTrusteeControls()
    {
        btnSubmit.Text = "Save";
        hfTrusteeId.Value = "0";
        txtSAID.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtTaxRefNo.Text = "";
        txtDateOfBirth.Text = "";
        ddlTitle.SelectedValue = "";
        txtPhoneNum.Text = "";
    }

    private void GetClientRegistartion()
    {

        ClientProfileBL _ObjClientProfileBL = new ClientProfileBL();
        ds = _ObjClientProfileBL.GetClientPersonal(txtSAID.Text.Trim());
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            // txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
            txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
            txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
            txtDateOfBirth.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
            ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
        }
        else
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtTaxRefNo.Text = "";
            txtDateOfBirth.Text = "";
            ddlTitle.SelectedValue = "";
        }

    }
  

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrustDetails.aspx", false);
    }
    protected void gvTrustee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["TrusteeId"] = ((Label)row.FindControl("lblTrusteeId")).Text.ToString();
                string UIC = ((Label)row.FindControl("lblReferenceUIC")).Text.ToString();
                string TrusteeName = ((Label)row.FindControl("lblFirstName")).Text.ToString() + " " + ((Label)row.FindControl("lblLastName")).Text.ToString();

                txtTrusteeNameBank.Text = TrusteeName;
                txtSAIDBank.Text = ViewState["SAID"].ToString();

                txtTrusteeAddress.Text = TrusteeName;
                txtSAIDAddress.Text = ViewState["SAID"].ToString();

                EncryptDecrypt ObjEn = new EncryptDecrypt();
                switch (e.CommandName)
                {
                    case "EditTrustee":
                        int TrusteeId = Convert.ToInt32(e.CommandArgument.ToString());
                        Enable();
                        BindTrustee(TrusteeId);
                        break;
                    case "Document":
                        Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("6") + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                        break;
                    case "DeleteTrustee":
                        ViewState["flag"] = 1;
                        lbldeletemessage.Text = "Are you sure, you want to delete Trstee Details?";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                        break;
                    case "Address":
                        DataSet dsAddress = addressbankBL.GetAddressDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                        if (dsAddress.Tables[0].Rows.Count > 0)
                        {
                            if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "6")
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
                                ddlCity.SelectedValue = dsAddress.Tables[0].Rows[0]["City"].ToString();
                                txtPostalCode.Text = dsAddress.Tables[0].Rows[0]["PostalCode"].ToString();
                                ddlProvince.SelectedValue = dsAddress.Tables[0].Rows[0]["Province"].ToString();
                                ddlCountry.SelectedValue = dsAddress.Tables[0].Rows[0]["Country"].ToString();
                            }
                        }
                        btnUpdateAddress.Visible = false;
                        btnAddressSubmit.Visible = true;
                        addressmessage.InnerText = "Save Address Details";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                        break;
                    case "Bank":
                        DataSet dsBank = addressbankBL.GetBankDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                        if (dsBank.Tables[0].Rows.Count > 0)
                        {
                            if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "6")
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
                        btnUpdateBank.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                        break;
                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    #endregion


    /// <summary>
    /// Address Details Methods
    /// Address Details Info Events
    /// </summary>
    /// <returns></returns>
    #region Address Details

    protected void dropAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAddressDetails();
    }
    protected void BindAddressDetails()
    {
        try
        {
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 6);
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
        ddlCity.SelectedValue = "-1";
        ddlCountry.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
    }

    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.Type = 6;
            addressEntity.UIC = txtUIC.Text.ToString();
            addressEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
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
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddressControls();
                BindAddressDetails();

            }
            else
            {
                message.Text = "Please try again!";
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            addressEntity.Type = 6;
            addressEntity.SAID = ViewState["AddressSAID"].ToString();
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.UIC = txtUIC.Text.Trim();
            addressEntity.HouseNo = txtHouseNo.Text;
            addressEntity.BuildingName = txtBulding.Text;
            addressEntity.Floor = txtFloor.Text;
            addressEntity.FlatNo = txtFlatNo.Text;
            addressEntity.RoadName = txtRoadName.Text;
            addressEntity.RoadNo = txtRoadNo.Text;
            addressEntity.SuburbName = txtSuburbName.Text;
            addressEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
            addressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            addressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            addressEntity.PostalCode = txtPostalCode.Text;
            addressEntity.AdvisorId = 0;
            addressEntity.Status = 1;
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";

            int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
            if (result == 1)
            {
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddressControls();
                BindAddressDetails();
            }
            else
            {
                message.Text = "Please try again!";
                BindAddressDetails();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnAddressCancel_Click(object sender, EventArgs e)
    {
        ClearAddressControls();
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

                if (e.CommandName == "EditAddress")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);

                    txtSAIDAddress.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtTrusteeAddress.Text = ((Label)row.FindControl("lblFullName")).Text.ToString();

                    txtHouseNo.Text = ((Label)row.FindControl("lblHouseNo")).Text.ToString();
                    txtBulding.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                    txtFloor.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                    txtFlatNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                    txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                    txtRoadNo.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                    txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                    ddlCity.SelectedValue = ((Label)row.FindControl("lblCity")).Text.ToString();
                    txtPostalCode.Text = ((Label)row.FindControl("lblPostalCode")).Text.ToString();
                    ddlProvince.SelectedValue = ((Label)row.FindControl("lblProvince")).Text.ToString();
                    ddlCountry.SelectedValue = ((Label)row.FindControl("lblCountry")).Text.ToString();
                }
                else if (e.CommandName == "DeleteAddress")
                {
                    ViewState["flag"] = 3;
                    lbldeletemessage.Text = "Are you sure, you want to delete Address Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAddress.PageIndex = e.NewPageIndex;
        BindAddressDetails();
    }



    #endregion


    /// <summary>
    /// Bank Details Methods
    /// Bank Details Info Events
    /// </summary>
    /// <returns></returns>
    #region Bank Details

    

    protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBankDetails();
    }
    protected void btnBankSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.Type = 6;
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
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBankControls();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            bankEntity.Type = 6;
            bankEntity.SAID = ViewState["BankSAID"].ToString();
            bankEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            bankEntity.UIC = txtUIC.Text.Trim();
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            bankEntity.CreatedBy = 0;
            bankEntity.AdvisorID = 0;
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'u');
            if (result == 1)
            {
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBankControls();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                BindBankDetails();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
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
            ds = bankBL.GetBankList(Session["SAID"].ToString(), 6);
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
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

                if (e.CommandName == "EditBank")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);

                    txtSAIDBank.Text = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                    txtTrusteeNameBank.Text = ((Label)row.FindControl("lblTrusteeName")).Text.ToString();

                    txtBankName.Text = ((Label)row.FindControl("lblBankName")).Text.ToString();
                    txtBranchNumber.Text = ((Label)row.FindControl("lblBranchNumber")).Text.ToString();
                    txtAccountNumber.Text = ((Label)row.FindControl("lblAccountNumber")).Text.ToString();
                    txtCurrency.Text = ((Label)row.FindControl("lblCurrency")).Text.ToString();
                    txtSwift.Text = ((Label)row.FindControl("lblSWIFT")).Text.ToString();
                    ddlAccountType.SelectedValue = ((Label)row.FindControl("lblAccountType")).Text.ToString();
                }
                else if (e.CommandName == "DeleteBank")
                {
                    ViewState["flag"] = 2;
                    lbldeletemessage.Text = "Are you sure, you want to delete Bank Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);

                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gdvBankList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBankList.PageIndex = e.NewPageIndex;
        BindBankDetails();
    }

    #endregion

    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int res = _objTrusteeBL.DeleteTrustee(Convert.ToInt32(ViewState["TrusteeId"]), txtUIC.Text.Trim(), ViewState["SAID"].ToString());
                if (res > 0)
                {
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Trustee details removed successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    GetTrusteeGrid(txtUIC.Text.Trim());
                    BindBankDetails();
                    BindAddressDetails();

                    ClearTrusteeControls();
                    ClearAddressControls();
                    ClearBankControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
                if (result == 1)
                {
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Bank details of Trustee removed successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    ClearBankControls();
                    BindBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
                if (result == 1)
                {
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Address details of Trustee removed successfully!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    ClearAddressControls();
                    BindAddressDetails();
                }
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

    }


    protected void imgSearchsaid_Click(object sender, ImageClickEventArgs e)
    {
        DataSet dataset = validateSAID.ValidateSAID(txtSAID.Text, Session["SAID"].ToString(), txtUIC.Text);
        if (dataset.Tables[0].Rows.Count > 0)
        {
            if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() == "3")
            {
                message.Text = "The member already exists as trustee!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
            else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS SPOUSE OR CHILD" ||
                dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG" ||
                dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH SAME ORG BUT WITH OTHER CLIENT" ||
                dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG AND THER CLIENT" || dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS INDIVIDUAL")
            {
                Disable();
                btnSubmit.Enabled = true;
                ddlTitle.SelectedValue = dataset.Tables[0].Rows[0]["TITLE"].ToString();
                txtFirstName.Text = dataset.Tables[0].Rows[0]["FIRSTNAME"].ToString();
                txtLastName.Text = dataset.Tables[0].Rows[0]["LASTNAME"].ToString();
                txtEmail.Text = dataset.Tables[0].Rows[0]["EMAILID"].ToString();
                txtMobile.Text = dataset.Tables[0].Rows[0]["MOBILE"].ToString();
                txtPhoneNum.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                txtTaxRefNo.Text = dataset.Tables[0].Rows[0]["TAXREFNO"].ToString();
                DateTime DOB = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString());
                txtDateOfBirth.Text = DOB.ToShortDateString();
            }
            else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
            {
                Enable();
            }
        }
    }
}