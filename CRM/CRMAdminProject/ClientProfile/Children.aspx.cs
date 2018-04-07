using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntityManager;
using DataManager;
using BusinessLogic;

public partial class ClientProfile_Children : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    ChildrenEntity childEntity = new ChildrenEntity();
    ChildrenBL childBL = new ChildrenBL();
    BankInfoEntity bankEntity = new BankInfoEntity();
    BankBL bankBL = new BankBL();
    BasicDropdownBL basicdropdownBL = new BasicDropdownBL();
    AddressEntity addressEntity = new AddressEntity();
    AddressBL addressBL = new AddressBL();
    DataSet dataset = new DataSet();


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
                    Response.Redirect("../Login.aspx", false);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                        _objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(DropPage1);
                        _objComman.getRecordsPerPage(dropPage2);
                        ViewState["ps"] = 5;
                        BindChildDetails();
                        BindAddressDetails();
                        BindBankDetails();
                        btnChildUpdate.Visible = false;
                    }
                    if (this.IsPostBack)
                    {
                        if (Request.Form[TabName.UniqueID].Contains("gvChildDetails"))
                        {
                            TabName.Value = "tab1";
                        }
                        else if (Request.Form[TabName.UniqueID].Contains("gdvBankList"))
                        {
                            TabName.Value = "tab2";
                        }
                        else if (Request.Form[TabName.UniqueID].Contains("gvAddress"))
                        {
                            TabName.Value = "tab3";
                        }
                        else
                        {
                            TabName.Value = Request.Form[TabName.UniqueID];
                        }
                    }
                }
            }
            if (strPreviousPage == "")
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnChildSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            childEntity.SAID = txtSAID.Text;
            childEntity.Title = ddlTitle.SelectedValue;
            childEntity.FirstName = txtFirstName.Text;
            childEntity.LastName = txtLastName.Text;
            childEntity.Mobile = txtMobileNum.Text;
            childEntity.Phone = txtPhoneNum.Text;
            childEntity.EmailID = txtEmailId.Text;
            childEntity.TaxRefNo = txtTaxRefNum.Text;
            childEntity.DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text;

            childEntity.ReferenceSAID = Session["SAID"].ToString();


            int result = childBL.ChildCRUD(childEntity, 'i');
            if (result == 1)
            {
                message.Text = "Child details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindChildDetails();
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Child Information not Saved please check the Details !!";
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
        //Response.Redirect(Request.Url.AbsoluteUri);
    }


    private void BindChildDetails()
    {
        try
        {
            gvChildDetails.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = childBL.GetAllChilds(Session["SAID"].ToString(), "");

            if (dataset.Tables[0].Rows.Count > 0)
            {
                search.Visible = true;
                gvChildDetails.DataSource = dataset;
                gvChildDetails.DataBind();
                ChildList.Visible = true;
            }
            else
            {
                gvChildDetails.DataSource = null;
                gvChildDetails.DataBind();
                search.Visible = false;
                ChildList.Visible = false;
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }



    protected void gvChildDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["ChildrenID"] = ((Label)row.FindControl("lblChildrenID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                string ChildName = ((Label)row.FindControl("lblFirstName")).Text.ToString() + " " + ((Label)row.FindControl("lblLastName")).Text.ToString();
                txtChildNameBank.Text = ChildName;
                txtChildNameAddress.Text = ChildName;
                txtSAIDBank.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                txtSAIDAddress.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                if (e.CommandName == "Edit")
                {
                    btnChildUpdate.Visible = true;
                    btnChildSubmit.Visible = false;
                    txtSAID.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtSAID.ReadOnly = true;
                    ddlTitle.SelectedValue = ((Label)row.FindControl("lblTitle")).Text.ToString();
                    txtFirstName.Text = ((Label)row.FindControl("lblFirstName")).Text.ToString();
                    txtLastName.Text = ((Label)row.FindControl("lblLastName")).Text.ToString();
                    txtEmailId.Text = ((Label)row.FindControl("lblEmailID")).Text.ToString();
                    txtMobileNum.Text = ((Label)row.FindControl("lblMobile")).Text.ToString();
                    txtPhoneNum.Text = ((Label)row.FindControl("lblPhone")).Text.ToString();
                    txtTaxRefNum.Text = ((Label)row.FindControl("lblTaxRefNo")).Text.ToString();
                    txtDateOfBirth.Text = (((Label)row.FindControl("lblDateOfBirth")).Text);

                }

                else if (e.CommandName == "Address")
                {
                    btnUpdateAddress.Visible = false;
                    btnAddressSubmit.Visible = true;
                    addressmessage.InnerText = "Save Address Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                }

                else if (e.CommandName == "Bank")
                {
                    bankmessage.InnerText = "Save Bank Details";
                    btnBankSubmit.Visible = true;
                    btnUpdateBank.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                }
                else if (e.CommandName == "Delete")
                {
                    ViewState["flag"] = 1;
                    lbldeletemessage.Text = "Are you sure, you want to delete Child Details?";
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


    protected void btnChildUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            childEntity.ReferenceSAID = ViewState["ReferenceSAID"].ToString();
            childEntity.SAID = ViewState["SAID"].ToString();
            childEntity.Title = ddlTitle.SelectedValue;
            childEntity.FirstName = txtFirstName.Text;
            childEntity.LastName = txtLastName.Text;
            childEntity.Mobile = txtMobileNum.Text;
            childEntity.Phone = txtPhoneNum.Text;
            childEntity.EmailID = txtEmailId.Text;
            childEntity.TaxRefNo = txtTaxRefNum.Text;
            childEntity.DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text;



            int result = childBL.ChildCRUD(childEntity, 'u');
            if (result == 1)
            {
                message.Text = "Child details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindChildDetails();
                BindBankDetails();
                BindAddressDetails();
                btnChildUpdate.Visible = false;
                btnChildSubmit.Visible = true;
                txtSAID.ReadOnly = false;
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Child Information not updated please check the Details !!";
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
        //Response.Redirect(Request.Url.AbsoluteUri);        
    }

    protected void gvChildDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void BindAddressDetails()
    {
        try
        {
            gvAddress.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = addressBL.GetAddressDetails(Session["SAID"].ToString(), 3);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                searchaddress.Visible = true;
            }
            else
            {
                searchaddress.Visible = false;
            }
            gvAddress.DataSource = dataset;
            gvAddress.DataBind();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void BindBankDetails()
    {
        try
        {
            gdvBankList.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = bankBL.GetBankList(Session["SAID"].ToString(), 3);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                searchbank.Visible = true;

            }
            else
            {
                searchbank.Visible = false;
            }
            gdvBankList.DataSource = dataset;
            gdvBankList.DataBind();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    protected void btnChildCancel_Click(object sender, EventArgs e)
    {
        Clear();
        Response.Redirect("ChildDetails.aspx");
    }

    protected void gvChildDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

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


    }

    private void ClearBank()
    {
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        ddlAccountType.SelectedValue = "-1";
        txtCurrency.Text = "";
        txtSwift.Text = "";
        msgAccountNum.Text = "";
    }

    private void ClearAddress()
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



    protected void btnBankSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.Type = 3;
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
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"]);
            bankEntity.UpdatedBy = 0;
            int result = bankBL.CURDBankInfo(bankEntity, 'i');
            if (result == 1)
            {
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                BindBankDetails();
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

    protected void btnBankCancel_Click(object sender, EventArgs e)
    {
        ClearBank();
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
                ViewState["BankSAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

                if (e.CommandName == "Edit")
                {
                    bankmessage.InnerText = "Update Bank Details";
                    btnBankSubmit.Visible = false;
                    btnUpdateBank.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                    txtSAIDBank.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtChildNameBank.Text = ((Label)row.FindControl("lblChildName")).Text.ToString();
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gdvBankList_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void btnUpdateBank_Click(object sender, EventArgs e)
    {
        try
        {
            bankEntity.BankDetailID = Convert.ToInt32(ViewState["BankDetailID"]);
            bankEntity.Type = 3;
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
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"]);
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'u');
            if (result == 1)
            {
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearBank();
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

    protected void gdvBankList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnAddressSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            addressEntity.Type = 3;
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
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"]);
            addressEntity.CreatedBy = 0;

            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                BindAddressDetails();

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

    protected void btnAddressCancel_Click(object sender, EventArgs e)
    {

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

                if (e.CommandName == "Edit")
                {
                    addressmessage.InnerText = "Update Address Details";
                    btnAddressSubmit.Visible = false;
                    btnUpdateAddress.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                    txtSAIDAddress.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtChildNameAddress.Text = ((Label)row.FindControl("lblAddChildName")).Text.ToString();
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
            addressEntity.Type = 3;
            addressEntity.SAID = ViewState["AddressSAID"].ToString();
            addressEntity.ReferenceSAID = ViewState["AddressReferenceSAID"].ToString();
            addressEntity.UIC = "0";
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
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"]);
            addressEntity.Status = 1;
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = "0";



            int result = addressBL.InsertUpdateAddress(addressEntity, 'u');
            if (result == 1)
            {
                message.Text = "Address details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                BindAddressDetails();
            }
            else
            {
                message.Text = "Please try again!";
                ClearAddress();
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

    protected void gvAddress_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int result = childBL.DeleteChildDetails(ViewState["SAID"].ToString());
                if (result > 0)
                {
                    BindChildDetails();
                    BindBankDetails();
                    BindAddressDetails();
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
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

    }
    protected void gvAddress_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }


    protected void gvChildDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvChildDetails.PageIndex = e.NewPageIndex;
            BindChildDetails();
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
        try
        {
            gvAddress.PageIndex = e.NewPageIndex;
            BindAddressDetails();
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
        try
        {
            gdvBankList.PageIndex = e.NewPageIndex;
            BindBankDetails();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage.SelectedItem.ToString().Trim();
            BindChildDetails();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void DropPage1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage.SelectedItem.ToString().Trim();
            BindAddressDetails();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }


    protected void dropPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage.SelectedItem.ToString().Trim();
            BindBankDetails();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void txtSAID_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string ExistsSAID = txtSAID.Text;
            dataset = childBL.GetAllChilds("", ExistsSAID);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                msgSAID.Text = "Already Exists";
                txtSAID.Text = "";
            }
            else
            {
                msgSAID.Text = "";
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
}