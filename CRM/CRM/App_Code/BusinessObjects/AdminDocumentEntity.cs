using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EntityManager
{
    /// <summary>
    /// Summary description for AdminDocumentEntity
    /// </summary>
    public class AdminDocumentEntity
    {

        public int? DocId { get; set; }  
        public string SAID { get; set; }
   
        public string Document { get; set; }
        public string DocumentName { get; set; }
        public string UpdatedOn { get; set; }
        public int? AdvisorID { get; set; }   
        public int? DocType { get; set; } 
        public int? Status { get; set; }

    }
}