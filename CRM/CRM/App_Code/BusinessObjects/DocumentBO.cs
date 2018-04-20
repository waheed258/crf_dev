using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DocumentBO
/// </summary>
public class DocumentBO
{
    public int DocId { get; set; }
    public string SAID { get; set; }
    public string ReferenceSAID { get; set; }
    public string UIC { get; set; }
    public string DocumentName { get; set; }
    public string Document{ get; set; }
    public int DocType { get; set; }
    public int ClientType { get; set; }

    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public int? AdvisorID { get; set; }
    public int? Status { get; set; }
}