using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Collections;
using DataManager;
using System.Data;

/// <summary>
/// Summary description for ResetPasswordBL
/// </summary>
namespace BusinessLogic
{
    public class ResetPasswordBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int ResetPassword(string OldPassword,string NewPassword,string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@OldPassword", OldPassword);
            hashtable.Add("@NewPassword", NewPassword);
            hashtable.Add("@SAID", SAID);
            int result = dataUtilities.ExecuteNonQuery("ResetPassword", hashtable);
            return result;
        }
    }
}