using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManager;
using EntityManager;
using System.Collections;
using System.Data;


namespace BusinessLogic
{

    /// <summary>
    /// Summary description for ClientDcoumentAdvisorBL
    /// </summary>
    public class ClientDcoumentAdvisorBL:DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();

        public DataSet GetClientDocuments() 
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetClientDocumentsByAdvisor");
            return ds;
        }


        public int AdminDocumentManager(AdminDocumentEntity admindocentity, char operation) 
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@DocId", admindocentity.DocId);           
            hsparams.Add("@inSAID", admindocentity.SAID);
            hsparams.Add("@inDocType", admindocentity.DocType); 
            hsparams.Add("@inDocument", admindocentity.Document);
            hsparams.Add("@inDocumentName", admindocentity.DocumentName);                       
            hsparams.Add("@inStatus", admindocentity.Status);
            hsparams.Add("@inAdvisorId", admindocentity.AdvisorID);
            hsparams.Add("@OperationName", operation);
            return ExecuteNonQuery("AdminDocumentManager", hsparams);
           
        }

        public DataSet GetDocuments(string SAID, int DocId)
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inSAID", SAID);
            hsparams.Add("@inDocId", DocId);
            return ExecuteDataSet("GetAdminDocuments", hsparams);
        }

        public DataSet GetAdminDocumentById(int DocID) 
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inDocId", DocID);
            return ExecuteDataSet("GetAdminDocumentById", hsparams);
        }

        public int DeleteAdminDocument(int DocId) 
        {
            Hashtable hsparams = new Hashtable();
            hsparams.Add("@inDocId", DocId);

            return ExecuteNonQuery("DeleteAdminDocumet", hsparams);
        }

    }
}