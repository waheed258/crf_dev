using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataManager;
using EntityManager;
using BusinessLogic;

public partial class AdminForms_InvoicePayment : System.Web.UI.Page
{
    CommanClass _objComman = new CommanClass();
    DataSet dataset = new DataSet();
    InvoicePaymentBL invoicePaymentBL = new InvoicePaymentBL();
    InvoicePaymentEntity invoicePaymentEntity = new InvoicePaymentEntity();
    InvoiceBL invoiceBL = new InvoiceBL();
    EncryptDecrypt ObjDec = new EncryptDecrypt();
    string amount = string.Empty;
    string srno = string.Empty;
    string invoicenum = string.Empty;
    Decimal amount1 = 0;
    Decimal dueamount = 0;
    Decimal recievedamount = 0;


    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _objComman.getRecordsPerPage(DropPage);
            GetAmountDetails();
            BindInvoiceDetails();
        }
    }

    private void GetAmountDetails()
    {
        try
        {
            invoicenum = ObjDec.Decrypt(Request.QueryString["payment"].ToString());
            DataSet dataset = new DataSet();
            dataset = invoicePaymentBL.GetPaymentInvoiceNum(invoicenum);
            if(dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {
                amount = dataset.Tables[0].Rows[0]["Amount"].ToString();
                srno = dataset.Tables[0].Rows[0]["ClientSRNO"].ToString();
                ViewState["srno"] = srno;
            }
            DataSet ds1 = new DataSet();
            ds1 = invoicePaymentBL.GetPaymentRemainingData(invoicenum);
            if(ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                amount1 = Convert.ToDecimal(ds1.Tables[0].Rows[0]["TotalAmount"].ToString());
                recievedamount = Convert.ToDecimal(ds1.Tables[1].Rows[0]["PaymentReceived"].ToString());
                dueamount = amount1 - recievedamount;
                txtTotalAmount.Text = amount1.ToString();                
                txtReceivedAmount.Text = recievedamount.ToString();
                txtDueAmount.Text = dueamount.ToString();
            }
            else
            {
                txtTotalAmount.Text = amount;
                txtDueAmount.Text = amount;
                txtReceivedAmount.Text = "0";
            }

        }
        catch { }
    }
    protected void BindInvoiceDetails()
    {
        try
        {
            invoicenum = ObjDec.Decrypt(Request.QueryString["payment"].ToString());
            dataset = invoicePaymentBL.GetAllInvoices(invoicenum);
            if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
            {              
                gvInvoice.DataSource = dataset;
                invoicelist.Visible = true;
                search.Visible = true;                
            }
            else
            {
                gvInvoice.DataSource = null;
                invoicelist.Visible = false;
                search.Visible = false;
            }
            gvInvoice.PageSize = Convert.ToInt32(DropPage.SelectedValue);
            gvInvoice.DataBind();

        }
        catch
        {
            //message.ForeColor = System.Drawing.Color.Red;
            //message.Text = "Something went wrong, please contact administrator";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            invoicePaymentEntity.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
            invoicePaymentEntity.ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            invoicePaymentEntity.DueAmount = Convert.ToDecimal(txtDueAmount.Text);
            invoicePaymentEntity.PaymentDate = string.IsNullOrEmpty(txtNextFollowUpDate.Text) ? null : txtNextFollowUpDate.Text;
            invoicePaymentEntity.PaymentReceived = Convert.ToDecimal(txtPaymentReceived.Text);
            invoicePaymentEntity.PaymentMode = ddlPaymentMode.SelectedValue;
            invoicePaymentEntity.Notes = txtNotes.Text;
            invoicePaymentEntity.InvoiceNum = ObjDec.Decrypt(Request.QueryString["payment"].ToString());

            int result = invoicePaymentBL.InvPayment(invoicePaymentEntity);
            if (result == 1)
            {
                message.Text = "Payment done successfully!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                BindInvoiceDetails();
                DataSet ds1 = new DataSet();
                ds1 = invoicePaymentBL.GetPaymentRemainingData(invoicenum);
                if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    amount1 = Convert.ToDecimal(ds1.Tables[0].Rows[0]["TotalAmount"].ToString());
                    recievedamount = Convert.ToDecimal(ds1.Tables[1].Rows[0]["PaymentReceived"].ToString());
                    dueamount = amount1 - recievedamount;
                    txtTotalAmount.Text = amount1.ToString();
                    txtReceivedAmount.Text = recievedamount.ToString();
                    txtDueAmount.Text = dueamount.ToString();
                }

                Clear();
            }
            else
            {
                
            }
        }
        catch
        {
            //message.ForeColor = System.Drawing.Color.Red;
            //message.Text = "Something went wrong, please contact administrator";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    public void Clear()
    {
        
        txtNextFollowUpDate.Text = "";
        txtNotes.Text = "";
        txtPaymentReceived.Text = "";
        ddlPaymentMode.SelectedValue = "-1";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SRWiseInvoiceList.aspx?srnum=" + ObjDec.Encrypt(ViewState["srno"].ToString()));
    }
    protected void gvInvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvInvoice.PageIndex = e.NewPageIndex;
            BindInvoiceDetails();
        }
        catch
        {
        //    message.ForeColor = System.Drawing.Color.Red;
        //    message.Text = "Something went wrong, please contact administrator";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
    protected void DropPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindInvoiceDetails();
    }
}