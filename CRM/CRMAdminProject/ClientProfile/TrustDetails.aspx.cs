using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Session["AdvisorID"] == null || Session["AdvisorID"].ToString() == "")
                {
                    Response.Redirect("../Login.aspx", false);
                }
                else
                {
                    message.ForeColor = System.Drawing.Color.Green;
                    _objComman.GetCountry(ddlCountry);
                    _objComman.GetProvince(ddlProvince);
                    _objComman.GetCity(ddlCity);
                    _objComman.GetAccountType(ddlAccountType);
                    GetTrustGrid();
                    BindBankDetails();
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
    }

    /// <summary>
    /// Trust Info Methods
    /// Trust Info Events
    /// </summary>
    /// <returns></returns>
    #region TrustDetails

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvTrust.PageSize = Convert.ToInt32(DropPage.SelectedValue);
    }
    protected void btnSubmitTrust_Click(object sender, EventArgs e)
    {
        try
        {
            int res = ManageTrust();
            if (res > 0)
            {
                if (btnSubmitTrust.Text == "Update")
                    message.Text = "Updated Successfully !!";
                else
                    message.Text = "Saved Successfully !!";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearTrustControls();
                GetTrustGrid();
            }
            else
            {
                message.ForeColor = System.Drawing.Color.Blue;
                message.Text = "Trust Information not Saved please check the Details !!";
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

    protected void btnCancleTrust_Click(object sender, EventArgs e)
    {
        ClearTrustControls();
    }

    private int ManageTrust()
    {
        TrustEntity _objTrust = new TrustEntity
        {
            UIC = txtUIC.Text.Trim(),
            TrustName = txtTrustName.Text.Trim(),
            YearOfFoundation = txtYearofFoundation.Text.Trim(),
            TaxRefNo = txtTaxRef.Text.Trim(),
            Telephone = txtTelephone.Text.Trim(),
            EmailID = txtEmail.Text.Trim(),
            FaxNo = txtFax.Text.Trim(),
            Website = txtWebsite.Text.Trim(),
            ReferenceSAID = Session["SAID"].ToString(),
            Status = 1,
            AdvisorID = Convert.ToInt32(Session["AdvisorID"]) 
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
        txtTaxRef.Text = "";
        txtTelephone.Text = "";
        txtEmail.Text = "";
        txtFax.Text = "";
        txtWebsite.Text = "";
    }

    private void BindTrust(string UIC)
    {
        ds = _objTrustBL.GetTrust(Session["SAID"].ToString(), UIC);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            txtUIC.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
            txtTrustName.Text = ds.Tables[0].Rows[0]["TrustName"].ToString();
            txtYearofFoundation.Text = ds.Tables[0].Rows[0]["YearOfFoundation"].ToString();
            txtTelephone.Text = ds.Tables[0].Rows[0]["Telephone"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
            txtFax.Text = ds.Tables[0].Rows[0]["FaxNo"].ToString();
            txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
            txtTaxRef.Text = ds.Tables[0].Rows[0]["TaxRefNo"].ToString();
            btnSubmitTrust.Text = "Update";
        }
    }

    private void GetTrustGrid()
    {
        ds = _objTrustBL.GetTrust(Session["SAID"].ToString(), "0");
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvTrust.DataSource = ds.Tables[0];
            gvTrust.DataBind();
            search.Visible = true;
        }
        else
        {
            gvTrust.DataSource = null;
            gvTrust.DataBind();
            search.Visible = false;
        }
    }

    protected void gvTrust_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["UIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();

            string UIC = e.CommandArgument.ToString();
            EncryptDecrypt ObjEn = new EncryptDecrypt();
            ObjEn.Encrypt(UIC);

            switch (e.CommandName)
            {
                case "EditTrust":
                    BindTrust(UIC);
                    break;
                case "EditTrustee":
                    Response.Redirect("Trustee.aspx?x=" + ObjEn.Encrypt(UIC), false);
                    break;
                case "EditSettler":
                    Response.Redirect("TrustSettlor.aspx?x=" + ObjEn.Encrypt(UIC), false);
                    break;
                case "EditBeneficiary":
                    Response.Redirect("Beneficiary.aspx?x=" + ObjEn.Encrypt(UIC) + "&t=" + ObjEn.Encrypt("1"), false);
                    break;
                case "Address":
                    btnUpdateAddress.Visible = false;
                    btnAddressSubmit.Visible = true;
                    addressmessage.InnerText = "Save Address Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAddressModal();", true);
                    break;
                case "Bank":
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
            }

        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvTrust_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrust.PageIndex = e.NewPageIndex;
        GetTrustGrid();
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
        gvAddress.PageSize = Convert.ToInt32(dropAddress.SelectedValue);
    }
    protected void BindAddressDetails()
    {
        try
        {
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 4);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddress.DataSource = ds.Tables[0];
                ViewState["dt"] = ds.Tables[0];
                gvAddress.DataBind();
                searchaddress.Visible = true;
            }
            else
            {
                gvAddress.DataSource = null;
                gvAddress.DataBind();
                searchaddress.Visible = false;
            }
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
            addressEntity.AdvisorId = 0;
            addressEntity.CreatedBy = 0;
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
    /// Bank Grid
    /// </summary>
    /// <returns></returns>
    #region Bank Details

    protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        gdvBankList.PageSize = Convert.ToInt32(dropBank.SelectedValue);
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

            ds = bankBL.GetBankList(Session["SAID"].ToString(), 4);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gdvBankList.DataSource = ds.Tables[0];
                ViewState["dt"] = ds.Tables[0];
                gdvBankList.DataBind();
                searchbank.Visible = true;
            }
            else
            {
                gdvBankList.DataSource = null;
                gdvBankList.DataBind();
                searchbank.Visible = false;
            }
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
                int res = _objTrustBL.DeleteTrust(ViewState["UIC"].ToString());
                if (res > 0)
                    GetTrustGrid();
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


}