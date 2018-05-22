using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using DataManager;
using EntityManager;

/// <summary>
/// Summary description for InvoiceBL
/// </summary>
/// 
namespace BusinessLogic
{
    public class InvoiceBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int InsertInvoice(InvoiceEntity InvoiceEntity)
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("@SrNo", InvoiceEntity.SrNo);
            hashtable.Add("@Description", InvoiceEntity.Description);
            hashtable.Add("@Amount", InvoiceEntity.Amount);
            hashtable.Add("@InvoiceDate", InvoiceEntity.InvoiceDate);
            hashtable.Add("@VatInclusive", InvoiceEntity.VatInclusive);
            hashtable.Add("@ClientSRNO", InvoiceEntity.ClientSRNO);
            int result = dataUtilities.ExecuteNonQuery("InvoiceMasterCRUD", hashtable);
            return result;


        }

        public DataSet GetInvoice(string ClientSRNO)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ClientSRNO", ClientSRNO);
            DataSet ds = dataUtilities.ExecuteDataSet("GetInvoiceDetails", hashtable);
            return ds;
        }

        public DataSet GetClientSRDataPdf(string SRNO)
        {

            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SRNO", SRNO);
            DataSet ds = dataUtilities.ExecuteDataSet("GetClientSRData", hashtable);
            return ds;
        }
        public DataSet GetInvoiceByClient(string SAID)
        {

            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            DataSet ds = dataUtilities.ExecuteDataSet("GetInvoiceListBySAID", hashtable);
            return ds;
        }


        
    }
}