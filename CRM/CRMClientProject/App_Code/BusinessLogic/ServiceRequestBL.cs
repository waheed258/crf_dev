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

            }
            else
            {
                hashtable.Add("@inClientServiceID", clinetservicem.ClientServiceID); 
            }
           
            hashtable.Add("@inSAID", clinetservicem.SAID);
            hashtable.Add("@inClientService", clinetservicem.ClientService);
            hashtable.Add("@inDetailInformation", clinetservicem.DetailInformation);
            hashtable.Add("@inStatus", clinetservicem.Status);      
            hashtable.Add("@OperationName", Operation);

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

    }
}