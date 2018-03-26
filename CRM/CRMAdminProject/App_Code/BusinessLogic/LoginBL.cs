using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for LoginBL
/// </summary>
public class LoginBL
{
    DataUtilities dataUtilities = new DataUtilities();
    DataSet ds = new DataSet();
    public DataSet ValidateUser(string EmailId)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@EmailID", EmailId);
        ds = dataUtilities.ExecuteDataSet("ValidateUser", hashtable);
        return ds;
    }
}