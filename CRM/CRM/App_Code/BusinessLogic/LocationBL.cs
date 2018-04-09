using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using DataManager;
using EntityManager;

/// <summary>
/// Summary description for LocationBL
/// </summary>
/// 
namespace BusinessLogic
{
    public class LocationBL:DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();

        public int LocationCRUD(LocationEntity locationEntity,char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation== 'i')
            {
                hashtable.Add("@LocationID",0);
            }
            else
            {
                hashtable.Add("@LocationID", locationEntity.LocationID);
            }
            
            hashtable.Add("@LocationName", locationEntity.LocationName);
            hashtable.Add("@MobileNum", locationEntity.MobileNum);
            hashtable.Add("@TelephoneNum", locationEntity.TelephoneNum);
            hashtable.Add("@PrimaryEmail", locationEntity.PrimaryEmail);
            hashtable.Add("@SecondaryEmail", locationEntity.SecondaryEmail);
            hashtable.Add("@VatRegistration", locationEntity.VatRegistration);
            hashtable.Add("@VatPercentage", locationEntity.VatPercentage);
            hashtable.Add("@PlotNo", locationEntity.PlotNo);
            hashtable.Add("@BuildingName", locationEntity.BuildingName);
            hashtable.Add("@FloorNo", locationEntity.FloorNo);
            hashtable.Add("@FlatNo", locationEntity.FlatNo);
            hashtable.Add("@RoadName", locationEntity.RoadName);
            hashtable.Add("@RoadNo", locationEntity.RoadNo);
            hashtable.Add("@SuburbName", locationEntity.SuburbName);
            hashtable.Add("@City", locationEntity.City);
            hashtable.Add("@PostalCode", locationEntity.PostalCode);
            hashtable.Add("@Province", locationEntity.Province);
            hashtable.Add("@Country", locationEntity.Country);
            hashtable.Add("@CreatedBy", locationEntity.CreatedBy);
            hashtable.Add("@UpdatedBy", locationEntity.UpdatedBy);
            hashtable.Add("@Operation", Operation);

            int result = dataUtilities.ExecuteNonQuery("LocationCRUD", hashtable);
            return result;
        }

        public DataSet GetLocation()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetLocation");
            return ds;
        }

        public int DeleteChildDetails(int LocationID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@LocationID", LocationID);
            int result = dataUtilities.ExecuteNonQuery("DeleteLocationMaster", hashtable);
            return result;
        }

        
    }
}