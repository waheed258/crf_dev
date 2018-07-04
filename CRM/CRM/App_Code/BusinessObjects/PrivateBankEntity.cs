using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PrivateBankEntity
/// </summary>
namespace EntityManager
{
    public class PrivateBankEntity
    {
        public int PrivateBankID { get; set; }
        public string PrivateBankName { get; set; }
        public string PrivateContactNum { get; set; }
        public string UICNo { get; set; }
        public int AdvisorID { get; set; }
        public string ReferenceSAID { get; set; }
     
    }
}