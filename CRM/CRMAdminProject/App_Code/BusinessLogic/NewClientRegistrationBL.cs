using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Collections;
using System.Data;

namespace BusinessLogic
{
    /// <summary>
    /// Summary description for NewClientRegistrationBL
    /// </summary>
    public class NewClientRegistrationBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int CUDclientinfo(ClientRegistrationEntity clientinfo, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@ClientRegistartionID", 0);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", DBNull.Value);
                hashtable.Add("@VerifiedThough", DBNull.Value);
                hashtable.Add("@Status", 1);
            }
            else
            {
                hashtable.Add("@ClientRegistartionID", clientinfo.ClientRegistartionID);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", DBNull.Value);
                hashtable.Add("@VerifiedThough", DBNull.Value);
                hashtable.Add("@Status", clientinfo.Status);
            }
            hashtable.Add("@SAID", clientinfo.SAID);
            hashtable.Add("@Title", clientinfo.Title);
            hashtable.Add("@FirstName", clientinfo.FirstName);
            hashtable.Add("@LastName", clientinfo.LastName);
            hashtable.Add("@EmailID", clientinfo.EmailID);
            hashtable.Add("@MobileNumber", clientinfo.MobileNumber);
            hashtable.Add("@CompanyName", clientinfo.CompanyName);
            hashtable.Add("@CompanyRegNo", clientinfo.CompanyRegNo);
            hashtable.Add("@TrustName", clientinfo.TrustName);
            hashtable.Add("@TrustRegNo", clientinfo.TrustRegNo);

            hashtable.Add("@Operation", Operation);

            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("ClientCRUD", hashtable);
            return result;
        }

        public int ChangeClientActions(ClientRegistrationEntity clientinfo, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'S')
            {
                hashtable.Add("@ClientStatus", clientinfo.Status);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", DBNull.Value);
                hashtable.Add("@VerifiedThough", DBNull.Value);
                hashtable.Add("@ClientRegistrationID", clientinfo.ClientRegistartionID);
            }
            hashtable.Add("@Operation", Operation);
            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("usp_ClientActions", hashtable);
            return result;
        }

        public DataSet GetClientRegisteredList()
        {
            var newClientRegList = new List<ClientRegistrationEntity>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", 0);
            DataSet ds = dataUtilities.ExecuteDataSet("GetAllClients", hashtable);
            return ds;
        }

        public DataSet GetClientStatus()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetClientRegStatus");
            return ds;
        }
    }
}