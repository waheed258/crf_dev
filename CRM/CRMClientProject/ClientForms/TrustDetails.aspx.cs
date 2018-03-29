using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using EntityManager;

public partial class ClientForms_TrustDetails : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    TrustBL _objTrustBL = new TrustBL();
    DataSet ds = new DataSet();
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

                    GetTrustGrid(Session["SAID"].ToString(), "");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert(" + ex.Message + ");", true);
            }
        }
    }

    /// <summary>
    /// Trust Info Methods
    /// Trust Info Events
    /// </summary>
    /// <returns></returns>
    #region

    protected void btnSubmitTrust_Click(object sender, EventArgs e)
    {
        try
        {
            int res = ManageTrust();
            if (res > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Trust Information Updated Successfully !!.');", true);
                ClearTrustControls();
                GetTrustGrid(Session["SAID"].ToString(), "");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Trust Information not Saved please check the Details !!');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert(" + ex.Message + ");", true);
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
            Status = 1
        };
        int res;
        if (btnSubmitTrust.Text == "Update")
            res= _objTrustBL.TrustManager(_objTrust, 'U');
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
        ds = _objTrustBL.GetTrust("", UIC, 'd');
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

    private void GetTrustGrid(string ReferenceSAId, string UIC)
    {
        ds = _objTrustBL.GetTrust(ReferenceSAId, UIC, 'l');
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvTrust.DataSource = ds.Tables[0];
            gvTrust.DataBind();
        }
        else
        {
            gvTrust.DataSource = null;
            gvTrust.DataBind();
        }
    }


    protected void gvTrust_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvTrust_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditTrust")
            {
                string UIC = e.CommandArgument.ToString();
                BindTrust(UIC);
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
    #region

    protected void btnSubmitAddress_Click(object sender, EventArgs e)
    {
        try
        {
            int res = InsertUpdateAddress();
            if (res > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Address Updated Successfully !!.');", true);
                clearAddresscontrols();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Address not saved please check the Details !!');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert(" + ex.Message + ");", true);
        }
    }

    private int InsertUpdateAddress()
    {
        AddressEntity _objAddress = new AddressEntity
        {
            AddressDetailID = 0,
            Type = 1,
            SAID = "1",
            ReferenceSAID = "1",
            UIC = "1",
            HouseNo = txtPlotNo.Text.Trim(),
            BuildingName = txtBulding.Text.Trim(),
            Floor = txtFloor.Text.Trim(),
            FlatNo = txtFlatrNo.Text.Trim(),
            RoadName = txtRoadName.Text.Trim(),
            RoadNo = txtRoadNo.Text.Trim(),
            SuburbName = txtSuburbName.Text.Trim(),
            City = Convert.ToInt32(ddlCity.SelectedValue),
            PostalCode = txtPostalCode.Text.Trim(),
            Province = Convert.ToInt32(ddlProvince.SelectedValue),
            Country = Convert.ToInt32(ddlCountry.SelectedValue),
            AdvisorId = 1,

            Status = 1,
            CreatedBy = 1,
        };
        return new AddressBL().InsertUpdateAddress(_objAddress, 'i');
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

    #endregion



    /// <summary>
    /// Bank Details Methods
    /// Bank Details Info Events
    /// </summary>
    /// <returns></returns>
    #region

    protected void btnSubmitBank_Click(object sender, EventArgs e)
    {
        try
        {
            int res = InsertUpdateBank();
            if (res > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Bank Details Updated Successfully !!.');", true);
                clearBankcontrols();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert('Bank not Saved please check the Details !!');", true);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "message alert", "alert(" + ex.Message + ");", true);
        }
    }

    private int InsertUpdateBank()
    {
        BankInfoEntity _objBAnk = new BankInfoEntity
        {
            SAID = "123",
            BankName = txtBankName.Text,
            BranchNumber = txtBranchNumber.Text,
            AccountNumber = txtAccountNumber.Text,
            AccountType = Convert.ToInt32(ddlAccountType.SelectedValue),
            Currency = txtCurrency.Text,
            SWIFT = txtSwift.Text
        };
        return new BankBL().CURDBankInfo(_objBAnk, 'i');
    }

    private void clearBankcontrols()
    {
        txtBankName.Text = "";
        txtBranchNumber.Text = "";
        txtAccountNumber.Text = "";
        ddlAccountType.SelectedIndex = 0;
        txtCurrency.Text = "";
        txtSwift.Text = "";
    }

    #endregion




    
}