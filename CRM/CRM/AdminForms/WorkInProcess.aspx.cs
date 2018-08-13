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
using System.Text;
using System.Net;

public partial class AdminForms_WorkInProcess : System.Web.UI.Page
{
    ServiceRequestBL serviceRequestBL = new ServiceRequestBL();
    DataSet dataset = new DataSet();
    InvoiceBL invoiceBL = new InvoiceBL();
    InvoiceEntity invoiceEntity = new InvoiceEntity();
    EncryptDecrypt ObjDec = new EncryptDecrypt();
    FollowUpBL followBL = new FollowUpBL();
    FollowUpEntity followupEntity = new FollowUpEntity();
    CommanClass _objComman = new CommanClass();
    ServiceRequestBL _objServiceRequestBL = new ServiceRequestBL();
    InvoicePaymentBL invoicePaymentBL = new InvoicePaymentBL();

    string emailid = string.Empty;
    string invoicenum = string.Empty;
    decimal totalamount = 0;

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
                        FollowUpSection.Visible = false;
                        InvoiceSection.Visible = false;
                        BindActivityType();
                        BindServiceStatus();

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
    protected void gvWorkInProcess_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Page")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                ImageButton InvoiceButton = (ImageButton)row.FindControl("btnGenerateInvoice");
                ImageButton PDFButton = (ImageButton)row.FindControl("btnPDF");
                int RowIndex = row.RowIndex;
                ViewState["ClientServiceID"] = ((Label)row.FindControl("lblClientServiceID")).Text.ToString();
                ViewState["ServiceName"] = ((Label)row.FindControl("lblServiceName")).Text.ToString();
                ViewState["AdvisorID"] = ((Label)row.FindControl("lblAdvisorID")).Text.ToString();
                ViewState["ClientName"] = ((Label)row.FindControl("lblClientName")).Text.ToString();
                ViewState["SAID"] = ((Label)row.FindControl("lblSAID")).Text.ToString();
                ViewState["Name"] = ((Label)row.FindControl("lblAdvisorName")).Text.ToString();
                ViewState["SRNO"] = ((Label)row.FindControl("lblSRNO")).Text.ToString();
                ViewState["ServiceStatus"] = ((Label)row.FindControl("lblServiceStatusID")).Text.ToString();
                string SRNO = ((Label)row.FindControl("lblSRNO")).Text.ToString();
                int clientServiceID = Convert.ToInt32(((Label)row.FindControl("lblClientServiceID")).Text.ToString());

