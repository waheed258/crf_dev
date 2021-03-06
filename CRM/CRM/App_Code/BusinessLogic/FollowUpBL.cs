﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using DataManager;
using EntityManager;

/// <summary>
/// Summary description for FollowUpBL
/// </summary>
/// 
namespace BusinessLogic
{
    public class FollowUpBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        
        

        public int FollowUpCRUD(FollowUpEntity followupEntity, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@FollowUpID", 0);


            }
            else
            {
                hashtable.Add("@FollowUpID", followupEntity.FollowUpID);

            }
            hashtable.Add("@ServiceRequest", followupEntity.ServiceRequest);
            hashtable.Add("@ClientSAID", followupEntity.ClientSAID);
            hashtable.Add("@ClientName", followupEntity.ClientName);
            hashtable.Add("@AssignedTo", followupEntity.AssignedTo);
            hashtable.Add("@FollowUpDate", followupEntity.FollowUpDate);
            //hashtable.Add("@FollowUpTime", followupEntity.FollowUpTime);
            hashtable.Add("@DueDate", followupEntity.DueDate);
            //hashtable.Add("@DueTime", followupEntity.DueTime);            
            hashtable.Add("@ActivityType", followupEntity.ActivityType);
            hashtable.Add("@ClientServiceID", followupEntity.ClientServiceID);
            hashtable.Add("@Notes", followupEntity.Notes);  
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("usp_FollowUpCRUD", hashtable);
            return result;


        }

        public DataSet GetFollowupUpdates(int ClientServiceID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ClientServiceID", ClientServiceID);
            DataSet ds = dataUtilities.ExecuteDataSet("GetFollowUpUpdates", hashtable);
            return ds;
        }
        public DataSet GetServiceStatus()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetFollowUpServiceStatus");
            return ds;
        }
    }
}