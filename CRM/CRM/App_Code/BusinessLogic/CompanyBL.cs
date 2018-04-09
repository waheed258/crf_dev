using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Data;
using System.Collections;

public class CompanyBL
{
    DataUtilities dataUtilities = new DataUtilities();
    DataSet ds = new DataSet();   

    public int CUDCompany(CompanyInfoEntity companyInfoEntity, char Operation)
    {
        Hashtable hashtable = new Hashtable();
        if (Operation == 'i')
        {
            hashtable.Add("@CompanyID", 0);            
        }
        else
        {
            hashtable.Add("@CompanyID", companyInfoEntity.CompanyID);            
        }
        hashtable.Add("@ReferenceSAID", companyInfoEntity.ReferenceSAID);
        hashtable.Add("@UIC", companyInfoEntity.UIC);
        hashtable.Add("@CompanyName", companyInfoEntity.CompanyName);
        hashtable.Add("@YearOfEstablishment", companyInfoEntity.YearOfEstablishment);
        hashtable.Add("@Telephone", companyInfoEntity.Telephone);
        hashtable.Add("@FaxNo", companyInfoEntity.FaxNo);
        hashtable.Add("@EmailID", companyInfoEntity.EmailID);
        hashtable.Add("@Website", companyInfoEntity.Website);
        hashtable.Add("@AdvisorID", companyInfoEntity.AdvisorID);
        
        hashtable.Add("@Operation", Operation);

        int result = dataUtilities.ExecuteNonQuery("usp_CUDCompany", hashtable);
        return result;
    }

    public DataSet GetCompanyList(string SAID, string UIC)
    {
        var newLead = new List<CompanyInfoEntity>();
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@ReferenceSAID", SAID);
        hashtable.Add("@UIC", UIC);
        DataSet ds = dataUtilities.ExecuteDataSet("GetCompanyInfo", hashtable);
        return ds;
    }

    public int DeleteCompanyDetails(string UIC)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@UIC", UIC);
        int result = dataUtilities.ExecuteNonQuery("usp_DeleteCompanyDetails", hashtable);
        return result;
    }
}