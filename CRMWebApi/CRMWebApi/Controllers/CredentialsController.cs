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
    public class CredentialsController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Credentials
        public IQueryable<tbl_Credentials> Gettbl_Credentials()
        {
            return db.tbl_Credentials;
        }

        // GET api/Credentials/5
        [ResponseType(typeof(tbl_Credentials))]
        public IHttpActionResult Gettbl_Credentials(string id)
        {
            tbl_Credentials tbl_credentials = db.tbl_Credentials.Find(id);
            if (tbl_credentials == null)
            {
                return NotFound();
            }

            return Ok(tbl_credentials);
        }

        // PUT api/Credentials/5
        public IHttpActionResult Puttbl_Credentials(string id, tbl_Credentials tbl_credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_credentials.SAID)
            {
                return BadRequest();
            }

            db.Entry(tbl_credentials).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CredentialsExists(id))
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

        // POST api/Credentials
        [ResponseType(typeof(tbl_Credentials))]
        public IHttpActionResult Posttbl_Credentials(tbl_Credentials tbl_credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Credentials.Add(tbl_credentials);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_CredentialsExists(tbl_credentials.SAID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_credentials.SAID }, tbl_credentials);
        }

        // DELETE api/Credentials/5
        [ResponseType(typeof(tbl_Credentials))]
        public IHttpActionResult Deletetbl_Credentials(string id)
        {
            tbl_Credentials tbl_credentials = db.tbl_Credentials.Find(id);
            if (tbl_credentials == null)
            {
                return NotFound();
            }

            db.tbl_Credentials.Remove(tbl_credentials);
            db.SaveChanges();

            return Ok(tbl_credentials);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CredentialsExists(string id)
        {
            return db.tbl_Credentials.Count(e => e.SAID == id) > 0;
        }
    }
}