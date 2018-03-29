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
                    txtUIC.Text = "12356";
                    GetTrusteeGrid(txtUIC.Text);
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
        ds = _objTrusteeBL.GetTrustee(0, ReferenceUIC, 'l');
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

        ds = _objTrusteeBL.GetTrustee(TrusteeId, "", 'd');
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
            Mobile = txtMobile.Text.Trim()
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
        txtUIC.Text = "";
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
            if (e.CommandName == "EditTrustee")
            {
                int TrusteeId = Convert.ToInt32(e.CommandArgument.ToString());
                BindTrustee(TrusteeId);
            }
        }
        catch { }
    }

    #endregion
   
}