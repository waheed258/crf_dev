using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityManager;
using BusinessLogic;
using System.Data;
using System.IO;
using System.Text;

public partial class AdminForms_AdminDocument : System.Web.UI.Page
{
    ClientProfileBL _ObjClientProfileBL = new ClientProfileBL();
    DataSet ds = new DataSet();
    EncryptDecrypt ObjEn = new EncryptDecrypt();
    ClientDcoumentAdvisorBL _ObjClientDcoumentAdvisorBL = new ClientDcoumentAdvisorBL();
    AdminDocumentEntity AdminDocumentEntity = new AdminDocumentEntity();
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
                        _objComman.getRecordsPerPage(DropPage);
                        GetClientPersonal();
                        GetClientDcoument(ddlDocumentType);
                        GetAdminDouments();
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
                ClearService();
                GetAdminDouments();
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
        Response.Redirect("ActiveClientList.aspx", false);
    }
     
    private void ClearService()
    {
        hfDocID.Value = "0";
        ddlDocumentType.SelectedIndex = -1;
        lblFileName.Text = "";
        fuDocument.AllowMultiple = true;
     }


    private int InsertDocument()
    {
        DocumentBL _objDocBL = new DocumentBL();
        int res = 0;
        if (fuDocument.HasFile)
        {
            List<HttpPostedFile> lst = fuDocument.PostedFiles.ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                //HttpPostedFile uploadfile = lst[i];
                string inFilename = fuDocument.PostedFiles[i].FileName;
                string strfile = Path.GetExtension(inFilename);
                string date = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                var folder = Server.MapPath("~/AdminDocuments/" + ObjEn.Decrypt(Request.QueryString["x"].ToString()) + "/" + "AdminRequest");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                string fileName = date + strfile;
                fuDocument.SaveAs(Path.Combine(folder, fileName));
                AdminDocumentEntity AdminDocumentEntity = new AdminDocumentEntity 
                {
                    DocId =Convert.ToInt32(hfDocID.Value),
                    SAID = txtSaId.Text.ToString(),                    
                    Document = fileName,
                    DocumentName = inFilename,
                    DocType = Convert.ToInt32(ddlDocumentType.SelectedValue),                  
                    AdvisorID = Convert.ToInt32(Session["AdvisorID"].ToString()),
                    Status = 1,
                };
                 if (btnSubmit.Text == "Update")
                     res = _ObjClientDcoumentAdvisorBL.AdminDocumentManager(AdminDocumentEntity, 'u');
                 else
                     res = _ObjClientDcoumentAdvisorBL.AdminDocumentManager(AdminDocumentEntity, 'i');
            }
        }
        return res;
    }

    private void GetAdminDouments()
     {
         ds = _ObjClientDcoumentAdvisorBL.GetDocuments(txtSaId.Text,0);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            search.Visible = true;
            gvDocument.DataSource = ds.Tables[0];
        }
        else
        {
            search.Visible = false;
            gvDocument.DataSource = null;
        }
          gvDocument.PageSize = Convert.ToInt32(DropPage.SelectedValue.ToString());
          gvDocument.DataBind();
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
                    BindAdminDocument(DocID);
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


    private void BindAdminDocument(int DocId) 
    {
        ds = _ObjClientDcoumentAdvisorBL.GetAdminDocumentById(DocId);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            hfDocID.Value = Convert.ToString(ds.Tables[0].Rows[0]["DocId"]);
            ddlDocumentType.SelectedIndex = ddlDocumentType.Items.IndexOf(ddlDocumentType.Items.FindByValue(ds.Tables[0].Rows[0]["DocType"].ToString()));
            lblFileName.Text = ds.Tables[0].Rows[0]["DocumentName"].ToString();
        }
    }

    protected void gvDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        try
        {
            gvDocument.PageIndex = e.NewPageIndex;
            GetAdminDouments();
        }
        catch { }
    }

    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetAdminDouments();
        }
        catch { }
    }

  

    protected void btnSure_Click(object sender, EventArgs e)
    {
        try
        {
            int res = _ObjClientDcoumentAdvisorBL.DeleteAdminDocument(Convert.ToInt32(ViewState["DocId"]));
            if (res > 0)
            {
                var folder = Server.MapPath("~/AdminDocuments/" + ObjEn.Decrypt(Request.QueryString["x"].ToString()) + "/" + "AdminRequest");
                if (File.Exists(Path.Combine(folder, hfDocumentName.Value.ToString())))
                {
                    //delete file in folder
                    File.Delete(Path.Combine(folder, hfDocumentName.Value.ToString()));
                }
                GetAdminDouments();
                ClearService();
                message.Text = "Succesfully Delete Document";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }
        }
        catch
        {
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    

    private void GetClientPersonal()
    {
        try
        {
            DataSet ds = _ObjClientProfileBL.GetClientPersonal(ObjEn.Decrypt(Request.QueryString["x"].ToString()));
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtSaId.Text = ds.Tables[0].Rows[0]["SAID"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
            }
           
        }
        catch
        {
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    

    public void GetClientDcoument(DropDownList ddlDocumentType)  
    {
        try
        {
            ds = _ObjClientDcoumentAdvisorBL.GetClientDocuments();
            ddlDocumentType.DataSource = ds;
            ddlDocumentType.DataTextField = "ClientDocumentsName";
            ddlDocumentType.DataValueField = "ClientDocumentsid";
            ddlDocumentType.DataBind();
            ddlDocumentType.Items.Insert(0, new ListItem("--Select ClientDcoument--", "-1"));
        }
        catch
        {

        }
    }

     
}