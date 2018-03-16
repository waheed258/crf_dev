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
    public class BankController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Bank
        public IQueryable<tbl_BankDetail> Gettbl_BankDetail()
        {
            return db.tbl_BankDetail;
        }

        // GET api/Bank/5
        [ResponseType(typeof(tbl_BankDetail))]
        public IHttpActionResult Gettbl_BankDetail(int id)
        {
            tbl_BankDetail tbl_bankdetail = db.tbl_BankDetail.Find(id);
            if (tbl_bankdetail == null)
            {
                return NotFound();
            }

            return Ok(tbl_bankdetail);
        }

        // PUT api/Bank/5
        public IHttpActionResult Puttbl_BankDetail(int id, tbl_BankDetail tbl_bankdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_bankdetail.BankDetailID)
            {
                return BadRequest();
            }

            db.Entry(tbl_bankdetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_BankDetailExists(id))
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

        // POST api/Bank
        [ResponseType(typeof(tbl_BankDetail))]
        public IHttpActionResult Posttbl_BankDetail(tbl_BankDetail tbl_bankdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_BankDetail.Add(tbl_bankdetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_bankdetail.BankDetailID }, tbl_bankdetail);
        }

        // DELETE api/Bank/5
        [ResponseType(typeof(tbl_BankDetail))]
        public IHttpActionResult Deletetbl_BankDetail(int id)
        {
            tbl_BankDetail tbl_bankdetail = db.tbl_BankDetail.Find(id);
            if (tbl_bankdetail == null)
            {
                return NotFound();
            }

            db.tbl_BankDetail.Remove(tbl_bankdetail);
            db.SaveChanges();

            return Ok(tbl_bankdetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_BankDetailExists(int id)
        {
            return db.tbl_BankDetail.Count(e => e.BankDetailID == id) > 0;
        }
    }
}