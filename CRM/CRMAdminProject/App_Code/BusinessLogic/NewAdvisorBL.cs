using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using DataManager;
using EntityManager;

namespace BusinessLogic
{
   public class NewAdvisorBL
    {
       DataUtilities dataUtilities = new DataUtilities();
        public DataSet GetDesignation()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetDesignation");
            return ds;
        }
        public DataSet GetBranch()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetBranch");
            return ds;
        }
        public DataSet GetAdvisorType()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetAdvisorType");
            return ds;
        }
        public DataSet GetStatus()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetAdvisorStatus");
            return ds;
        }
        public DataSet GetRole()
        {
            DataSet ds = dataUtilities.ExecuteDataSet("GetAdvisorRole");
            return ds;
        }

        public int CUDAdvisor(AdvisorEntity advisorEntity, char Operation)
        {
            Hashtable hashtable = new Hashtable();
            if (Operation == 'i')
            {
                hashtable.Add("@AdvisorID", 0);
                hashtable.Add("@UpdatedBy", 0);
            }
            else
            {
                hashtable.Add("@AdvisorID", advisorEntity.AdvisorID);
                hashtable.Add("@UpdatedBy", advisorEntity.UpdatedBy);
            }            
            hashtable.Add("@FirstName", advisorEntity.FirstName);
            hashtable.Add("@LastName", advisorEntity.LastName);
            hashtable.Add("@Mobile", advisorEntity.Mobile);
            hashtable.Add("@Phone", advisorEntity.Phone);
            hashtable.Add("@EmailID", advisorEntity.EmailID);
            hashtable.Add("@LoginId", advisorEntity.LoginId);
            hashtable.Add("@Password", advisorEntity.Password);
            hashtable.Add("@Designation", advisorEntity.Designation);
            hashtable.Add("@Branch", advisorEntity.Branch);
            hashtable.Add("@AdvisorType", advisorEntity.AdvisorType);
            hashtable.Add("@Status", advisorEntity.Status);
            hashtable.Add("@Image", advisorEntity.Image);
            hashtable.Add("@AdvisorRole", advisorEntity.AdvisorRole);
            hashtable.Add("@Operation", Operation);           
            
            int result = dataUtilities.ExecuteNonQuery("AdvisorCRUD", hashtable);
            return result;
        }

        public DataSet GetAdvisor(int AdvisorID)
        {
            Hashtable htParams = new Hashtable
            {
                {"@AdvisorID",AdvisorID},
            };
            return dataUtilities.ExecuteDataSet("GetAdvisor", htParams);
        }
        public DataSet GetAdvisorList()
        {
            var newLead = new List<AdvisorEntity>();
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@AdvisorID", 0);
            DataSet ds = dataUtilities.ExecuteDataSet("GetAdvisor", hashtable);
            return ds;
        }
    }
}
