﻿using System;
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
                        {"@inFaxNo",DBNull.Value},
                        {"@inEmailID",_objTrust.EmailID},
                        {"@inWebsite",_objTrust.Website},
                        {"@inVATNo",_objTrust.VATNo},
                        {"@inAdvisorID",_objTrust.AdvisorID},
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

        public DataSet GetTrustTest(string UIC)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inUIC", UIC);

            return ExecuteDataSet("GetTrustTest", hsparams);
        }


        public int DeleteTrust(string UIC, int AdvisorID)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inUIC", UIC);
            hsparams.Add("@Deletedby", AdvisorID);
            return ExecuteNonQuery("DeleteTrust", hsparams);
        }
    }
}
