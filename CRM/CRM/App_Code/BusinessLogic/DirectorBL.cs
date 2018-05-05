using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using EntityManager;
using System.Data;
using DataManager;


/// <summary>
/// Summary description for DirectorBL
/// </summary>
public class DirectorBL : DataUtilities
{
    public int DirectorCRUD(DirectorEntity directorEntity, char operation)
    {
        Hashtable hsparams = new Hashtable
                    {
                        {"@DirectorID",directorEntity.DirectorID},
                        {"@ReferenceSAID",directorEntity.ReferenceSAID},
                        {"@UIC",directorEntity.UIC},
                        {"@SAID",directorEntity.SAID},
                        {"@Title",directorEntity.Title},
                        {"@FirstName",directorEntity.FirstName},
                        {"@LastName",directorEntity.LastName},
                        {"@EmailID",directorEntity.EmailID},
                        {"@Mobile",directorEntity.Mobile},
                        {"@DateOfBirth",directorEntity.DateOfBirth},
                        {"@Phone",directorEntity.Phone},
                        {"@AdvisorID",directorEntity.AdvisorID},
                        {"@Status",directorEntity.Status},
                        {"@TaxRefNo",directorEntity.TaxRefNo},                      
                        {"@ShareHolderPercentage",directorEntity.ShareHolderPercentage},
                        {"@ShareValue",directorEntity.ShareValue},
                        {"@Operation",operation}
                    };

        return ExecuteNonQuery("usp_DirectorCRUD", hsparams);
    }

    public DataSet GetDirector(int DirectorID, string UIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@DirectorID", DirectorID);
        hsparams.Add("@UIC", UIC);


        return ExecuteDataSet("GetDirector", hsparams);
    }

    public DataSet GetSAIDDirector(string ReferenceUCID, string SAID)
    {
        Hashtable hsparams = new Hashtable();

        hsparams.Add("@ReferenceUIC", ReferenceUCID);
        hsparams.Add("@SAID", SAID);
        return ExecuteDataSet("GetDirectorBYSAID", hsparams);
    }
    public int DeleteDirector(int DirectorID, string SAID, string UIC)
    {
        Hashtable hsparams = new Hashtable();
        hsparams.Add("@DirectorID", DirectorID);
        hsparams.Add("@SAID", SAID);
        hsparams.Add("@UIC", UIC);

        return ExecuteNonQuery("DeleteDirector", hsparams);
    }
}