using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using DataManager;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for ClientServiceBL
/// </summary>
namespace BusinessLogic
{
    public class ClientServiceBL : DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int CURDClientService(ClientServiceEntity clientServiceEntity, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@ServiceID", 0);
            }
            else
            {
                hashtable.Add("@ServiceID", clientServiceEntity.ServiceID);
            }

            hashtable.Add("@ServiceName", clientServiceEntity.ServiceName);
            hashtable.Add("@Operation", Operation);


           
            int result = dataUtilities.ExecuteNonQuery("ClientServiceCrud", hashtable);
            return result;

        }
        public DataSet GetClientService()
        {
            Hashtable hashtable = new Hashtable();
            return dataUtilities.ExecuteDataSet("GetClientService", hashtable);
        }
        public int DeleteClientService(int ServiceID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ServiceID", ServiceID);
            int result = dataUtilities.ExecuteNonQuery("DeleteClientService", hashtable);
            return result;
        }
    }
}