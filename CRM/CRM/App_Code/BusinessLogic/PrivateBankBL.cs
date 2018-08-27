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
    /// <summary>
    /// Summary description for PrivateBankBL
    /// </summary>
    public class PrivateBankBL : DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int InsUpdatePrivatebank(PrivateBankEntity privateentity, char Operation)
        {
            Hashtable htable = new Hashtable{
                {"@PrivateBankID",privateentity.PrivateBankID},
                {"@PrivateBankName",privateentity.PrivateBankName},
                {"@PrivateContactNum",privateentity.PrivateContactNum},
                {"@UICNo",privateentity.UICNo},
                {"@AdvisorID",privateentity.AdvisorID},
                {"@ReferenceSAID",privateentity.ReferenceSAID},
                {"@BankerName",privateentity.BankerName},
                {"@BankerEmailId",privateentity.BankerEmailId},
                {"@OperationName",Operation}
            };
            return dataUtilities.ExecuteNonQuery("InsUpdatePrivatebank", htable);
        }

        public DataSet GetPrivateBank(string ReferenceSAID)
        {
            DataSet ds = new DataSet();
            Hashtable htable = new Hashtable();
            htable.Add("@ReferenceSAID", ReferenceSAID);
            ds = dataUtilities.ExecuteDataSet("GetPrivateBank", htable);
            return ds;

        }
        public int DeletePrivateBank(int PrivateBankID, string UIC, int Deletedby)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@PrivateBankID", PrivateBankID);
            hashtable.Add("@inUIC", UIC);
            hashtable.Add("@Deletedby", Deletedby);
            int result = dataUtilities.ExecuteNonQuery("DeletePrivatebank", hashtable);
            return result;
        }
    }
}