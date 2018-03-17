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
    public class AddressController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Address
        public IQueryable<tbl_AddressDetail> Gettbl_AddressDetail()
        {
            return db.tbl_AddressDetail;
        }

        // GET api/Address/5
        [ResponseType(typeof(tbl_AddressDetail))]
        public IHttpActionResult Gettbl_AddressDetail(int id)
        {
            tbl_AddressDetail tbl_addressdetail = db.tbl_AddressDetail.Find(id);
            if (tbl_addressdetail == null)
            {
                return NotFound();
            }

            return Ok(tbl_addressdetail);
        }

        // PUT api/Address/5
        public IHttpActionResult Puttbl_AddressDetail(int id, tbl_AddressDetail tbl_addressdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_addressdetail.AddressDetailID)
            {
                return BadRequest();
            }

            db.Entry(tbl_addressdetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AddressDetailExists(id))
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

        // POST api/Address
        [ResponseType(typeof(tbl_AddressDetail))]
        public IHttpActionResult Posttbl_AddressDetail(tbl_AddressDetail tbl_addressdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_AddressDetail.Add(tbl_addressdetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_addressdetail.AddressDetailID }, tbl_addressdetail);
        }

        // DELETE api/Address/5
        [ResponseType(typeof(tbl_AddressDetail))]
        public IHttpActionResult Deletetbl_AddressDetail(int id)
        {
            tbl_AddressDetail tbl_addressdetail = db.tbl_AddressDetail.Find(id);
            if (tbl_addressdetail == null)
            {
                return NotFound();
            }

            db.tbl_AddressDetail.Remove(tbl_addressdetail);
            db.SaveChanges();

            return Ok(tbl_addressdetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_AddressDetailExists(int id)
        {
            return db.tbl_AddressDetail.Count(e => e.AddressDetailID == id) > 0;
        }
    }
}