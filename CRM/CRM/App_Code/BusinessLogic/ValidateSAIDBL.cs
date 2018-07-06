using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for ValidateSAIDBL
/// </summary>
public class ValidateSAIDBL
{
    DataUtilities dataUtilities = new DataUtilities();
    DataSet ds = new DataSet();

    public DataSet ValidateSAID(string SAID,string RSAID,string UIC)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@SAID", SAID);
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateSAID", hashtable);
        return ds;
    }
    public DataSet ValidateAdvisorSAID(string SAID)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@SAID", SAID);
        ds = dataUtilities.ExecuteDataSet("ValidateAdvisor", hashtable);
        return ds;
    }
    public DataSet ValidateTrustUIC(string RSAID, string UIC)
    {
        Hashtable hashtable = new Hashtable();       
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateTrustUIC", hashtable);
        return ds;
    }

    public DataSet ValidateCompanyUIC(string RSAID, string UIC)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateCompanyUIC", hashtable);
        return ds;
    }
    public DataSet ValidateBeneficiaryUIC(string RSAID, string UIC,string UICNo)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@REFSAID", RSAID);
        hashtable.Add("@UIC", UIC);
        hashtable.Add("@UICNo", UICNo);
        ds = dataUtilities.ExecuteDataSet("usp_ValidateBeneficiaryUIC", hashtable);
        return ds;
    }
    public int UpdateValidation(string ReferenceSAID, string TrustSAID, string UIC, string ReferenceUIC, int ClientType)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@ReferenceSAID", ReferenceSAID);
        hashtable.Add("@SAID", TrustSAID);
        hashtable.Add("@UIC", UIC);
        hashtable.Add("@ReferenceUIC", ReferenceUIC);
        hashtable.Add("@ClientType", ClientType);
        return dataUtilities.ExecuteNonQuery("usp_UpdateValidation", hashtable);
    }
}