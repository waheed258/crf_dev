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
                {"@inSAID",DBNull.Value},
                {"@inEmailID",_objCredentials.EmailID},
                {"@inGenaratePassword",DBNull.Value},
                {"@inPassword",_objCredentials.Password},
                {"@Image",_objCredentials.Image},
                {"@FirstName",_objCredentials.FirstName},
                {"@LastName",_objCredentials.LastName},
                {"@inCreatedBy",DBNull.Value},
                {"@inUpdatedBy",DBNull.Value}
               
            };
            return ExecuteNonQuery("CredentialsManager", hsparams);
        }
    }
}