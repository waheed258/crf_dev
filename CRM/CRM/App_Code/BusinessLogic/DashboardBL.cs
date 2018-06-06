using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataManager;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for DashboardBL
/// </summary>
public class DashboardBL 
{
    DataUtilities dataUtilities = new DataUtilities();
    public string GetData(string strMonth, string type )
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@inMonth", strMonth);
        hsparams.Add("@type", type);
         DataSet ds = dataUtilities.ExecuteDataSet("GetReportsBydate", hsparams);
         return ConvertDataTabletoJSON(ds.Tables[0]);
    }

    private string ConvertDataTabletoJSON(DataTable dt)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);        
    }

}