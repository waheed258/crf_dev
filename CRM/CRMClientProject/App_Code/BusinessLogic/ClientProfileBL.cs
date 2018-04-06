using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;
using System.Collections;
using EntityManager;


namespace BusinessLogic
{
    public class ClientProfileBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        DataSet ds = new DataSet();

        public DataSet GetCountry()
        {
            ds = dataUtilities.ExecuteDataSet("GetCountry");
            return ds;
        }

        public DataSet GetProvince()
        {
            ds = dataUtilities.ExecuteDataSet("GetProvince");
            return ds;
        }

        public DataSet GetCity()
        {
            ds = dataUtilities.ExecuteDataSet("GetCity");
            return ds;
        }
        public DataSet GetAccountType()
        {
            ds = dataUtilities.ExecuteDataSet("GetAccountType");
            return ds;
        }



        public DataSet GetClientRegistartion(string SAId)
        {
            DataUtilities datautilities = new DataUtilities();
            Hashtable htParams = new Hashtable
            {
                {"@inSAID",SAId},
            };
            return dataUtilities.ExecuteDataSet("GetClientRegistartion", htParams); 

        }


        public DataSet GetClientPersonal(string SAId) 
        {
            DataUtilities datautilities = new DataUtilities();
            Hashtable htParams = new Hashtable
            {
                {"@inSAID",SAId},
            };
            return datautilities.ExecuteDataSet("GetClientPersonal", htParams);
        }


        public int CURDClientPersonalInfo(ClientPersonalInfoEntity PersonalInfo, char Operation)  
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@inSAID", PersonalInfo.SAID);
            hashtable.Add("@inFirstName", PersonalInfo.FirstName);
            hashtable.Add("@inLastName", PersonalInfo.LastName);
            hashtable.Add("@inEmailID", PersonalInfo.EmailID);
            hashtable.Add("@inPhone", PersonalInfo.Phone);
            hashtable.Add("@inMobile", PersonalInfo.Mobile);
            hashtable.Add("@inTaxRefNo", PersonalInfo.TaxRefNo);
            hashtable.Add("@inDateOfBirth", PersonalInfo.DateOfBirth);
            hashtable.Add("@Image", PersonalInfo.Image);
            hashtable.Add("@inStatus", 0);
            hashtable.Add("@inAdvisorID", 0);
            hashtable.Add("@inUpdatedBy", 0);
            hashtable.Add("@inUpdatedOn", 0);
            hashtable.Add("@OperationName", Operation);

            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("InsUpClientPersonal", hashtable);
            return result;

        }



        //public DataSet GetCustomer(int CustomerId)
        //{
        //    DataUtilities datautilities = new DataUtilities();
        //    Hashtable htParams = new Hashtable
        //    {
        //        {"@CustomerId",CustomerId},
        //    };
        //    return datautilities.ExecuteDataSet("uspGetCustomerInfo", htParams);
        //}



        //public int CURDBankInfo(BankInfoEntity bankinfo, char Operation)
        //{
        //    Hashtable hashtable = new Hashtable();
        //    if(Operation == 'i')
        //    {
        //        hashtable.Add("@inBankDetailID", 0);
        //    }
        //    else
        //    {
        //        hashtable.Add("@inBankDetailID", bankinfo.BankDetailID);
        //    }

        //    hashtable.Add("@inSAID", bankinfo.SAID);
        //    hashtable.Add("@inBankName",bankinfo.BankName);
        //    hashtable.Add("@inBranchNumber", bankinfo.BranchNumber);
        //    hashtable.Add("@inAccountNumber", bankinfo.AccountNumber);
        //    hashtable.Add("@inAccountType", bankinfo.AccountType);
        //    hashtable.Add("@inCurrency", bankinfo.Currency);
        //    hashtable.Add("@inSWIFT", bankinfo.SWIFT);
        //    hashtable.Add("@inStatus", 0);
        //    hashtable.Add("@inAdvisorID", 0);
        //    hashtable.Add("@inUpdatedBy", 0);

        //    hashtable.Add("@OperationName", Operation);


        //    DataUtilities dataUtilities = new DataUtilities();
        //    int result = dataUtilities.ExecuteNonQuery("InsUpdBankDetail", hashtable);
        //    return result;

        //}



    }
}