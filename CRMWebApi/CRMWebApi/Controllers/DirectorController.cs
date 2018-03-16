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
    public class DirectorController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Director
        public IQueryable<tbl_Director> Gettbl_Director()
        {
            return db.tbl_Director;
        }

        // GET api/Director/5
        [ResponseType(typeof(tbl_Director))]
        public IHttpActionResult Gettbl_Director(int id)
        {
            tbl_Director tbl_director = db.tbl_Director.Find(id);
            if (tbl_director == null)
            {
                return NotFound();
            }

            return Ok(tbl_director);
        }

        // PUT api/Director/5
        public IHttpActionResult Puttbl_Director(int id, tbl_Director tbl_director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_director.DirectorID)
            {
                return BadRequest();
            }

            db.Entry(tbl_director).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_DirectorExists(id))
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

        // POST api/Director
        [ResponseType(typeof(tbl_Director))]
        public IHttpActionResult Posttbl_Director(tbl_Director tbl_director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Director.Add(tbl_director);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_director.DirectorID }, tbl_director);
        }

        // DELETE api/Director/5
        [ResponseType(typeof(tbl_Director))]
        public IHttpActionResult Deletetbl_Director(int id)
        {
            tbl_Director tbl_director = db.tbl_Director.Find(id);
            if (tbl_director == null)
            {
                return NotFound();
            }

            db.tbl_Director.Remove(tbl_director);
            db.SaveChanges();

            return Ok(tbl_director);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_DirectorExists(int id)
        {
            return db.tbl_Director.Count(e => e.DirectorID == id) > 0;
        }
    }
}