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
    public class ClientRegStatusController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientRegStatus
        public IQueryable<tbl_ClientRegStatus> Gettbl_ClientRegStatus()
        {
            return db.tbl_ClientRegStatus;
        }

        // GET api/ClientRegStatus/5
        [ResponseType(typeof(tbl_ClientRegStatus))]
        public IHttpActionResult Gettbl_ClientRegStatus(int id)
        {
            tbl_ClientRegStatus tbl_clientregstatus = db.tbl_ClientRegStatus.Find(id);
            if (tbl_clientregstatus == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientregstatus);
        }

        // PUT api/ClientRegStatus/5
        public IHttpActionResult Puttbl_ClientRegStatus(int id, tbl_ClientRegStatus tbl_clientregstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientregstatus.StatusID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientregstatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientRegStatusExists(id))
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

        // POST api/ClientRegStatus
        [ResponseType(typeof(tbl_ClientRegStatus))]
        public IHttpActionResult Posttbl_ClientRegStatus(tbl_ClientRegStatus tbl_clientregstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientRegStatus.Add(tbl_clientregstatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientregstatus.StatusID }, tbl_clientregstatus);
        }

        // DELETE api/ClientRegStatus/5
        [ResponseType(typeof(tbl_ClientRegStatus))]
        public IHttpActionResult Deletetbl_ClientRegStatus(int id)
        {
            tbl_ClientRegStatus tbl_clientregstatus = db.tbl_ClientRegStatus.Find(id);
            if (tbl_clientregstatus == null)
            {
                return NotFound();
            }

            db.tbl_ClientRegStatus.Remove(tbl_clientregstatus);
            db.SaveChanges();

            return Ok(tbl_clientregstatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientRegStatusExists(int id)
        {
            return db.tbl_ClientRegStatus.Count(e => e.StatusID == id) > 0;
        }
    }
}