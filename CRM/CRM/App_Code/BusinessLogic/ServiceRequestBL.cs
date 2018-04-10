using System.Text;
using System.Threading.Tasks;
using DataManager;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;
using System.Collections;
using EntityManager;
using System.Web;
using System.Collections.Generic;
using System;


namespace BusinessLogic
{

    public class ServiceRequestBL
    {

        DataUtilities dataUtilities = new DataUtilities();
        DataSet ds = new DataSet();


        public DataSet GetServiceRequestmaster() 
        {
            ds = dataUtilities.ExecuteDataSet("GetClientService");
            return ds;
        }

        public DataSet GetServiceRequest(string SAID)
        {
            var newAddress = new List<ClientServiceMasterEntity>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            DataSet ds = dataUtilities.ExecuteDataSet("usp_GetClientService", hashtable);
            return ds;
        }


        public int CUDUServiceRequest(ClientServiceMasterEntity clinetservicem, char Operation) 
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@inClientServiceID", 0);
                hashtable.Add("@inSAID", clinetservicem.SAID);
                hashtable.Add("@inClientService", clinetservicem.ClientService);
                hashtable.Add("@inDetailInformation", clinetservicem.DetailInformation);
                hashtable.Add("@inStatus", clinetservicem.Status);
                hashtable.Add("@OperationName", Operation);

            }
            else if(Operation == 'a')
            {
                hashtable.Add("@inClientServiceID", clinetservicem.ClientServiceID);
                hashtable.Add("@AdvisorID", clinetservicem.AdvisorID);
                hashtable.Add("@inSAID", DBNull.Value);
                hashtable.Add("@inClientService", DBNull.Value);
                hashtable.Add("@inDetailInformation", DBNull.Value);
                hashtable.Add("@inStatus", DBNull.Value);
                hashtable.Add("@OperationName", Operation);

            }
            else
            {
                hashtable.Add("@inClientServiceID", clinetservicem.ClientServiceID);
                hashtable.Add("@inSAID", clinetservicem.SAID);
                hashtable.Add("@inClientService", clinetservicem.ClientService);
                hashtable.Add("@inDetailInformation", clinetservicem.DetailInformation);
                hashtable.Add("@inStatus", clinetservicem.Status);
                hashtable.Add("@OperationName", Operation);
            }
           
          
            

            DataUtilities dataUtilities = new DataUtilities();
            int result = dataUtilities.ExecuteNonQuery("InsUpAddressClientServiceMaster", hashtable);
            return result;

        }


        public int DeleteServicesDetails(string ClientServiceID)  
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ClientServiceID", @ClientServiceID);
            int result = dataUtilities.ExecuteNonQuery("DeleteClientServicemaster", hashtable);
            return result;
        }

        public DataSet GetAdvisors()
        {
            Hashtable hashtable = new Hashtable();
            DataSet ds = dataUtilities.ExecuteDataSet("GetAdvisors", hashtable);
            return ds;
        }

        public DataSet GetPriority()
        {

            DataSet ds = dataUtilities.ExecuteDataSet("usp_GetPriority");
            return ds;
        }

        public DataSet GetActivityType()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("usp_GetActivityType");
            return ds;
        }

    }
}