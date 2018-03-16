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
    public class FeedBackController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/FeedBack
        public IQueryable<tbl_FeedBack> Gettbl_FeedBack()
        {
            return db.tbl_FeedBack;
        }

        // GET api/FeedBack/5
        [ResponseType(typeof(tbl_FeedBack))]
        public IHttpActionResult Gettbl_FeedBack(int id)
        {
            tbl_FeedBack tbl_feedback = db.tbl_FeedBack.Find(id);
            if (tbl_feedback == null)
            {
                return NotFound();
            }

            return Ok(tbl_feedback);
        }

        // PUT api/FeedBack/5
        public IHttpActionResult Puttbl_FeedBack(int id, tbl_FeedBack tbl_feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_feedback.FeedBackID)
            {
                return BadRequest();
            }

            db.Entry(tbl_feedback).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_FeedBackExists(id))
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

        // POST api/FeedBack
        [ResponseType(typeof(tbl_FeedBack))]
        public IHttpActionResult Posttbl_FeedBack(tbl_FeedBack tbl_feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_FeedBack.Add(tbl_feedback);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_feedback.FeedBackID }, tbl_feedback);
        }

        // DELETE api/FeedBack/5
        [ResponseType(typeof(tbl_FeedBack))]
        public IHttpActionResult Deletetbl_FeedBack(int id)
        {
            tbl_FeedBack tbl_feedback = db.tbl_FeedBack.Find(id);
            if (tbl_feedback == null)
            {
                return NotFound();
            }

            db.tbl_FeedBack.Remove(tbl_feedback);
            db.SaveChanges();

            return Ok(tbl_feedback);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_FeedBackExists(int id)
        {
            return db.tbl_FeedBack.Count(e => e.FeedBackID == id) > 0;
        }
    }
}