using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessLogic;
using EntityManager;

public partial class AdminForms_LocationMaster : System.Web.UI.Page
{
    LocationEntity locationEntity = new LocationEntity();
    LocationBL locationBL = new LocationBL();
    BasicDropdownBL basicdropdownBL = new BasicDropdownBL();
    DataSet dataset = new DataSet();
    CommanClass _objComman = new CommanClass();
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
                        ViewState["ps"] = 5;
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                        _objComman.GetCity(ddlCity);
                        btnUpdate.Visible = false;
                        BindLocation();
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
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            locationEntity.LocationName = txtLocationName.Text;
            locationEntity.MobileNum = txtMobileNum.Text;
            locationEntity.TelephoneNum = txtTelNum.Text;
            locationEntity.PrimaryEmail = txtPrimaryEmail.Text;
            locationEntity.SecondaryEmail = txtSecondaryEmail.Text;
            locationEntity.VatPercentage = txtVatPerc.Text;
            locationEntity.VatRegistration = txtVatReg.Text;
            locationEntity.PlotNo = txtPlotNo.Text;
            locationEntity.BuildingName = txtBuildingName.Text;
            locationEntity.FloorNo = txtFloorNo.Text;
            locationEntity.FlatNo = txtFlatNo.Text;
            locationEntity.RoadName = txtRoadName.Text;
            locationEntity.RoadNo = txtRoadNum.Text;
            locationEntity.SuburbName = txtSuburbName.Text;
            locationEntity.PostalCode = txtPostalCode.Text;
            locationEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
            locationEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            locationEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            locationEntity.CreatedBy = 0;

