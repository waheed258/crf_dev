using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using DataManager;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for SpouseBL
/// </summary>
namespace BusinessLogic
{
    public class SpouseBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int SpouseCRUD(SpouseEntity spouseEntity, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@SpouseID", 0);
            }
            else
            {
                hashtable.Add("@SpouseID", spouseEntity.SpouseID);
            }
            hashtable.Add("@SAID", spouseEntity.SAID);
            hashtable.Add("@FirstName", spouseEntity.FirstName);
            hashtable.Add("@LastName", spouseEntity.LastName);
            hashtable.Add("@Mobile", spouseEntity.Mobile);
            hashtable.Add("@Phone", spouseEntity.Phone);
            hashtable.Add("@ReferenceSAID", spouseEntity.ReferenceSAID);
            hashtable.Add("@TaxRefNo", spouseEntity.TaxRefNo);
            hashtable.Add("@Title", spouseEntity.Title);
            hashtable.Add("@EmailID", spouseEntity.EmailID);
            hashtable.Add("@DateOfBirth", spouseEntity.DateOfBirth);
            hashtable.Add("@AdvisorID",spouseEntity.AdvisorID);
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("SpouseCRUD", hashtable);
            return result;
        }
        public DataSet GetAllSpouse(string RefSAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", RefSAID);
            return dataUtilities.ExecuteDataSet("GetSpouse", hashtable);
        }
       
        public int DeleteSpouse(string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            int result = dataUtilities.ExecuteNonQuery("DeleteSpouse", hashtable);
            return result;
        }
    }
}