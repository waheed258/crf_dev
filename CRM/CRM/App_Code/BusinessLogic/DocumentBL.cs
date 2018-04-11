using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using DataManager;
using EntityManager;

public class DocumentBL:DataUtilities
{
	public int DocumentManager(DocumentBO _objDoc,char operation)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@DocId", _objDoc.DocId);
        hsparams.Add("@inReferenceSAID",_objDoc.ReferenceSAID );
        hsparams.Add("@inUIC", _objDoc.UIC);
        hsparams.Add("@inSAID",_objDoc.SAID);
        hsparams.Add("@inDocument", _objDoc.Document);
        hsparams.Add("@inDocumentName",_objDoc.DocumentName);
        hsparams.Add("@inDocType",_objDoc.DocType);
        hsparams.Add("@inStatus", _objDoc.Status);
        hsparams.Add("@inAdvisorId", _objDoc.AdvisorID);
        hsparams.Add("@OperationName", operation);
        return ExecuteNonQuery("DocumentManager", hsparams);
    }
}