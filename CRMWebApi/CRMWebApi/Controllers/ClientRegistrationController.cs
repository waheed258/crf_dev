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
    public class ClientRegistrationController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientRegistration
        public IQueryable<tbl_ClientRegistration> Gettbl_ClientRegistration()
        {
            return db.tbl_ClientRegistration;
        }

        // GET api/ClientRegistration/5
        [ResponseType(typeof(tbl_ClientRegistration))]
        public IHttpActionResult Gettbl_ClientRegistration(string id)
        {
            tbl_ClientRegistration tbl_clientregistration = db.tbl_ClientRegistration.Find(id);
            if (tbl_clientregistration == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientregistration);
        }

        // PUT api/ClientRegistration/5
        public IHttpActionResult Puttbl_ClientRegistration(string id, tbl_ClientRegistration tbl_clientregistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientregistration.SAID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientregistration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientRegistrationExists(id))
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

        // POST api/ClientRegistration
        [ResponseType(typeof(tbl_ClientRegistration))]
        public IHttpActionResult Posttbl_ClientRegistration(tbl_ClientRegistration tbl_clientregistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientRegistration.Add(tbl_clientregistration);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_ClientRegistrationExists(tbl_clientregistration.SAID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientregistration.SAID }, tbl_clientregistration);
        }

        // DELETE api/ClientRegistration/5
        [ResponseType(typeof(tbl_ClientRegistration))]
        public IHttpActionResult Deletetbl_ClientRegistration(string id)
        {
            tbl_ClientRegistration tbl_clientregistration = db.tbl_ClientRegistration.Find(id);
            if (tbl_clientregistration == null)
            {
                return NotFound();
            }

            db.tbl_ClientRegistration.Remove(tbl_clientregistration);
            db.SaveChanges();

            return Ok(tbl_clientregistration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientRegistrationExists(string id)
        {
            return db.tbl_ClientRegistration.Count(e => e.SAID == id) > 0;
        }
    }
}