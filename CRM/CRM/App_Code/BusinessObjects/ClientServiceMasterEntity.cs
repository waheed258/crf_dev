using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for ClientServiceMasterEntity
    /// </summary>
    public class ClientServiceMasterEntity
    {
        public int ClientServiceID { get; set; }
        public string SAID { get; set; }
        public int? ClientService { get; set; }
        public string DetailInformation { get; set; }
        public string AdvisorID { get; set; }
        public string UpdatedOn { get; set; }

        public int? Status { get; set; }
    }
}