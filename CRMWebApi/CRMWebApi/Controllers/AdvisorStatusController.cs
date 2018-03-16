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
    public class AdvisorStatusController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/AdvisorStatus
        public IQueryable<tbl_AdvisorStatus> Gettbl_AdvisorStatus()
        {
            return db.tbl_AdvisorStatus;
        }

        // GET api/AdvisorStatus/5
        [ResponseType(typeof(tbl_AdvisorStatus))]
        public IHttpActionResult Gettbl_AdvisorStatus(int id)
        {
            tbl_AdvisorStatus tbl_advisorstatus = db.tbl_AdvisorStatus.Find(id);
            if (tbl_advisorstatus == null)
            {
                return NotFound();
            }

            return Ok(tbl_advisorstatus);
        }

        // PUT api/AdvisorStatus/5
        public IHttpActionResult Puttbl_AdvisorStatus(int id, tbl_AdvisorStatus tbl_advisorstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_advisorstatus.AdvisorStatusID)
            {
                return BadRequest();
            }

            db.Entry(tbl_advisorstatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AdvisorStatusExists(id))
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

        // POST api/AdvisorStatus
        [ResponseType(typeof(tbl_AdvisorStatus))]
        public IHttpActionResult Posttbl_AdvisorStatus(tbl_AdvisorStatus tbl_advisorstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_AdvisorStatus.Add(tbl_advisorstatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_advisorstatus.AdvisorStatusID }, tbl_advisorstatus);
        }

        // DELETE api/AdvisorStatus/5
        [ResponseType(typeof(tbl_AdvisorStatus))]
        public IHttpActionResult Deletetbl_AdvisorStatus(int id)
        {
            tbl_AdvisorStatus tbl_advisorstatus = db.tbl_AdvisorStatus.Find(id);
            if (tbl_advisorstatus == null)
            {
                return NotFound();
            }

            db.tbl_AdvisorStatus.Remove(tbl_advisorstatus);
            db.SaveChanges();

            return Ok(tbl_advisorstatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_AdvisorStatusExists(int id)
        {
            return db.tbl_AdvisorStatus.Count(e => e.AdvisorStatusID == id) > 0;
        }
    }
}