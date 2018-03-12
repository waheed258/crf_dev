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
    public class StatusController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Status
        public IQueryable<tbl_Status> Gettbl_Status()
        {
            return db.tbl_Status;
        }

        // GET api/Status/5
        [ResponseType(typeof(tbl_Status))]
        public IHttpActionResult Gettbl_Status(int id)
        {
            tbl_Status tbl_status = db.tbl_Status.Find(id);
            if (tbl_status == null)
            {
                return NotFound();
            }

            return Ok(tbl_status);
        }

        // PUT api/Status/5
        public IHttpActionResult Puttbl_Status(int id, tbl_Status tbl_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_status.StatusID)
            {
                return BadRequest();
            }

            db.Entry(tbl_status).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_StatusExists(id))
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

        // POST api/Status
        [ResponseType(typeof(tbl_Status))]
        public IHttpActionResult Posttbl_Status(tbl_Status tbl_status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Status.Add(tbl_status);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_StatusExists(tbl_status.StatusID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_status.StatusID }, tbl_status);
        }

        // DELETE api/Status/5
        [ResponseType(typeof(tbl_Status))]
        public IHttpActionResult Deletetbl_Status(int id)
        {
            tbl_Status tbl_status = db.tbl_Status.Find(id);
            if (tbl_status == null)
            {
                return NotFound();
            }

            db.tbl_Status.Remove(tbl_status);
            db.SaveChanges();

            return Ok(tbl_status);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_StatusExists(int id)
        {
            return db.tbl_Status.Count(e => e.StatusID == id) > 0;
        }
    }
}