using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using DataManager;

public class DocumentBL:DataUtilities
{
	public int DocumentManager(string SAID,string Document,char Operation)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inSAID",SAID);
        hsparams.Add("@inDocument",Document);
        hsparams.Add("@OperationName", Operation);
        return ExecuteNonQuery("DocumentManager", hsparams);
    }
}