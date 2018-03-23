using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for CredentialsEntity
    /// </summary>
    public class CredentialsEntity
    {
        public int CredentialsID { get; set; }
        public string SAID { get; set; }
        public string EmailID { get; set; }
        public string GenaratePassword { get; set; }
        public string Password { get; set; }
        public int? CreatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Status { get; set; }
    }
}