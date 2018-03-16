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
    public class ClientServiceMasterController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientServiceMaster
        public IQueryable<tbl_ClientServiceMaster> Gettbl_ClientServiceMaster()
        {
            return db.tbl_ClientServiceMaster;
        }

        // GET api/ClientServiceMaster/5
        [ResponseType(typeof(tbl_ClientServiceMaster))]
        public IHttpActionResult Gettbl_ClientServiceMaster(int id)
        {
            tbl_ClientServiceMaster tbl_clientservicemaster = db.tbl_ClientServiceMaster.Find(id);
            if (tbl_clientservicemaster == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientservicemaster);
        }

        // PUT api/ClientServiceMaster/5
        public IHttpActionResult Puttbl_ClientServiceMaster(int id, tbl_ClientServiceMaster tbl_clientservicemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientservicemaster.ClientServiceID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientservicemaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientServiceMasterExists(id))
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

        // POST api/ClientServiceMaster
        [ResponseType(typeof(tbl_ClientServiceMaster))]
        public IHttpActionResult Posttbl_ClientServiceMaster(tbl_ClientServiceMaster tbl_clientservicemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientServiceMaster.Add(tbl_clientservicemaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientservicemaster.ClientServiceID }, tbl_clientservicemaster);
        }

        // DELETE api/ClientServiceMaster/5
        [ResponseType(typeof(tbl_ClientServiceMaster))]
        public IHttpActionResult Deletetbl_ClientServiceMaster(int id)
        {
            tbl_ClientServiceMaster tbl_clientservicemaster = db.tbl_ClientServiceMaster.Find(id);
            if (tbl_clientservicemaster == null)
            {
                return NotFound();
            }

            db.tbl_ClientServiceMaster.Remove(tbl_clientservicemaster);
            db.SaveChanges();

            return Ok(tbl_clientservicemaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientServiceMasterExists(int id)
        {
            return db.tbl_ClientServiceMaster.Count(e => e.ClientServiceID == id) > 0;
        }
    }
}