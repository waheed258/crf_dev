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
    public class BeneficiaryController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Beneficiary
        public IQueryable<tbl_Beneficiary> Gettbl_Beneficiary()
        {
            return db.tbl_Beneficiary;
        }

        // GET api/Beneficiary/5
        [ResponseType(typeof(tbl_Beneficiary))]
        public IHttpActionResult Gettbl_Beneficiary(int id)
        {
            tbl_Beneficiary tbl_beneficiary = db.tbl_Beneficiary.Find(id);
            if (tbl_beneficiary == null)
            {
                return NotFound();
            }

            return Ok(tbl_beneficiary);
        }

        // PUT api/Beneficiary/5
        public IHttpActionResult Puttbl_Beneficiary(int id, tbl_Beneficiary tbl_beneficiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_beneficiary.BeneficiaryID)
            {
                return BadRequest();
            }

            db.Entry(tbl_beneficiary).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_BeneficiaryExists(id))
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

        // POST api/Beneficiary
        [ResponseType(typeof(tbl_Beneficiary))]
        public IHttpActionResult Posttbl_Beneficiary(tbl_Beneficiary tbl_beneficiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Beneficiary.Add(tbl_beneficiary);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_beneficiary.BeneficiaryID }, tbl_beneficiary);
        }

        // DELETE api/Beneficiary/5
        [ResponseType(typeof(tbl_Beneficiary))]
        public IHttpActionResult Deletetbl_Beneficiary(int id)
        {
            tbl_Beneficiary tbl_beneficiary = db.tbl_Beneficiary.Find(id);
            if (tbl_beneficiary == null)
            {
                return NotFound();
            }

            db.tbl_Beneficiary.Remove(tbl_beneficiary);
            db.SaveChanges();

            return Ok(tbl_beneficiary);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_BeneficiaryExists(int id)
        {
            return db.tbl_Beneficiary.Count(e => e.BeneficiaryID == id) > 0;
        }
    }
}