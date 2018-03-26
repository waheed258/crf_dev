using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for DirectorEntity
    /// </summary>
    public class DirectorEntity
    {
        public int DirectorID { get; set; }
        public string ReferenceSAID { get; set; }
        public int? CompanyID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string UpdatedOn { get; set; }
        public int? AdvisorID { get; set; }
    }
}