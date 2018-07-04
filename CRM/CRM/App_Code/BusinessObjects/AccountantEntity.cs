using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountantEntity
/// </summary>
/// 
namespace EntityManager
{
    public class AccountantEntity
    {
        public int AccountantID { get; set; }
        public string AccountantName { get; set; }
        public string AccountantTelNum { get; set; }
        public string AccountantEmail { get; set; }
        public int Type { get; set; }
        public string UICNo { get; set; }
        public int AdvisorID { get; set; }
        public string ReferenceSAID { get; set; }
    }
}