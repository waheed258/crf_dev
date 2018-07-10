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
                        {"@inTitle",_objBeneficiary.Title},
                        {"@inFirstName",_objBeneficiary.FirstName},
                        {"@inLastName",_objBeneficiary.LastName},
                        {"@inEmailID",_objBeneficiary.EmailID},
                        {"@inMobile",_objBeneficiary.Mobile},
                        {"@inPhone",_objBeneficiary.Phone},
                        {"@inDateOfBirth",_objBeneficiary.DateOfBirth},
                        {"@inAdvisorID",_objBeneficiary.AdvisorID},
                        {"@inStatus",_objBeneficiary.Status},
                        {"@inTaxRefNo",_objBeneficiary.TaxRefNo},
                        {"@inType",_objBeneficiary.Type},
                        {"@inUICNo",_objBeneficiary.UICNo},
                        {"@inCompanyName",_objBeneficiary.CompanyName},
                        {"@inYearOfEstablishment",_objBeneficiary.YearOfEstablishment},
                        {"@inVATNo",_objBeneficiary.VATNo},
                        {"@inCompanyTelephone",_objBeneficiary.CompanyTelephone},
                        {"@inCompanyEmailID",_objBeneficiary.CompanyEmailID},
                        {"@inCompanyWebsite",_objBeneficiary.CompanyWebsite},
                        {"@inBenificiaryType",_objBeneficiary.BenificiaryType},
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

    public int DeleteBenefaciary(int BeneficiaryID, string SAID, string UIC, int AdvisorID)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inBeneficiaryID", BeneficiaryID);
        hsparams.Add("@inSAID", SAID);
        hsparams.Add("@inUIC", UIC);
        hsparams.Add("@Deletedby", AdvisorID);
        return ExecuteNonQuery("DeleteBenefaciary", hsparams);
    }
    public DataSet GetBeneficiaryType()
    {
        return ExecuteDataSet("GetBeneficiaryType");
    }
}