using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    public class CredentialsBO
    {
        public string SAID { get; set; }
        public string EmailID { get; set; }
        public string GenaratePassword { get; set; }
        public string Password { get; set; }
        public string TimeStamp { get; set; }
        public int? CreatedBy { get; set; }
        public string UpdatedBy{ get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int? UpdatedOn { get; set; }
        public int? Status { get; set; }
    }
}