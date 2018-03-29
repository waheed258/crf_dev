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
                        {"@inAdvisorID",DBNull.Value},
                        {"@inStatus",1},
                        {"@OperationName",operation}
                    };

            return ExecuteNonQuery("InsertUpdateTrustee", hsparams);
        }

        public DataSet GetTrustee(int TrusteeId,string ReferenceUCID, char operation)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inTrusteeID", TrusteeId);
            hsparams.Add("@inReferenceUIC", ReferenceUCID);
            hsparams.Add("@inOperationName", operation);

            return ExecuteDataSet("GetTrustee", hsparams);
        }
    }
}