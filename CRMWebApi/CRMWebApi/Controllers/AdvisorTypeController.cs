using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRMWebApi.Models;

namespace CRMWebApi.Controllers
{
    public class AdvisorTypeController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/AdvisorType
        public IQueryable<tbl_TypeofAdvisor> Gettbl_TypeofAdvisor()
        {
            return db.tbl_TypeofAdvisor;
        }

        // GET api/AdvisorType/5
        [ResponseType(typeof(tbl_TypeofAdvisor))]
        public IHttpActionResult Gettbl_TypeofAdvisor(int id)
        {
            tbl_TypeofAdvisor tbl_typeofadvisor = db.tbl_TypeofAdvisor.Find(id);
            if (tbl_typeofadvisor == null)
            {
                return NotFound();
            }

            return Ok(tbl_typeofadvisor);
        }

        // PUT api/AdvisorType/5
        public IHttpActionResult Puttbl_TypeofAdvisor(int id, tbl_TypeofAdvisor tbl_typeofadvisor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_typeofadvisor.AdvisorTypeID)
            {
                return BadRequest();
            }

            db.Entry(tbl_typeofadvisor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TypeofAdvisorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/AdvisorType
        [ResponseType(typeof(tbl_TypeofAdvisor))]
        public IHttpActionResult Posttbl_TypeofAdvisor(tbl_TypeofAdvisor tbl_typeofadvisor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_TypeofAdvisor.Add(tbl_typeofadvisor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_typeofadvisor.AdvisorTypeID }, tbl_typeofadvisor);
        }

        // DELETE api/AdvisorType/5
        [ResponseType(typeof(tbl_TypeofAdvisor))]
        public IHttpActionResult Deletetbl_TypeofAdvisor(int id)
        {
            tbl_TypeofAdvisor tbl_typeofadvisor = db.tbl_TypeofAdvisor.Find(id);
            if (tbl_typeofadvisor == null)
            {
                return NotFound();
            }

            db.tbl_TypeofAdvisor.Remove(tbl_typeofadvisor);
            db.SaveChanges();

            return Ok(tbl_typeofadvisor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_TypeofAdvisorExists(int id)
        {
            return db.tbl_TypeofAdvisor.Count(e => e.AdvisorTypeID == id) > 0;
        }
    }
}