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
    
    public partial class tbl_Director
    {
        public int DirectorID { get; set; }
        public string ReferenceSAID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> AdvisorID { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}
