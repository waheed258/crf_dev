using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
using System.Net;


public partial class AdminForms_SRWiseInvoiceList : System.Web.UI.Page
{
    InvoiceBL invoiceBL = new InvoiceBL();
    CommanClass _objComman = new CommanClass();
    string invoicenum = string.Empty;
    string invamount = string.Empty;
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
                        GetGridData();
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

        }
    }

    protected void GetGridData()
    {
        try
        {
            string srno = ObjDec.Decrypt(Request.QueryString["srnum"].ToString());    
            DataSet dataset = new DataSet();
            dataset = invoiceBL.GetInvoice(srno);
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvSRInvoiceList.DataSource = dataset;
                gvSRInvoiceList.DataBind();
                invoicenum = dataset.Tables[0].Rows[0]["InvoiceNum"].ToString();
                invamount = dataset.Tables[0].Rows[0]["TotalAmount"].ToString();
                search.Visible = true;
                InvoiceList.Visible = true;
            }
            else
            {
                search.Visible = false;
                InvoiceList.Visible = false;
            }
            gvSRInvoiceList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvSRInvoiceList.DataBind();
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvSRInvoiceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvSRInvoiceList.PageIndex = e.NewPageIndex;
            GetGridData();
        }
        catch
        {
        }
    }
  
    protected void gvSRInvoiceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                ImageButton InvoiceButton = (ImageButton)row.FindControl("imgInvoiceList");
                int RowIndex = row.RowIndex;
                ViewState["InvoiceNum"] = ((Label)row.FindControl("lblInvoiceNum")).Text.ToString();
                ViewState["Amount"] = ((Label)row.FindControl("lblAmount")).Text.ToString();
                if (e.CommandName == "Payment")
                {
                    Response.Redirect("InvoicePayment.aspx?payment=" + ObjDec.Encrypt(ViewState["InvoiceNum"].ToString()));
                }
            }
        }
        catch { }

    }
    protected void imgPDF_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;

        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string InvNo = gvSRInvoiceList.DataKeys[gvrow.RowIndex].Value.ToString();


        string path = Server.MapPath("~/InvoiceDocuments/" + "Invoice " + InvNo + ".pdf");

        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-length", buffer.Length.ToString());
        Response.BinaryWrite(buffer);
    }
}