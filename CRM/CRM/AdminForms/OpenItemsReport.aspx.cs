using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


public partial class AdminForms_OpenItemsReport : System.Web.UI.Page
{
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    CommanClass _objComman = new CommanClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _objComman.getRecordsPerPage(DropPage);
            GetGridData();
        }
    }
    protected void GetGridData()
    {
        try
        {
            DataSet dataset = new DataSet();
            dataset = serviceRequestBL.OpenItemsReport();
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvOpenItemsReport.DataSource = dataset;
                gvOpenItemsReport.PageSize = Convert.ToInt32(DropPage.SelectedValue);
                gvOpenItemsReport.DataBind();
            }
            else
            {
                gvOpenItemsReport.DataSource = null;
                gvOpenItemsReport.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetGridData();
    }
    protected void gvOpenItemsReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvOpenItemsReport.PageIndex = e.NewPageIndex;
            GetGridData();
        }
        catch
        {
        }
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
            string FileName = "OpenItemsReport " + datetime + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            gvOpenItemsReport.GridLines = GridLines.Both;
            gvOpenItemsReport.HeaderStyle.Font.Bold = true;
            gvOpenItemsReport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
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
        /* Verifies that the control is rendered */
    }
    protected void imgpdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            PdfPTable pdfptable = new PdfPTable(gvOpenItemsReport.HeaderRow.Cells.Count);
            foreach (TableCell headerCell in gvOpenItemsReport.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = GrayColor.BLUE;
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, font));
                pdfptable.AddCell(pdfCell);
            }
            foreach (GridViewRow gridviewrow in gvOpenItemsReport.Rows)
            {
                foreach (TableCell tableCell in gridviewrow.Cells)
                {

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
            Response.AppendHeader("content-disposition", "attachment;filename=OpenItemsReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
        catch { }
    }
    protected void gvOpenItemsReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType.Equals(DataControlRowType.DataRow))
        {
            e.Row.Cells[0].Text = "" + ((((GridView)sender).PageIndex * ((GridView)sender).PageSize) + (e.Row.RowIndex + 1));
        }
    }
}