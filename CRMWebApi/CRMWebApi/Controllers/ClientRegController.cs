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
    public class ClientRegController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientReg
        public IQueryable<tbl_ClientReg> Gettbl_ClientReg()
        {
            return db.tbl_ClientReg;
        }

        // GET api/ClientReg/5
        [ResponseType(typeof(tbl_ClientReg))]
        public IHttpActionResult Gettbl_ClientReg(int id)
        {
            tbl_ClientReg tbl_clientreg = db.tbl_ClientReg.Find(id);
            if (tbl_clientreg == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientreg);
        }

        // PUT api/ClientReg/5
        public IHttpActionResult Puttbl_ClientReg(int id, tbl_ClientReg tbl_clientreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientreg.ClientID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientreg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientRegExists(id))
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

        // POST api/ClientReg
        [ResponseType(typeof(tbl_ClientReg))]
        public IHttpActionResult Posttbl_ClientReg(tbl_ClientReg tbl_clientreg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientReg.Add(tbl_clientreg);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientreg.ClientID }, tbl_clientreg);
        }

        // DELETE api/ClientReg/5
        [ResponseType(typeof(tbl_ClientReg))]
        public IHttpActionResult Deletetbl_ClientReg(int id)
        {
            tbl_ClientReg tbl_clientreg = db.tbl_ClientReg.Find(id);
            if (tbl_clientreg == null)
            {
                return NotFound();
            }

            db.tbl_ClientReg.Remove(tbl_clientreg);
            db.SaveChanges();

            return Ok(tbl_clientreg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientRegExists(int id)
        {
            return db.tbl_ClientReg.Count(e => e.ClientID == id) > 0;
        }
    }
}