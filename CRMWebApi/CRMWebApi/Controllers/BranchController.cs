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
    public class BranchController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Branch
        public IQueryable<tbl_Branch> Gettbl_Branch()
        {
            return db.tbl_Branch;
        }

        // GET api/Branch/5
        [ResponseType(typeof(tbl_Branch))]
        public IHttpActionResult Gettbl_Branch(int id)
        {
            tbl_Branch tbl_branch = db.tbl_Branch.Find(id);
            if (tbl_branch == null)
            {
                return NotFound();
            }

            return Ok(tbl_branch);
        }

        // PUT api/Branch/5
        public IHttpActionResult Puttbl_Branch(int id, tbl_Branch tbl_branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_branch.BranchId)
            {
                return BadRequest();
            }

            db.Entry(tbl_branch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_BranchExists(id))
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

        // POST api/Branch
        [ResponseType(typeof(tbl_Branch))]
        public IHttpActionResult Posttbl_Branch(tbl_Branch tbl_branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Branch.Add(tbl_branch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_branch.BranchId }, tbl_branch);
        }

        // DELETE api/Branch/5
        [ResponseType(typeof(tbl_Branch))]
        public IHttpActionResult Deletetbl_Branch(int id)
        {
            tbl_Branch tbl_branch = db.tbl_Branch.Find(id);
            if (tbl_branch == null)
            {
                return NotFound();
            }

            db.tbl_Branch.Remove(tbl_branch);
            db.SaveChanges();

            return Ok(tbl_branch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_BranchExists(int id)
        {
            return db.tbl_Branch.Count(e => e.BranchId == id) > 0;
        }
    }
}