using CRMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMWebApi.Controllers
{
    public class GetAdvisorController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();
        [Route("api/GetActiveAdvisor")]
        [HttpGet]
        public IHttpActionResult GetAdvisor()
        {
            var query = (from a in db.tbl_Advisor
                         join d in db.tbl_Designation on a.Designation equals d.DesignationID
                         where a.Status == 1
                         select new
                         {
                             a.AdvisorID,
                             a.FirstName,
                             a.LastName,
                             a.Mobile,
                             a.Phone,
                             a.EmailID,
                             a.LoginId,
                             a.Password,
                             a.Branch,
                             a.AdvisorType,
                             a.Status,
                             d.Designation,
                             a.Image,
                             a.CreatedBy,
                             a.UpdatedBy,                           
                             a.UpdatedOn,
                         });
            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }
    }
}
