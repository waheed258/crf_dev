using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMWebApi.Models;
using System.Web.Http.Description;

namespace CRMWebApi.Controllers
{
    public class VerifiedByController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();
        [Route("api/AdvisorFirstName/{id}")]
        [HttpGet]
        public IHttpActionResult GetAdvisorById(int id)
        {
            var query = db.tbl_ClientReg
  .Join(db.tbl_Advisor,
     c => c.VerifiedBy,
     cm => cm.AdvisorId,
     (c, cm) => new
     {
         c.ClientID,        
         cm.FirstName
     }) // project result
  .Where(t => t.ClientID == id);  // select result



            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }



         [Route("api/StatusName/{id}")]
         [HttpGet]
        public IHttpActionResult GetStatusById(int id)
        {
            var query = db.tbl_ClientReg
  .Join(db.tbl_Status,
     c => c.Status,
     cm => cm.StatusID,
     (c, cm) => new
     {
         c.ClientID,
         cm.Status
     }) // project result
  .Where(t => t.ClientID == id);  // select result



            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }
    }
}
