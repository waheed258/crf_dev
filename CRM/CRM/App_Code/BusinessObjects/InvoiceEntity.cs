﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoiceEntity
/// </summary>
/// 
namespace EntityManager
{
    public class InvoiceEntity
    {
        public int SrNo { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceDate { get; set; }
        public int VatInclusive { get; set; }
        public string ClientSRNO { get; set; }
        public decimal TotalAmount { get; set; }
     
        
    }
}