                if (e.CommandName == "FollowUp")
                {

                    FollowUpSection.Visible = true;
                    sectionRequestList.Visible = false;
                    InvoiceSection.Visible = false;
                    //txtFollowTime.Text = DateTime.Now.ToShortTimeString();
                    txtServiceRequest.Text = ViewState["ServiceName"].ToString();
                    txtClientSAID.Text = ViewState["SAID"].ToString();
                    txtClientName.Text = ViewState["ClientName"].ToString();
                    txtAssignedTo.Text = ViewState["Name"].ToString();
                    BindFollowUp(clientServiceID);
                    if (ViewState["ServiceStatus"].ToString() == "1" || ViewState["ServiceStatus"].ToString() == "2")
                    {
                        dropServiceStatus.SelectedValue = "-1";
                    }
                    else
                    {
                        dropServiceStatus.SelectedValue = ViewState["ServiceStatus"].ToString();
                    }
                    
           
                    if(dropServiceStatus.SelectedValue == "6")
                    {
                        dropServiceStatus.Enabled = false;
                    }

                }
                else if (e.CommandName == "GenerateInvoice")
                {
                    InvoiceSection.Visible = true;
                    FollowUpSection.Visible = false;
                    sectionRequestList.Visible = false;
                    GetPDFClientData(SRNO);                
                    if (chkVatInclusive.Checked == true)
                    {
                        lblvat.Visible = false;
                    }
                    else
                    {
                        lblvat.Visible = true;
                    }

                }
                else if(e.CommandName=="InvoiceList")
                {
                    Response.Redirect("SRWiseInvoiceList.aspx?srnum=" + ObjDec.Encrypt(ViewState["SRNO"].ToString()));                    
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

    protected void FollowUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            followupEntity.ClientServiceID = Convert.ToInt32(ViewState["ClientServiceID"]);
            followupEntity.ServiceRequest = txtServiceRequest.Text;
            followupEntity.ClientSAID = txtClientSAID.Text;
            followupEntity.ClientName = txtClientName.Text;
            followupEntity.AssignedTo = txtAssignedTo.Text;
            followupEntity.FollowUpDate = string.IsNullOrEmpty(txtFollowDate.Text) ? null : txtFollowDate.Text;
            //followupEntity.FollowUpTime = string.IsNullOrEmpty(txtFollowTime.Text) ? null : txtFollowTime.Text;
            followupEntity.DueDate = string.IsNullOrEmpty(txtDueDate.Text) ? null : txtDueDate.Text;
            //followupEntity.DueTime = string.IsNullOrEmpty(txtDueTime.Text) ? null : txtDueTime.Text;
            followupEntity.ActivityType = Convert.ToInt32(dropActivityType.SelectedValue);
            followupEntity.Notes = txtNotes.Text;
            int Result = followBL.FollowUpCRUD(followupEntity, 'i');
            if (Result > 0)
            {
                string srno= ViewState["SRNO"].ToString();
                int status = 0;
                if(dropServiceStatus.SelectedValue =="-1")
                {
                    status = 2;
                }
                else
                {
                    status = Convert.ToInt32(dropServiceStatus.SelectedValue);
                }
               
                int res = serviceRequestBL.UpdateServiceStatus(status, srno);
                Clear();
                TabName.Value = "tab2";
                BindFollowUp(Convert.ToInt32(ViewState["ClientServiceID"]));
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
    protected void FollowClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }

    private void Clear()
    {
        txtFollowDate.Text = "";
        //txtFollowTime.Text = "";
        txtDueDate.Text = "";
        //txtDueTime.Text = "";
        dropActivityType.SelectedValue = "-1";
    }

    private void BindActivityType()
    {
        try
        {
            dataset = serviceRequestBL.GetActivityType();
            dropActivityType.DataSource = dataset;
            dropActivityType.DataTextField = "ActivityType";
            dropActivityType.DataValueField = "ActivityID";
            dropActivityType.DataBind();
            dropActivityType.Items.Insert(0, new ListItem("--Select Mode Of Contact --", "-1"));
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

    private void BindServiceStatus()
    {
        try
        {
            dataset = followBL.GetServiceStatus();
            dropServiceStatus.DataSource = dataset;
            dropServiceStatus.DataTextField = "Status";
            dropServiceStatus.DataValueField = "StatusID";
            dropServiceStatus.DataBind();
            dropServiceStatus.Items.Insert(0, new ListItem("--Select Status --", "-1"));
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

    private void BindFollowUp(int clientServiceID)
    {
        try
        {
            dataset = followBL.GetFollowupUpdates(clientServiceID);
            if(dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gdvUpdatesList.DataSource = dataset;
                gdvUpdatesList.DataBind();
            }
            else
            {
                gdvUpdatesList.DataSource = null;
                gdvUpdatesList.DataBind();
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
    protected void btnFollowListCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }
    protected void GetGridData()
    {
        try
        {
            DataSet dataset = new DataSet();
            dataset = serviceRequestBL.GetWorkInProcess();
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                gvWorkInProcess.DataSource = dataset;
                gvWorkInProcess.PageSize = Convert.ToInt32(DropPage.SelectedValue);
                gvWorkInProcess.DataBind();
            }
            else
            {
                gvWorkInProcess.DataSource = null;
                gvWorkInProcess.DataBind();
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
        txtDescription.Text = "";
        txtAmount.Text = "";
        chkVatInclusive.Checked = false;
    }

    protected void btnInvoiceSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           
            decimal amount = 0;
            decimal vatper = 0;
            decimal incamount = 0;
            decimal subamount = 0;
            int inVat = 0;

            invoiceEntity.Description = txtDescription.Text;
            invoiceEntity.Amount = Convert.ToDecimal(txtAmount.Text);
            invoiceEntity.InvoiceDate = System.DateTime.Now.ToShortDateString();
            invoiceEntity.VatInclusive = Convert.ToInt32(chkVatInclusive.Checked);
            invoiceEntity.ClientSRNO = ViewState["SRNO"].ToString();
            string serviceno = ViewState["SRNO"].ToString();

            amount = Convert.ToDecimal(txtAmount.Text);
            inVat = Convert.ToInt32(chkVatInclusive.Checked);
            if (inVat == 0)
            {
                incamount = Math.Round(amount, 2);
                vatper = Math.Round((amount * Convert.ToDecimal(0.15)) + vatper, 2);
                subamount = Math.Round(amount + vatper, 2);
            }
            else
            {
                incamount = Math.Round((amount / Convert.ToDecimal(1.15)), 2);
                vatper = Math.Round((amount - incamount), 2);
                subamount = Math.Round((incamount + vatper), 2);
            }
            totalamount = subamount;
            invoiceEntity.TotalAmount=totalamount;
            int Result = invoiceBL.InsertInvoice(invoiceEntity);
            if (Result > 0)
            {
                lblTitle.Text = "Thank You";
                lblTitle.ForeColor = System.Drawing.Color.Green;
                message.ForeColor = System.Drawing.Color.Green;
                message.Text = "Invoice Generated Successfully";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                ClearControls();
                DataSet ds = new DataSet();
                ds = invoiceBL.GetClientSRDataPdf(ViewState["SRNO"].ToString());
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    emailid = ds.Tables[0].Rows[0]["EmailID"].ToString();
                }

                DataSet ds1 = new DataSet();
                ds1 = invoiceBL.GetInvoiceNum();
                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    invoicenum = ds1.Tables[0].Rows[0]["InvoiceNum"].ToString();
                }
                
                SendMail(emailid, invoicenum, serviceno);
                string srno1 = ViewState["SRNO"].ToString();
                int status1 = 6;
                int res1 = serviceRequestBL.UpdateServiceStatus(status1, srno1);
                string invAmountStatus = "Not Yet Received";
                int result1 = invoicePaymentBL.UpdateAmountStatus(invAmountStatus,invoicenum);
                           
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

    
    protected void btnInvoiceCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("WorkInProcess.aspx");
    }

    private void GetPDFClientData(string SRNO)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = invoiceBL.GetClientSRDataPdf(SRNO);
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
    private void GetPdf()
    {
        try
        {
            string SRNO = ViewState["SRNO"].ToString();
            DataSet ds = new DataSet();
            ds = invoiceBL.GetInvoiceNum();
            StreamReader reader = new StreamReader(Server.MapPath("~/AdminForms/PdfInvoice.html"));
            //string url = "~/AdminForms/PdfInvoice.html";
            //string s = "window.open('" + url + "', '_blank');";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            string readFile = reader.ReadToEnd();
            reader.Close();

            StringBuilder sbMainrow = new StringBuilder();

            int CompanyAddress = 0;
            decimal totalamount = 0;
            decimal amount = 0;
            decimal vatper = 0;
            decimal incamount = 0;
            decimal subamount = 0;
            int inVat = 0;
            int count = 1;
            string invoicenum = string.Empty;

            if (ds.Tables.Count > 0)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dtlRow in ds.Tables[0].Rows)
                    {
                        if (CompanyAddress == 0)
                        {
                            readFile = readFile.Replace("{InvoiceNum}", dtlRow["InvoiceNum"].ToString());
                            readFile = readFile.Replace("{InvoiceDate}", dtlRow["InvoiceDate"].ToString());
                            readFile = readFile.Replace("{ClientName}", dtlRow["ClientName"].ToString());
                            readFile = readFile.Replace("{ClientSAID}", dtlRow["SAID"].ToString());
                            readFile = readFile.Replace("{ServiceName}", dtlRow["ServiceName"].ToString());
                            invoicenum = dtlRow["InvoiceNum"].ToString();

                        }
                        CompanyAddress = 1;

                        sbMainrow.Append("<tr>");
                        sbMainrow.Append("<td colspan='7' style='font-weight:bold;border: 1px ridge black;padding: 5px;background-color: white;border-bottom: 1px ridge black;border-radius:5px;'>Srno</td>");
                        sbMainrow.Append("<td colspan='7' style='font-weight:bold;border: 1px ridge black;padding: 5px;background-color: white;border-bottom: 1px ridge black;border-radius:5px;'>Service Request Num</td>");
                        sbMainrow.Append("<td colspan='7' style='font-weight:bold;border: 1px ridge black;padding: 5px;background-color: white;border-bottom: 1px ridge black;border-radius:5px;'>Invoice Summary</td>");
                        sbMainrow.Append("<td colspan='7' style='font-weight:bold;border: 1px ridge black;padding: 5px;background-color: white;border-bottom: 1px ridge black;border-radius:5px;text-align:right''>Amount</td>");
                        sbMainrow.Append("</tr>");

                        amount = amount + Convert.ToDecimal(dtlRow["Amount"]);
                        inVat = Convert.ToInt32(dtlRow["VatInclusive"]);
                        if (inVat == 0)
                        {
                            incamount = Math.Round(amount, 2);
                            vatper = Math.Round((amount * Convert.ToDecimal(0.15)) + vatper, 2);
                            subamount = Math.Round(amount + vatper, 2);
                        }
                        else
                        {
                            incamount = Math.Round((amount / Convert.ToDecimal(1.15)), 2);
                            vatper = Math.Round((amount - incamount), 2);
                            subamount = Math.Round((incamount + vatper), 2);
                        }

                        sbMainrow.Append("<tr>");
                        sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;'>" + count + "</td>");
                        sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;'>" + dtlRow["SRNO"] + "</td>");
                        sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;'>" + dtlRow["Description"] + "</td>");
                        sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;text-align:right'/>" + dtlRow["Amount"] + "</td>");
                        sbMainrow.Append("</tr>");
                        count++;
                    }
                    sbMainrow.Append("<tr>");
                    sbMainrow.Append("<td colspan='21' style='border: 1px ridge black; font-weight:bold;padding:3px;color:blue;'>Amount</td>");
                    sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;text-align:right'>" + incamount + "</td></tr>");
                    sbMainrow.Append("<td colspan='21' style='border: 1px ridge black; font-weight:bold;padding:3px;color:blue;'>Vat % </td>");
                    sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;text-align:right'>" + vatper + "</td></tr>");
                    sbMainrow.Append("<tr>");

                    totalamount = subamount;

                    sbMainrow.Append("<tr>");
                    sbMainrow.Append("<td colspan='21' style='border: 1px ridge black; font-weight:bold;padding:3px;color:blue;'>Invoice Total </td>");
                    sbMainrow.Append("<td colspan='7' style='border: 1px ridge black; font-weight:bold;padding:3px;color:blue;text-align:right'>" + totalamount + "</td></tr>");
                    sbMainrow.Append("</tr>");




                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    readFile = readFile.Replace("{InvoiceNum}", " ");
                    readFile = readFile.Replace("{ClientName}", " ");
                    readFile = readFile.Replace("{ClientSAID}", " ");
                    readFile = readFile.Replace("{ServiceName}", " ");
                    readFile = readFile.Replace("{TimeStamp}", " ");
                }


                readFile = readFile.Replace("{MainRows}", sbMainrow.ToString());
                string StrContent = readFile;

                string strFileName = "Invoice" + " " + invoicenum;
                string strFileSavePath = Server.MapPath("../InvoiceDocuments/" + strFileName + ".pdf");               
                GenerateHTML_TO_PDF(StrContent, true, strFileSavePath, true);

            }
        }
        catch (Exception ex)
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }



    }
    private void GenerateHTML_TO_PDF(string HtmlString, bool ResponseShow, string FileName, bool SaveFileDir)
    {
        try
        {
            string pdf_page_size = "A4";
            SelectPdf.PdfPageSize pageSize = (SelectPdf.PdfPageSize)Enum.Parse(typeof(SelectPdf.PdfPageSize),
                pdf_page_size, true);

            string pdf_orientation = "Portrait";
            SelectPdf.PdfPageOrientation pdfOrientation =
                (SelectPdf.PdfPageOrientation)Enum.Parse(typeof(SelectPdf.PdfPageOrientation),
                pdf_orientation, true);


            int webPageWidth = 1024;


            int webPageHeight = 0;




            // instantiate a html to pdf converter object
            SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            SelectPdf.PdfDocument doc = converter.ConvertHtmlString(HtmlString, "");

            doc.Save(FileName);
            // save pdf document      

            //if (!SaveFileDir)
            //    doc.Save(Response, ResponseShow, FileName);
            //else
            //    doc.Save(FileName);

            string FilePath = FileName;
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            //if (FileBuffer != null)
            //{
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("content-length", FileBuffer.Length.ToString());
            //    Response.BinaryWrite(FileBuffer);
            //}
            doc.Close();

        }
        catch (Exception ex)
        {
            lblTitle.Text = "Warning!";
            lblTitle.ForeColor = System.Drawing.Color.Red;
            message.ForeColor = System.Drawing.Color.Red;
            message.Text = "Sorry,Something went wrong, please contact administrator";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    public void SendMail(string ToMail, string invoicenum, string serviceno)
    {
        try
        {
            GetPdf();
            DataSet ds = _objServiceRequestBL.get_config_mst();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string SmtpServer = ds.Tables[0].Rows[0]["con_smtp_host"].ToString();
                int SmtpPort = Convert.ToInt32(ds.Tables[0].Rows[0]["con_smtp_port"].ToString());
                string MailFrom = ds.Tables[0].Rows[0]["con_mail_from"].ToString();
                string DisplayNameFrom = ds.Tables[0].Rows[0]["con_from_name"].ToString();
                string FromPassword = ds.Tables[0].Rows[0]["con_from_pwd"].ToString();
                string MailTo = ToMail;
                string DisplayNameTo = "";
                string MailCc = ds.Tables[0].Rows[0]["con_mail_cc"].ToString();
                string mailCc2 = ds.Tables[0].Rows[0]["con_mail_cc1"].ToString();
                string DisplayNameCc = "";
                string MailBcc = "";
                string Subject = "Activ8 Group";
                string MailText;
                // string Attachment = "";

                string path = Server.MapPath("~/InvoiceDocuments");
                FileStream fStream;
                DirectoryInfo dir = new DirectoryInfo(path);
                string filename = "";
                string Attachment = "";
                foreach (FileInfo flInfo in dir.GetFiles())
                {
                    filename = flInfo.Name;
                    string css = "Invoice " + invoicenum + ".pdf";
                    if (filename == css)
                    {
                        fStream = File.OpenRead(path + "\\" + filename.ToString());

                        Attachment = fStream.Name;
                        fStream.Close();
                        break;
                    }
                }

                MailText = "Hi, <br/><br/>Your Invoice for the Service Request: '"+serviceno+"'  .<br/>Please find attachment<br/></b> <br/><br/> Thank you, <br/><br/><strong> Activ8 System Admin.</strong><br/>";

                bool mail = CommanClass.UpdateMail(SmtpServer, SmtpPort, MailFrom, DisplayNameFrom, FromPassword, MailTo, DisplayNameTo, MailCc, mailCc2, "", "", DisplayNameCc, MailBcc, Subject, MailText, Attachment);
                if (mail == true)
                {
                    lblTitle.Text = "Thank You";
                    lblTitle.ForeColor = System.Drawing.Color.Green;
                    message.ForeColor = System.Drawing.Color.Green;
                    message.Text = "Invoice Generated successfully and sent the Mail";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
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
    protected void chkVatInclusive_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkVatInclusive.Checked == true)
            {
                lblvat.Visible = false;
            }
            else
            {
                lblvat.Visible = true;
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
        GetGridData();
    }
    protected void gvWorkInProcess_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvWorkInProcess.PageIndex = e.NewPageIndex;
            GetGridData();
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



   
   
}