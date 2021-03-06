﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using BusinessLogic;

public partial class ClientProfile_Beneficiary : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    BeneficiaryBL _objBeneficiaryBL = new BeneficiaryBL();
    DataSet ds = new DataSet();
    BankBL bankBL = new BankBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressBL addressBL = new AddressBL();
    AddressEntity addressEntity = new AddressEntity();
    EncryptDecrypt ObjEn = new EncryptDecrypt();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();
    ValidateSAIDBL validateSAIDBL = new ValidateSAIDBL();
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
                        message.ForeColor = System.Drawing.Color.Green;
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                       // _objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(dropAddress);
                        _objComman.getRecordsPerPage(dropBank);

                        if (!string.IsNullOrEmpty(Request.QueryString["t"]))
                        {
                            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
                            {
                                txtUIC.Text = Session["TrustUIC"].ToString();
                                btnBack.Text = "Back to Trust";
                            }
                            else
                            {
                                txtUIC.Text = Session["CompanyUIC"].ToString();
                                btnBack.Text = "Back to Company";

                            }
                            divCompany.Visible = false;
                            divIndividual.Visible = false;
                            GetBenificiaryType();
                            GetBeneficiaryGrid(txtUIC.Text.Trim());
                            BindBankDetails();
                            BindAddressDetails();
                        }
                        Disable();
                        Disable1();
                    }
                }

                if (this.IsPostBack)
                {
                    if (Request.Form[TabName.UniqueID].Contains("gvBeneficiary"))
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
                Response.Redirect("~/AdminLogin.aspx");
            }
        }

        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

    }

    /// <summary>
    /// Beneficiary EMthods and Events
    /// Beneficiary Grid
    /// </summary>
    /// <returns></returns>
    #region Beneficiary Details

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBeneficiaryGrid(txtUIC.Text.Trim());
    }
    private int BeneficiaryInsertUpdate()
    {     
            int Result;
            BenificiaryEntity _objBeneficiary = new BenificiaryEntity
            {
                BeneficiaryID = Convert.ToInt32(hfBenefaciaryId.Value.Trim()),
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
                Type = Request.QueryString["t"] != null ? Convert.ToInt32(ObjEn.Decrypt(Request.QueryString["t"].ToString())) : 0,
                Status = 1,
                AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),
                BenificiaryType = Convert.ToInt32(dropBenificiaryType.SelectedValue),
                UICNo = txtCompanyUIC.Text.Trim(),
                CompanyName = txtCompanyName.Text.Trim(),
                CompanyEmailID = txtCompanyEmail.Text.Trim(),
                YearOfEstablishment = string.IsNullOrEmpty(txtYearofFoundation.Text) ? null : txtYearofFoundation.Text,
                CompanyTelephone = txtTelephoneNum.Text.Trim(),
                CompanyWebsite = txtWebsite.Text.Trim(),
                VATNo = txtVATRef.Text.Trim(),
            };
            if (btnSubmit.Text == "Update")
            {
                Result = _objBeneficiaryBL.BeneficiaryInsertUpdate(_objBeneficiary, 'u');
            }
            else
            {
                Result = _objBeneficiaryBL.BeneficiaryInsertUpdate(_objBeneficiary, 'i');
            }
            return Result;
       
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int res = BeneficiaryInsertUpdate();
            if (res > 0)
            {
                if (btnSubmit.Text == "Update")
                    message.Text = "Share Holder details updated successfully!";
                else
                    message.Text = "Share Holder details saved successfully!";

                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBeneficiaryControls();
                GetBeneficiaryGrid(txtUIC.Text.Trim());
                Disable();
                Disable1();
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
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Sorry,Beneficiary Information not Saved please check the Details !!";
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

    private void GetBeneficiaryGrid(string UIC)
    {
        try
        {

            int Type = Convert.ToInt32(ObjEn.Decrypt(Request.QueryString["t"].ToString()));
            ds = _objBeneficiaryBL.GetBeneficiary(0, Type, UIC);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvBeneficiary.DataSource = ds.Tables[0];
                divBeneficiarylist.Visible = true;
            }
            else
            {
                gvBeneficiary.DataSource = null;
                divBeneficiarylist.Visible = false;
            }
            gvBeneficiary.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvBeneficiary.DataBind();
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

    private void BindBeneficiary(int BeneficiaryId)
    {
        try
        {

            int Type = Convert.ToInt32(Request.QueryString["t"] != null ? Convert.ToInt32(ObjEn.Decrypt(Request.QueryString["t"].ToString())) : 0);
            ds = _objBeneficiaryBL.GetBeneficiary(BeneficiaryId, Type, txtUIC.Text.Trim());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hfBenefaciaryId.Value = ds.Tables[0].Rows[0]["BeneficiaryID"].ToString();
                txtUIC.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
                if (ds.Tables[0].Rows[0]["BenificiaryType"].ToString()=="1")
                {
                    divIndividual.Visible = true;
                    divCompany.Visible = false;
                }
                else
                {
                    divCompany.Visible = true;
                    divIndividual.Visible = false;
                }
                dropBenificiaryType.SelectedValue = ds.Tables[0].Rows[0]["BenificiaryType"].ToString();
                dropBenificiaryType.Enabled = false;
                txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                txtSAID.ReadOnly = true;
                ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["DateOfBirth"].ToString() == "")
                {
                    txtDateOfBirth.Text = "";
                }
                else
                {
                    txtDateOfBirth.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()).ToString("yyyy-MM-dd");
                }
                //DateTime DOB = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString());
               // txtDateOfBirth.Text = DOB.ToShortDateString();
                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                txtCompanyUIC.Text = ds.Tables[0].Rows[0]["UICNo"].ToString();
                txtCompanyUIC.ReadOnly = true;
                txtCompanyName.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                if (ds.Tables[0].Rows[0]["YearOfEstablishment"].ToString() == "")
                {
                    txtYearofFoundation.Text = "";
                }
                else
                {
                    txtYearofFoundation.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["YearOfEstablishment"].ToString()).ToString("yyyy-MM-dd");
                }
                //txtYearofFoundation.Text = ds.Tables[0].Rows[0]["YearOfEstablishment"].ToString();
                txtVATRef.Text = ds.Tables[0].Rows[0]["VATNo"].ToString();
                txtTelephoneNum.Text = ds.Tables[0].Rows[0]["CompanyTelephone"].ToString();
                txtCompanyEmail.Text = ds.Tables[0].Rows[0]["CompanyEmailID"].ToString();
                txtWebsite.Text = ds.Tables[0].Rows[0]["CompanyWebsite"].ToString();
                btnSubmit.Text = "Update";
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

    private void ClearBeneficiaryControls()
    {
        btnSubmit.Text = "Save";
        hfBenefaciaryId.Value = "0";
        txtSAID.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtPhone.Text = "";
        txtTaxRefNo.Text = "";
        ddlTitle.SelectedValue = "";
        txtDateOfBirth.Text = "";
        txtCompanyUIC.Text = "";
        txtCompanyName.Text = "";
        txtYearofFoundation.Text = "";
        txtVATRef.Text = "";
        txtTelephoneNum.Text = "";
        txtCompanyEmail.Text = "";
        txtWebsite.Text = "";
        dropBenificiaryType.SelectedValue = "0";
        dropBenificiaryType.Enabled = true;
        divCompany.Visible = false;
        divIndividual.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearBeneficiaryControls();
    }

    private void GetClientRegistartion()
    {
        try
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
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
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
        catch {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

  
    protected void gvBeneficiary_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvBeneficiary.PageIndex = e.NewPageIndex;
            GetBeneficiaryGrid(txtUIC.Text.Trim());
        }
        catch {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            Response.Redirect("TrustDetails.aspx", false);
        else
            Response.Redirect("Company.aspx", false);
    }
    protected void gvBeneficiary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                string UIC = ((Label)row.FindControl("lblReferenceUIC")).Text.ToString();
                ViewState["BeneficiaryID"] = ((Label)row.FindControl("lblBeneficiaryID")).Text.ToString();
                ViewState["ShareHolderType"] = ((Label)row.FindControl("lblShareHolderType")).Text.ToString();
                ViewState["UICNO"] = ((Label)row.FindControl("lblUICNo")).Text.ToString();
                ViewState["CompanyName"] = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                if (ViewState["ShareHolderType"].ToString() == "Individual")
                {
                    string BeneficiaryName = ((Label)row.FindControl("lblFirstName")).Text.ToString() + " " + ((Label)row.FindControl("lblLastName")).Text.ToString();
                    txtBeneficiaryNameBank.Text = BeneficiaryName;
                    txtSAIDBank.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtSAIDBeneficiary.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtBeneficiaryAddress.Text = BeneficiaryName;
                }
                else
                {
                    txtBeneficiaryNameBank.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                    txtSAIDBank.Text = ((Label)row.FindControl("lblUICNo")).Text.ToString();
                    txtSAIDBeneficiary.Text = ((Label)row.FindControl("lblUICNo")).Text.ToString();
                    txtBeneficiaryAddress.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                }
                
                if (e.CommandName == "EditBeneficiary")
                {
                    Enable();
                    Enable1();
                    int BenfId = Convert.ToInt32(ViewState["BeneficiaryID"].ToString());
                    BindBeneficiary(BenfId);
                }
                else if (e.CommandName == "Document")
                {
                    if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
                        if (ViewState["ShareHolderType"].ToString() == "Individual")
                        {
                            Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("7") + "&type=t" + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                        }
                        else
                        {
                            Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("7") + "&type=t" + "&x=" + ObjEn.Encrypt(ViewState["UICNO"].ToString()), false);
                        }
                    else
                    {
                        if (ViewState["ShareHolderType"].ToString() == "Individual")
                        {
                            Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("7") + "&type=c" + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                        }
                        else
                        {
                            Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("7") + "&type=c" + "&x=" + ObjEn.Encrypt(ViewState["UICNO"].ToString()), false);
                        }
                    }
                        
                }
                else if (e.CommandName == "DeleteBeneficiary")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Beneficiary Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }
                else if (e.CommandName == "Address")
                {
                    DataSet dsAddress = new DataSet();
                        if (ViewState["ShareHolderType"].ToString() == "Individual")
                        {
                            dsAddress = addressbankBL.GetAddressDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                        }
                        else
                        {
                            dsAddress = addressbankBL.GetAddressDetails(ViewState["UICNO"].ToString(), Session["SAID"].ToString(), UIC);
                        }
                    
                    if (dsAddress.Tables[0].Rows.Count > 0)
                    {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "7")
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
                            txtComplex.Text = dsAddress.Tables[0].Rows[0]["Complex"].ToString();
                            txtCity.Text = dsAddress.Tables[0].Rows[0]["City"].ToString();
                            txtPostalCode.Text = dsAddress.Tables[0].Rows[0]["PostalCode"].ToString();
                            ddlProvince.SelectedValue = dsAddress.Tables[0].Rows[0]["Province"].ToString();
                            ddlCountry.SelectedValue = dsAddress.Tables[0].Rows[0]["Country"].ToString();
                        }
                    }
                    btnUpdateAddress.Visible = false;
                    btnAddressSubmit.Visible = true;
                    addressmessage.InnerText = "Save Address Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                }
                else if (e.CommandName == "Bank")
                {
                    DataSet dsBank = new DataSet();
                    if (ViewState["ShareHolderType"].ToString() == "Individual")
                    {
                        dsBank = addressbankBL.GetBankDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                    }
                    else
                    {
                        dsBank = addressbankBL.GetBankDetails(ViewState["UICNO"].ToString(), Session["SAID"].ToString(), UIC);
                    }
                    
                    if (dsBank.Tables[0].Rows.Count > 0)
                    {
                        if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "7")
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
                }
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
            DataSet ds = new DataSet();
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 7, txtUIC.Text);

            }
            else
            {
                ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 12, txtUIC.Text);

            }
            //ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 7);
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
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

    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                addressEntity.Type = 7;
            }
            else
            {
                addressEntity.Type = 12;
            }
            //addressEntity.Type = 7;
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
            if (ViewState["ShareHolderType"].ToString() == "Individual")
            {
                addressEntity.SAID = ViewState["SAID"].ToString();
            }
            else
            {
                addressEntity.SAID = ViewState["UICNO"].ToString();
            }
            //addressEntity.SAID = ViewState["SAID"].ToString();
            addressEntity.SuburbName = txtSuburbName.Text;
            addressEntity.RoadNo = txtRoadNo.Text;
            addressEntity.RoadName = txtRoadName.Text;
            addressEntity.Status = 1;
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";

            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddressControls();
                BindAddressDetails();

            }
            else
            {
                ClearAddressControls();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindAddressDetails();
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
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                addressEntity.Type = 7;
            }
            else
            {
                addressEntity.Type = 12;
            }
           // addressEntity.Type = 7;
           
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
            addressEntity.City = txtCity.Text;
            addressEntity.Complex = txtComplex.Text;
            addressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            addressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            addressEntity.PostalCode = txtPostalCode.Text;
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
            addressEntity.Status = 1;
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";


            int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddressControls();
                BindAddressDetails();
            }
            else
            {
                ClearAddressControls();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindAddressDetails();
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
                ViewState["BeneficiaryName"] = ((Label)row.FindControl("lblBeneficiaryName")).Text.ToString();

                if (e.CommandName == "EditAddress")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                    txtSAIDBeneficiary.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtBeneficiaryAddress.Text = ((Label)row.FindControl("lblBeneficiaryName")).Text.ToString();
                    txtHouseNo.Text = ((Label)row.FindControl("lblHouseNo")).Text.ToString();
                    txtBulding.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                    txtFloor.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                    txtFlatNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                    txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                    txtRoadNo.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                    txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                    txtCity.Text = ((Label)row.FindControl("lblCity")).Text.ToString();
                    txtComplex.Text = ((Label)row.FindControl("lblComplex")).Text.ToString();
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
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
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                bankEntity.Type = 7;
            }
            else
            {
                bankEntity.Type =12;
            }
            
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            if (ViewState["ShareHolderType"].ToString()=="Individual")
            {
                bankEntity.SAID = ViewState["SAID"].ToString();
            }
            else
            {
                bankEntity.SAID = ViewState["UICNO"].ToString();
            }
            
            bankEntity.ReferenceID = Session["SAID"].ToString();
            bankEntity.UIC = txtUIC.Text.Trim();
            bankEntity.CreatedBy = 0;
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBankControls();
                BindBankDetails();
            }
            else
            {
                ClearBankControls();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Beneficiary Information not Saved please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindBankDetails();
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
    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                bankEntity.Type = 7;
            }
            else
            {
                bankEntity.Type = 12;
            }
            //if (ViewState["ShareHolderType"].ToString() == "Individual")
            //{
            //    bankEntity.SAID = ViewState["SAID"].ToString();
            //}
            //else
            //{
            //    bankEntity.SAID = ViewState["UICNO"].ToString();
            //}
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
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBankControls();
                BindBankDetails();
            }
            else
            {
                ClearBankControls();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Beneficiary Information not Saved please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindBankDetails();
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
            if (ObjEn.Decrypt(Request.QueryString["t"].ToString()) == "1")
            {
                ds = bankBL.GetBankList(Session["SAID"].ToString(), 7, txtUIC.Text);
            }
            else
            {
                ds = bankBL.GetBankList(Session["SAID"].ToString(), 12, txtUIC.Text);
            }

            
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
                //if (((Label)row.FindControl("lblShareType")).Text.ToString() == "1")
                //{
                //    ViewState["BankSAID"] = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                //}
                //else
                //{
                //    ViewState["BankSAID"] = ((Label)row.FindControl("lblBankUICNo")).Text.ToString();
                //}
                ViewState["BankSAID"] = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                ViewState["BeneficiaryName"] = ((Label)row.FindControl("lblBeneficiaryName")).Text.ToString();
                if (e.CommandName == "EditBank")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                    txtSAIDBank.Text = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                    txtBeneficiaryNameBank.Text = ((Label)row.FindControl("lblBeneficiaryName")).Text.ToString();
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    #endregion
    protected void Disable()
    {
        ddlTitle.Enabled = false;
        txtFirstName.ReadOnly = true;
        txtLastName.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtMobile.ReadOnly = true;
        txtPhone.ReadOnly = true;
        txtTaxRefNo.ReadOnly = true;
       // txtDateOfBirth.ReadOnly = true;
        rfvtxtFirstName.Enabled = false;
        //rfvtxtLastName.Enabled = false;
        //rfvtxtTaxRefNo.Enabled = false;
        //rfvtxtEmail.Enabled = false;
        //rfvtxtMobile.Enabled = false;
        //rfvPhone.Enabled = false;
        btnSubmit.Enabled = false;
        rfvTitle.Enabled = false;
        //rfvDateOfBirth.Enabled = false;
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
        //txtDateOfBirth.ReadOnly = false;
        txtDateOfBirth.Attributes.Remove("disabled");
        rfvtxtFirstName.Enabled = true;
        //rfvtxtLastName.Enabled = true;
        //rfvtxtTaxRefNo.Enabled = true;
        //rfvtxtEmail.Enabled = true;
        //rfvtxtMobile.Enabled = true;
        //rfvPhone.Enabled = true;
        btnSubmit.Enabled = true;
        rfvTitle.Enabled = true;
        //rfvDateOfBirth.Enabled = true;
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int res = 0;
                if (ViewState["ShareHolderType"].ToString() == "Individual")
                {
                    res = _objBeneficiaryBL.DeleteBenefaciary(Convert.ToInt32(ViewState["BeneficiaryID"]), ViewState["SAID"].ToString(), txtUIC.Text.Trim(), Convert.ToInt32(Session["AdvisorID"].ToString()));
                }
                else
                {
                    res = _objBeneficiaryBL.DeleteBenefaciary(Convert.ToInt32(ViewState["BeneficiaryID"]), ViewState["UICNO"].ToString(), txtUIC.Text.Trim(), Convert.ToInt32(Session["AdvisorID"].ToString()));
                }
                
                if (res > 0)
                {
                    GetBeneficiaryGrid(txtUIC.Text.Trim());
                    BindAddressDetails();
                    BindBankDetails();

                    ClearBeneficiaryControls();
                    ClearBankControls();
                    ClearAddressControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["BankSAID"].ToString(), ViewState["BeneficiaryName"].ToString());
                if (result == 2)
                {
                    ClearBankControls();
                    BindBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["AddressSAID"].ToString(), ViewState["BeneficiaryName"].ToString());
                if (result == 2)
                {
                    ClearAddressControls();
                    BindAddressDetails();
                }
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
                    if (dataset.Tables[0].Rows[i]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[i]["MEMBERTYPE"].ToString() == "5")
                    {
                        count = count + 1;
                        lblTitle.Text = "Warning!";
                        lblTitle.ForeColor = System.Drawing.Color.Red;
                        message.ForeColor = System.Drawing.Color.Red;
                        message.Text = "The member already exists as Share Holder!";
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
                        btnSubmit.Enabled = true;
                        ddlTitle.SelectedValue = dataset.Tables[0].Rows[0]["TITLE"].ToString();
                        txtFirstName.Text = dataset.Tables[0].Rows[0]["FIRSTNAME"].ToString();
                        txtLastName.Text = dataset.Tables[0].Rows[0]["LASTNAME"].ToString();
                        txtEmail.Text = dataset.Tables[0].Rows[0]["EMAILID"].ToString();
                        txtMobile.Text = dataset.Tables[0].Rows[0]["MOBILE"].ToString();
                        txtPhone.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                        txtTaxRefNo.Text = dataset.Tables[0].Rows[0]["TAXREFNO"].ToString();
                        if (dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString() == "")
                        {
                            txtDateOfBirth.Text = "";
                        }
                        else
                        {
                            txtDateOfBirth.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString()).ToString("yyyy-MM-dd");
                        }

                        //DateTime DOB = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString());
                        //txtDateOfBirth.Text = DOB.ToShortDateString();
                    }
                    else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
                    {
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtEmail.Text = "";
                        txtMobile.Text = "";
                        txtPhone.Text = "";
                        txtTaxRefNo.Text = "";
                        ddlTitle.SelectedValue = "";
                        txtDateOfBirth.Text = "";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void imgSearchUID_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataSet dataset = validateSAIDBL.ValidateBeneficiaryUIC(Session["SAID"].ToString(), txtUIC.Text, txtCompanyUIC.Text);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "ALREADY EXIST")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, The Share Holder as Company is already registered with you!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXIST WITH OTHER CLIENT")
                {
                    Disable1();
                    btnSubmit.Enabled = true;
                    txtCompanyName.Text = dataset.Tables[0].Rows[0]["CompanyName"].ToString();
                    if (dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString() == "")
                    {
                        txtYearofFoundation.Text = "";
                    }
                    else
                    {
                        txtYearofFoundation.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString()).ToString("yyyy-MM-dd");
                    }
                    txtCompanyEmail.Text = dataset.Tables[0].Rows[0]["CompanyEmailID"].ToString();
                    txtVATRef.Text = dataset.Tables[0].Rows[0]["VATNo"].ToString();
                    txtTelephoneNum.Text = dataset.Tables[0].Rows[0]["CompanyTelephone"].ToString();
                    //txtFax.Text = dataset.Tables[0].Rows[0]["FaxNo"].ToString();
                    txtWebsite.Text = dataset.Tables[0].Rows[0]["CompanyWebsite"].ToString();
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH COMPANY")
                {
                    Disable1();
                    btnSubmit.Enabled = true;
                    txtCompanyName.Text = dataset.Tables[0].Rows[0]["CompanyName"].ToString();
                    if (dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString() == "")
                    {
                        txtYearofFoundation.Text = "";
                    }
                    else
                    {
                        txtYearofFoundation.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString()).ToString("yyyy-MM-dd");
                    }
                    //txtYearofFoundation.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString()).ToString("yyyy-MM-dd");
                    txtCompanyEmail.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
                    txtVATRef.Text = dataset.Tables[0].Rows[0]["VATNo"].ToString();
                    txtTelephoneNum.Text = dataset.Tables[0].Rows[0]["Telephone"].ToString();
                    //txtFax.Text = dataset.Tables[0].Rows[0]["FaxNo"].ToString();
                    txtWebsite.Text = dataset.Tables[0].Rows[0]["Website"].ToString();
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
                {
                    Enable1();
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
    protected void Disable1()
    {
        txtCompanyName.ReadOnly = true;
        //txtYearofFoundation.ReadOnly = true;
        txtVATRef.ReadOnly = true;
        txtTelephoneNum.ReadOnly = true;
        txtCompanyEmail.ReadOnly = true;
        txtWebsite.ReadOnly = true;
        rfvTCompanyName.Enabled = false;
        rgvWebsite.Enabled = false;
        btnSubmit.Enabled = false;
    }

    protected void Enable1()
    {
        txtCompanyName.ReadOnly = false;
        //txtYearofFoundation.ReadOnly = false;
        txtYearofFoundation.Attributes.Remove("disabled");
        txtVATRef.ReadOnly = false;
        txtTelephoneNum.ReadOnly = false;
        txtCompanyEmail.ReadOnly = false;
        txtWebsite.ReadOnly = false;
        rfvTCompanyName.Enabled = true;
        rgvWebsite.Enabled = true;
        btnSubmit.Enabled = true;
    }

    private void GetBenificiaryType()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objBeneficiaryBL.GetBeneficiaryType();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dropBenificiaryType.DataSource = ds;
                dropBenificiaryType.DataTextField = "BeneficiaryType";
                dropBenificiaryType.DataValueField = "BeneficiaryTypeID";
                dropBenificiaryType.DataBind();
                dropBenificiaryType.Items.Insert(0, new ListItem("--Select Type --", "0"));
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
    protected void dropBenificiaryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (dropBenificiaryType.SelectedValue == "1")
            {
                divIndividual.Visible = true;
                divCompany.Visible = false;
                Disable();
            }
            else
            {
                divCompany.Visible = true;
                divIndividual.Visible = false;
                Disable1();
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
    protected void gvBeneficiary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Flag"].ToString().Equals("0") && drv["AdvisorID"].ToString() != "0")
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    ((Image)e.Row.FindControl("btnEdit")).Visible = false;
                    ((Image)e.Row.FindControl("btnDelete")).Visible = false;
                    ((Image)e.Row.FindControl("btnDocument")).Visible = false;
                    ((Image)e.Row.FindControl("btnBank")).Visible = false;
                    ((Image)e.Row.FindControl("btnAddress")).Visible = false;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                    ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                    ((Image)e.Row.FindControl("btnDocument")).Visible = true;
                    ((Image)e.Row.FindControl("btnBank")).Visible = true;
                    ((Image)e.Row.FindControl("btnAddress")).Visible = true;
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
}