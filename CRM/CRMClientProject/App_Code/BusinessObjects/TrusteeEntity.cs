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
        public int SpouseID { get; set; }
        public string SAID { get; set; }
        public string ReferenceSAID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string TaxRefNo { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> AdvisorID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> TimeStamp { get; set; }
    }
}