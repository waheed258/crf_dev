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

public partial class ClientForms_ClientPersonal : System.Web.UI.Page
{
    ClientProfileBL _ObjClientProfileBL = new ClientProfileBL();
    BankInfoEntity BankInfoEntity = new BankInfoEntity();
    AddressEntity AddressEntity = new AddressEntity();
    ClientPersonalInfoEntity ClientPersonalInfoEntity = new ClientPersonalInfoEntity();
    DataSet ds = new DataSet();
    BankBL bankbl = new BankBL();
    AddressBL addressbl = new AddressBL();

    CommanClass _objComman = new CommanClass();


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

                    GetClientPersonal();
                    GetBankDetails();
                    GetAddressDetails();
                }
            }
            catch
            {

            }
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
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                btnSubmitClientPersonal.Text = "Edit";
            }
        }
        catch
        {

        }
    }


    private void GetClientPersonal()
    {
        try
        {
            //DataSet ds = _ObjClientProfileBL.GetClientPersonal(Session["SAID"].ToString());

            DataSet ds = _ObjClientProfileBL.GetClientPersonal(Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSAId.ReadOnly = true;
                txtFirstName.ReadOnly = true;
                txtLastName.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtPhoneNo.ReadOnly = true;
                txtMobileNo.ReadOnly = true;
                txtDateofBirth.ReadOnly = true;
                txtTaxRefNo.ReadOnly = true;
                ViewState["flag"] = 1;
                txtSAId.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtPhoneNo.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

                if (ds.Tables[0].Rows[0]["DateOfBirth"].ToString() != null)
                {
                    txtDateofBirth.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfBirth"].ToString()).Date.ToString("yyyy-MM-dd");
                }

                txtTaxRefNo.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
                btnSubmitClientPersonal.Text = "Edit";
            }
            else
            {
                txtSAId.ReadOnly = false;
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtPhoneNo.ReadOnly = false;
                txtMobileNo.ReadOnly = false;
                txtDateofBirth.ReadOnly = false;
                txtTaxRefNo.ReadOnly = false;
                ViewState["flag"] = 2;
                btnSubmitClientPersonal.Text = "Submit";
                GetClientRegistartion();
            }
        }
        catch
        {

        }
    }

    protected void btnSubmitClientPersonal_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSubmitClientPersonal.Text == "Edit")
            {
                if (Convert.ToInt32(ViewState["flag"]) == 1)
                {
                    btnSubmitClientPersonal.Text = "Update";
                    txtSAId.ReadOnly = false;
                    txtFirstName.ReadOnly = false;
                    txtLastName.ReadOnly = false;
                    txtEmail.ReadOnly = false;
                    txtPhoneNo.ReadOnly = false;
                    txtMobileNo.ReadOnly = false;
                    txtDateofBirth.ReadOnly = false;
                    txtTaxRefNo.ReadOnly = false;
                }
               
            }
            else
            {
                ClientPersonalInfoEntity.SAID = txtSAId.Text;
                ClientPersonalInfoEntity.FirstName = txtFirstName.Text;
                ClientPersonalInfoEntity.LastName = txtLastName.Text;
                ClientPersonalInfoEntity.EmailID = txtEmail.Text;
                ClientPersonalInfoEntity.Phone = txtPhoneNo.Text;
                ClientPersonalInfoEntity.Mobile = txtMobileNo.Text;
                ClientPersonalInfoEntity.DateOfBirth = txtDateofBirth.Text;
                ClientPersonalInfoEntity.TaxRefNo = txtTaxRefNo.Text;
                int result;
                if (Convert.ToInt32(ViewState["flag"]) == 1)
                {
                    result = _ObjClientProfileBL.CURDClientPersonalInfo(ClientPersonalInfoEntity, 'u');
                    lblMessage.Text = "ClientPersonal Updated Successfully";
                }
                else
                {
                    result = _ObjClientProfileBL.CURDClientPersonalInfo(ClientPersonalInfoEntity, 'i');
                    lblMessage.Text = "New ClientPersonal Created Successfully!";
                }
                if (result == 1)
                {
                    
                    txtSAId.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtPhoneNo.ReadOnly = true;
                    txtMobileNo.ReadOnly = true;
                    txtDateofBirth.ReadOnly = true;
                    txtTaxRefNo.ReadOnly = true;
                    btnSubmitClientPersonal.Text = "Edit";
                }
                else
                {
                    lblMessage.Text = "Please try again!";
                }
            }
        }
        catch (Exception ex)
        {

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
        txtPlotNo.Text = "";
        txtBulding.Text = "";
        txtFloor.Text = "";
        txtFlatrNo.Text = "";
        txtRoadName.Text = "";
        txtRoadNo.Text = "";
        txtSuburbName.Text = "";
        ddlCity.SelectedIndex = 0;
        txtPostalCode.Text = "";
        ddlProvince.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
    }

  

    #region Bank Details 

    protected void btnSubmitBank_Click(object sender, EventArgs e)
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
                lblMessage.Text = "BankDetails Updated Successfully";
            }
            else
            {
                result = new BankBL().CURDBankInfo(BankInfoEntity, 'i');
                lblMessage.Text = "New Bank Created Successfully!";
            }
            if (result == 1)
            {
                ClearBank();
                GetBankDetails();
            }
            else
            {
                lblMessage.Text = "Please try again!";
            }
        }
        catch (Exception ex)
        {

        }
    }

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
            ds = bankbl.GetBankList(Session["SAID"].ToString(),1);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvBankDetails.DataSource = ds.Tables[0];
                gvBankDetails.DataBind();
            }
            else
            {
                gvBankDetails.DataSource = null;
                gvBankDetails.DataBind();
            }
        }
        catch
        {

        }
    }



    protected void gvBankDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["BankDetailID"] = ((Label)row.FindControl("lblBankDetailID")).Text.ToString();
            //ViewState["BankUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
            ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

            if (e.CommandName == "EditBank")
            {
                //bankmessage.InnerText = "Update Bank Details";
                //btnBankSubmit.Visible = false;
                //btnUpdateBank.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBankModal();", true);
                txtBankName.Text = ((Label)row.FindControl("lblBankName")).Text.ToString();
                txtBranchNumber.Text = ((Label)row.FindControl("lblBranchNumber")).Text.ToString();
                txtAccountNumber.Text = ((Label)row.FindControl("lblAccountNumber")).Text.ToString();
                txtCurrency.Text = ((Label)row.FindControl("lblCurrency")).Text.ToString();
                txtSwift.Text = ((Label)row.FindControl("lblSWIFT")).Text.ToString();
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
        catch
        {

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

    protected void btnSubmitAddress_Click(object sender, EventArgs e)
    {
        try
        {
            AddressEntity.SAID = txtSAId.Text;
            AddressEntity.Type = 1;
            AddressEntity.UIC = "0";
            AddressEntity.ReferenceSAID = Session["SAID"].ToString();
            AddressEntity.HouseNo = txtPlotNo.Text;
            AddressEntity.BuildingName = txtBulding.Text;
            AddressEntity.Floor = txtFloor.Text;
            AddressEntity.FlatNo = txtFlatrNo.Text;
            AddressEntity.RoadName = txtRoadName.Text;
            AddressEntity.RoadNo = txtRoadNo.Text.Trim();
            AddressEntity.SuburbName = txtRoadNo.Text;
            AddressEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
            AddressEntity.PostalCode = txtPostalCode.Text;
            AddressEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            AddressEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            AddressEntity.AdvisorId = 1;

            AddressEntity.Status = 1;
            AddressEntity.CreatedBy = 1;

            int result;
            if (Convert.ToInt32(ViewState["Addressflag"]) == 1)
            {
                AddressEntity.AddressDetailID = Convert.ToInt32(ViewState["AddressDetailID"]);
                result = new AddressBL().InsertUpdateAddress(AddressEntity, 'u');
                lblMessage.Text = "AddressDetails Updated Successfully";
            }
            else
            {
                result = new AddressBL().InsertUpdateAddress(AddressEntity, 'i');
                lblMessage.Text = "New Address Created Successfully!";
            }
            if (result == 1)
            {
                clearAddresscontrols();
                GetAddressDetails();
            }
            else
            {
                lblMessage.Text = "Please try again!";
            }

        }
        catch
        {

        }
    }

    protected void GetAddressDetails()
    {
        try
        {
            //gvAdvisor.PageSize = int.Parse(ViewState["ps"].ToString());
            ds = addressbl.GetAddressDetails(Session["SAID"].ToString(), 1);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddressDetails.DataSource = ds;
                gvAddressDetails.DataBind();
            }
            else
            {
                gvAddressDetails.DataSource = null;
                gvAddressDetails.DataBind();
            }
        }
        catch { }
    }

    protected void gvAddressDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["AddressDetailID"] = ((Label)row.FindControl("lblAddressDetailID")).Text.ToString();
            // ViewState["AddressUIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
            ViewState["AddressReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();

            if (e.CommandName == "EditAddress")
            {
                // addressmessage.InnerText = "Update Address Details";
                //btnAddressSubmit.Visible = false;
                //btnUpdateAddress.Visible = true;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
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
                ViewState["Addressflag"] = 1;
            }
            else if (e.CommandName == "Delete")
            {
                ViewState["flag"] = 2;
                lbldeletemessage.Text = "Are you sure, you want to delete Address Details?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
            }
        }
        catch { }
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

        if (Convert.ToInt32(ViewState["flag"]) == 1)
        {
            int result = bankbl.DeleteBankDetails(ViewState["BankDetailID"].ToString());
            if (result == 1)
            {
                GetBankDetails();
            }
        }
        else if (Convert.ToInt32(ViewState["flag"]) == 2)
        {
            int result = addressbl.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
            if (result == 1)
            {
                GetAddressDetails();
            }
        }

    }
    

    
}