using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using System.Data;
using DataManager;


/// <summary>
/// Summary description for BeneficiaryBL
/// </summary>
public class BeneficiaryBL:DataUtilities
{
    public int BeneficiaryInsertUpdate(BenificiaryEntity _objBeneficiary, char operation)
    {
        Hashtable hsparams = new Hashtable
                    {
                        {"@inBeneficiaryID",_objBeneficiary.BeneficiaryID},
                        {"@inReferenceSAID",_objBeneficiary.ReferenceSAID},
                        {"@inUIC",_objBeneficiary.UIC},
                        {"@inSAID",_objBeneficiary.SAID},
                        {"@inFirstName",_objBeneficiary.FirstName},
                        {"@inLastName",_objBeneficiary.LastName},
                        {"@inEmailID",_objBeneficiary.EmailID},
                        {"@inMobile",_objBeneficiary.Mobile},
                        {"@inPhone",_objBeneficiary.Phone},
                        {"@inAdvisorID",_objBeneficiary.AdvisorID},
                        {"@inStatus",_objBeneficiary.Status},
                        {"@inType",_objBeneficiary.Type},
                        {"@inOperationName",operation}
                    };

        return ExecuteNonQuery("BeneficiaryManager", hsparams);
    }

    public DataSet GetBeneficiary(int BeneficiaryId,int type,string UIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inBeneficiaryID", BeneficiaryId);
        hsparams.Add("@inType", type);
        hsparams.Add("@inUIC", UIC);


        return ExecuteDataSet("GetBeneficiary", hsparams);
    }

    public DataSet GetBeneficiaryTest(string ReferenceUCID, string SAID)
    {
        Hashtable hsparams = new Hashtable();

        hsparams.Add("@inReferenceUIC", ReferenceUCID);
        hsparams.Add("@inSAID", SAID);
        return ExecuteDataSet("GetBeneficiaryTest", hsparams);
    }

    public int DeleteBenefaciary(int BeneficiaryID,string SAID,string UIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inBeneficiaryID", BeneficiaryID);
        hsparams.Add("@inSAID", SAID);
        hsparams.Add("@inUIC", UIC);

        return ExecuteNonQuery("DeleteBenefaciary", hsparams);
    }
}