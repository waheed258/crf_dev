﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityManager;
using System.Collections;
using DataManager;


namespace BusinessLogic
{
    public class BasicDropdownBL
    {
        DataUtilities dataUtilities = new DataUtilities();
        DataSet ds = new DataSet();

        public DataSet GetCountry()
        {
            ds = dataUtilities.ExecuteDataSet("GetCountry");
            return ds;
        }

        public DataSet GetProvince()
        {
            ds = dataUtilities.ExecuteDataSet("GetProvince");
            return ds;
        }

        public DataSet GetCity()
        {
            ds = dataUtilities.ExecuteDataSet("GetCity");
            return ds;
        }
        public DataSet GetAccountType()
        {
            ds = dataUtilities.ExecuteDataSet("GetAccountType");
            return ds;
        }

       

    }
}