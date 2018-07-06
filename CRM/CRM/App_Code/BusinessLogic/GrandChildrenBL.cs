using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using DataManager;
using System.Collections;
using System.Data;

namespace BusinessLogic
{
    public class GrandChildrenBL
    {

        DataUtilities dataUtilities = new DataUtilities();

        public int GrandChildCRUD(GrandChildrenEntity grandChildrenEntity, char Operation)   
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@GrandchildrenID", 0);
            }
            else            {
                hashtable.Add("@GrandchildrenID", grandChildrenEntity.GrandChildrenID);
            }
            hashtable.Add("@SAID", grandChildrenEntity.SAID);
            hashtable.Add("@FirstName", grandChildrenEntity.FirstName);
            hashtable.Add("@LastName", grandChildrenEntity.LastName);
            hashtable.Add("@Mobile", grandChildrenEntity.Mobile);
            hashtable.Add("@Phone", grandChildrenEntity.Phone);
            hashtable.Add("@ReferenceSAID", grandChildrenEntity.ReferenceSAID);
            hashtable.Add("@TaxRefNo", grandChildrenEntity.TaxRefNo); 
            hashtable.Add("@Title", grandChildrenEntity.Title);
            hashtable.Add("@EmailID", grandChildrenEntity.EmailID);
            hashtable.Add("@Image", grandChildrenEntity.Image);
            hashtable.Add("@DateOfBirth", grandChildrenEntity.DateOfBirth);
            hashtable.Add("@AdvisorID", grandChildrenEntity.AdvisorID);
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("GrandChildCRUD", hashtable);
            return result;
        }


        public DataSet GetAllGrandChild(string RefSAID, string SAID) 
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", RefSAID);
            hashtable.Add("@GrandchildrenSAID", SAID);
            return dataUtilities.ExecuteDataSet("GetGrandchild", hashtable);
        }

        public int DeleteGrandChild(string SAID, int AdvisorID) 
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            hashtable.Add("@Deletedby", AdvisorID);
            int result = dataUtilities.ExecuteNonQuery("DeleteGrandchildren", hashtable);
            return result;
        }

    }
} 