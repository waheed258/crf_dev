using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using EntityManager;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class AdminForms_InvoiceReport : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    InvoiceBL invoiceBL = new InvoiceBL();
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
    private void GetGridData()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = invoiceBL.GetInvoiceReport();
            if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvInvoiceReport.DataSource = ds;
                search.Visible = true;
                InvoiceList.Visible = true;
            }
            else
            {
                search.Visible = false;
                InvoiceList.Visible = false;
            }
            gvInvoiceReport.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvInvoiceReport.DataBind();
        }
        catch { }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvInvoiceReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInvoiceReport.PageIndex = e.NewPageIndex;
        GetGridData();
    }

    protected void imgbtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string datetime = DateTime.Now.ToString();
            string FileName = "InvoiceReport " + datetime + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvInvoiceReport.GridLines = GridLines.Both;
            gvInvoiceReport.HeaderStyle.Font.Bold = true;
            gvInvoiceReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
        catch { }
    }
    protected void imgpdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            PdfPTable pdfptable = new PdfPTable(gvInvoiceReport.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in gvInvoiceReport.HeaderRow.Cells)
            {

                Font font = new Font();
                font.Color = GrayColor.BLUE;
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfptable.AddCell(pdfCell);

            }
            foreach (GridViewRow gridviewrow in gvInvoiceReport.Rows)
            {
                foreach (TableCell tableCell in gridviewrow.Cells)
                {

                    tableCell.BackColor = gvInvoiceReport.HeaderStyle.BackColor;
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text.Trim()));
                    pdfptable.AddCell(pdfCell);

                }

            }
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfptable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=LeadList.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
        catch { }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        try
        {

        }
        catch { }
        // Verifies that the control is rendered /
    }
    protected void gvInvoiceReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType.Equals(DataControlRowType.DataRow))
        {
            e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));
        }
    }
}