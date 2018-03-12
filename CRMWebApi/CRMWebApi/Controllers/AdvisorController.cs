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
    public class AdvisorController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Advisor
        public IQueryable<tbl_Advisor> Gettbl_Advisor()
        {
            return db.tbl_Advisor;
        }

        // GET api/Advisor/5
        [ResponseType(typeof(tbl_Advisor))]
        public IHttpActionResult Gettbl_Advisor(int id)
        {
            tbl_Advisor tbl_advisor = db.tbl_Advisor.Find(id);
            if (tbl_advisor == null)
            {
                return NotFound();
            }

            return Ok(tbl_advisor);
        }

        // PUT api/Advisor/5
        public IHttpActionResult Puttbl_Advisor(int id, tbl_Advisor tbl_advisor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_advisor.AdvisorId)
            {
                return BadRequest();
            }

            db.Entry(tbl_advisor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AdvisorExists(id))
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

        // POST api/Advisor
        [ResponseType(typeof(tbl_Advisor))]
        public IHttpActionResult Posttbl_Advisor(tbl_Advisor tbl_advisor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Advisor.Add(tbl_advisor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_advisor.AdvisorId }, tbl_advisor);
        }

        // DELETE api/Advisor/5
        [ResponseType(typeof(tbl_Advisor))]
        public IHttpActionResult Deletetbl_Advisor(int id)
        {
            tbl_Advisor tbl_advisor = db.tbl_Advisor.Find(id);
            if (tbl_advisor == null)
            {
                return NotFound();
            }

            db.tbl_Advisor.Remove(tbl_advisor);
            db.SaveChanges();

            return Ok(tbl_advisor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_AdvisorExists(int id)
        {
            return db.tbl_Advisor.Count(e => e.AdvisorId == id) > 0;
        }
    }
}