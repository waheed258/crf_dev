//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ClientRegistration
    {
        public int ClientRegistartionID { get; set; }
        public string SAID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegNo { get; set; }
        public string TrustName { get; set; }
        public string TrustRegNo { get; set; }
        public Nullable<int> VerifiedBy { get; set; }
        public Nullable<System.DateTime> VerifiedOn { get; set; }
        public string VerifiedThough { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}