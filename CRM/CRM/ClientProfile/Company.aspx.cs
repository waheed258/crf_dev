using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
using System.Data;
public partial class ClientProfile_Company : System.Web.UI.Page
{
    CompanyBL companyBL = new CompanyBL();
    CompanyInfoEntity companyInfoEntity = new CompanyInfoEntity();
    DataSet dataset = new DataSet();
    CommanClass commonClass = new CommanClass();
    BankInfoEntity bankInfoEntity = new EntityManager.BankInfoEntity();
    BankBL bankBL = new BankBL();
    AddressEntity addressEntity = new AddressEntity();
    AddressBL addressBL = new AddressBL();
    ValidateSAIDBL validateSAID = new ValidateSAIDBL();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();
    AccountantEntity accountEntity = new AccountantEntity();
    AccountantBL accountBL = new AccountantBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (Session["AdvisorID"] != null)
                {
                    if (!IsPostBack)
                    {
                        commonClass.GetAccountType(ddlAccountType);
                        commonClass.GetCity(ddlCity);
                        commonClass.GetCountry(ddlCountry);
                        commonClass.GetProvince(ddlProvince);
                        commonClass.getRecordsPerPage(DropPage);
                        commonClass.getRecordsPerPage(dropBank);
                        commonClass.getRecordsPerPage(dropAddress);
                        commonClass.getRecordsPerPage(dropAccountant);
                        GetGridData();
                        //GetTrustNames();
                        GetBankDetails();
                        GetAddressDetails();
                        btnUpdateCompany.Visible = false;
                        btnUpdateBank.Visible = false;
                        btnUpdateAddress.Visible = false;
                        BindAccountant();
                        Disable();
                    }
                    if (this.IsPostBack)
                    {
                        if (Request.Form[TabName.UniqueID].Contains("gvCompany"))
                        {
                            TabName.Value = "tab1";
                        }
                        else if (Request.Form[TabName.UniqueID].Contains("gvBankDetails"))
                        {
                            TabName.Value = "tab2";
                        }
                        else if (Request.Form[TabName.UniqueID].Contains("gvAddressDetails"))
                        {
                            TabName.Value = "tab3";
                        }
                        else if (Request.Form[TabName.UniqueID].Contains("gvAccountDetails"))
                        {
                            TabName.Value = "tabAccountant";
                        }
                        else
                        {
                            TabName.Value = Request.Form[TabName.UniqueID];
                        }
                    }
                }
                else
                {
                    Response.Redirect("../AdminLogin.aspx");
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

    protected void GetGridData()
    {
        try
        {
            dataset = companyBL.GetCompanyList(Session["SAID"].ToString(), "0");
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvCompany.DataSource = dataset;
                companylist.Visible = true;
            }
            else
            {
                gvCompany.DataSource = null;
                companylist.Visible = false;
            }
            gvCompany.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvCompany.DataBind();

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
    protected void GetBankDetails()
    {
        try
        {
            dataset = bankBL.GetBankList(Session["SAID"].ToString(), 8,"");
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvBankDetails.DataSource = dataset;
                searchbank.Visible = true;
            }
            else
            {
                gvBankDetails.DataSource = null;
                searchbank.Visible = false;
            }
            gvBankDetails.PageSize = Convert.ToInt32(dropBank.SelectedValue);
            gvBankDetails.DataBind();

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

    protected void GetAddressDetails()
    {
        try
        {
            dataset = addressBL.GetAddressDetails(Session["SAID"].ToString(), 8);
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvAddressDetails.DataSource = dataset;
                searchaddress.Visible = true;
            }
            else
            {
                gvAddressDetails.DataSource = null;
                searchaddress.Visible = false;
            }
            gvAddressDetails.PageSize = Convert.ToInt32(dropAddress.SelectedValue);
            gvAddressDetails.DataBind();
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


    protected void btnCompantDetails_Click(object sender, EventArgs e)
    {
        try
        {
            companyInfoEntity.ReferenceSAID = Session["SAID"].ToString();
            companyInfoEntity.UIC = txtCompanyUIC.Text;
            companyInfoEntity.CompanyName = txtCompanyName.Text;
            companyInfoEntity.YearOfEstablishment = string.IsNullOrEmpty(txtYearofFoundation.Text) ? null : txtYearofFoundation.Text;
            companyInfoEntity.Telephone = txtTelephone.Text;
           // companyInfoEntity.FaxNo = txtFax.Text;
            companyInfoEntity.EmailID = txtEmail.Text;
            companyInfoEntity.Website = txtWebsite.Text;
            companyInfoEntity.VATNo = txtVATRef.Text.Trim();
            companyInfoEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            //if (ddlTrustNames.SelectedValue != "0")
            //{
            //    companyInfoEntity.TrustUIC = ddlTrustNames.SelectedValue;
            //}
            //else
            //{
            //    companyInfoEntity.TrustUIC = "0";
            //}
            int result = companyBL.CUDCompany(companyInfoEntity, 'C');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Company details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                Disable();
                GetGridData();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Company Information not Saved please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
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

    public void Clear()
    {
        txtCompanyUIC.Text = "";
        txtCompanyName.Text = "";
        txtVATRef.Text = "";
        txtYearofFoundation.Text = "";
        txtTelephone.Text = "";
        //txtFax.Text = "";
        txtEmail.Text = "";
        txtWebsite.Text = "";
        //ddlTrustNames.SelectedValue = "0";

    }

    //private void GetTrustNames()
    //{
    //    try
    //    {
    //        DataSet ds = companyBL.GetTrustNames();
    //        if (ds.Tables.Count > 0)
    //        {
    //            ddlTrustNames.DataSource = ds;
    //            ddlTrustNames.DataTextField = "TrustName";
    //            ddlTrustNames.DataValueField = "UIC";
    //            ddlTrustNames.DataBind();
    //            ddlTrustNames.Items.Insert(0, new ListItem("--Select Trust --", "0"));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblTitle.Text = "Warning!";
    //        lblTitle.ForeColor = System.Drawing.Color.Red;
    //        message.ForeColor = System.Drawing.Color.Red;
    //        message.Text = "Sorry,Something went wrong, please contact administrator";
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    //    }
    //}
    protected void btnCpmpanyDetailsCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Company.aspx");
    }

    protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                string UIC = e.CommandArgument.ToString();
                EncryptDecrypt ObjEn = new EncryptDecrypt();
                Session["CompanyUIC"] = UIC;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["CompanyID"] = ((Label)row.FindControl("lblCompanyID")).Text.ToString();
                ViewState["UIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["CompanyReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                txtCompanyUICBank.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtCompanyNameBank.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();

                txtAddrUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtAddrCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();

                txtaccCompanyRegNum.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                txtaccCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();

                if (e.CommandName == "EditCompany")
                {
                    Enable();
                    btnCompantDetails.Visible = false;
                    btnUpdateCompany.Visible = true;
                    txtCompanyUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtCompanyUIC.ReadOnly = true;
                    txtCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                    txtYearofFoundation.Text = ((Label)row.FindControl("lblYearOfEstablishment")).Text.ToString();
                    txtTelephone.Text = ((Label)row.FindControl("lblTelephone")).Text.ToString();
                    //txtFax.Text = ((Label)row.FindControl("lblFaxNo")).Text.ToString();
                    txtEmail.Text = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                    txtWebsite.Text = ((Label)row.FindControl("lblWebsite")).Text.ToString();
                    txtVATRef.Text = ((Label)row.FindControl("lblVATNo")).Text.ToString();
                    //ddlTrustNames.SelectedValue = ((Label)row.FindControl("lblTrusts")).Text.ToString();
                }
                else if (e.CommandName == "Document")
                {
                    Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("8"), false);
                }
                else if (e.CommandName == "Bank")
                {
                    DataSet dsBank = addressbankBL.GetBankDetails("0", Session["SAID"].ToString(), ViewState["UIC"].ToString());
                    if (dsBank.Tables[0].Rows.Count > 0)
                    {
                        if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "8")
                        {
                            ClearBank();
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
                else if (e.CommandName == "Address")
                {
                    DataSet dsAddress = addressbankBL.GetAddressDetails("0", Session["SAID"].ToString(), ViewState["UIC"].ToString());
                    if (dsAddress.Tables[0].Rows.Count > 0)
                    {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "8")
                        {
                            ClearAddress();
                        }
                        else
                        {
                            txtPlotNo.Text = dsAddress.Tables[0].Rows[0]["HouseNo"].ToString();
                            txtBulding.Text = dsAddress.Tables[0].Rows[0]["BuildingName"].ToString();
                            txtFloor.Text = dsAddress.Tables[0].Rows[0]["FloorNo"].ToString();
                            txtFlatrNo.Text = dsAddress.Tables[0].Rows[0]["FlatNo"].ToString();
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
                }
                else if (e.CommandName == "DeleteCompany")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Company Details?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }

                else if (e.CommandName == "EditBeneficiary")
                {
                    Response.Redirect("Beneficiary.aspx?t=" + ObjEn.Encrypt("2"), false);
                }
                else if (e.CommandName == "EditDirector")
                {
                    Response.Redirect("Director.aspx?t=" + ObjEn.Encrypt("3"), false);
                }
                else if (e.CommandName == "Accountant")
                {
                    accountmessage.InnerText = "Save Accountant Details";
                    btnAccountSubmit.Visible = true;
                    btnAccountUpdate.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccountantModal();", true);
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
    protected void btnUpdateCompany_Click(object sender, EventArgs e)
    {
        try
        {
            companyInfoEntity.ReferenceSAID = ViewState["CompanyReferenceSAID"].ToString();
            companyInfoEntity.CompanyID = Convert.ToInt32(ViewState["CompanyID"]);
            companyInfoEntity.UIC = txtCompanyUIC.Text;
            companyInfoEntity.CompanyName = txtCompanyName.Text;
            companyInfoEntity.YearOfEstablishment = txtYearofFoundation.Text;
            companyInfoEntity.Telephone = txtTelephone.Text;
            //companyInfoEntity.FaxNo = txtFax.Text;
            companyInfoEntity.EmailID = txtEmail.Text;
            companyInfoEntity.Website = txtWebsite.Text;
            companyInfoEntity.VATNo = txtVATRef.Text.Trim();
            companyInfoEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            //companyInfoEntity.TrustUIC = ddlTrustNames.SelectedValue;
            int result = companyBL.CUDCompany(companyInfoEntity, 'U');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Company details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                Disable();
                btnUpdateCompany.Visible = false;
                btnCompantDetails.Visible = true;
                txtCompanyUIC.ReadOnly = false;
                GetGridData();
                GetBankDetails();
                GetAddressDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Company details not updated please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
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

    protected void btnBankSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bankInfoEntity.Type = 8;
            bankInfoEntity.SAID = "0";
            bankInfoEntity.ReferenceID = Session["SAID"].ToString();
            bankInfoEntity.UIC = ViewState["UIC"].ToString();
            bankInfoEntity.BankName = txtBankName.Text;
            bankInfoEntity.BranchNumber = txtBranchNumber.Text;
            bankInfoEntity.AccountNumber = txtAccountNumber.Text;
            bankInfoEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankInfoEntity.Currency = txtCurrency.Text;
            bankInfoEntity.SWIFT = txtSwift.Text;
            bankInfoEntity.CreatedBy = 0;
            bankInfoEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            bankInfoEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankInfoEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                ClearBank();
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
    protected void ClearBank()
    {
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        txtCurrency.Text = "";
        txtSwift.Text = "";
        ddlAccountType.SelectedValue = "-1";
    }


    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = 0;
            addressEntity.Type = 8;
            addressEntity.SAID = "0";
            addressEntity.ReferenceSAID = Session["SAID"].ToString();
            addressEntity.UIC = ViewState["UIC"].ToString();
            addressEntity.HouseNo = txtPlotNo.Text;
            addressEntity.BuildingName = txtBulding.Text;
            addressEntity.Floor = txtFloor.Text;
            addressEntity.FlatNo = txtFlatrNo.Text;
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


            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                GetAddressDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please try again!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
            }
        }
        catch
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void ClearAddress()
    {
        txtPlotNo.Text = "";
        txtBulding.Text = "";
        txtFloor.Text = "";
        txtFlatrNo.Text = "";
        txtRoadName.Text = "";
        txtRoadNo.Text = "";
        txtSuburbName.Text = "";
        ddlCity.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
        ddlCountry.SelectedValue = "-1";
        txtPostalCode.Text = "";
    }
    protected void gvBankDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

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
                ViewState["BankUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "Edit")
                {
                    accountmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                    txtCompanyUICBank.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtCompanyNameBank.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                    txtBankName.Text = ((Label)row.FindControl("lblBankName")).Text.ToString();
                    txtBranchNumber.Text = ((Label)row.FindControl("lblBranchNumber")).Text.ToString();
                    txtAccountNumber.Text = ((Label)row.FindControl("lblAccountNumber")).Text.ToString();
                    txtCurrency.Text = ((Label)row.FindControl("lblCurrency")).Text.ToString();
                    txtSwift.Text = ((Label)row.FindControl("lblSWIFT")).Text.ToString();
                    ddlAccountType.SelectedValue = ((Label)row.FindControl("lblAccountType")).Text.ToString();
                }
                else if (e.CommandName == "Delete")
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
    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            bankInfoEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            bankInfoEntity.Type = 8;
            bankInfoEntity.SAID = "0";
            bankInfoEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            bankInfoEntity.UIC = ViewState["BankUIC"].ToString();
            bankInfoEntity.BankName = txtBankName.Text;
            bankInfoEntity.BranchNumber = txtBranchNumber.Text;
            bankInfoEntity.AccountNumber = txtAccountNumber.Text;
            bankInfoEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankInfoEntity.Currency = txtCurrency.Text;
            bankInfoEntity.SWIFT = txtSwift.Text;
            bankInfoEntity.CreatedBy = 0;
            bankInfoEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            bankInfoEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankInfoEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please try again!";
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
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            addressEntity.Type = 8;
            addressEntity.SAID = "0";
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.UIC = ViewState["AddressUIC"].ToString();
            addressEntity.HouseNo = txtPlotNo.Text;
            addressEntity.BuildingName = txtBulding.Text;
            addressEntity.Floor = txtFloor.Text;
            addressEntity.FlatNo = txtFlatrNo.Text;
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
                ClearAddress();
                GetAddressDetails();
            }
            else
            {                
                ClearAddress();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please try again!";
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
    protected void gvAddressDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

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
                ViewState["AddressUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "Edit")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                    txtAddrUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtAddrCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                    txtPlotNo.Text = ((Label)row.FindControl("lblHouseNo")).Text.ToString();
                    txtBulding.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                    txtFloor.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                    txtFlatrNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                    txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                    txtRoadNo.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                    txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                    ddlCity.SelectedValue = ((Label)row.FindControl("lblCity")).Text.ToString();
                    txtPostalCode.Text = ((Label)row.FindControl("lblPostalCode")).Text.ToString();
                    ddlProvince.SelectedValue = ((Label)row.FindControl("lblProvince")).Text.ToString();
                    ddlCountry.SelectedValue = ((Label)row.FindControl("lblCountry")).Text.ToString();
                }
                else if (e.CommandName == "Delete")
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
    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {

            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int result = companyBL.DeleteCompanyDetails(ViewState["UIC"].ToString());
                if (result > 0)
                {
                    GetGridData();
                    GetBankDetails();
                    GetAddressDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
                if (result == 1)
                {
                    GetBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
                if (result == 1)
                {
                    GetAddressDetails();
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

    protected void gvBankDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAddressDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }


    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void dropAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetAddressDetails();
    }
    protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetBankDetails();
    }

    
    protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvCompany.PageIndex = e.NewPageIndex;
            GetGridData();
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
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
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void imgSearchsaid_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            DataSet dataset = validateSAID.ValidateCompanyUIC(Session["SAID"].ToString(), txtCompanyUIC.Text);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "ALREADY EXIST")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry,The Company is already registered with you!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXIST WITH OTHER CLIENT")
                {
                    Disable();
                    btnCompantDetails.Enabled = true;
                    txtCompanyName.Text = dataset.Tables[0].Rows[0]["CompanyName"].ToString();
                    if (dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString() == "")
                        txtYearofFoundation.Text = "";
                    else
                        txtYearofFoundation.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString()).ToString("yyyy-MM-dd");                    
                    //DateTime YOF = Convert.ToDateTime(dataset.Tables[0].Rows[0]["YearOfEstablishment"].ToString());
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
        txtCompanyName.ReadOnly = true;
        txtYearofFoundation.ReadOnly = true;
        txtVATRef.ReadOnly = true;
        txtTelephone.ReadOnly = true;
        //txtFax.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtWebsite.ReadOnly = true;
        rfvTCompanyName.Enabled = false;
        //rfvYearOfFoundation.Enabled = false;
        //rfvtxtVATRef.Enabled = false;
        //rfvTelephone.Enabled = false;
        //rgvFax.Enabled = false;
        //rfvEmail.Enabled = false;
        rgvWebsite.Enabled = false;
        btnCompantDetails.Enabled = false;
    }

    protected void Enable()
    {
        txtCompanyName.ReadOnly = false;
        txtYearofFoundation.ReadOnly = false;
        txtVATRef.ReadOnly = false;
        txtTelephone.ReadOnly = false;
        //txtFax.ReadOnly = false;
        txtEmail.ReadOnly = false;
        txtWebsite.ReadOnly = false;
        rfvTCompanyName.Enabled = true;
        //rfvYearOfFoundation.Enabled = true;
        //rfvtxtVATRef.Enabled = true;
        //rfvTelephone.Enabled = true;
        //rgvFax.Enabled = true;
        //rfvEmail.Enabled = true;
        rgvWebsite.Enabled = true;
        btnCompantDetails.Enabled = true;
    }
    protected void dropAccountant_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAccountant();
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
                    bankmessage.InnerText = "Update Accountant Details";
                    btnAccountSubmit.Visible = false;
                    btnAccountUpdate.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAccountantModal();", true);
                    txtaccCompanyRegNum.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtaccCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
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
    protected void btnAccountSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            accountEntity.AccountantName = txtAccountantName.Text;
            accountEntity.AccountantTelNum = txtAccTelNum.Text;
            accountEntity.AccountantEmail = txtAccEmailId.Text;
            accountEntity.Type = 2;
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
            accountEntity.Type = 2;
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
            ds = accountBL.GetCompanyAccountant(Session["SAID"].ToString(),2);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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
    protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    ((Image)e.Row.FindControl("btnAccountant")).Visible = false;
                    ((Image)e.Row.FindControl("btnBeneficiary")).Visible = false;
                    ((Image)e.Row.FindControl("btnDirector")).Visible = false;
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
                    ((Image)e.Row.FindControl("btnBeneficiary")).Visible = true;
                    ((Image)e.Row.FindControl("btnDirector")).Visible = true;
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