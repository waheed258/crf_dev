﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class crm_dev_dbEntities : DbContext
    {
        public crm_dev_dbEntities()
            : base("name=crm_dev_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_AccountType> tbl_AccountType { get; set; }
        public DbSet<tbl_Advisor> tbl_Advisor { get; set; }
        public DbSet<tbl_AdvisorStatus> tbl_AdvisorStatus { get; set; }
        public DbSet<tbl_Branch> tbl_Branch { get; set; }
        public DbSet<tbl_Children> tbl_Children { get; set; }
        public DbSet<tbl_City> tbl_City { get; set; }
        public DbSet<tbl_ClientRegistration> tbl_ClientRegistration { get; set; }
        public DbSet<tbl_ClientRegStatus> tbl_ClientRegStatus { get; set; }
        public DbSet<tbl_ClientService> tbl_ClientService { get; set; }
        public DbSet<tbl_ClientServiceMaster> tbl_ClientServiceMaster { get; set; }
        public DbSet<tbl_ClientType> tbl_ClientType { get; set; }
        public DbSet<tbl_CompanyShare> tbl_CompanyShare { get; set; }
        public DbSet<tbl_Country> tbl_Country { get; set; }
        public DbSet<tbl_Credentials> tbl_Credentials { get; set; }
        public DbSet<tbl_Designation> tbl_Designation { get; set; }
        public DbSet<tbl_FeedBack> tbl_FeedBack { get; set; }
        public DbSet<tbl_Province> tbl_Province { get; set; }
        public DbSet<tbl_RoleMaster> tbl_RoleMaster { get; set; }
        public DbSet<tbl_Spouse> tbl_Spouse { get; set; }
        public DbSet<tbl_Trust> tbl_Trust { get; set; }
        public DbSet<tbl_TypeofAdvisor> tbl_TypeofAdvisor { get; set; }
        public DbSet<tbl_AddressDetail> tbl_AddressDetail { get; set; }
        public DbSet<tbl_BankDetail> tbl_BankDetail { get; set; }
        public DbSet<tbl_ClientPersonal> tbl_ClientPersonal { get; set; }
        public DbSet<tbl_CompanyDetail> tbl_CompanyDetail { get; set; }
        public DbSet<tbl_Director> tbl_Director { get; set; }
        public DbSet<tbl_TrustSettler> tbl_TrustSettler { get; set; }
        public DbSet<tbl_Beneficiary> tbl_Beneficiary { get; set; }
        public DbSet<tbl_Trustee> tbl_Trustee { get; set; }
    }
}
