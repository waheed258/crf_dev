using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EntityManager
{

    public class GrandChildrenEntity
    {

        public int GrandChildrenID { get; set; } 
        public string SAID { get; set; }
        public string ReferenceSAID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string TaxRefNo { get; set; }
        public string Image { get; set; }
        public string DateOfBirth { get; set; }
        public string UpdatedOn { get; set; }
        public int? AdvisorID { get; set; }
        public int? Status { get; set; }


    }
}