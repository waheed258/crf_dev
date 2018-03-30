using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Web;
using EntityManager;
using DataManager;


public class TrustSettlerBL:DataUtilities
{
    public int TrustSettlerInsertUpdate(TrustSettlerEntity _objSettler, char operation)
    {
        Hashtable hsparams = new Hashtable
                    {
                        {"@inTrustSettlerID",_objSettler.TrustSettlerID},
                        {"@inSAID",_objSettler.SAID},
                        {"@inReferenceSAID",_objSettler.ReferenceSAID},
                        {"@inReferenceUIC",_objSettler.ReferenceUIC},
                        {"@inFirstName",_objSettler.FirstName},
                        {"@inLastName",_objSettler.LastName},
                        {"@inEmailID",_objSettler.EmailID},
                        {"@inMobile",_objSettler.Mobile},
                        {"@inPhone",_objSettler.Phone},
                        {"@inAdvisorID",DBNull.Value},
                        {"@inTaxRefNo",_objSettler.TaxRefNo},
                        {"@inStatus",_objSettler.Status},
                        {"@inOperationName",operation}
                    };

        return ExecuteNonQuery("TrustSettlerManager", hsparams);
    }


    public DataSet GetTrustSettler(int TRustSettlerId, string RefUIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inTrustSettlerID", TRustSettlerId);
        hsparams.Add("@inReferenceUIC", RefUIC);

        return ExecuteDataSet("GetTrustSettler", hsparams);
    }


    public int DeleteTrustSettler(int TrustSettlerId)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inTrustSettlerID", TrustSettlerId);

        return ExecuteNonQuery("DeleteTrustSettler", hsparams);
    }
}