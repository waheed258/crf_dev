using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EntityManager
{
    /// <summary>
    /// Summary description for BankInfoEntity
    /// </summary>
    public class BankInfoEntity
    {
        public int BankDetailID { get; set; }
        public int? Type { get; set; }
        public string SAID { get; set; }
        public string ReferenceID { get; set; }
        public string UIC { get; set; }
        public string BankName { get; set; }
        public string BranchNumber { get; set; }
        public string AccountNumber { get; set; }
        public int? AccountType { get; set; }
        public string Currency { get; set; }
        public string SWIFT { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string FullName { get; set; }
        public int AdvisorID { get; set; }
        public string UpdatedOn { get; set; }
        public int? Status { get; set; }
    }
}