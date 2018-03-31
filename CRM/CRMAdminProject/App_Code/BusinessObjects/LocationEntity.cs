using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LocationEntity
/// </summary>
/// 
namespace EntityManager
{
    public class LocationEntity
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string MobileNum { get; set; }
        public string TelephoneNum { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string VatRegistration { get; set; }
        public string VatPercentage { get; set; }
        public string PlotNo { get; set; }
        public string BuildingName { get; set; }
        public string FloorNo { get; set; }
        public string FlatNo { get; set; }
        public string RoadName { get; set; }
        public string RoadNo { get; set; }
        public string SuburbName { get; set; }
        public int City { get; set; }
        public string PostalCode { get; set; }
        public int Province { get; set; }
        public int Country { get; set; }       
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}