using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for CompanyShareEntity
    /// </summary>
    public class CompanyShareEntity
    {
        public int CompanyShareID { get; set; }
        public string CompanyID { get; set; }
        public int? SAID { get; set; }
        public int? Share { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int? Status { get; set; }
    }
}