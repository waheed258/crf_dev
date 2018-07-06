using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using EntityManager;


public partial class ClientProfile_TrustDetails : System.Web.UI.Page
{

    CommanClass _objComman = new CommanClass();
    TrustBL _objTrustBL = new TrustBL();
    DataSet ds = new DataSet();
    BankBL bankBL = new BankBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressBL addressBL = new AddressBL();
    AddressEntity addressEntity = new AddressEntity();
    ValidateSAIDBL validateSAID = new ValidateSAIDBL();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();
    AccountantEntity accountEntity = new AccountantEntity();
    AccountantBL accountBL = new AccountantBL();
    PrivateBankEntity privateEntity = new PrivateBankEntity();
    PrivateBankBL privateBL = new PrivateBankBL();
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
                        _objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(dropAddress);
                        _objComman.getRecordsPerPage(dropBank);
                        _objComman.getRecordsPerPage(dropAccountant);
                        _objComman.getRecordsPerPage(dropPrivateBank);
                        GetTrustGrid();
                        BindBankDetails();
                        BindAddressDetails();
                        BindAccountant();
                        BindPrivateBanker();
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
                    else if (Request.Form[TabName.UniqueID].Contains("gvAccountDetails"))
                    {
                        TabName.Value = "tabAccountant";
                    }
                    else if (Request.Form[TabName.UniqueID].Contains("gvPrivateBank"))
                    {
                        TabName.Value = "tabPrivateBank";
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

    /// <summary>
    /// Trust Info Methods
    /// Trust Info Events
    /// </summary>
    /// <returns></returns>
    #region TrustDetails

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTrustGrid();
    }
    protected void btnSubmitTrust_Click(object sender, EventArgs e)
    {
        try
        {
            int res = ManageTrust();
            if (res > 0)
            {

                if (btnSubmitTrust.Text == "Update")

                    message.Text = "Trust details updated successfully !";
                else
                    message.Text = "Trust details saved successfully !";

                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                GetTrustGrid();
                ClearTrustControls();
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
                message.Text = "Trust Information not Saved please check the Details !!";
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

    protected void btnCancleTrust_Click(object sender, EventArgs e)
    {
        ClearTrustControls();
        Response.Redirect("TrustDetails.aspx", false);
    }

    private int ManageTrust()
    {
        TrustEntity _objTrust = new TrustEntity
        {
            UIC = txtUIC.Text.Trim(),
            TrustName = txtTrustName.Text.Trim(),
            YearOfFoundation = string.IsNullOrEmpty(txtYearofFoundation.Text) ? null : txtYearofFoundation.Text,          
            VATNo = txtVATRef.Text.Trim(),
            Telephone = txtTelephone.Text.Trim(),
            EmailID = txtEmail.Text.Trim(),
            //FaxNo = txtFax.Text.Trim(),
            Website = txtWebsite.Text.Trim(),
            ReferenceSAID = Session["SAID"].ToString(),
            Status = 1,
            AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),

        };
        int res;
        if (btnSubmitTrust.Text == "Update")
            res = _objTrustBL.TrustManager(_objTrust, 'U');
        else
            res = _objTrustBL.TrustManager(_objTrust, 'I');

        return res;
    }



    private void ClearTrustControls()
    {
        btnSubmitTrust.Text = "Save";
        txtUIC.Text = "";
        txtTrustName.Text = "";
        txtYearofFoundation.Text = "";
        txtVATRef.Text = "";
        txtTelephone.Text = "";
        txtEmail.Text = "";
        //txtFax.Text = "";
        txtWebsite.Text = "";
    }

    private void BindTrust(string UIC)
    {
        try
        {
            ds = _objTrustBL.GetTrust(Session["SAID"].ToString(), UIC);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtUIC.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
                txtTrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();
                txtYearofFoundation.Text = ds.Tables[0].Rows[0]["YearOfFoundation"].ToString();
                txtTelephone.Text = ds.Tables[0].Rows[0]["Telephone"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                //txtFax.Text = ds.Tables[0].Rows[0]["FaxNo"].ToString();
                txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                txtVATRef.Text = ds.Tables[0].Rows[0]["VATNo"].ToString();
                btnSubmitTrust.Text = "Update";
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

    private void GetTrustGrid()
    {
        try
        {
            ds = _objTrustBL.GetTrust(Session["SAID"].ToString(), "0");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvTrust.DataSource = ds.Tables[0];
                divTrustlist.Visible = true;
            }
            else
            {
                gvTrust.DataSource = null;
                divTrustlist.Visible = false;
            }
            gvTrust.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvTrust.DataBind();
        }
        catch {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvTrust_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["UIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();

                txtTrustUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtTrustNameBank.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();

                txtUICAddress.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtTrustNameAddress.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();

                txtaccTrustRegNum.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtaccTrustName.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();

                txtBankerTrustRegNo.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtBankerTrustname.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();

                string UIC = e.CommandArgument.ToString();
                EncryptDecrypt ObjEn = new EncryptDecrypt();
                Session["TrustUIC"] = UIC;
                switch (e.CommandName)
                {
                    case "Document":
                        Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("4"), false);
                        break;
                    case "EditTrust":
                        Enable();
                        BindTrust(UIC);
                        break;
                    case "EditTrustee":
                        Response.Redirect("Trustee.aspx", false);
                        break;
                    case "EditSettler":
                        Response.Redirect("TrustSettlor.aspx", false);
                        break;
                    case "EditBeneficiary":
                        Response.Redirect("Beneficiary.aspx?t=" + ObjEn.Encrypt("1"), false);
                        break;
                    case "Address":
                         DataSet dsAddress = addressbankBL.GetAddressDetails("0", Session["SAID"].ToString(), ViewState["UIC"].ToString());
                        if (dsAddress.Tables[0].Rows.Count > 0)
                        {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "4")
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
                        DataSet dsBank = addressbankBL.GetBankDetails("0", Session["SAID"].ToString(), ViewState["UIC"].ToString());
                        if (dsBank.Tables[0].Rows.Count > 0)
                        {
                            if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "4")
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
                    case "DeleteTrust":
                        ViewState["flag"] = 1;
                        lbldeletemessage.Text = "Are you sure, you want to delete Trust Details?";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                        break;
                    case "Accountant":
                        accountmessage.InnerText = "Save Accountant Details";
                        btnAccountSubmit.Visible = true;
                        btnAccountUpdate.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccountantModal();", true);
                        break;
                    case "PrivateBanker":
                        bankermessage.InnerText = "Save Banker Details";
                        btnBankerSubmit.Visible = true;
                        btnBankerUpdate.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPrivateBankerModal();", true);
                        break;
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

    protected void gvTrust_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvTrust.PageIndex = e.NewPageIndex;
            GetTrustGrid();
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
    /// Address Grid
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
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 4);
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
        ddlCity.SelectedValue = "-1";
        ddlCountry.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
    }

    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.Type = 4;
            addressEntity.UIC = ViewState["UIC"].ToString();
            addressEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
            addressEntity.BuildingName = txtBulding.Text;
            addressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            addressEntity.FlatNo = txtFlatNo.Text;
            addressEntity.HouseNo = txtHouseNo.Text;
            addressEntity.Floor = txtFloor.Text;
            addressEntity.PostalCode = txtPostalCode.Text;
            addressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            addressEntity.ReferenceSAID = Session["SAID"].ToString();
            addressEntity.SAID = "0";
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
                ClearAddressControls();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
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
            addressEntity.Type = 4;
            addressEntity.SAID = "0";
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.UIC = ViewState["AddressUIC"].ToString();
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
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["AddressDetailID"] = ((Label)row.FindControl("lblAddressDetailID")).Text.ToString();
                ViewState["AddressUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "EditAddress")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);

                    txtUICAddress.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtTrustNameAddress.Text = ((Label)row.FindControl("lblFullName")).Text.ToString();

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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
    /// Bank Grid
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
            bankEntity.Type = 4;
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            bankEntity.SAID = "0";
            bankEntity.ReferenceID = Session["SAID"].ToString();
            bankEntity.UIC = ViewState["UIC"].ToString();
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
            bankEntity.Type = 4;
            bankEntity.SAID = "0";
            bankEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            bankEntity.UIC = ViewState["BankUIC"].ToString();
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
            ds = bankBL.GetBankList(Session["SAID"].ToString(), 4);
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
                ViewState["BankUIC"] = ((Label)row.FindControl("lblBankUIC")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "EditBank")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                    txtTrustUIC.Text = ((Label)row.FindControl("lblBankUIC")).Text.ToString();
                    txtTrustNameBank.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();
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
                int res = _objTrustBL.DeleteTrust(ViewState["UIC"].ToString());
                if (res > 0)
                {
                    GetTrustGrid();
                    BindBankDetails();
                    BindAddressDetails();
                    ClearAddressControls();
                    ClearBankControls();
                    ClearTrustControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
                if (result == 1)
                {
                    BindBankDetails();
                    ClearBankControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
                if (result == 1)
                {
                    BindAddressDetails();
                    ClearAddressControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 4)
            {
                int result = accountBL.DeleteAccountant(Convert.ToInt32(ViewState["AccountantID"].ToString()));
                if (result == 1)
                {
                    BindAccountant();
                    ClearAcountant();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 5)
            {
                int result = privateBL.DeletePrivateBank(Convert.ToInt32(ViewState["PrivateBankID"].ToString()));
                if (result == 1)
                {
                    ClearPrivateBanker();
                    BindPrivateBanker();
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
            DataSet dataset = validateSAID.ValidateTrustUIC(Session["SAID"].ToString(), txtUIC.Text);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "ALREADY EXIST")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry,The Trust is already registered with you!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXIST WITH OTHER CLIENT")
                {
                    Disable();
                    btnSubmitTrust.Enabled = true;
                    txtTrustName.Text = dataset.Tables[0].Rows[0]["TrustName"].ToString();
                    if (dataset.Tables[0].Rows[0]["YearOfFoundation"].ToString() == "")
                        txtYearofFoundation.Text = "";
                    else
                        txtYearofFoundation.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfFoundation"].ToString()).ToString("yyyy-MM-dd");                   
                    //DateTime YOF = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfFoundation"].ToString());
                    //txtYearofFoundation.Text = YOF.ToShortDateString();
                    txtEmail.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
                    txtVATRef.Text = dataset.Tables[0].Rows[0]["VATNo"].ToString();
                    txtTelephone.Text = dataset.Tables[0].Rows[0]["Telephone"].ToString();
                    //txtFax.Text = dataset.Tables[0].Rows[0]["FaxNo"].ToString();
                    txtWebsite.Text = dataset.Tables[0].Rows[0]["Website"].ToString();
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
                {
                    Enable();
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
    protected void Disable()
    {
        txtTrustName.ReadOnly = true;
        txtYearofFoundation.ReadOnly = true;
        txtVATRef.ReadOnly = true;
        txtTelephone.ReadOnly = true;
        //txtFax.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtWebsite.ReadOnly = true;
        rfvTrustName.Enabled = false;
        //rfvYearOfFoundation.Enabled = false;
        //rfvtxtVATRef.Enabled = false;
        //rfvTelephone.Enabled = false;
        //revtxtFax.Enabled = false;
        //rfvEmail.Enabled = false;
        rgvWebsite.Enabled = false;
        btnSubmitTrust.Enabled = false;
    }

    protected void Enable()
    {
        txtTrustName.ReadOnly = false;
        txtYearofFoundation.ReadOnly = false;
        txtVATRef.ReadOnly = false;
        txtTelephone.ReadOnly = false;
        //txtFax.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtWebsite.ReadOnly = false;
        rfvTrustName.Enabled = true;
        //rfvYearOfFoundation.Enabled = true;
        //rfvtxtVATRef.Enabled = true;
        //rfvTelephone.Enabled = true;
        //revtxtFax.Enabled = true;
        //rfvEmail.Enabled = true;
        rgvWebsite.Enabled = true;
        btnSubmitTrust.Enabled = true;
    }
    protected void btnAccountSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            accountEntity.AccountantName = txtAccountantName.Text;
            accountEntity.AccountantTelNum = txtAccTelNum.Text;
            accountEntity.AccountantEmail = txtAccEmailId.Text;
            accountEntity.Type = 1;
            accountEntity.UICNo = ViewState["UIC"].ToString();
            accountEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            accountEntity.ReferenceSAID = Session["SAID"].ToString();

            int result = accountBL.InsertUpdateAccountant(accountEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Accountant details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAcountant();
                BindAccountant();
            }
            else
            {
                ClearAcountant();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindAccountant();
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
    protected void btnAccountUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            accountEntity.AccountantID = Convert.ToInt32(ViewState["AccountantID"].ToString());
            accountEntity.AccountantName = txtAccountantName.Text;
            accountEntity.AccountantTelNum = txtAccTelNum.Text;
            accountEntity.AccountantEmail = txtAccEmailId.Text;
            accountEntity.Type = 1;
            accountEntity.UICNo = ViewState["AccountantUIC"].ToString();
            accountEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            accountEntity.ReferenceSAID = Session["SAID"].ToString();

            int result = accountBL.InsertUpdateAccountant(accountEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Accountant details Updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAcountant();
                BindAccountant();
            }
            else
            {
                ClearAcountant();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindAccountant();
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
    private void ClearAcountant()
    {

        txtAccountantName.Text = "";
        txtAccTelNum.Text = "";
        txtAccEmailId.Text = "";
    }
    protected void btnAccountantCancel_Click(object sender, EventArgs e)
    {
        ClearAcountant();
    }

    private void BindAccountant()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = accountBL.GetTrustAccountant(Session["SAID"].ToString(),1);
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAccountDetails.DataSource = ds.Tables[0];
                searchaccountant.Visible = true;
            }
            else
            {
                gvAccountDetails.DataSource = null;
                searchaccountant.Visible = false;
            }
            gvAccountDetails.PageSize = Convert.ToInt32(dropAccountant.SelectedValue);
            gvAccountDetails.DataBind();
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
    protected void gvAccountDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["AccountantID"] = ((Label)row.FindControl("lblAccountantID")).Text.ToString();
                ViewState["AccountantUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                ViewState["AccType"] = ((Label)row.FindControl("lblAccountantType")).Text.ToString();
                ViewState["UICNo"] = ((Label)row.FindControl("lblAccountUICNo")).Text.ToString();

                if (e.CommandName == "EditAccount")
                {
                    accountmessage.InnerText = "Update Accountant Details";
                    btnAccountSubmit.Visible = false;
                    btnAccountUpdate.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccountantModal();", true);
                    txtaccTrustRegNum.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtaccTrustName.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();
                    txtAccountantName.Text = ((Label)row.FindControl("lblAccountantName")).Text.ToString();
                    txtAccTelNum.Text = ((Label)row.FindControl("lblAccountantTelNum")).Text.ToString();
                    txtAccEmailId.Text = ((Label)row.FindControl("lblAccountantEmail")).Text.ToString();
                }
                else if (e.CommandName == "DeleteAccount")
                {
                    ViewState["flag"] = 4;
                    lbldeletemessage.Text = "Are you sure, you want to delete Accountant Details?";
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
    protected void gvAccountDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAccountDetails.PageIndex = e.NewPageIndex;
            BindAccountant();
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
    protected void dropAccountant_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAccountant();
    }
    private void BindPrivateBanker()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = privateBL.GetPrivateBank(Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvPrivateBank.DataSource = ds.Tables[0];
                searchprivatebank.Visible = true;
            }
            else
            {
                gvPrivateBank.DataSource = null;
                searchprivatebank.Visible = false;
            }
            gvPrivateBank.PageSize = Convert.ToInt32(dropAccountant.SelectedValue);
            gvPrivateBank.DataBind();
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
    protected void dropPrivateBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPrivateBanker();
    }
    protected void gvPrivateBank_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["PrivateBankID"] = ((Label)row.FindControl("lblPrivateBankID")).Text.ToString();
                ViewState["UIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                ViewState["BankerUICNo"] = ((Label)row.FindControl("lblBankerUICNo")).Text.ToString();

                if (e.CommandName == "EditBanker")
                {
                    bankermessage.InnerText = "Update Banker Details";
                    btnBankerSubmit.Visible = false;
                    btnBankerUpdate.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openPrivateBankerModal();", true);
                    txtBankerTrustRegNo.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtBankerTrustname.Text = ((Label)row.FindControl("lblTrustName")).Text.ToString();
                    txtPrivBankName.Text = ((Label)row.FindControl("lblPrivateBankName")).Text.ToString();
                    txtPrivBankTelNum.Text = ((Label)row.FindControl("lblPrivateContactNum")).Text.ToString();
                }
                else if (e.CommandName == "DeleteBanker")
                {
                    ViewState["flag"] = 5;
                    lbldeletemessage.Text = "Are you sure, you want to delete Private Banker Details?";
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
    protected void gvPrivateBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvPrivateBank.PageIndex = e.NewPageIndex;
            BindPrivateBanker();
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
    protected void btnBankerSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            privateEntity.PrivateBankName = txtPrivBankName.Text;
            privateEntity.PrivateContactNum = txtPrivBankTelNum.Text;
            privateEntity.UICNo = ViewState["UIC"].ToString();
            privateEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            privateEntity.ReferenceSAID = Session["SAID"].ToString();

            int result = privateBL.InsUpdatePrivatebank(privateEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Private Banker details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearPrivateBanker();
                BindPrivateBanker();
            }
            else
            {
                ClearPrivateBanker();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindPrivateBanker();
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
    protected void btnBankerUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            privateEntity.PrivateBankID = Convert.ToInt32(ViewState["PrivateBankID"].ToString());
            privateEntity.PrivateBankName = txtPrivBankName.Text;
            privateEntity.PrivateContactNum = txtPrivBankTelNum.Text;
            privateEntity.UICNo = ViewState["BankerUICNo"].ToString();
            privateEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            privateEntity.ReferenceSAID = Session["SAID"].ToString();
            int result = privateBL.InsUpdatePrivatebank(privateEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Private Banker details Updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearPrivateBanker();
                BindPrivateBanker();
            }
            else
            {
                ClearPrivateBanker();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindPrivateBanker();
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
    private void ClearPrivateBanker()
    {
        txtPrivBankName.Text = "";
        txtPrivBankTelNum.Text = "";
    }
    protected void btnBankerCancel_Click(object sender, EventArgs e)
    {
        ClearPrivateBanker();
    }
    protected void gvTrust_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Flag"].ToString().Equals("0"))
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    ((Image)e.Row.FindControl("btnEdit")).Visible = false;
                    ((Image)e.Row.FindControl("btnDelete")).Visible = false;
                    ((Image)e.Row.FindControl("btnDocument")).Visible = false;
                    ((Image)e.Row.FindControl("btnBank")).Visible = false;
                    ((Image)e.Row.FindControl("btnAddress")).Visible = false;
                    ((Image)e.Row.FindControl("btnAccountant")).Visible = false;
                    ((Image)e.Row.FindControl("btnPrivateBanker")).Visible = false;
                    ((Image)e.Row.FindControl("btnTrustee")).Visible = false;
                    ((Image)e.Row.FindControl("btnSettlor")).Visible = false;
                    ((Image)e.Row.FindControl("btnBeneficiary")).Visible = false;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                    ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                    ((Image)e.Row.FindControl("btnDocument")).Visible = true;
                    ((Image)e.Row.FindControl("btnBank")).Visible = true;
                    ((Image)e.Row.FindControl("btnAddress")).Visible = true;
                    ((Image)e.Row.FindControl("btnAccountant")).Visible = true;
                    ((Image)e.Row.FindControl("btnPrivateBanker")).Visible = true;
                    ((Image)e.Row.FindControl("btnTrustee")).Visible = true;
                    ((Image)e.Row.FindControl("btnSettlor")).Visible = true;
                    ((Image)e.Row.FindControl("btnBeneficiary")).Visible = true;
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


