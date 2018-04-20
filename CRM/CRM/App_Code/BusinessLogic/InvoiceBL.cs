﻿using System;
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
            int result = dataUtilities.ExecuteNonQuery("InvoiceMasterCRUD", hashtable);
            return result;


        }

        public DataSet GetInvoice(int CServiceID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@CServiceID", CServiceID);
            DataSet ds = dataUtilities.ExecuteDataSet("GetInvoiceDetails", hashtable);
            return ds;
        }
    }
}