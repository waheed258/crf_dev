using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for TrustEntity
    /// </summary>
    public class TrustEntity
    {
        public int TrustID { get; set; }
        public string UIC { get; set; }
        public string TrustName { get; set; }
        public string YearOfFoundation { get; set; }
        public string Telephone { get; set; }
        public string FaxNo { get; set; }
        public string EmailID { get; set; }
        public string Website { get; set; }
        public string VATNo { get; set; }
        public string UpdatedOn { get; set; }
        public int? AdvisorID { get; set; }
        public string TimeStamp { get; set; }
        public int? Status { get; set; }
        public string ReferenceSAID { get; set; }
    }
}