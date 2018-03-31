using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections;
using System.Web;
using EntityManager;
using DataManager;

namespace BusinessLogic
{
    public class TrustBL : DataUtilities
    {
        public int TrustManager(TrustEntity _objTrust, char operation)
        {
            Hashtable hsparams = new Hashtable
                    {
                        {"@inUIC",_objTrust.UIC},
                        {"@ReferenceSAID",_objTrust.ReferenceSAID},
                        {"@inTrustName",_objTrust.TrustName},
                        {"@inYearOfFoundation",_objTrust.YearOfFoundation},
                        {"@inTelephone",_objTrust.Telephone},
                        {"@inFaxNo",_objTrust.FaxNo},
                        {"@inEmailID",_objTrust.EmailID},
                        {"@inWebsite",_objTrust.Website},
                        {"@inTaxRefNo",_objTrust.TaxRefNo},
                        {"@inAdvisorID",DBNull.Value},
                        {"@inStatus",_objTrust.Status},
                        {"@OperationName",operation}
                    };
            return ExecuteNonQuery("TrustManager", hsparams);
        }


        public DataSet GetTrust(string ReferenceSAId, string UIC)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inReferenceSAID", ReferenceSAId);
            hsparams.Add("@inUIC", UIC);

            return ExecuteDataSet("GetTrust", hsparams);
        }


        public int DeleteTrust(string UIC)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inUIC", UIC);

            return ExecuteNonQuery("DeleteTrust", hsparams);
        }
    }
}
