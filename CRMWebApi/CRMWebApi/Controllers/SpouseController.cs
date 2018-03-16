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
    public class SpouseController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Spouse
        public IQueryable<tbl_Spouse> Gettbl_Spouse()
        {
            return db.tbl_Spouse;
        }

        // GET api/Spouse/5
        [ResponseType(typeof(tbl_Spouse))]
        public IHttpActionResult Gettbl_Spouse(string id)
        {
            tbl_Spouse tbl_spouse = db.tbl_Spouse.Find(id);
            if (tbl_spouse == null)
            {
                return NotFound();
            }

            return Ok(tbl_spouse);
        }

        // PUT api/Spouse/5
        public IHttpActionResult Puttbl_Spouse(string id, tbl_Spouse tbl_spouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_spouse.SAID)
            {
                return BadRequest();
            }

            db.Entry(tbl_spouse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_SpouseExists(id))
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

        // POST api/Spouse
        [ResponseType(typeof(tbl_Spouse))]
        public IHttpActionResult Posttbl_Spouse(tbl_Spouse tbl_spouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Spouse.Add(tbl_spouse);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_SpouseExists(tbl_spouse.SAID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_spouse.SAID }, tbl_spouse);
        }

        // DELETE api/Spouse/5
        [ResponseType(typeof(tbl_Spouse))]
        public IHttpActionResult Deletetbl_Spouse(string id)
        {
            tbl_Spouse tbl_spouse = db.tbl_Spouse.Find(id);
            if (tbl_spouse == null)
            {
                return NotFound();
            }

            db.tbl_Spouse.Remove(tbl_spouse);
            db.SaveChanges();

            return Ok(tbl_spouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_SpouseExists(string id)
        {
            return db.tbl_Spouse.Count(e => e.SAID == id) > 0;
        }
    }
}