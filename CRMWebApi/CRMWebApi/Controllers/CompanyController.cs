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
    public class CompanyController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Company
        public IQueryable<tbl_CompanyDetail> Gettbl_CompanyDetail()
        {
            return db.tbl_CompanyDetail;
        }

        // GET api/Company/5
        [ResponseType(typeof(tbl_CompanyDetail))]
        public IHttpActionResult Gettbl_CompanyDetail(int id)
        {
            tbl_CompanyDetail tbl_companydetail = db.tbl_CompanyDetail.Find(id);
            if (tbl_companydetail == null)
            {
                return NotFound();
            }

            return Ok(tbl_companydetail);
        }

        // PUT api/Company/5
        public IHttpActionResult Puttbl_CompanyDetail(int id, tbl_CompanyDetail tbl_companydetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_companydetail.CompanyID)
            {
                return BadRequest();
            }

            db.Entry(tbl_companydetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CompanyDetailExists(id))
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

        // POST api/Company
        [ResponseType(typeof(tbl_CompanyDetail))]
        public IHttpActionResult Posttbl_CompanyDetail(tbl_CompanyDetail tbl_companydetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_CompanyDetail.Add(tbl_companydetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_companydetail.CompanyID }, tbl_companydetail);
        }

        // DELETE api/Company/5
        [ResponseType(typeof(tbl_CompanyDetail))]
        public IHttpActionResult Deletetbl_CompanyDetail(int id)
        {
            tbl_CompanyDetail tbl_companydetail = db.tbl_CompanyDetail.Find(id);
            if (tbl_companydetail == null)
            {
                return NotFound();
            }

            db.tbl_CompanyDetail.Remove(tbl_companydetail);
            db.SaveChanges();

            return Ok(tbl_companydetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CompanyDetailExists(int id)
        {
            return db.tbl_CompanyDetail.Count(e => e.CompanyID == id) > 0;
        }
    }
}