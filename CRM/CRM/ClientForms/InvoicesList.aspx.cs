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

public partial class ClientForms_InvoicesList : System.Web.UI.Page
{
    InvoiceBL invoiceBL = new InvoiceBL();
    CommanClass _objComman = new CommanClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string strPreviousPage = "";
            if (Request.UrlReferrer != null)
            {
                strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];

                if (Session["SAID"] == null || Session["SAID"].ToString() == "")
                {
                    Response.Redirect("../ClientLogin.aspx", false);
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
                Response.Redirect("~/ClientLogin.aspx");
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
            string said = Session["SAID"].ToString();
            DataSet dataset=new DataSet();
            dataset = invoiceBL.GetInvoiceByClient(said);
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {               
                gvInvoiceList.DataSource = dataset;
                gvInvoiceList.DataBind();               
                search.Visible = true;
                InvoiceList.Visible = true;
            }
            else
            {
                search.Visible = false;
                InvoiceList.Visible = false;
            }
            gvInvoiceList.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvInvoiceList.DataBind();
        }
        catch
        {
           
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvInvoiceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvInvoiceList.PageIndex = e.NewPageIndex;
            GetGridData();
        }
        catch
        {
        }
    }
    protected void imgPDF_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;

        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string InvNo = gvInvoiceList.DataKeys[gvrow.RowIndex].Value.ToString();


        string path = Server.MapPath("~/InvoiceDocuments/" + "Invoice " + InvNo + ".pdf");

        WebClient client = new WebClient();
        Byte[] buffer = client.DownloadData(path);
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-length", buffer.Length.ToString());
        Response.BinaryWrite(buffer);
    }
}