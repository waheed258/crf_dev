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

        public int ChangeClientActions(ClientRegistrationEntity clientinfo,FeedbackEntity feedbackEntity, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'S')
            {
                hashtable.Add("@ClientStatus", clientinfo.Status);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", DBNull.Value);
                hashtable.Add("@VerifiedThough", DBNull.Value);
                hashtable.Add("@ClientRegistrationID", clientinfo.ClientRegistartionID);
                hashtable.Add("@ClientSAID", DBNull.Value);
                hashtable.Add("@ClientFeedback", DBNull.Value);
                hashtable.Add("@AdvisorFeedback", DBNull.Value);
            }
            else if (Operation == 'V')
            {
                hashtable.Add("@ClientStatus", clientinfo.Status);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", clientinfo.VerifiedOn);
                hashtable.Add("@VerifiedThough", clientinfo.VerifiedThough);
                hashtable.Add("@ClientRegistrationID", clientinfo.ClientRegistartionID);
                hashtable.Add("@ClientSAID", clientinfo.SAID);
                hashtable.Add("@ClientFeedback", DBNull.Value);
                hashtable.Add("@AdvisorFeedback", feedbackEntity.AdvisorFeedBack);
            }
            else
            {
                hashtable.Add("@ClientStatus", DBNull.Value);
                hashtable.Add("@VerifiedBy", DBNull.Value);
                hashtable.Add("@VerifiedOn", DBNull.Value);
                hashtable.Add("@VerifiedThough", DBNull.Value);
                hashtable.Add("@ClientRegistrationID", DBNull.Value);
                hashtable.Add("@ClientSAID", clientinfo.SAID);
                hashtable.Add("@ClientFeedback", feedbackEntity.ClientFeedBack);
                hashtable.Add("@AdvisorFeedback", DBNull.Value);
            }
            hashtable.Add("@Operation", Operation);
            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("usp_ClientActions", hashtable);
            return result;
        }

        public DataSet GetClientRegisteredList()
        {            
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", 0);
            DataSet ds = dataUtilities.ExecuteDataSet("GetAllClients", hashtable);
            return ds;
        }
        public DataSet GetActiveClientList() {            
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", 0);
            DataSet ds = dataUtilities.ExecuteDataSet("GetActiveClients", hashtable);
            return ds;
        }

        public DataSet GetClientStatus()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetClientRegStatus");
            return ds;
        }

        public int CheckClient(string Email, string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@EmailID", Email);
            hashtable.Add("@SAID", SAID);
            hashtable.Add("@Exists", DBNull.Value);
            return dataUtilities.ExecuteNonQuery("usp_CheckClientRegistration", hashtable, "@return");
        }
    }
}