            int result = locationBL.LocationCRUD(locationEntity, 'i');
            if (result == 1)
            {
                message.Text = "Location details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindLocation();

            }
            else
            {
                message.Text = "Please try again!";
                Clear();

            }
        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void BindLocation()
    {
        try
        {
            gvLocation.PageSize = int.Parse(ViewState["ps"].ToString());
            dataset = locationBL.GetLocation();
            if (dataset.Tables[0].Rows.Count > 0)
            {
                gvLocation.DataSource = dataset;
                gvLocation.DataBind();
            }
        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    private void Clear()
    {
        txtLocationName.Text = "";
        txtMobileNum.Text = "";
        txtTelNum.Text = "";
        txtPrimaryEmail.Text = "";
        txtSecondaryEmail.Text = "";
        txtVatReg.Text = "";
        txtVatPerc.Text = "";
        txtPlotNo.Text = "";
        txtBuildingName.Text = "";
        txtFloorNo.Text = "";
        txtFlatNo.Text = "";
        txtRoadName.Text = "";
        txtRoadNum.Text = "";
        txtSuburbName.Text = "";
        txtPostalCode.Text = "";
        ddlCity.SelectedValue = "-1";
        ddlProvince.SelectedValue = "-1";
        ddlCountry.SelectedValue = "-1";


    }

    protected void GetCountry()
    {
        try
        {
            dataset = basicdropdownBL.GetCountry();
            if (dataset.Tables.Count > 0)
            {
                ddlCountry.DataSource = dataset;
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select Country --", "-1"));
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
       
    }
    protected void GetProvince()
    {
        try
        {
            dataset = basicdropdownBL.GetProvince();
            if (dataset.Tables.Count > 0)
            {
                ddlProvince.DataSource = dataset;
                ddlProvince.DataTextField = "Province";
                ddlProvince.DataValueField = "ProvinceID";
                ddlProvince.DataBind();
                ddlProvince.Items.Insert(0, new ListItem("--Select Province --", "-1"));
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void GetCity()
    {
        try
        {
            dataset = basicdropdownBL.GetCity();
            if (dataset.Tables.Count > 0)
            {
                ddlCity.DataSource = dataset;
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "CityID";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("--Select City --", "-1"));
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void gvLocation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            ViewState["LocationID"] = ((Label)row.FindControl("lblLocationID")).Text.ToString();
            if (e.CommandName == "Edit")
            {
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                txtLocationName.Text = ((Label)row.FindControl("lblLocationName")).Text.ToString();
                txtMobileNum.Text = ((Label)row.FindControl("lblMobileNum")).Text.ToString();
                txtTelNum.Text = ((Label)row.FindControl("lblTelephoneNum")).Text.ToString();
                txtPrimaryEmail.Text = ((Label)row.FindControl("lblPrimaryEmail")).Text.ToString();
                txtSecondaryEmail.Text = ((Label)row.FindControl("lblSecondaryEmail")).Text.ToString();
                txtVatReg.Text = ((Label)row.FindControl("lblVatRegistration")).Text.ToString();
                txtVatPerc.Text = ((Label)row.FindControl("lblVatPercentage")).Text.ToString();
                txtPlotNo.Text = ((Label)row.FindControl("lblPlotNo")).Text.ToString();
                txtBuildingName.Text = ((Label)row.FindControl("lblBuildingName")).Text.ToString();
                txtFloorNo.Text = ((Label)row.FindControl("lblFloorNo")).Text.ToString();
                txtFlatNo.Text = ((Label)row.FindControl("lblFlatNo")).Text.ToString();
                txtRoadName.Text = ((Label)row.FindControl("lblRoadName")).Text.ToString();
                txtRoadNum.Text = ((Label)row.FindControl("lblRoadNo")).Text.ToString();
                txtSuburbName.Text = ((Label)row.FindControl("lblSuburbName")).Text.ToString();
                txtPostalCode.Text = ((Label)row.FindControl("lblPostalCode")).Text.ToString();
                ddlCity.SelectedValue = ((Label)row.FindControl("lblCity")).Text.ToString();
                ddlProvince.SelectedValue = ((Label)row.FindControl("lblProvince")).Text.ToString();
                ddlCountry.SelectedValue = ((Label)row.FindControl("lblCountry")).Text.ToString();

            }
            else if (e.CommandName == "Delete")
            {
                ViewState["flag"] = 1;
                lbldeletemessage.Text = "Are you sure, you want to delete Location Details?";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
            }

        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            locationEntity.LocationID = Convert.ToInt32(ViewState["LocationID"]);
            locationEntity.LocationName = txtLocationName.Text;
            locationEntity.MobileNum = txtMobileNum.Text;
            locationEntity.TelephoneNum = txtTelNum.Text;
            locationEntity.PrimaryEmail = txtPrimaryEmail.Text;
            locationEntity.SecondaryEmail = txtSecondaryEmail.Text;
            locationEntity.VatPercentage = txtVatPerc.Text;
            locationEntity.VatRegistration = txtVatReg.Text;
            locationEntity.PlotNo = txtPlotNo.Text;
            locationEntity.BuildingName = txtBuildingName.Text;
            locationEntity.FloorNo = txtFloorNo.Text;
            locationEntity.FlatNo = txtFlatNo.Text;
            locationEntity.RoadName = txtRoadName.Text;
            locationEntity.RoadNo = txtRoadNum.Text;
            locationEntity.SuburbName = txtSuburbName.Text;
            locationEntity.PostalCode = txtPostalCode.Text;
            locationEntity.City = Convert.ToInt32(ddlCity.SelectedValue);
            locationEntity.Province = Convert.ToInt32(ddlProvince.SelectedValue);
            locationEntity.Country = Convert.ToInt32(ddlCountry.SelectedValue);
            locationEntity.UpdatedBy = 0;


            int result = locationBL.LocationCRUD(locationEntity, 'u');
            if (result == 1)
            {
                message.Text = "Location details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindLocation();
                btnUpdate.Visible = false;
                btnSubmit.Visible = true;
            }
            else
            {
                message.Text = "Please try again!";
                Clear();
                BindLocation();
            }
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void gvLocation_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ps"] = DropPage.SelectedItem.ToString().Trim();
            BindLocation();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["flag"]) == 1)
            {
                int result = locationBL.DeleteChildDetails(Convert.ToInt32(ViewState["LocationID"]));
                if (result == 1)
                {
                    BindLocation();
                }
            }
        }
        catch 
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void gvLocation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvLocation.PageIndex = e.NewPageIndex;
            BindLocation();
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please try again";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}