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
public class ClientLoginBL
{
    DataUtilities dataUtilities = new DataUtilities();
    DataSet ds = new DataSet();
    public DataSet ValidateClient(string SAID)
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("@SAID", SAID);
        ds = dataUtilities.ExecuteDataSet("ValidateClient", hashtable);
        return ds;
    }
}