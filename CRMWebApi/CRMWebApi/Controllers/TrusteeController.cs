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
    public class TrusteeController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Trustee
        public IQueryable<tbl_Trustee> Gettbl_Trustee()
        {
            return db.tbl_Trustee;
        }

        // GET api/Trustee/5
        [ResponseType(typeof(tbl_Trustee))]
        public IHttpActionResult Gettbl_Trustee(int id)
        {
            tbl_Trustee tbl_trustee = db.tbl_Trustee.Find(id);
            if (tbl_trustee == null)
            {
                return NotFound();
            }

            return Ok(tbl_trustee);
        }

        // PUT api/Trustee/5
        public IHttpActionResult Puttbl_Trustee(int id, tbl_Trustee tbl_trustee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_trustee.TrusteeID)
            {
                return BadRequest();
            }

            db.Entry(tbl_trustee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_TrusteeExists(id))
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

        // POST api/Trustee
        [ResponseType(typeof(tbl_Trustee))]
        public IHttpActionResult Posttbl_Trustee(tbl_Trustee tbl_trustee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Trustee.Add(tbl_trustee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_trustee.TrusteeID }, tbl_trustee);
        }

        // DELETE api/Trustee/5
        [ResponseType(typeof(tbl_Trustee))]
        public IHttpActionResult Deletetbl_Trustee(int id)
        {
            tbl_Trustee tbl_trustee = db.tbl_Trustee.Find(id);
            if (tbl_trustee == null)
            {
                return NotFound();
            }

            db.tbl_Trustee.Remove(tbl_trustee);
            db.SaveChanges();

            return Ok(tbl_trustee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_TrusteeExists(int id)
        {
            return db.tbl_Trustee.Count(e => e.TrusteeID == id) > 0;
        }
    }
}