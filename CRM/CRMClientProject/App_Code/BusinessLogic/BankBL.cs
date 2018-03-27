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

            hashtable.Add("@inSAID", bankinfo.SAID);
            hashtable.Add("@inBankName", bankinfo.BankName);
            hashtable.Add("@inBranchNumber", bankinfo.BranchNumber);
            hashtable.Add("@inAccountNumber", bankinfo.AccountNumber);
            hashtable.Add("@inAccountType", bankinfo.AccountType);
            hashtable.Add("@inCurrency", bankinfo.Currency);
            hashtable.Add("@inSWIFT", bankinfo.SWIFT);
            hashtable.Add("@inStatus", 0);
            hashtable.Add("@inAdvisorID", 0);
            hashtable.Add("@inUpdatedBy", 0);

            hashtable.Add("@OperationName", Operation);


            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("InsUpdBankDetail", hashtable);
            return result;

        }

    }

}