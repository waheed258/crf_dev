using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using DataManager;
using System.Data;
namespace BusinessLogic
{
    public class AddressBL : DataUtilities
    {
        DataUtilities dataUtilities = new DataUtilities();
        public int InsertUpdateAddress(AddressEntity _objAddress, char operation)
        {
            Hashtable hsparams = new Hashtable
                    {
                        {"@inAddressDetailID",_objAddress.AddressDetailID},
                        {"@inType",_objAddress.Type},
                        {"@inSAID",_objAddress.SAID},
                        {"@inReferenceSAID",_objAddress.ReferenceSAID},
                        {"@inUIC",_objAddress.UIC},
                        {"@inHouseNo",_objAddress.HouseNo},
                        {"@inBuildingName",_objAddress.BuildingName},
                        {"@inFloorNo",_objAddress.Floor},
                        {"@inFlatNo",_objAddress.FlatNo},
                        {"@inRoadName",_objAddress.RoadName},
                        {"@inRoadNo",_objAddress.RoadNo},
                        {"@inSuburbName",_objAddress.SuburbName},
                        {"@inCity",_objAddress.City},
                        {"@inPostalCode",_objAddress.PostalCode},
                        {"@inProvince",_objAddress.Province},
                        {"@inCountry",_objAddress.Country}, 
                        {"@inAdvisorID",_objAddress.AdvisorId},
                        {"@inStatus",_objAddress.Status},
                        {"@inCreatedBy",_objAddress.CreatedBy},
                        {"@inUpdatedBy",_objAddress.CreatedBy},
                        {"@inComplex",_objAddress.Complex},
                        {"@OperationName",operation}
                    };
            return ExecuteNonQuery("InsUpAddressDetail", hsparams);
        }

        public DataSet GetAddressDetails(string SAID, int Type, string RefUIC)
        {
            var newAddress = new List<AddressEntity>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@ReferenceSAID", SAID);
            hashtable.Add("@Type", Type);
            hashtable.Add("@RefUIC", RefUIC);
            DataSet ds = dataUtilities.ExecuteDataSet("usp_GetAddressDetails", hashtable);
            return ds;
        }
        public int DeleteAddressDetails(string AddressDetailID, int Deletedby, string SAID_OR_UIC, string NAME)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@AddressDetailID", @AddressDetailID);
            hashtable.Add("@Deletedby", Deletedby);
            hashtable.Add("@SAID_OR_UIC", SAID_OR_UIC);
            hashtable.Add("@NAME", NAME);
            int result = dataUtilities.ExecuteNonQuery("usp_DeleteAddressDetails", hashtable);
            return result;
        }

        public DataSet GetPrimaryAddrClient(string SAID)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@SAID", SAID);
            DataSet ds = dataUtilities.ExecuteDataSet("GetPrimaryClientAddr", hashtable);
            return ds;
        }
    }
}