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
    
        public DbSet<tbl_admin_User> tbl_admin_User { get; set; }
        public DbSet<tbl_City> tbl_City { get; set; }
        public DbSet<tbl_CompanyDetail> tbl_CompanyDetail { get; set; }
        public DbSet<tbl_CompanyShare> tbl_CompanyShare { get; set; }
        public DbSet<tbl_Country> tbl_Country { get; set; }
        public DbSet<tbl_IndividualDetail> tbl_IndividualDetail { get; set; }
        public DbSet<tbl_Province> tbl_Province { get; set; }
        public DbSet<tbl_Status> tbl_Status { get; set; }
        public DbSet<tbl_TrustDetail> tbl_TrustDetail { get; set; }
        public DbSet<tbl_User> tbl_User { get; set; }
        public DbSet<tbl_UserAddressDetail> tbl_UserAddressDetail { get; set; }
        public DbSet<tbl_UserBankDetail> tbl_UserBankDetail { get; set; }
        public DbSet<tbl_UserMasterDetail> tbl_UserMasterDetail { get; set; }
        public DbSet<tbl_ClientReg> tbl_ClientReg { get; set; }
    }
}
