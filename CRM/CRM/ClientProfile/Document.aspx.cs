using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;

public partial class ClientProfile_Document : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DocumentBL _objDocumentBL = new DocumentBL();
    CommanClass _objComman = new CommanClass();
    EncryptDecrypt ObjDec = new EncryptDecrypt();

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
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    #region Private Methods
    private void GetUICSAId()
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
                hfUIC.Value = "0";
                hfSAID.Value = txtSAID.Text;
                lblHeading.Text = "Trust Settlor Documents";
                ViewState["FoldertName"] = "Settlor";
                break;

            case "6":
                txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                lblName.Text = "Identification #";
                hfUIC.Value = "0";
                hfSAID.Value = txtSAID.Text;
                lblHeading.Text = "Trustee Documents";
                ViewState["FoldertName"] = "Trustee";
                break;

            case "7":
                txtSAID.Text = ObjDec.Decrypt(Request.QueryString["x"]);
                lblName.Text = "Identification #";
                hfUIC.Value = "0";
                hfSAID.Value = txtSAID.Text;
                lblHeading.Text = "Beneficiary Documents";
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
                hfUIC.Value = "0";
                hfSAID.Value = txtSAID.Text;
                lblHeading.Text = "Director Documents";
                ViewState["FoldertName"] = "Director";
                break;

        }
    }
    private void GetDocuType()
    {
        ds = _objDocumentBL.GetDocumentType();
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlDocType.Items.Clear();
            ddlDocType.Items.Add(new ListItem("-Select-", "-1"));
            ddlDocType.DataSource = ds.Tables[0];
            ddlDocType.DataTextField = "DocumentType";
            ddlDocType.DataValueField = "TypeId";
            ddlDocType.DataBind();
        }
    }
    private int InsertDocument()
    {
        DocumentBL _objDocBL = new DocumentBL();
        int res = 0;
        if (fuDoc.HasFile)
        {
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

                DocumentBO DocumentEntity = new DocumentBO
                {
                    DocId = Convert.ToInt32(hfDocID.Value),
                    ReferenceSAID = Session["SAID"].ToString(),
                    SAID = hfSAID.Value.ToString(),
                    UIC = hfUIC.Value.ToString(),
                    Document = fileName,
                    DocumentName = inFilename,
                    DocType = Convert.ToInt32(ddlDocType.SelectedValue),
                    ClientType = Request.QueryString["t"] != null ? Convert.ToInt32(ObjDec.Decrypt(Request.QueryString["t"])) : 0,
                    AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),
                    Status = 1,
                };

                if (btnSubmit.Text == "Update")
                    res = _objDocBL.DocumentManager(DocumentEntity, 'u');
                else
                    res = _objDocBL.DocumentManager(DocumentEntity, 'i');
            }
        }
        return res;

    }
    private void GetDouments()
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

    private void BindDocument(int DocId)
    {
        ds = _objDocumentBL.GetDocumentById(DocId, Session["SAID"].ToString());
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hfDocID.Value = ds.Tables[0].Rows[0]["DocId"].ToString();
            if (ds.Tables[0].Rows[0]["SAID"].ToString() == "0")
                txtSAID.Text = ds.Tables[0].Rows[0]["UIC"].ToString();
            else
                txtSAID.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
            ddlDocType.SelectedIndex = ddlDocType.Items.IndexOf(ddlDocType.Items.FindByValue(ds.Tables[0].Rows[0]["DocType"].ToString()));
            lblFileName.Text = ds.Tables[0].Rows[0]["DocumentName"].ToString();
            hfDocumentName.Value = ds.Tables[0].Rows[0]["Document"].ToString();

            fuDoc.AllowMultiple = false;
        }
    }

    private void ClearControls()
    {
        btnSubmit.Text = "Save";
        ddlDocType.SelectedIndex = -1;
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearControls();
                GetDouments();
            }
        }
        catch
        {
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            switch (ObjDec.Decrypt(Request.QueryString["t"].ToString()))
            {
                case  "1":
                    Response.Redirect("ClientPersonal.aspx", false);
                    break;
                case "2":
                    Response.Redirect("Spouse.aspx", false);
                    break;
                case "3":
                    Response.Redirect("ChildDetails.aspx", false);
                    break;
                case "4":
                    Response.Redirect("TrustDetails.aspx", false);
                    break;
                case "5":
                    Response.Redirect("TrustSettlor.aspx", false);
                    break;
                case "6":
                    Response.Redirect("Trustee.aspx", false);
                    break;
                case "7":
                    Response.Redirect("Beneficiary.aspx?t=" + ObjDec.Encrypt("1"), false);
                    break;
                case "8":
                    Response.Redirect("CompanyDetails.aspx", false);
                    break;
                case "9":
                    Response.Redirect("Director.aspx", false);
                    break;
            }
            ClearControls();
        }
        catch { }
    }
    protected void gvDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvDocument.PageIndex = e.NewPageIndex;
            GetDouments();
        }
        catch { }
    }
    protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                if (e.CommandName == "EditDoc")
                {
                    int DocID = Convert.ToInt32(e.CommandArgument.ToString());
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
            }
        }
        catch
        {
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetDouments();
        }
        catch { }
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
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    #endregion
}