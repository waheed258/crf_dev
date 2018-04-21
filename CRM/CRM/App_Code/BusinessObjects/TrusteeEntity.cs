using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for TrusteeEntity
    /// </summary>
    public class TrusteeEntity
    {
        public int TrusteeId { get; set; }
        public string SAID { get; set; }
        public string ReferenceSAID { get; set; }
        public string ReferenceUIC{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string TaxRefNo { get; set; }
        public int? AdvisorID { get; set; }
        public int? Status { get; set; }
    }
}