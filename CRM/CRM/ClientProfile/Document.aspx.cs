﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using BusinessLogic;
using System.Web.Services;
using System.Web.Script.Services;

public partial class ClientProfile_Document : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DocumentBL _objDocumentBL = new DocumentBL();
    CommanClass _objComman = new CommanClass();
    EncryptDecrypt ObjDec = new EncryptDecrypt();
    static Dictionary<string, string> allDocType = new Dictionary<string, string>();

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
                        _objComman.getRecordsPerPage(DropPage);
                        GetUICSAId();
                        GetDocuType();
                        GetDouments();
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

    #region Private Methods
    private void GetUICSAId()
    {
        try
        {
            switch (ObjDec.Decrypt(Request.QueryString["t"]))
            {
                case "1":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = "0";
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Client Documents";
                    ViewState["FoldertName"] = "Client";
                    break;
                case "2":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = "0";
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Spouse Documents";
                    ViewState["FoldertName"] = "Spouse";
                    break;

                case "3":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = "0";
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Child Documents";
                    ViewState["FoldertName"] = "Child";
                    break;

                case "4":
                    txtSAID.Text = Session["TrustUIC"].ToString();
                    lblName.Text = "Trust Registration #";
                    hfUIC.Value = Session["TrustUIC"].ToString();
                    hfSAID.Value = "0";
                    lblHeading.Text = "Trust Documents";
                    ViewState["FoldertName"] = "Trust";
                    break;

                case "5":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = Session["TrustUIC"].ToString();
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Trust Settlor Documents";
                    ViewState["FoldertName"] = "Settlor";
                    break;

                case "6":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = Session["TrustUIC"].ToString();
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Trustee Documents";
                    ViewState["FoldertName"] = "Trustee";
                    break;

                case "7":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = Session["TrustUIC"].ToString();
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Share Holder Documents";
                    ViewState["FoldertName"] = "Beneficiary";
                    break;

                case "8":
                    txtSAID.Text = Session["CompanyUIC"].ToString();
                    lblName.Text = "Company Registration #";
                    hfUIC.Value = Session["CompanyUIC"].ToString();
                    hfSAID.Value = "0";
                    lblHeading.Text = "Company Documents";
                    ViewState["FoldertName"] = "Company";
                    break;
                case "9":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = Session["CompanyUIC"].ToString();
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Director Documents";
                    ViewState["FoldertName"] = "Director";
                    break;
                case "10":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "GrandChildren #";
                    hfUIC.Value = "0";
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "GrandChildren Documents";
                    ViewState["FoldertName"] = "GrandChildren";
                    break;
                case "11":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Parent #";
                    hfUIC.Value = "0";
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Parent Documents";
                    ViewState["FoldertName"] = "Parent";
                    break;
                case "12":
                    txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                    lblName.Text = "Identification #";
                    hfUIC.Value = Session["CompanyUIC"].ToString();
                    hfSAID.Value = txtSAID.Text;
                    lblHeading.Text = "Share Holder Documents";
                    ViewState["FoldertName"] = "Share Holder";
                    break;
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
    private void GetDocuType()
    {
        try
        {
            ds = _objDocumentBL.GetDocumentType();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //ddlDocType.Items.Clear();
                //ddlDocType.Items.Add(new ListItem("-Select-", "-1"));
                //ddlDocType.DataSource = ds.Tables[0];
                //ddlDocType.DataTextField = "DocumentType";
                //ddlDocType.DataValueField = "TypeId";
                //ddlDocType.DataBind();
                allDocType = ds.Tables[0].AsEnumerable().ToDictionary<DataRow, string, string>(row => row.Field<int>(0).ToString(), row => row.Field<string>(1));
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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static Dictionary<string, string> GetDocumnetTypes(string pre)
    {
        return allDocType;
    }
    private int InsertDocument()
    {
        DocumentBL _objDocBL = new DocumentBL();
        int res = 0;
        if (fuDoc.HasFile)
        {
            HttpPostedFile file = fuDoc.PostedFile;
            int filesize = file.ContentLength;
            //if (filesize <= 1048576)
            //{
                List<HttpPostedFile> lst = fuDoc.PostedFiles.ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    string inFilename = lst[i].FileName;
                    string strfile = Path.GetExtension(inFilename);
                    string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    var folder = Server.MapPath("~/ClientDocuments/" + Session["SAID"].ToString() + "/" + ViewState["FoldertName"].ToString() + "/" + txtSAID.Text.Trim());
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    string fileName = date + strfile;
                    fuDoc.SaveAs(Path.Combine(folder, fileName));

                    if (File.Exists(Path.Combine(folder, hfDocumentName.Value.ToString())))
                    {
                        //delete file in folder
                        File.Delete(Path.Combine(folder, hfDocumentName.Value.ToString()));
                    }
                    int DocID = 0;
                    if (Convert.ToInt32(hfID.Value) == 0)
                    {
                        DocID = _objDocBL.InsertDocType(txtDocumentType.Text);
                    }
                    else
                    {
                        DocID = Convert.ToInt32(hfID.Value);
                    }   
                    DocumentBO DocumentEntity = new DocumentBO
                    {
                        DocId = Convert.ToInt32(hfDocID.Value),
                        ReferenceSAID = Session["SAID"].ToString(),
                        SAID = hfSAID.Value.ToString(),
                        UIC = hfUIC.Value.ToString(),
                        Document = fileName,
                        DocumentName = inFilename,
                        //DocType = Convert.ToInt32(ddlDocType.SelectedValue),
                        DocType = DocID,
                        ClientType = Request.QueryString["t"] != null ? Convert.ToInt32(ObjDec.Decrypt(Request.QueryString["t"])) : 0,
                        AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),
                        Status = 1,
                    };

                    if (btnSubmit.Text == "Update")
                        res = _objDocBL.DocumentManager(DocumentEntity, 'u');
                    else
                        res = _objDocBL.DocumentManager(DocumentEntity, 'i');
                }
                lblSizeError.Text = "";
            //}
            //else
            //{
            //    lblSizeError.ForeColor = System.Drawing.Color.Red;
            //    lblSizeError.Text = "Sorry,the document size should be less than 1MB";
            //}
        }
        return res;

    }
    private void GetDouments()
    {
        try
        {

            int CliType = Request.QueryString["t"] != null ? Convert.ToInt32(ObjDec.Decrypt(Request.QueryString["t"])) : 0;

            ds = _objDocumentBL.GetDocuments(hfSAID.Value.ToString(), hfUIC.Value.ToString(), CliType, Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvDocument.DataSource = ds.Tables[0];
                search.Visible = true;
            }
            else
            {
                gvDocument.DataSource = null;
                search.Visible = false;
            }
            gvDocument.PageSize = Convert.ToInt32(DropPage.SelectedValue.ToString());
            gvDocument.DataBind();
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

    private void BindDocument(int DocId)
    {
        try
        {
            ds = _objDocumentBL.GetDocumentById(DocId, Session["SAID"].ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                hfDocID.Value = ds.Tables[0].Rows[0]["DocId"].ToString();
                if (ds.Tables[0].Rows[0]["SAID"].ToString() == "0")
                    txtSAID.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
                else
                    txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                //ddlDocType.SelectedIndex = ddlDocType.Items.IndexOf(ddlDocType.Items.FindByValue(ds.Tables[0].Rows[0]["DocType"].ToString()));
                txtDocumentType.Text = allDocType[ds.Tables[0].Rows[0]["DocType"].ToString()];
                lblFileName.Text = ds.Tables[0].Rows[0]["DocumentName"].ToString();
                hfDocumentName.Value = ds.Tables[0].Rows[0]["Document"].ToString();

                fuDoc.AllowMultiple = false;
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

    private void ClearControls()
    {
        btnSubmit.Text = "Save";
        //ddlDocType.SelectedIndex = -1;
        txtDocumentType.Text = "";
        lblFileName.Text = "";
        fuDoc.AllowMultiple = true;
    }

    #endregion

    #region Events
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int result = InsertDocument();
            if (result > 0)
            {
                if (btnSubmit.Text == "Update")
                    message.Text = "Document updated successfully!";
                else
                    message.Text = "Documents saved successfully!";
                GetDocuType();
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearControls();
                GetDouments();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ObjDec.Decrypt(Request.QueryString["t"].ToString()))
            {
                case "1":
                    Response.Redirect("ClientPersonal.aspx", false);
                    break;
                case "2":
                    Response.Redirect("Spouse.aspx", false);
                    break;
                case "3":
                    Response.Redirect("Children.aspx", false);
                    break;
                case "4":
                    if (Session["TypeFlag"].ToString() == "1")
                    {
                        Response.Redirect("TrustDetails.aspx", false);
                    }
                    else if (Session["TypeFlag"].ToString() == "3")
                    {
                        Response.Redirect("TrustPersonal.aspx", false);
                    }
                    break;
                case "5":
                    Response.Redirect("TrustSettlor.aspx", false);
                    break;
                case "6":
                    Response.Redirect("Trustee.aspx", false);
                    break;
                case "7":
                    if (Request.QueryString["type"] == "t")
                        Response.Redirect("Beneficiary.aspx?t=" + ObjDec.Encrypt("1"), false);
                    else
                        Response.Redirect("Beneficiary.aspx?t=" + ObjDec.Encrypt("2"), false);
                    break;
                case "8":
                    if (Session["TypeFlag"].ToString() == "1")
                    {
                        Response.Redirect("Company.aspx", false);
                    }
                    else if (Session["TypeFlag"].ToString() == "2")
                    {
                        Response.Redirect("CompanyPersonal.aspx", false);
                    }
                    break;
                case "9":
                    Response.Redirect("Director.aspx", false);
                    break;
                case "10":
                    Response.Redirect("GrandChildren.aspx", false);
                    break;
                case "11":
                    Response.Redirect("Parents.aspx", false);
                    break;
                case "12":
                    if (Request.QueryString["type"] == "t")
                        Response.Redirect("Beneficiary.aspx?t=" + ObjDec.Encrypt("1"), false);
                    else
                        Response.Redirect("Beneficiary.aspx?t=" + ObjDec.Encrypt("2"), false);
                    break;
            }
            ClearControls();
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
    protected void gvDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDocument.PageIndex = e.NewPageIndex;
            GetDouments();
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
    protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int RowIndex = row.RowIndex;
                ViewState["ClientType"] = ((Label)row.FindControl("lblClientType")).Text.ToString();
                ViewState["DocId"] = ((Label)row.FindControl("lblDocId")).Text.ToString();
                ViewState["ReferenceSAID"] = ((Label)row.FindControl("lblReferenceSAID")).Text.ToString();
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["UIC"] = ((Label)row.FindControl("lblUIC")).Text.ToString();
                ViewState["ClientTypeID"] = ((Label)row.FindControl("lblClientTypeID")).Text.ToString();
                int DocID = Convert.ToInt32(ViewState["DocId"].ToString());
                if (e.CommandName == "EditDoc")
                {
                    BindDocument(DocID);
                    btnSubmit.Text = "Update";
                }
                else if (e.CommandName == "DeleteDec")
                {
                    string[] strparas = e.CommandArgument.ToString().Split(new char[] { ',' });
                    ViewState["DocId"] = Convert.ToInt32(strparas[0]);
                    hfDocumentName.Value = strparas[1];
                    lbldeletemessage.Text = "Are you sure, you want to delete Document ?";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
                }
                else if (e.CommandName == "Validate")
                {
                    if (ViewState["SAID"].ToString() != "0" && ViewState["UIC"].ToString() == "0")
                    {
                        divSAID.Visible = true;
                        divUIC.Visible = false;
                    }
                    else if (ViewState["SAID"].ToString() == "0" && ViewState["UIC"].ToString() != "0")
                    {
                        divSAID.Visible = false;
                        divUIC.Visible = true;
                    }
                    else if (ViewState["SAID"].ToString() != "0" && ViewState["UIC"].ToString() != "0")
                    {
                        divSAID.Visible = true;
                        divUIC.Visible = true;
                    }
                    txtvalidSAID.Text = ((Label)row.FindControl("lblSAID")).Text.ToString();
                    txtvalidUIC.Text = ((Label)row.FindControl("lblUIC")).Text.ToString();
                    txtDocType.Text = ((Label)row.FindControl("lblDocType")).Text.ToString();
                    lblDocName.Text = ((Label)row.FindControl("lblDocumentName")).Text.ToString();
                    validatedocmsg.InnerText = "Document Details";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openValidateModal();", true);

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
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetDouments();
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
    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            int res = _objDocumentBL.DeleteDocument(Convert.ToInt32(ViewState["DocId"]), Session["SAID"].ToString());
            if (res > 0)
            {
                var folder = Server.MapPath("~/ClientDocuments/" + Session["SAID"].ToString() + "/" + ViewState["FoldertName"].ToString() + "/" + txtSAID.Text.Trim());
                if (File.Exists(Path.Combine(folder, hfDocumentName.Value.ToString())))
                {
                    //delete file in folder
                    File.Delete(Path.Combine(folder, hfDocumentName.Value.ToString()));
                }
                GetDouments();
                ClearControls();
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

    #endregion

    protected void gvDocument_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblDoc = (Label)e.Row.FindControl("lblDoc");
                HtmlAnchor AnchorDoc = (HtmlAnchor)e.Row.FindControl("anchorId");
                string url = HttpContext.Current.Request.Url.Authority;
                AnchorDoc.HRef = "http://" + url + "/ClientDocuments/" + Session["SAID"].ToString() + "/" + ViewState["FoldertName"].ToString() + "/" + txtSAID.Text.Trim() + "/" + LblDoc.Text;

                DataRowView drv = e.Row.DataItem as DataRowView;
                if (drv["Flag"].ToString().Equals("0") && drv["AdvisorID"].ToString() != "0")
                {
                    if (Session["Designation"].ToString() == "1" && Session["isContentValidator"].ToString() == "True")
                    {
                       // e.Row.BackColor = System.Drawing.Color.LightPink;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                      //  ((Image)e.Row.FindControl("imgbtnValidate")).Visible = true;

                    }
                    else if (Session["Designation"].ToString() == "1" && Session["isContentValidator"].ToString() == "False")
                    {
                       // e.Row.BackColor = System.Drawing.Color.LightPink;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = false;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = false;
                       // ((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;
                    }
                    else if (Session["Designation"].ToString() == "2" && Session["isContentValidator"].ToString() == "False")
                    {
                       // e.Row.BackColor = System.Drawing.Color.LightPink;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = false;
                       // ((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;
                    }
                }

                else
                {
                    if (Session["Designation"].ToString() == "1" && Session["isContentValidator"].ToString() == "True")
                    {
                       // e.Row.BackColor = System.Drawing.Color.White;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                       // ((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;

                    }
                    else if (Session["Designation"].ToString() == "1" && Session["isContentValidator"].ToString() == "False")
                    {
                     //   e.Row.BackColor = System.Drawing.Color.White;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = true;
                       // ((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;
                    }
                    else if (Session["Designation"].ToString() == "2" && Session["isContentValidator"].ToString() == "False")
                    {
                       // e.Row.BackColor = System.Drawing.Color.White;
                        ((Image)e.Row.FindControl("btnEdit")).Visible = true;
                        ((Image)e.Row.FindControl("btnDelete")).Visible = false;
                        //((Image)e.Row.FindControl("imgbtnValidate")).Visible = false;
                    }
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


    protected void btnvalidDocOK_Click(object sender, EventArgs e)
    {
        try
        {
            int DocID = Convert.ToInt32(ViewState["DocId"].ToString());
            int ClientType = Convert.ToInt32(ViewState["ClientTypeID"].ToString());
            int result = _objDocumentBL.UpdateDocumentValidation(ViewState["ReferenceSAID"].ToString(), ViewState["SAID"].ToString(), ViewState["UIC"].ToString(), ClientType, DocID);
            if (result > 0)
            {
                lblTitle.Text = "Thank You!";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Details Validated successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                GetDouments();
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
    protected void btnvalidDocCancel_Click(object sender, EventArgs e)
    {

    }
}