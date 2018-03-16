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
    public class TrustSettlerController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/TrustSettler
        public IQueryable<tbl_TrustSettler> Gettbl_TrustSettler()
        {
            return db.tbl_TrustSettler;
        }

        // GET api/TrustSettler/5
        [ResponseType(typeof(tbl_TrustSettler))]
        public IHttpActionResult Gettbl_TrustSettler(int id)
        {
            tbl_TrustSettler tbl_trustsettler = db.tbl_TrustSettler.Find(id);
            if (tbl_trustsettler == null)
            {
                return NotFound();
            }

            return Ok(tbl_trustsettler);
        }

        // PUT api/TrustSettler/5
        public IHttpActionResult Puttbl_TrustSettler(int id, tbl_TrustSettler tbl_trustsettler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_trustsettler.TrustSettlerID)
            {
                return BadRequest();
            }

            db.Entry(tbl_trustsettler).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TrustSettlerExists(id))
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

        // POST api/TrustSettler
        [ResponseType(typeof(tbl_TrustSettler))]
        public IHttpActionResult Posttbl_TrustSettler(tbl_TrustSettler tbl_trustsettler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_TrustSettler.Add(tbl_trustsettler);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_trustsettler.TrustSettlerID }, tbl_trustsettler);
        }

        // DELETE api/TrustSettler/5
        [ResponseType(typeof(tbl_TrustSettler))]
        public IHttpActionResult Deletetbl_TrustSettler(int id)
        {
            tbl_TrustSettler tbl_trustsettler = db.tbl_TrustSettler.Find(id);
            if (tbl_trustsettler == null)
            {
                return NotFound();
            }

            db.tbl_TrustSettler.Remove(tbl_trustsettler);
            db.SaveChanges();

            return Ok(tbl_trustsettler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_TrustSettlerExists(int id)
        {
            return db.tbl_TrustSettler.Count(e => e.TrustSettlerID == id) > 0;
        }
    }
}