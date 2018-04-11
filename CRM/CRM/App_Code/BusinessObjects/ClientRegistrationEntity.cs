﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EntityManager
{
    /// <summary>
    /// Summary description for ClientRegistrationEntity
    /// </summary>
    public class ClientRegistrationEntity
    {
        public int ClientRegistartionID { get; set; }
        public string SAID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRegNo { get; set; }
        public string TrustName { get; set; }
        public string TrustRegNo { get; set; }
        public int? VerifiedBy { get; set; }
        public string VerifiedOn { get; set; }
        public string VerifiedThough { get; set; }
        public int? Status { get; set; }
    }
}