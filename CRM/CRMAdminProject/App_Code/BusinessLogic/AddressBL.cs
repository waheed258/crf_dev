﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using DataManager;

namespace BusinessLogic
{
    public class AddressBL : DataUtilities
    {

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
                        {"@OperationName",operation}
                    };
            return ExecuteNonQuery("InsUpAddressDetail", hsparams);
        }

    }
}