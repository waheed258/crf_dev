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
    
    public partial class tbl_IndividualDetail
    {
        public int IndividualID { get; set; }
        public string Type { get; set; }
        public string SAID { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }
        public string IDPaths { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> Status { get; set; }
        public byte[] DeleteFlag { get; set; }
    }
}
