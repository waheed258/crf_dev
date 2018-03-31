using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    /// <summary>
    /// Summary description for AddressEntity
    /// </summary>
    public class AddressEntity
    {
        public int AddressDetailID { get; set; }
        public int? Type { get; set; }
        public string SAID { get; set; }
        public string ReferenceSAID { get; set; }
        public string UIC { get; set; }
        public string HouseNo { get; set; }
        public string BuildingName { get; set; }
        public string Floor { get; set; }
        public string FlatNo { get; set; }
        public string RoadName { get; set; }
        public string RoadNo { get; set; }
        public string SuburbName { get; set; }
        public int? City { get; set; }
        public string PostalCode { get; set; }
        public int? Province { get; set; }
        public int? Country { get; set; }
        public int? AdvisorId { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}