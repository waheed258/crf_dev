﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
using System.Web.UI.HtmlControls;
public partial class ClientProfile_TrustSettlor : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    DataSet ds = new DataSet();
    TrustSettlerBL _ObjTrustSettlerBL = new TrustSettlerBL();
    BankBL bankBL = new BankBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressBL addressBL = new AddressBL();
    AddressEntity addressEntity = new AddressEntity();
    ValidateSAIDBL validateSAID = new ValidateSAIDBL();
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
                        //_objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(dropAddress);
                        _objComman.getRecordsPerPage(dropBank);
                        _objComman.getRecordsPerPage(dropDocument);

                        txtTrustUIC.Text = Session["TrustUIC"].ToString();
                        GetTrustSettlerGrid(txtTrustUIC.Text.Trim());
                        BindBankDetails();
                        BindAddressDetails();
                        BindDocumentList();
                        Disable();

                    }
                }
                if (this.IsPostBack)
                {
                    if (Request.Form[TabName.UniqueID].Contains("gvTrustSettler"))
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
                    else if (Request.Form[TabName.UniqueID].Contains("gvDocumentList"))
                    {
                        TabName.Value = "tabDocument";
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
        txtPhone.ReadOnly = true;
        txtTaxRefNo.ReadOnly = true;
        //txtDateOfBirth.ReadOnly = true;
        rfvtxtFirstName.Enabled = false;
        //rfvtxtLastName.Enabled = false;
        //rfvtxtMobile.Enabled = false;
        revtxtEmail.Enabled = false;
        btnSubmit.Enabled = false;
        //rfvTitle.Enabled = false;
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
        //rfvtxtMobile.Enabled = true;
        revtxtEmail.Enabled = true;
        btnSubmit.Enabled = true;
        //rfvTitle.Enabled = true;
        //rfvDateOfBirth.Enabled = true;
    }
    /// <summary>
    /// Trust Settler Methods, Events
    /// Settler Grid
    /// </summary>
    /// <param name="RefUIC"></param>
    #region TrustDSettler
    private void GetTrustSettlerGrid(string RefUIC)
    {
        try
        {
            ds = _ObjTrustSettlerBL.GetTrustSettler(0, RefUIC);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvTrustSettler.DataSource = ds.Tables[0];
                divTrusteeslist.Visible = true;
            }
            else
            {
                gvTrustSettler.DataSource = null;
                divTrusteeslist.Visible = false;
            }
            gvTrustSettler.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvTrustSettler.DataBind();
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

    private void BindTrustSettler(int TrId)
    {
        try
        {
            ds = _ObjTrustSettlerBL.GetTrustSettler(TrId, txtTrustUIC.Text.Trim());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hfTrustSettlerId.Value = ds.Tables[0].Rows[0]["TrustSettlerID"].ToString();
                txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                txtTrustUIC.Text = ds.Tables[0].Rows[0]["ReferenceUIC"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                txtDateOfBirth.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
                ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
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

    private int TrustSettlerManager()
    {
        int Result;
        TrustSettlerEntity _objSettler = new TrustSettlerEntity
        {
            TrustSettlerID = Convert.ToInt32(hfTrustSettlerId.Value.Trim()),
            SAID = txtSAID.Text.Trim(),
            ReferenceSAID = Session["SAID"].ToString(),
            ReferenceUIC = txtTrustUIC.Text.Trim(),
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            EmailID = txtEmail.Text.Trim(),
            Mobile = txtMobile.Text.Trim(),
            Phone = txtPhone.Text.Trim(),
            TaxRefNo = txtTaxRefNo.Text.Trim(),
            Status = 1,
            AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),
            Title = ddlTitle.SelectedValue,
            DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text
        };

        if (btnSubmit.Text == "Update")
        {
            Result = _ObjTrustSettlerBL.TrustSettlerInsertUpdate(_objSettler, 'u');
        }
        else
        {
            Result = _ObjTrustSettlerBL.TrustSettlerInsertUpdate(_objSettler, 'i');
        }
        return Result;
    }


    private void ClearTrustSettlerControls()
    {
        btnSubmit.Text = "Save";
        hfTrustSettlerId.Value = "0";
        txtSAID.Text = "";
        txtTaxRefNo.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtMobile.Text = "";
        txtPhone.Text = "";
        ddlTitle.SelectedValue = "";
        txtDateOfBirth.Text = "";
    }
    protected void gvTrustSettler_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvTrustSettler.PageIndex = e.NewPageIndex;
            GetTrustSettlerGrid(txtTrustUIC.Text.Trim());
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int res = TrustSettlerManager();
            if (res > 0)
            {

                if (btnSubmit.Text == "Update")
                    message.Text = "Settlor details updated successfully!";
                else
                    message.Text = "Settlor details saved successfully!";

                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

                ClearTrustSettlerControls();
                GetTrustSettlerGrid(txtTrustUIC.Text.Trim());
                ClearAddressControls();
                ClearBankControls();
                BindBankDetails();
                BindAddressDetails();
                Disable();

            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Trust Settlor Information not Saved please check the Details !!";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearTrustSettlerControls();
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
                txtDateOfBirth.Text = ds.Tables[0].Rows[0]["DateOfBirth"].ToString();
                ddlTitle.SelectedValue = ds.Tables[0].Rows[0]["Title"].ToString();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
                txtPhone.Text = "";
                txtTaxRefNo.Text = "";
                txtDateOfBirth.Text = "";
                ddlTitle.SelectedValue = "";
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


    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTrustSettlerGrid(txtTrustUIC.Text.Trim());
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("TrustDetails.aspx", false);
    }
    protected void gvTrustSettler_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {

                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["TrusteeSettlerId"] = ((Label)row.FindControl("lblTrustSettlerId")).Text.ToString();

                string UIC = ((Label)row.FindControl("lblReferenceUIC")).Text.ToString();
                string SettlorName = ((Label)row.FindControl("lblFirstName")).Text.ToString() + " " + ((Label)row.FindControl("lblLastName")).Text.ToString();
                txtSettlorNameBank.Text = SettlorName;
                txtSAIDBank.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();

                txtSAIDAddress.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                txtSettlorNameAddress.Text = SettlorName;

                EncryptDecrypt ObjEn = new EncryptDecrypt();

                if (e.CommandName == "EditTrustSettler")
                {
                    int TrustSettlerId = Convert.ToInt32(ViewState["TrusteeSettlerId"].ToString());
                    Enable();
                    BindTrustSettler(TrustSettlerId);
                }
                else if (e.CommandName == "Document")
                {
                    Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("5") + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                }
                else if (e.CommandName == "DeleteSettler")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Trust Settlor Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }
                else if (e.CommandName == "Address")
                {
                    DataSet dsAddress = addressbankBL.GetAddressDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                    if (dsAddress.Tables[0].Rows.Count > 0)
                    {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "5")
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
                    btnUpdateAddress.Visible = false;
                    btnAddressSubmit.Visible = true;
                    addressmessage.InnerText = "Save Address Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                }
                else if (e.CommandName == "Bank")
                {
                    DataSet dsBank = addressbankBL.GetBankDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), UIC);
                    if (dsBank.Tables[0].Rows.Count > 0)
                    {
                        if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "5")
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
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 5, txtTrustUIC.Text);
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
            addressEntity.Type = 5;
            addressEntity.UIC = txtTrustUIC.Text.Trim();
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
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
            addressEntity.CreatedBy = 0;
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
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Trust Settlor information not saved please check the details !";
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
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            addressEntity.Type = 5;
            addressEntity.SAID = ViewState["AddressSAID"].ToString();
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.UIC = txtTrustUIC.Text.Trim();
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
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
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
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["AddressDetailID"] = ((Label)row.FindControl("lblAddressDetailID")).Text.ToString();
            ViewState["AddressSAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
            ViewState["SettlorName"] = ((Label)row.FindControl("lblSettlorName")).Text.ToString();

            if (e.CommandName == "EditAddress")
            {
                addressmessage.InnerText = "Update Address Details";
                btnAddressSubmit.Visible = false;
                btnUpdateAddress.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);

                txtSAIDAddress.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                txtSettlorNameAddress.Text = ((Label)row.FindControl("lblSettlorName")).Text.ToString();

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
            bankEntity.Type = 5;
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            bankEntity.SAID = ViewState["SAID"].ToString();
            bankEntity.ReferenceID = Session["SAID"].ToString();
            bankEntity.UIC = txtTrustUIC.Text.Trim();
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
                message.Text = "Sorry,Please Try Again";
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
            bankEntity.Type = 5;
            bankEntity.SAID = ViewState["BankSAID"].ToString();
            bankEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            bankEntity.UIC = txtTrustUIC.Text.Trim();
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
                message.Text = "Sorry,Please Try Again";
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
            ds = bankBL.GetBankList(Session["SAID"].ToString(), 5, txtTrustUIC.Text);
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
                ViewState["BankSAID"] = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                ViewState["SettlorName"] = ((Label)row.FindControl("lblSettlorName")).Text.ToString();
                if (e.CommandName == "EditBank")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);

                    txtSAIDBank.Text = ((Label)row.FindControl("lblBankSAID")).Text.ToString();
                    txtSettlorNameBank.Text = ((Label)row.FindControl("lblSettlorName")).Text.ToString();

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


    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int res = _ObjTrustSettlerBL.DeleteTrustSettler(Convert.ToInt32(ViewState["TrusteeSettlerId"]), txtTrustUIC.Text.Trim(), ViewState["SAID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()));
                if (res > 0)
                {
                    GetTrustSettlerGrid(txtTrustUIC.Text.Trim());
                    BindBankDetails();
                    BindAddressDetails();
                    ClearTrustSettlerControls();
                    ClearBankControls();
                    ClearAddressControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["BankSAID"].ToString(), ViewState["SettlorName"].ToString());
                if (result == 2)
                {
                    ClearBankControls();
                    BindBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString(), Convert.ToInt32(Session["AdvisorID"].ToString()), ViewState["AddressSAID"].ToString(), ViewState["SettlorName"].ToString());
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

            DataSet dataset = validateSAID.ValidateSAID(txtSAID.Text, Session["SAID"].ToString(), txtTrustUIC.Text);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    if (dataset.Tables[0].Rows[i]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[i]["MEMBERTYPE"].ToString() == "4")
                    {
                        count = count + 1;
                        lblTitle.Text = "Warning!";
                        lblTitle.ForeColor = System.Drawing.Color.Red;
                        message.ForeColor = System.Drawing.Color.Red;
                        message.Text = "Sorry,The member already exists as settlor!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                }
                //if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() == "4")
                //{
                //    lblTitle.Text = "Warning!";
                //    lblTitle.ForeColor = System.Drawing.Color.Red;
                //    message.ForeColor = System.Drawing.Color.Red;
                //    message.Text = "Sorry,The member already exists as settlor!";
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //}
                if (count == 0)
                {
                    if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS SPOUSE OR CHILD" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH SAME ORG BUT WITH OTHER CLIENT" ||
                        dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH OTHER ORG AND THER CLIENT" || dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS INDIVIDUAL" || dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT")
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
                        //DateTime DOB = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString());
                        //txtDateOfBirth.Text = DOB.ToShortDateString();
                        if (dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString() == "")
                            txtDateOfBirth.Text = "";
                        else
                            txtDateOfBirth.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DATEOFBIRTH"].ToString()).ToString("yyyy-MM-dd");
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

    protected void gvTrustSettler_RowDataBound(object sender, GridViewRowEventArgs e)
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
    private void BindDocumentList()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = _objDocumentBL.GetDocumentList(Session["SAID"].ToString(), 5, txtTrustUIC.Text);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDocumentList.DataSource = ds.Tables[0];
                searchDocument.Visible = true;
            }
            else
            {
                gvDocumentList.DataSource = null;
                searchDocument.Visible = false;
            }
            gvDocumentList.PageSize = Convert.ToInt32(dropDocument.SelectedValue);
            gvDocumentList.DataBind();
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
    protected void dropDocument_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDocumentList();
    }
    protected void gvDocumentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDocumentList.PageIndex = e.NewPageIndex;
            BindDocumentList();
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
    protected void gvDocumentList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblDoc = (Label)e.Row.FindControl("lblDoc");
                Label lblsaid = (Label)e.Row.FindControl("lblSAID");
                HtmlAnchor AnchorDoc = (HtmlAnchor)e.Row.FindControl("anchorId");
                string url = HttpContext.Current.Request.Url.Authority;
                AnchorDoc.HRef = "http://" + url + "/ClientDocuments/" + Session["SAID"].ToString() + "/" + "Trustee" + "/" + lblsaid.Text + "/" + LblDoc.Text;
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