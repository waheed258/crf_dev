using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
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
    ValidateSAIDBL validateSAIDBL = new ValidateSAIDBL();
    AddressAndBankBL addressbankBL = new AddressAndBankBL();

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
                        _objComman.GetCountry(ddlCountry);
                        _objComman.GetProvince(ddlProvince);
                        _objComman.GetCity(ddlCity);
                        _objComman.GetAccountType(ddlAccountType);
                        _objComman.getRecordsPerPage(DropPage);
                        _objComman.getRecordsPerPage(DropPage1);
                        _objComman.getRecordsPerPage(dropPage2);
                        chkClientAddress.Visible = false;
                        GetClientAddress();
                        Disable();
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

    protected void Disable()
    {

        txtFirstName.ReadOnly = true;
        txtLastName.ReadOnly = true;
        txtEmailId.ReadOnly = true;
        txtMobileNum.ReadOnly = true;
        txtPhoneNum.ReadOnly = true;
        txtTaxRefNum.ReadOnly = true;
        txtDateOfBirth.ReadOnly = true;
        ddlTitle.Enabled = false;
        rfvFirstName.Enabled = false;
        //rfvLastName.Enabled = false;
        //rfvMobileNum.Enabled = false;
        //rfvEmailId.Enabled = false;
        fuPhoto.Enabled = false;
        btnChildSubmit.Enabled = false;
        rfvTitle.Enabled = false;
        //rfvDateOfBirth.Enabled = false;
    }
    protected void Enable()
    {

        txtFirstName.ReadOnly = false;
        txtLastName.ReadOnly = false;
        txtEmailId.ReadOnly = false;
        txtMobileNum.ReadOnly = false;
        txtPhoneNum.ReadOnly = false;
        txtTaxRefNum.ReadOnly = false;
        txtDateOfBirth.ReadOnly = false;
        ddlTitle.Enabled = true;
        fuPhoto.Enabled = true;
        btnChildSubmit.Enabled = true;
        rfvFirstName.Enabled = true;
        //rfvLastName.Enabled = true;
        //rfvMobileNum.Enabled = true;
        //rfvEmailId.Enabled = true;
        rfvTitle.Enabled = true;
        //rfvDateOfBirth.Enabled = true;
    }

    protected void btnChildSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = string.Empty;
            string fileNamemain = string.Empty;
            if (fuPhoto.HasFile)
            {
                fuPhoto.SaveAs(Server.MapPath("~/ChildImages/" + txtSAID.Text + this.fuPhoto.FileName));
                fileName = Path.GetFileName(this.fuPhoto.PostedFile.FileName);
                childEntity.Image = "~/ChildImages/" + txtSAID.Text + fileName;
            }
            else
            {
                childEntity.Image = "";
            }
            childEntity.SAID = txtSAID.Text;
            childEntity.Title = ddlTitle.SelectedValue;
            childEntity.FirstName = txtFirstName.Text;
            childEntity.LastName = txtLastName.Text;
            childEntity.Mobile = txtMobileNum.Text;
            childEntity.Phone = txtPhoneNum.Text;
            childEntity.EmailID = txtEmailId.Text;
            childEntity.TaxRefNo = txtTaxRefNum.Text;
            childEntity.DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text;
            childEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            childEntity.ReferenceSAID = Session["SAID"].ToString();

            int result = childBL.ChildCRUD(childEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Child details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                BindChildDetails();
                Disable();
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
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
        //Response.Redirect(Request.Url.AbsoluteUri);
    }


    private void BindChildDetails()
    {
        try
        {
            dataset = childBL.GetAllChilds(Session["SAID"].ToString(), "0");
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvChildDetails.DataSource = dataset;
                search.Visible = true;
                ChildList.Visible = true;
            }
            else
            {
                gvChildDetails.DataSource = null;
                search.Visible = false;
                ChildList.Visible = false;
            }
            gvChildDetails.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvChildDetails.DataBind();
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
                EncryptDecrypt ObjEn = new EncryptDecrypt();
                if (e.CommandName == "Edit")
                {
                    Enable();
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
                    lblPhotoName.Text = (((Label)row.FindControl("lblImage")).Text);
                    anchorId.Attributes["href"] = lblPhotoName.Text;

                }

                else if (e.CommandName == "Document")
                {
                    Response.Redirect("Document.aspx?t=" + ObjEn.Encrypt("3") + "&x=" + ObjEn.Encrypt(ViewState["SAID"].ToString()), false);
                }
                else if (e.CommandName == "Address")
                {
                    DataSet dsAddress = addressbankBL.GetAddressDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), "0");
                    if (dsAddress.Tables[0].Rows.Count > 0)
                    {
                        if (dsAddress.Tables[0].Rows[0]["Type"].ToString() == "3")
                        {
                            ClearAddress();
                        }
                        else
                        {
                            txtHouseNo.Text = dsAddress.Tables[0].Rows[0]["HouseNo"].ToString();
                            txtBulding.Text = dsAddress.Tables[0].Rows[0]["BuildingName"].ToString();
                            txtFloor.Text = dsAddress.Tables[0].Rows[0]["FloorNo"].ToString();
                            txtFlatNo.Text = dsAddress.Tables[0].Rows[0]["FlatNo"].ToString();
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

                else if (e.CommandName == "Bank")
                {
                    DataSet dsBank = addressbankBL.GetBankDetails(ViewState["SAID"].ToString(), Session["SAID"].ToString(), "0");
                    if (dsBank.Tables[0].Rows.Count > 0)
                    {

                        if (dsBank.Tables[0].Rows[0]["Type"].ToString() == "3")
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            childEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString());
            childEntity.DateOfBirth = string.IsNullOrEmpty(txtDateOfBirth.Text) ? null : txtDateOfBirth.Text;
            string fileName = string.Empty;
            string fileNamemain = string.Empty;
            if (lblPhotoName.Text != "" && fuPhoto.HasFile == false)
            {
                childEntity.Image = lblPhotoName.Text;
            }
            else
            {
                fuPhoto.SaveAs(Server.MapPath("~/ChildImages/" + txtSAID.Text + this.fuPhoto.FileName));
                fileName = Path.GetFileName(this.fuPhoto.PostedFile.FileName);
                childEntity.Image = "~/ChildImages/" + txtSAID.Text + fileName;
            }
            int result = childBL.ChildCRUD(childEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Child details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Clear();
                Disable();
                BindChildDetails();
                BindBankDetails();
                BindAddressDetails();
                btnChildUpdate.Visible = false;
                btnChildSubmit.Visible = true;
                txtSAID.ReadOnly = false;
            }
            else
            {
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Child Information not updated please check the Details !!";
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
        //Response.Redirect(Request.Url.AbsoluteUri);        
    }

    protected void gvChildDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void BindAddressDetails()
    {
        try
        {
            dataset = addressBL.GetAddressDetails(Session["SAID"].ToString(), 3,"");
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvAddress.DataSource = dataset;
                searchaddress.Visible = true;
            }
            else
            {
                gvAddress.DataSource = null;
                searchaddress.Visible = false;
            }
            gvAddress.PageSize = Convert.ToInt32(DropPage1.SelectedValue);
            gvAddress.DataBind();
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

    protected void BindBankDetails()
    {
        try
        {
            dataset = bankBL.GetBankList(Session["SAID"].ToString(), 3,"");
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                searchbank.Visible = true;
                gdvBankList.DataSource = dataset;
            }
            else
            {
                gdvBankList.DataSource = null;
                searchbank.Visible = false;
            }
            gdvBankList.PageSize = Convert.ToInt32(dropPage2.SelectedValue);
            gdvBankList.DataBind();
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


    protected void btnChildCancel_Click(object sender, EventArgs e)
    {
        Clear();
        Response.Redirect("Children.aspx");
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
        lblPhotoName.Text = "";


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
        chkClientAddress.Checked = false;
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
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()); 
            bankEntity.UpdatedBy = 0;
            int result = bankBL.CURDBankInfo(bankEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                BindBankDetails();
            }
            else
            {
                ClearBank();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            bankEntity.AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()); 
            bankEntity.UpdatedBy = 0;

            int result = bankBL.CURDBankInfo(bankEntity, 'u');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Bank details updated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearBank();
                BindBankDetails();
            }
            else
            {
                ClearBank();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);              
                BindBankDetails();
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
            addressEntity.AdvisorId = Convert.ToInt32(Session["AdvisorID"].ToString());
            addressEntity.CreatedBy = 0;

            int result = addressBL.InsertUpdateAddress(addressEntity, 'i');
            if (result == 1)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Address details saved successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearAddress();
                BindAddressDetails();

            }
            else
            {                
                ClearAddress();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
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

    protected void btnAddressCancel_Click(object sender, EventArgs e)
    {
        ClearAddress();
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
                    chkClientAddress.Visible = false;
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
                BindAddressDetails();
            }
            else
            {            
                ClearAddress();
                lblTitle.Text = "Warning!";
                lblTitle.ForeColor = System.Drawing.Color.Red;
                message.ForeColor = System.Drawing.Color.Red;
                message.Text = "Sorry,Please Try Again";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindAddressDetails();
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
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
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindChildDetails();

    }

    protected void DropPage1_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindAddressDetails();

    }


    protected void dropPage2_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindBankDetails();

    }


    protected void chkClientAddress_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkClientAddress.Checked)
            {
                DataSet ds = (DataSet)ViewState["ClientAddress"];
                if (ds.Tables.Count > 0)
                {
                    txtHouseNo.Text = ds.Tables[0].Rows[0]["HouseNo"].ToString();
                    txtBulding.Text = ds.Tables[0].Rows[0]["BuildingName"].ToString();
                    txtFloor.Text = ds.Tables[0].Rows[0]["FloorNo"].ToString();
                    txtFlatNo.Text = ds.Tables[0].Rows[0]["FlatNo"].ToString();
                    txtRoadName.Text = ds.Tables[0].Rows[0]["RoadName"].ToString();
                    txtRoadNo.Text = ds.Tables[0].Rows[0]["RoadNo"].ToString();
                    txtSuburbName.Text = ds.Tables[0].Rows[0]["SuburbName"].ToString();
                    ddlCity.SelectedValue = ds.Tables[0].Rows[0]["City"].ToString();
                    ddlProvince.SelectedValue = ds.Tables[0].Rows[0]["Province"].ToString();
                    ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                    txtPostalCode.Text = ds.Tables[0].Rows[0]["PostalCode"].ToString();
                }
            }
            else
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
        }
        catch {
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

            dataset = validateSAIDBL.ValidateSAID(txtSAID.Text, Session["SAID"].ToString(), "0");

            if (dataset.Tables[0].Rows.Count > 0)
            {
                if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "CLIENT")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, Client can't be a Child!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT" && dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() == "2")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry, Duplicate Child ID!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() == "1")
                {
                    lblTitle.Text = "Warning!";
                    lblTitle.ForeColor = System.Drawing.Color.Red;
                    message.ForeColor = System.Drawing.Color.Red;
                    message.Text = "Sorry,The member already exists as Spouse, you cannot add as Child!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() != "1" && dataset.Tables[0].Rows[0]["MEMBERTYPE"].ToString() != "2"
                    && dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS WITH CLIENT")
                {
                    btnChildSubmit.Enabled = true;
                    ddlTitle.SelectedValue = dataset.Tables[0].Rows[0]["Title"].ToString();
                    txtFirstName.Text = dataset.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = dataset.Tables[0].Rows[0]["LastName"].ToString();
                    txtEmailId.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
                    txtMobileNum.Text = dataset.Tables[0].Rows[0]["Mobile"].ToString();
                    txtPhoneNum.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                    txtTaxRefNum.Text = dataset.Tables[0].Rows[0]["TaxRefNo"].ToString();
                    if (dataset.Tables[0].Rows[0]["DateOfBirth"].ToString() == "")
                        txtDateOfBirth.Text = "";
                    else
                        txtDateOfBirth.Text = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DateOfBirth"].ToString()).ToString("yyyy-MM-dd");                  
                    //DateTime DOB = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DateOfBirth"].ToString());
                    //txtDateOfBirth.Text = DOB.ToShortDateString();
                    //txtDateOfBirth.Text = dataset.Tables[0].Rows[0]["DateOfBirth"].ToString();
                }

                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "NO RECORD")
                {
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    ddlTitle.SelectedValue = "";
                    txtPhoneNum.Text = "";
                    txtMobileNum.Text = "";
                    txtEmailId.Text = "";
                    txtTaxRefNum.Text = "";
                    txtDateOfBirth.Text = "";
                    Enable();
                }
                else if (dataset.Tables[0].Rows[0]["EXIST"].ToString() == "EXISTS AS INDIVIDUAL")
                {
                    btnChildSubmit.Enabled = true;
                    ddlTitle.SelectedValue = dataset.Tables[0].Rows[0]["Title"].ToString();
                    txtFirstName.Text = dataset.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = dataset.Tables[0].Rows[0]["LastName"].ToString();
                    txtEmailId.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
                    txtMobileNum.Text = dataset.Tables[0].Rows[0]["Mobile"].ToString();
                    txtPhoneNum.Text = dataset.Tables[0].Rows[0]["Phone"].ToString();
                    txtTaxRefNum.Text = dataset.Tables[0].Rows[0]["TaxRefNo"].ToString();
                    DateTime DOB = Convert.ToDateTime(dataset.Tables[0].Rows[0]["DateOfBirth"].ToString());
                    txtDateOfBirth.Text = DOB.ToShortDateString();
                }
               
            }
        }
        catch {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    private void GetClientAddress()
    {
        try
        {
            string CLientSAID = Session["SAID"].ToString();
            DataSet ds = addressBL.GetPrimaryAddrClient(CLientSAID);
            ViewState["ClientAddress"] = ds;
            if (ds.Tables.Count > 0)
            {
                chkClientAddress.Visible = true;

            }
            else
            {
                chkClientAddress.Visible = false;
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

    protected void gvChildDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                    ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                    ((Image)e.Row.FindControl("btnDocument")).Visible = true;
                    ((Image)e.Row.FindControl("btnBank")).Visible = true;
                    ((Image)e.Row.FindControl("btnAddress")).Visible = true;
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