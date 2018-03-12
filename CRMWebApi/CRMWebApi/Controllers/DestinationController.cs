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
    public class DestinationController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Destination
        public IQueryable<tbl_Designation> Gettbl_Designation()
        {
            return db.tbl_Designation;
        }

        // GET api/Destination/5
        [ResponseType(typeof(tbl_Designation))]
        public IHttpActionResult Gettbl_Designation(int id)
        {
            tbl_Designation tbl_designation = db.tbl_Designation.Find(id);
            if (tbl_designation == null)
            {
                return NotFound();
            }

            return Ok(tbl_designation);
        }

        // PUT api/Destination/5
        public IHttpActionResult Puttbl_Designation(int id, tbl_Designation tbl_designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_designation.DesignationId)
            {
                return BadRequest();
            }

            db.Entry(tbl_designation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_DesignationExists(id))
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

        // POST api/Destination
        [ResponseType(typeof(tbl_Designation))]
        public IHttpActionResult Posttbl_Designation(tbl_Designation tbl_designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Designation.Add(tbl_designation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_designation.DesignationId }, tbl_designation);
        }

        // DELETE api/Destination/5
        [ResponseType(typeof(tbl_Designation))]
        public IHttpActionResult Deletetbl_Designation(int id)
        {
            tbl_Designation tbl_designation = db.tbl_Designation.Find(id);
            if (tbl_designation == null)
            {
                return NotFound();
            }

            db.tbl_Designation.Remove(tbl_designation);
            db.SaveChanges();

            return Ok(tbl_designation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_DesignationExists(int id)
        {
            return db.tbl_Designation.Count(e => e.DesignationId == id) > 0;
        }
    }
}