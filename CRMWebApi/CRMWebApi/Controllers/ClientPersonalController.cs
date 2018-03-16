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
    public class ClientPersonalController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientPersonal
        public IQueryable<tbl_ClientPersonal> Gettbl_ClientPersonal()
        {
            return db.tbl_ClientPersonal;
        }

        // GET api/ClientPersonal/5
        [ResponseType(typeof(tbl_ClientPersonal))]
        public IHttpActionResult Gettbl_ClientPersonal(int id)
        {
            tbl_ClientPersonal tbl_clientpersonal = db.tbl_ClientPersonal.Find(id);
            if (tbl_clientpersonal == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientpersonal);
        }

        // PUT api/ClientPersonal/5
        public IHttpActionResult Puttbl_ClientPersonal(int id, tbl_ClientPersonal tbl_clientpersonal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientpersonal.ClientPersonalID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientpersonal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientPersonalExists(id))
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

        // POST api/ClientPersonal
        [ResponseType(typeof(tbl_ClientPersonal))]
        public IHttpActionResult Posttbl_ClientPersonal(tbl_ClientPersonal tbl_clientpersonal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientPersonal.Add(tbl_clientpersonal);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientpersonal.ClientPersonalID }, tbl_clientpersonal);
        }

        // DELETE api/ClientPersonal/5
        [ResponseType(typeof(tbl_ClientPersonal))]
        public IHttpActionResult Deletetbl_ClientPersonal(int id)
        {
            tbl_ClientPersonal tbl_clientpersonal = db.tbl_ClientPersonal.Find(id);
            if (tbl_clientpersonal == null)
            {
                return NotFound();
            }

            db.tbl_ClientPersonal.Remove(tbl_clientpersonal);
            db.SaveChanges();

            return Ok(tbl_clientpersonal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientPersonalExists(int id)
        {
            return db.tbl_ClientPersonal.Count(e => e.ClientPersonalID == id) > 0;
        }
    }
}