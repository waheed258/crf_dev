using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoicePaymentEntity
/// </summary>
namespace EntityManager
{
    public class InvoicePaymentEntity
    {
        public int PaymentID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal DueAmount { get; set; }
        public string PaymentDate { get; set; }
        public string Notes { get; set; }
        public decimal PaymentReceived { get; set; }
        public string PaymentMode { get; set; }
        public string InvoiceNum { get; set; }
    }
}