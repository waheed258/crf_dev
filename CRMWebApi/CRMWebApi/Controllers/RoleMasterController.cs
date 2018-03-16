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
    public class RoleMasterController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/RoleMaster
        public IQueryable<tbl_RoleMaster> Gettbl_RoleMaster()
        {
            return db.tbl_RoleMaster;
        }

        // GET api/RoleMaster/5
        [ResponseType(typeof(tbl_RoleMaster))]
        public IHttpActionResult Gettbl_RoleMaster(int id)
        {
            tbl_RoleMaster tbl_rolemaster = db.tbl_RoleMaster.Find(id);
            if (tbl_rolemaster == null)
            {
                return NotFound();
            }

            return Ok(tbl_rolemaster);
        }

        // PUT api/RoleMaster/5
        public IHttpActionResult Puttbl_RoleMaster(int id, tbl_RoleMaster tbl_rolemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_rolemaster.RoleID)
            {
                return BadRequest();
            }

            db.Entry(tbl_rolemaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_RoleMasterExists(id))
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

        // POST api/RoleMaster
        [ResponseType(typeof(tbl_RoleMaster))]
        public IHttpActionResult Posttbl_RoleMaster(tbl_RoleMaster tbl_rolemaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_RoleMaster.Add(tbl_rolemaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_rolemaster.RoleID }, tbl_rolemaster);
        }

        // DELETE api/RoleMaster/5
        [ResponseType(typeof(tbl_RoleMaster))]
        public IHttpActionResult Deletetbl_RoleMaster(int id)
        {
            tbl_RoleMaster tbl_rolemaster = db.tbl_RoleMaster.Find(id);
            if (tbl_rolemaster == null)
            {
                return NotFound();
            }

            db.tbl_RoleMaster.Remove(tbl_rolemaster);
            db.SaveChanges();

            return Ok(tbl_rolemaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_RoleMasterExists(int id)
        {
            return db.tbl_RoleMaster.Count(e => e.RoleID == id) > 0;
        }
    }
}