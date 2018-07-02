using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for BenificiaryEntity
    /// </summary>
    public class BenificiaryEntity
    {
        public int BeneficiaryID { get; set; }
        public string ReferenceSAID { get; set; }
        public string UIC { get; set; }
        public string SAID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string TaxRefNo { get; set; }
        public string UpdatedOn { get; set; }
        public int? AdvisorID { get; set; }
        public int? Type { get; set; }
        public int? Status { get; set; }
        public string UICNo { get; set; }
        public string CompanyName { get; set; }
        public string YearOfEstablishment { get; set; }
        public string VATNo { get; set; }
        public string CompanyTelephone { get; set; }
        public string CompanyEmailID { get; set; }
        public string CompanyWebsite { get; set; }
        public int BenificiaryType { get; set; }
        
    }
}