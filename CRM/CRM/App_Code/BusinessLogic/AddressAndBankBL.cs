using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for AddressAndBankBL
/// </summary>
public class AddressAndBankBL
{
    DataUtilities dataUtilities = new DataUtilities();
    DataSet ds = new DataSet();

    public DataSet GetAddressDetails(string SAID, string RSAID, string UIC)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@SAID", SAID);
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateAddressDetails", hashtable);
        return ds;
    }
    public DataSet GetBankDetails(string SAID, string RSAID, string UIC)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@SAID", SAID);
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateBankDetails", hashtable);
        return ds;
    }
}