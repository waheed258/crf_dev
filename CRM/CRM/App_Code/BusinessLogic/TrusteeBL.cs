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
    public class TrusteeBL : DataUtilities
    {
        public int TrusteeInsertUpdate(TrusteeEntity _objTrustee, char operation)
        {
            Hashtable hsparams = new Hashtable
                    {
                        {"@inTrusteeID",_objTrustee.TrusteeId},
                        {"@inReferenceSAID",_objTrustee.ReferenceSAID},
                        {"@inReferenceUIC",_objTrustee.ReferenceUIC},
                        {"@inSAID",_objTrustee.SAID},
                        {"@inFirstName",_objTrustee.FirstName},
                        {"@inLastName",_objTrustee.LastName},
                        {"@inEmailID",_objTrustee.EmailID},
                        {"@inMobile",_objTrustee.Mobile},
                        {"@inAdvisorID",_objTrustee.AdvisorID},
                        {"@inTaxRefNo",_objTrustee.TaxRefNo},
                        {"@inStatus",_objTrustee.Status},
                        {"@inTitle",_objTrustee.Title},
                        {"@inDOB",_objTrustee.DateOfBirth},
                        {"@inPhone",_objTrustee.Phone},
                        {"@OperationName",operation}
                    };

            return ExecuteNonQuery("TrusteeManager", hsparams);
        }

        public DataSet GetTrustee(int TrusteeId,string ReferenceUCID)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inTrusteeID", TrusteeId);
            hsparams.Add("@inReferenceUIC", ReferenceUCID);

            return ExecuteDataSet("GetTrustee", hsparams);
        }

        public DataSet GetTrusteeTest(string ReferenceUIC,string SAID)
        {
            Hashtable hsparams = new Hashtable();
           
            hsparams.Add("@inReferenceUIC", ReferenceUIC);
            hsparams.Add("@inSAID", SAID);           

            return ExecuteDataSet("GetTrusteeTest", hsparams);
        }

        public int DeleteTrustee(int TrusteeId, string UIC, string SAID, int AdvisorID)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inTrusteeID", TrusteeId);
            hsparams.Add("@inUIC", UIC);
            hsparams.Add("@inSAID",SAID);
            hsparams.Add("@Deletedby", AdvisorID);
            return ExecuteNonQuery("DeleteTrustee", hsparams);
        }
    }
}