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
    public class TrustController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Trust
        public IQueryable<tbl_Trust> Gettbl_Trust()
        {
            return db.tbl_Trust;
        }

        // GET api/Trust/5
        [ResponseType(typeof(tbl_Trust))]
        public IHttpActionResult Gettbl_Trust(string id)
        {
            tbl_Trust tbl_trust = db.tbl_Trust.Find(id);
            if (tbl_trust == null)
            {
                return NotFound();
            }

            return Ok(tbl_trust);
        }

        // PUT api/Trust/5
        public IHttpActionResult Puttbl_Trust(string id, tbl_Trust tbl_trust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_trust.UIC)
            {
                return BadRequest();
            }

            db.Entry(tbl_trust).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TrustExists(id))
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

        // POST api/Trust
        [ResponseType(typeof(tbl_Trust))]
        public IHttpActionResult Posttbl_Trust(tbl_Trust tbl_trust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Trust.Add(tbl_trust);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_TrustExists(tbl_trust.UIC))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_trust.UIC }, tbl_trust);
        }

        // DELETE api/Trust/5
        [ResponseType(typeof(tbl_Trust))]
        public IHttpActionResult Deletetbl_Trust(string id)
        {
            tbl_Trust tbl_trust = db.tbl_Trust.Find(id);
            if (tbl_trust == null)
            {
                return NotFound();
            }

            db.tbl_Trust.Remove(tbl_trust);
            db.SaveChanges();

            return Ok(tbl_trust);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_TrustExists(string id)
        {
            return db.tbl_Trust.Count(e => e.UIC == id) > 0;
        }
    }
}