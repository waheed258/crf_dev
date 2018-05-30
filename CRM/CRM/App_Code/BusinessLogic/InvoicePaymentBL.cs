using DataManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Data;

/// <summary>
/// Summary description for InvoicePaymentBL
/// </summary>
namespace BusinessLogic
{
    public class InvoicePaymentBL : DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int InvPayment(InvoicePaymentEntity invoicePaymentEntity)
        {
            Hashtable hashtable = new Hashtable();
         
            hashtable.Add("@PaymentID", invoicePaymentEntity.PaymentID);
            hashtable.Add("@TotalAmount", invoicePaymentEntity.TotalAmount);
            hashtable.Add("@ReceivedAmount", invoicePaymentEntity.ReceivedAmount);
            hashtable.Add("@DueAmount", invoicePaymentEntity.DueAmount);
            hashtable.Add("@PaymentDate", invoicePaymentEntity.PaymentDate);
            hashtable.Add("@Notes", invoicePaymentEntity.Notes);
            hashtable.Add("@PaymentReceived", invoicePaymentEntity.PaymentReceived);
            hashtable.Add("@PaymentMode", invoicePaymentEntity.PaymentMode);
            hashtable.Add("@InvoiceNum", invoicePaymentEntity.InvoiceNum);

            int result = dataUtilities.ExecuteNonQuery("InsUpdateInvoicePayment", hashtable);
            return result;


        }

        public DataSet GetAllInvoices(string InvoiceNum)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@InvoiceNum", InvoiceNum);
            DataSet ds = dataUtilities.ExecuteDataSet("GetPaymentByInvoice", hashtable);
            return ds;
        }

    }
}