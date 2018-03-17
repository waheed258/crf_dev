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
    public class ChildrenController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Children
        public IQueryable<tbl_Children> Gettbl_Children()
        {
            return db.tbl_Children;
        }

        // GET api/Children/5
        [ResponseType(typeof(tbl_Children))]
        public IHttpActionResult Gettbl_Children(string id)
        {
            tbl_Children tbl_children = db.tbl_Children.Find(id);
            if (tbl_children == null)
            {
                return NotFound();
            }

            return Ok(tbl_children);
        }

        // PUT api/Children/5
        public IHttpActionResult Puttbl_Children(string id, tbl_Children tbl_children)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_children.SAID)
            {
                return BadRequest();
            }

            db.Entry(tbl_children).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ChildrenExists(id))
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

        // POST api/Children
        [ResponseType(typeof(tbl_Children))]
        public IHttpActionResult Posttbl_Children(tbl_Children tbl_children)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Children.Add(tbl_children);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_ChildrenExists(tbl_children.SAID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_children.SAID }, tbl_children);
        }

        // DELETE api/Children/5
        [ResponseType(typeof(tbl_Children))]
        public IHttpActionResult Deletetbl_Children(string id)
        {
            tbl_Children tbl_children = db.tbl_Children.Find(id);
            if (tbl_children == null)
            {
                return NotFound();
            }

            db.tbl_Children.Remove(tbl_children);
            db.SaveChanges();

            return Ok(tbl_children);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ChildrenExists(string id)
        {
            return db.tbl_Children.Count(e => e.SAID == id) > 0;
        }
    }
}