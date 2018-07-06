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
    public class ParentBL
    {
        DataUtilities dataUtilities = new DataUtilities();

        public int ParentCRUD(ParentEntity ParentEntity, char Operation)  
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@ParentID", 0);
            }
            else
            {
                hashtable.Add("@ParentID", ParentEntity.ParentID);
            }
            hashtable.Add("@SAID", ParentEntity.SAID);
            hashtable.Add("@FirstName", ParentEntity.FirstName);
            hashtable.Add("@LastName", ParentEntity.LastName);
            hashtable.Add("@Mobile", ParentEntity.Mobile);
            hashtable.Add("@Phone", ParentEntity.Phone);
            hashtable.Add("@ReferenceSAID", ParentEntity.ReferenceSAID);
            hashtable.Add("@TaxRefNo", ParentEntity.TaxRefNo);
            hashtable.Add("@Title", ParentEntity.Title);
            hashtable.Add("@EmailID", ParentEntity.EmailID);
            hashtable.Add("@Image", ParentEntity.Image);
            hashtable.Add("@DateOfBirth", ParentEntity.DateOfBirth);
            hashtable.Add("@AdvisorID", ParentEntity.AdvisorID);
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("ParentCRUD", hashtable);
            return result;
        }


        public DataSet GetAllParent(string RefSAID, string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", RefSAID);
            hashtable.Add("@ParentSAID", SAID);
            return dataUtilities.ExecuteDataSet("GetParent", hashtable);
        }

        public int DeleteParent(string SAID, int AdvisorID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            hashtable.Add("@Deletedby", AdvisorID);
            int result = dataUtilities.ExecuteNonQuery("DeleteParent", hashtable);
            return result;
        }

    }
}