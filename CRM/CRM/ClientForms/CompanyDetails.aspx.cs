﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using BusinessLogic;
using EntityManager;
using System.Data;

public partial class ClientForms_CompanyDetails : System.Web.UI.Page
{
    CompanyBL companyBL = new CompanyBL();
    CompanyInfoEntity companyInfoEntity = new CompanyInfoEntity();
    DataSet dataset = new DataSet();
    CommanClass commonClass = new CommanClass();
    BankInfoEntity bankInfoEntity = new EntityManager.BankInfoEntity();
    BankBL bankBL = new BankBL();
    AddressEntity addressEntity = new AddressEntity();
    AddressBL addressBL = new AddressBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (Session["SAID"] != null)
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
                        GetGridData();
                        GetBankDetails();
                        GetAddressDetails();
                        btnUpdateCompany.Visible = false;
                        btnUpdateBank.Visible = false;
                        btnUpdateAddress.Visible = false;
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
                        else
                        {
                            TabName.Value = Request.Form[TabName.UniqueID];
                        }
                    }
                }
                else
                {
                    Response.Redirect("../ClientLogin.aspx");
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

    protected void GetGridData()
    {
        try
        {
            dataset = companyBL.GetCompanyList(Session["SAID"].ToString(), "");
            if (dataset.Tables[0].Rows.Count > 0)
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void GetBankDetails()
    {
        try
        {
            dataset = bankBL.GetBankList(Session["SAID"].ToString(), 8);
            if (dataset.Tables[0].Rows.Count > 0)
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void GetAddressDetails()
    {
        try
        {
            dataset = addressBL.GetAddressDetails(Session["SAID"].ToString(), 8);
            if (dataset.Tables[0].Rows.Count > 0)
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void InsertDocument()
    {
        DocumentBL _objDocBL = new DocumentBL();

        if (fuDocument.HasFile)
        {
            List<HttpPostedFile> lst = fuDocument.PostedFiles.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                string inFilename = fuDocument.PostedFiles[i].FileName;
                string strfile = Path.GetExtension(inFilename);
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var folder = Server.MapPath("~/ClientDocuments/" + Session["SAID"].ToString() + "/" + "Company" + "/" + txtCompanyUIC.Text);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string fileName = date + strfile;
                fuDocument.SaveAs(Path.Combine(folder, fileName));
                DocumentBO DocumentEntity = new DocumentBO
                {
                    DocId = 0,
                    ReferenceSAID = Session["SAID"].ToString(),
                    SAID = "0",
                    UIC = txtCompanyUIC.Text.Trim(),
                    Document = fileName,
                    DocumentName = inFilename,
                    DocType = 1,
                    AdvisorID = 0,
                    Status = 1,
                };

                int res = _objDocBL.DocumentManager(DocumentEntity, 'i');
            }
        }

    }
    protected void btnCompantDetails_Click(object sender, EventArgs e)
    {
        try
        {
            companyInfoEntity.ReferenceSAID = Session["SAID"].ToString();
            companyInfoEntity.UIC = txtCompanyUIC.Text;
            companyInfoEntity.CompanyName = txtCompanyName.Text;
            companyInfoEntity.YearOfEstablishment = txtYearofFoundation.Text;
            companyInfoEntity.Telephone = txtTelephone.Text;
            companyInfoEntity.FaxNo = txtFax.Text;
            companyInfoEntity.EmailID = txtEmail.Text;
            companyInfoEntity.Website = txtWebsite.Text;
            companyInfoEntity.AdvisorID = 0;
            int result = companyBL.CUDCompany(companyInfoEntity, 'C');
            if (result == 1)
            {
                InsertDocument();
                message.Text = "Company details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                GetGridData();
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Company Information not Saved please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    public void Clear()
    {
        txtCompanyUIC.Text = "";
        txtCompanyName.Text = "";
        txtYearofFoundation.Text = "";
        txtTelephone.Text = "";
        txtFax.Text = "";
        txtEmail.Text = "";
        txtWebsite.Text = "";

    }
    protected void btnCpmpanyDetailsCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
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

                if (e.CommandName == "EditCompany")
                {
                    btnCompantDetails.Visible = false;
                    btnUpdateCompany.Visible = true;
                    txtCompanyUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtCompanyUIC.ReadOnly = true;
                    txtCompanyName.Text = ((Label)row.FindControl("lblCompanyName")).Text.ToString();
                    txtYearofFoundation.Text = Convert.ToDateTime(((Label)row.FindControl("lblYearOfEstablishment")).Text.ToString()).Date.ToString("yyyy-MM-dd");
                    txtTelephone.Text = ((Label)row.FindControl("lblTelephone")).Text.ToString();
                    txtFax.Text = ((Label)row.FindControl("lblFaxNo")).Text.ToString();
                    txtEmail.Text = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                    txtWebsite.Text = ((Label)row.FindControl("lblWebsite")).Text.ToString();
                }
                else if (e.CommandName == "Bank")
                {
                    bankmessage.InnerText = "Save Bank Details";
                    btnBankSubmit.Visible = true;
                    btnUpdateBank.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                }
                else if (e.CommandName == "Address")
                {
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
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            companyInfoEntity.FaxNo = txtFax.Text;
            companyInfoEntity.EmailID = txtEmail.Text;
            companyInfoEntity.Website = txtWebsite.Text;
            companyInfoEntity.AdvisorID = 0;
            int result = companyBL.CUDCompany(companyInfoEntity, 'U');
            if (result == 1)
            {
                message.Text = "Company details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                btnUpdateCompany.Visible = false;
                btnCompantDetails.Visible = true;
                txtCompanyUIC.ReadOnly = false;
                GetGridData();
                GetBankDetails();
                GetAddressDetails();
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Company details not updated please check the Details !!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            bankInfoEntity.AdvisorID = 0;
            bankInfoEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankInfoEntity, 'i');
            if (result == 1)
            {
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearBank();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            addressEntity.AdvisorId = 0;
            addressEntity.Status = 1;

            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";


            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                GetAddressDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearAddress();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            ClearAddress();
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
                    bankmessage.InnerText = "Update Bank Details";
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
        catch { }
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
            bankInfoEntity.AdvisorID = 0;
            bankInfoEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankInfoEntity, 'u');
            if (result == 1)
            {
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                GetBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearBank();
                GetBankDetails();
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
            addressEntity.AdvisorId = 0;
            addressEntity.Status = 1;

            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";


            int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
            if (result == 1)
            {
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                GetAddressDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearAddress();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
                if (result == 1)
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

        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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

    protected void txtCompanyUIC_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string ExistsUIC = txtCompanyUIC.Text;
            dataset = companyBL.GetCompanyList("", ExistsUIC);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                msgUIC.Text = "Already Exists";
                txtCompanyUIC.Text = "";
            }
            else
            {
                msgUIC.Text = "";
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void txtAccountNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {

            string accountNum = txtAccountNumber.Text;
            dataset = bankBL.CheckAccountNum(accountNum);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                msgAccountNum.Text = "Already Exists";
                txtAccountNumber.Text = "";
            }
            else
            {
                msgAccountNum.Text = "";
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}