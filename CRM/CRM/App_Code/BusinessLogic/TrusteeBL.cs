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
                        {"@inStatus",_objTrustee.Status},
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



        public int DeleteTrustee(int TrusteeId,string SAID)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inTrusteeID", TrusteeId);
            hsparams.Add("@inSAID",SAID);

            return ExecuteNonQuery("DeleteTrustee", hsparams);
        }
    }
}