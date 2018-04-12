using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using DataManager;

namespace BusinessLogic
{
    public class CredentialsBL : DataUtilities
    {
        public int ManageCredentials(CredentialsBO _objCredentials, char Operation)
        {
            Hashtable hsparams = new Hashtable
            {
                {"@inOperationName",Operation},
                {"@inSAID",_objCredentials.SAID},
                {"@inEmailID",_objCredentials.EmailID},
                {"@inGenaratePassword",_objCredentials.GenaratePassword},
                {"@inPassword",_objCredentials.Password},
                {"@inCreatedBy",DBNull.Value},
                {"@inUpdatedBy",DBNull.Value},
                {"@FirstName",_objCredentials.FirstName},
                {"@LastName",_objCredentials.LastName},
                {"@Image",DBNull.Value}
            };
            return ExecuteNonQuery("CredentialsManager", hsparams);
        }

        public int InsImage(string Image, string SAID)
        {
            DataUtilities dataUtilities = new DataUtilities();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@Image", Image);
            hashtable.Add("@SAID", SAID);
            return dataUtilities.ExecuteNonQuery("InsImageCredentials", hashtable);
        }
    }
}