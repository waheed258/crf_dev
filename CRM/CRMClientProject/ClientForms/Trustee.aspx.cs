using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                    if (!string.IsNullOrEmpty(Request.QueryString["x"]))
                    {
                        EncryptDecrypt ObjEn = new EncryptDecrypt();
                        txtUIC.Text = ObjEn.Decrypt(Request.QueryString["x"].ToString());
                        GetTrusteeGrid(txtUIC.Text);
                        BindBankDetails();
                        BindAddressDetails();
                    }

                }
            }
            catch
            {
            }
        }
    }

    /// <summary>
    /// Trustee Methhods,Events 
    /// Trestee Gridview 
    /// </summary>
    /// <param name="ReferenceSAId"></param>
    /// <param name="UIC"></param>
    #region Trustee Details
    private void GetTrusteeGrid(string ReferenceUIC)
    {
        ds = _objTrusteeBL.GetTrustee(0, ReferenceUIC);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvTrustee.DataSource = ds.Tables[0];
            gvTrustee.DataBind();
        }
        else
        {
            gvTrustee.DataSource = null;
            gvTrustee.DataBind();
        }
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
            Status = 1
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Trustee Information Updated Successfully !!.');", true);
                GetTrusteeGrid(txtUIC.Text);
                ClearTrusteeControls();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Trustee Information not Saved please check the Details !!');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert(" + ex.Message + ");", true);
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
    }

 

    protected void gvTrustee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
            ViewState["TrusteeId"] = ((Label)row.FindControl("lblTrusteeId")).Text.ToString();

            if (e.CommandName == "EditTrustee")
            {
                int TrusteeId = Convert.ToInt32(e.CommandArgument.ToString());
                BindTrustee(TrusteeId);
            }

            else if (e.CommandName == "DeleteTrustee")
            {
                ViewState["flag"] = 1;
                lbldeletemessage.Text = "Are you sure, you want to delete Trstee Details?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
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
        }
        catch { }
    }

    #endregion


    /// <summary>
    /// Address Details Methods
    /// Address Details Info Events
    /// </summary>
    /// <returns></returns>
    #region Address Details

    protected void BindAddressDetails()
    {
        try
        {
            ds = addressBL.GetAddressDetails(Session["SAID"].ToString(), 6);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvAddress.DataSource = ds.Tables[0];
                ViewState["dt"] = ds.Tables[0];
                gvAddress.DataBind();
            }
            else
            {
                gvAddress.DataSource = null;
                gvAddress.DataBind();
            }
        }
        catch { }
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
                ClearAddressControls();
                BindAddressDetails();

            }
            else
            {
                message.Text = "Please try again!";
            }
        }
        catch {

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
            addressEntity.AdvisorId = 0;
            addressEntity.Status = 1;
            addressEntity.CreatedBy = 0;
            addressEntity.UpdatedBy = 0;


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
        catch { }
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
        catch { }
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
            bankEntity.UIC = "0";
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
                ClearBankControls();
                BindBankDetails();
            }
            else
            {
                message.Text = "Please try again!";
                BindBankDetails();
            }
        }
        catch { }
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
                ViewState["dt"] = ds.Tables[0];
                gdvBankList.DataBind();
            }
            else
            {
                gdvBankList.DataSource = null;
                gdvBankList.DataBind();
            }
        }
        catch { }
    }

    protected void gdvBankList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
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
        catch { }
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
                int res = _objTrusteeBL.DeleteTrustee(Convert.ToInt32(ViewState["TrusteeId"]));
                if (res > 0)
                {
                    GetTrusteeGrid(txtUIC.Text.Trim());
                    ClearTrusteeControls();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 2)
            {
                int result = bankBL.DeleteBankDetails(ViewState["BankDetailID"].ToString());
                if (result == 1)
                {
                    ClearAddressControls();
                    BindBankDetails();
                }
            }
            else if (Convert.ToInt32(ViewState["flag"]) == 3)
            {
                int result = addressBL.DeleteAddressDetails(ViewState["AddressDetailID"].ToString());
                if (result == 1)
                {
                    ClearAddressControls();
                    BindAddressDetails();
                }
            }
        }
        catch
        {

        }

    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dropBank_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dropAddress_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}