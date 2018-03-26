using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdvisorEntity
/// </summary>
/// 
namespace EntityManager
{
    public class AdvisorEntity
    {
        public int AdvisorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string EmailID { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int Designation { get; set; }
        public int Branch { get; set; }
        public int AdvisorType { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }
        public int AdvisorRole { get; set; }
        public int? UpdatedBy { get; set; }
    }
}