using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using DataManager;
using EntityManager;


namespace BusinessLogic
{
    public class BankBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int CURDBankInfo(BankInfoEntity bankinfo, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@inBankDetailID", 0);
                
            }
            else
            {
                hashtable.Add("@inBankDetailID", bankinfo.BankDetailID);
            }
            hashtable.Add("@inType", bankinfo.Type);
            hashtable.Add("@inSAID", bankinfo.SAID);
            hashtable.Add("@inReferenceSAID", bankinfo.ReferenceID);
            hashtable.Add("@inUIC", bankinfo.UIC);
            hashtable.Add("@inBankName", bankinfo.BankName);
            hashtable.Add("@inBranchNumber", bankinfo.BranchNumber);
            hashtable.Add("@inAccountNumber", bankinfo.AccountNumber);
            hashtable.Add("@inAccountType", bankinfo.AccountType);
            hashtable.Add("@inCurrency", bankinfo.Currency);
            hashtable.Add("@inSWIFT", bankinfo.SWIFT);
            hashtable.Add("@inCreatedBy", bankinfo.CreatedBy);            
            hashtable.Add("@inAdvisorID", bankinfo.AdvisorID);
            hashtable.Add("@inUpdatedBy", bankinfo.UpdatedBy);
            hashtable.Add("@inFullName", bankinfo.FullName);
            hashtable.Add("@OperationName", Operation);


            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("InsUpdBankDetail", hashtable);
            return result;

        }

        public DataSet GetBankList(string SAID,int Type)
        {
            var newBank = new List<BankInfoEntity>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", SAID);
            hashtable.Add("@Type", Type);
            DataSet ds = dataUtilities.ExecuteDataSet("usp_GetBankDetails", hashtable);
            return ds;
        }

        public int DeleteBankDetails(string BankDetailID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@BankDetailID", BankDetailID);
            int result = dataUtilities.ExecuteNonQuery("usp_DeleteBankDetails", hashtable);
            return result;
        }

        public DataSet CheckAccountNum(string AccountNumber)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@AccountNumber", AccountNumber);
            DataSet ds = dataUtilities.ExecuteDataSet("CheckAccountNum", hashtable);
            return ds;
        }
    }

}