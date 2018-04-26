using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for CompanyInfoEntity
    /// </summary>
    public class CompanyInfoEntity
    {
        public int CompanyID { get; set; }
        public string ReferenceSAID { get; set; }
        public string UIC { get; set; }
        public string CompanyName { get; set; }
        public string YearOfEstablishment { get; set; }
        public string Telephone { get; set; }
        public string FaxNo { get; set; }
        public string EmailID { get; set; }
        public string Website { get; set; }
        public string VATNo{ get; set; }
        public string UpdatedOn { get; set; }
        public string TrustUIC { get; set; }
        public int? AdvisorID { get; set; }
        public int? Status { get; set; }
    }
}