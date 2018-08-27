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
    public DataSet GetDocumentType()
    {
        return ExecuteDataSet("GetDocType");
    }
	public int DocumentManager(DocumentBO _objDoc,char operation)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@DocId", _objDoc.DocId);
        hsparams.Add("@inReferenceSAID",_objDoc.ReferenceSAID );
        hsparams.Add("@inUIC", _objDoc.UIC);
        hsparams.Add("@inSAID",_objDoc.SAID);
        hsparams.Add("@inDocument", _objDoc.Document);
        hsparams.Add("@inDocumentName",_objDoc.DocumentName);
        hsparams.Add("@inDocType", _objDoc.DocType);
        hsparams.Add("@inClientType", _objDoc.ClientType);
        hsparams.Add("@inStatus", _objDoc.Status);
        hsparams.Add("@inAdvisorId", _objDoc.AdvisorID);
        hsparams.Add("@OperationName", operation);
        return ExecuteNonQuery("DocumentManager", hsparams);
    }

    public DataSet GetDocuments(string SAID, string UIC, int ClientType, string ReferenceSAID)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inSAID", SAID);
        hsparams.Add("@inUIC", UIC);
        hsparams.Add("@inClientType", ClientType);
        hsparams.Add("@inReferenceSAID", ReferenceSAID);
        return ExecuteDataSet("GetDocuments", hsparams);
    }

    public DataSet GetDocumentById(int DocID, string ReferenceSAID)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inDocId", DocID);
        hsparams.Add("@inReferenceSAID", ReferenceSAID);
        return ExecuteDataSet("GetDocumentById", hsparams);
    }

    public int DeleteDocument(int DocId,string referenceSAId)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inDocId",DocId);
        hsparams.Add("@inReferenceSAID",referenceSAId);

        return ExecuteNonQuery("DeleteDocumet", hsparams);
    }

    public DataSet GetDocumentList(string ReferenceSAID,int ClientType,string RefUIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@ReferenceSAID", ReferenceSAID);
        hsparams.Add("@ClientType", ClientType);
        hsparams.Add("@RefUIC", RefUIC);
        return ExecuteDataSet("usp_GetDocumentList", hsparams);
    }
}