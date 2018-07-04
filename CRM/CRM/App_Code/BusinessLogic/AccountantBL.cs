using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using DataManager;
using System.Data;
namespace BusinessLogic
{
    public class AccountantBL : DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int InsertUpdateAccountant(AccountantEntity accountEntity,char Operation)
        {
            Hashtable htable = new Hashtable{
                {"@AccountantID",accountEntity.AccountantID},
                {"@AccountantName",accountEntity.AccountantName},
                {"@AccountantTelNum",accountEntity.AccountantTelNum},
                {"@AccountantEmail",accountEntity.AccountantEmail},
                {"@Type",accountEntity.Type},
                {"@UICNo",accountEntity.UICNo},
                {"@AdvisorID",accountEntity.AdvisorID},
                {"@ReferenceSAID",accountEntity.ReferenceSAID},
                {"@OperationName",Operation}
            };
            return dataUtilities.ExecuteNonQuery("InsUpdateAccountant", htable);
        }

        public DataSet GetTrustAccountant(string ReferenceSAID, int Type)
        {
            DataSet ds = new DataSet();
            Hashtable htable = new Hashtable();
            htable.Add("@ReferenceSAID", ReferenceSAID);
            htable.Add("@Type", Type);
            ds = dataUtilities.ExecuteDataSet("GetTrustAccountant", htable);
            return ds;

        }
        public DataSet GetCompanyAccountant(string ReferenceSAID, int Type)
        {
            DataSet ds = new DataSet();
            Hashtable htable = new Hashtable();
            htable.Add("@ReferenceSAID", ReferenceSAID);
            htable.Add("@Type", Type);
            ds = dataUtilities.ExecuteDataSet("GetCompanyAccountant", htable);
            return ds;

        }
        public int DeleteAccountant(int AccountantID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@AccountantID", AccountantID);
            int result = dataUtilities.ExecuteNonQuery("DeleteAccountant", hashtable);
            return result;
        }
    }
}