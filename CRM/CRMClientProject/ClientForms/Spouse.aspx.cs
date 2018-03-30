using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using BusinessLogic;
using System.Data;

public partial class ClientForms_Spouse : System.Web.UI.Page
{
     CommanClass _objComman = new CommanClass();
    SpouseEntity spouseEntity = new SpouseEntity();
    SpouseBL spouseBL = new SpouseBL();
    AddressBL addressBL = new AddressBL();
    DataSet dataset = new DataSet();
    BankInfoEntity bankEntity = new BankInfoEntity();
    AddressEntity addressEntity = new AddressEntity();
    BankBL bankBL = new BankBL();
    BasicDropdownBL basicDropdownBL = new BasicDropdownBL();
    
    protected void Page_Load(object sender, EventArgs e)
    {    
        if (!IsPostBack)
        {

            try
            {
                if (Session["SAID"] == null || Session["SAID"].ToString() == "")
                {
                    Response.Redirect("../Login.aspx", false);
                }
                else
                {
                    _objComman.GetCountry(ddlCountry);
                    _objComman.GetProvince(ddlProvince);
                    _objComman.GetCity(ddlCity);
                    _objComman.GetAccountType(ddlAccountType);
                    ViewState["ps"] = 5;
                    BindSpouseDetails();
                    btnUpdateSpouse.Visible = false;
                    BindAddressDetails();
                    BindBankDetails();
                }
            }
            catch { }
            }

    }
    protected void btnSpouseSubmit_Click(object sender, EventArgs e)
    {
        try
        {          
            spouseEntity.SAID = txtSAID.Text;
            spouseEntity.Title = ddlTitle.SelectedValue;
            spouseEntity.FirstName = txtFirstName.Text;
            spouseEntity.LastName = txtLastName.Text;
            spouseEntity.Mobile = txtMobileNum.Text;
            spouseEntity.Phone = txtPhoneNum.Text;
            spouseEntity.ReferenceSAID = Session["SAID"].ToString();
            spouseEntity.TaxRefNo = txtTaxRefNum.Text;
            spouseEntity.EmailID = txtEmailId.Text;
            spouseEntity.DateOfBirth = txtDateOfBirth.Text;

            int result = spouseBL.SpouseCRUD(spouseEntity, 'i');
            if (result == 1)
            {
                message.Text = "Spouse details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);             
                BindSpouseDetails();
                Clear();
            }
            else
            {

                Clear();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void GetCountry()
    {
        try
        {
            dataset = basicDropdownBL.GetCountry();
            if (dataset.Tables.Count > 0)
            {
                ddlCountry.DataSource = dataset;
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select Country --", "-1"));
            }
        }
        catch(Exception ex){

        }
    }
    protected void GetProvince()
    {
        try
        {
            dataset = basicDropdownBL.GetProvince();
            if (dataset.Tables.Count > 0)
            {
                ddlProvince.DataSource = dataset;
                ddlProvince.DataTextField = "Province";
                ddlProvince.DataValueField = "ProvinceID";
                ddlProvince.DataBind();
                ddlProvince.Items.Insert(0, new ListItem("--Select Province --", "-1"));
            }
        }
        catch(Exception ex){

        }
    }
    protected void GetCity()
    {
        try
        {
            dataset = basicDropdownBL.GetCity();
            if (dataset.Tables.Count > 0)
            {
                ddlCity.DataSource = dataset;
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("--Select City --", "-1"));
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void GetAccountType()
    {
        try
        {
            dataset = basicDropdownBL.GetAccountType();
            if (dataset.Tables.Count > 0)
            {
                ddlAccountType.DataSource = dataset;
                ddlAccountType.DataTextField = "AccountType";
                ddlAccountType.DataValueField = "AccountTypeID";
                ddlAccountType.DataBind();
                ddlAccountType.Items.Insert(0, new ListItem("--Select Account Type --", "-1"));
            }

        }
        catch (Exception ex)
        {

        }
    }
    private void Clear()
    { 
        txtSAID.Text = ""; 
        txtFirstName.Text = ""; 
        txtLastName.Text = ""; 
        ddlTitle.SelectedValue = ""; 
        txtPhoneNum.Text = ""; 
        txtMobileNum.Text = ""; 
        txtEmailId.Text = ""; 
        txtTaxRefNum.Text = ""; 
        txtDateOfBirth.Text = "";
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
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        ddlAccountType.SelectedValue = "-1";
        txtCurrency.Text = "";
        txtSwift.Text = "";
    }
    protected void BindSpouseDetails()
    {
        try
        {
            gvSpouse.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = spouseBL.GetAllSpouse(Session["SAID"].ToString());
            if (dataset.Tables[0].Rows.Count > 0)
            {
                gvSpouse.DataSource = dataset;
                gvSpouse.DataBind();
                spouselist.Visible = true;
            }
            else
            {
                spouselist.Visible = false;
            }

        }
        catch (Exception ex)
        { }
    }
    protected void BindAddressDetails()
    {
        try
        {
            gvAddress.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = addressBL.GetAddressDetails(Session["SAID"].ToString(),2);
            gvAddress.DataSource = dataset;
            gvAddress.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
   
    protected void btnUpdateSpouse_Click(object sender, EventArgs e)
    {
        try
        {
            spouseEntity.SAID = ViewState["SAID"].ToString();
            spouseEntity.Title = ddlTitle.SelectedValue;
            spouseEntity.FirstName = txtFirstName.Text;
            spouseEntity.LastName = txtLastName.Text;
            spouseEntity.Mobile = txtMobileNum.Text;
            spouseEntity.Phone = txtPhoneNum.Text;
            spouseEntity.ReferenceSAID = ViewState["ReferenceSAID"].ToString();
            spouseEntity.TaxRefNo = txtTaxRefNum.Text;
            spouseEntity.EmailID = txtEmailId.Text;
            spouseEntity.DateOfBirth = txtDateOfBirth.Text;

            int result = spouseBL.SpouseCRUD(spouseEntity, 'u');
            if (result == 1)
            {
                message.Text = "Spouse details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindSpouseDetails();
                Clear();
            }
            else
            {

                Clear();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnSpouseCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void gvSpouse_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvSpouse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["SpouseID"] = ((Label)row.FindControl("lblSpouseID")).Text.ToString();
            ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
            if (e.CommandName == "Edit")
            {
                btnUpdateSpouse.Visible = true;
                btnSpouseSubmit.Visible = false;
                txtSAID.ReadOnly = true;
                txtFirstName.Text = ((Label)row.FindControl("lblFirstName")).Text.ToString();
                txtLastName.Text = ((Label)row.FindControl("lblLastName")).Text.ToString();
                txtMobileNum.Text =((Label)row.FindControl("lblMobile")).Text.ToString();
                txtSAID.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                txtPhoneNum.Text = ((Label)row.FindControl("lblPhone")).Text.ToString();
                txtEmailId.Text = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                txtTaxRefNum.Text = ((Label)row.FindControl("lblTaxRefNo")).Text.ToString();
                txtDateOfBirth.Text = Convert.ToDateTime(((Label)row.FindControl("lblDateOfBirth")).Text.ToString()).Date.ToShortDateString();
                ddlTitle.SelectedValue = ((Label)row.FindControl("lblTitle")).Text.ToString();
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
            else if (e.CommandName == "Delete")
            {
                ViewState["flag"] = 1;
                lbldeletemessage.Text = "Are you sure, you want to delete Company Details?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
            }
        }
        catch (Exception ex)
        {

        }      
    }
    private void BindBankDetails()
    {
        try
        {
            gdvBankList.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = bankBL.GetBankList(Session["SAID"].ToString(),2);
            gdvBankList.DataSource = dataset;
            gdvBankList.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnBankSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.Type = 2;
            bankEntity.BankName = txtBankName.Text;
            bankEntity.BranchNumber = txtBranchNumber.Text;
            bankEntity.AccountNumber = txtAccountNumber.Text;
            bankEntity.AccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            bankEntity.Currency = txtCurrency.Text;
            bankEntity.SWIFT = txtSwift.Text;
            bankEntity.SAID = ViewState["SAID"].ToString();
            bankEntity.ReferenceID = Session["SAID"].ToString();
            bankEntity.UIC = "0";
            bankEntity.CreatedBy = 0;
            bankEntity.AdvisorID = 0;
            bankEntity.UpdatedBy = 0;
            int result = bankBL.CURDBankInfo(bankEntity, 'i');
            if (result == 1)
            {
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                Clear();
            }


        }
        catch (Exception ex)
        {

        }
    }
    protected void btnBankCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.Type = 2;
            addressEntity.UIC = "0";
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
            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindAddressDetails();
               
            }
            else
            {
                message.Text = "Please try again!";
                Clear();
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void btnAddressCancel_Click(object sender, EventArgs e)
    {

    }
    protected void gvAddress_RowEditing(object sender, GridViewEditEventArgs e)
    {

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

            if (e.CommandName == "Edit")
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
        catch { }
    }
    protected void gdvBankList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gdvBankList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["BankDetailID"] = ((Label)row.FindControl("lblBankDetailID")).Text.ToString();
            ViewState["BankSAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

            if (e.CommandName == "Edit")
            {
                bankmessage.InnerText = "Update Bank Details";
                btnBankSubmit.Visible = false;
                btnUpdateBank.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
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
        catch { }
    }
    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            bankEntity.Type = 2;
            bankEntity.SAID = ViewState["BankSAID"].ToString();
            bankEntity.ReferenceID = ViewState["ReferenceSAID"].ToString();
            bankEntity.UIC = "0";
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
                Clear();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                Clear();
                BindBankDetails();
            }
        }
        catch { }
    }
    protected void btnUpdateAddress_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
            addressEntity.Type = 2;
            addressEntity.UIC= "0";
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.SAID = ViewState["AddressSAID"].ToString();
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
            addressEntity.UpdatedBy = 0;


            int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
            if (result == 1)
            {
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindAddressDetails();
            }
            else
            {
                message.Text = "Please try again!";
                Clear();
            }
        }
        catch { }
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int result = spouseBL.DeleteSpouse(ViewState["SAID"].ToString());
                if (result == 1)
                {
                    BindSpouseDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
                if (result == 1)
                {
                    BindBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
                if (result == 1)
                {
                    BindAddressDetails();
                }
            }
        
        }
        catch { }
    }
    protected void gvSpouse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gdvBankList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvSpouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSpouse.PageIndex = e.NewPageIndex;
            BindSpouseDetails();
        }
        catch { }
    }
    protected void gvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvAddress.PageIndex = e.NewPageIndex;
            BindAddressDetails();
        }
        catch { }
    }
    protected void gdvBankList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gdvBankList.PageIndex = e.NewPageIndex;
            BindBankDetails();
        }
        catch { }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage.SelectedItem.ToString().Trim();
            BindSpouseDetails();
        }
        catch { }
    }
    protected void DropPage1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage1.SelectedItem.ToString().Trim();
            BindAddressDetails();
        }
        catch { }
    }
    protected void DropPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage2.SelectedItem.ToString().Trim();
            BindBankDetails();
        }
        catch { }
    }
}