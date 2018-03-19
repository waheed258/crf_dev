using CRMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMWebApi.Controllers
{
    public class GetClientsController : ApiController
    {
         private crm_dev_dbEntities db = new crm_dev_dbEntities();
        [Route("api/GetClient")]
        [HttpGet]
         public IHttpActionResult GetAdvisor()
         {
             var query = (from a in db.tbl_ClientRegistration 
                          join d in db.tbl_ClientRegStatus on a.Status equals d.StatusID
                          where a.Status != 4
                          select new
                          {
                              a.SAID,
                              a.FirstName,
                              a.LastName,
                              a.MobileNumber,
                              a.ClientRegistartionID,
                              a.EmailID,
                              a.CompanyRegNo,
                              a.CompanyName,
                              a.TrustName,
                              a.TrustRegNo,
                              d.Status,
                              a.VerifiedBy,
                              a.VerifiedOn,
                              a.VerifiedThough,
                              a.Title,
                          });
             if (query == null)
             {
                 return NotFound();
             }

             return Ok(query);
         }
    }
}
