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
    public class ClientTypeController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientType
        public IQueryable<tbl_ClientType> Gettbl_ClientType()
        {
            return db.tbl_ClientType;
        }

        // GET api/ClientType/5
        [ResponseType(typeof(tbl_ClientType))]
        public IHttpActionResult Gettbl_ClientType(int id)
        {
            tbl_ClientType tbl_clienttype = db.tbl_ClientType.Find(id);
            if (tbl_clienttype == null)
            {
                return NotFound();
            }

            return Ok(tbl_clienttype);
        }

        // PUT api/ClientType/5
        public IHttpActionResult Puttbl_ClientType(int id, tbl_ClientType tbl_clienttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clienttype.ClientTypeID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clienttype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientTypeExists(id))
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

        // POST api/ClientType
        [ResponseType(typeof(tbl_ClientType))]
        public IHttpActionResult Posttbl_ClientType(tbl_ClientType tbl_clienttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientType.Add(tbl_clienttype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clienttype.ClientTypeID }, tbl_clienttype);
        }

        // DELETE api/ClientType/5
        [ResponseType(typeof(tbl_ClientType))]
        public IHttpActionResult Deletetbl_ClientType(int id)
        {
            tbl_ClientType tbl_clienttype = db.tbl_ClientType.Find(id);
            if (tbl_clienttype == null)
            {
                return NotFound();
            }

            db.tbl_ClientType.Remove(tbl_clienttype);
            db.SaveChanges();

            return Ok(tbl_clienttype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientTypeExists(int id)
        {
            return db.tbl_ClientType.Count(e => e.ClientTypeID == id) > 0;
        }
    }
}