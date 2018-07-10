using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using DataManager;


public class ActivitylogBL
{
    DataUtilities dataUtilities = new DataUtilities();
    public DataSet GetActivitylog() 
    {

        Hashtable hashtable = new Hashtable();
        DataSet ds = dataUtilities.ExecuteDataSet("GetActivityLog", hashtable);
        return ds;
    }

}