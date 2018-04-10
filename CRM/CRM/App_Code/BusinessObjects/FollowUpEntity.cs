using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FollowUpEntity
/// </summary>
/// 

namespace EntityManager
{
    public class FollowUpEntity
    {
        public int FollowUpID { get; set; }
        public string ServiceRequest { get; set; }
        public string ClientSAID { get; set; }
        public string ClientName { get; set; }
        public string AssignedTo { get; set; }
        public string FollowUpDate { get; set; }
        public string FollowUpTime { get; set; }
        public string DueDate { get; set; }
        public int Priority { get; set; }
        public int ActivityType { get; set; }
        public int ClientServiceID { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}