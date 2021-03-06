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
/// Summary description for ChildrenBL
/// </summary>
/// 
namespace BusinessLogic
{
    public class ChildrenBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int ChildCRUD(ChildrenEntity childEntity ,char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if(Operation=='i')
            {
                hashtable.Add("@ChildrenID",0);
                
                
            }
            else
            {               
                hashtable.Add("@ChildrenID", childEntity.ChildrenID);
               
            }
            hashtable.Add("@SAID", childEntity.SAID);
            hashtable.Add("@ReferenceSAID", childEntity.ReferenceSAID);
            hashtable.Add("@Title", childEntity.Title);
            hashtable.Add("@FirstName", childEntity.FirstName);
            hashtable.Add("@LastName", childEntity.LastName);
            hashtable.Add("@EmailID", childEntity.EmailID);
            hashtable.Add("@Mobile", childEntity.Mobile);
            hashtable.Add("@Phone", childEntity.Phone);
            hashtable.Add("@TaxRefNo", childEntity.TaxRefNo);
            hashtable.Add("@DateOfBirth", childEntity.DateOfBirth);
            hashtable.Add("@Image", childEntity.Image);
            hashtable.Add("@AdvisorID", childEntity.AdvisorID);
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("ChildCRUD", hashtable);
            return result;


        }

        public DataSet GetAllChilds(string RSAID, string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", RSAID);
            hashtable.Add("@SAID", SAID);
            DataSet ds = dataUtilities.ExecuteDataSet("GetChildDetails", hashtable);
            return ds;
        }

        public int DeleteChildDetails(string SAID, int AdvisorID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            hashtable.Add("@Deletedby", AdvisorID);
            int result = dataUtilities.ExecuteNonQuery("DeleteChild", hashtable);
            return result;
        }



    }
}
