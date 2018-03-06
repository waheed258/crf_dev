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
    public class UserTypeController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/UserType
        public IQueryable<tbl_UserType> Gettbl_UserType()
        {
            return db.tbl_UserType;
        }

        // GET api/UserType/5
        [ResponseType(typeof(tbl_UserType))]
        public IHttpActionResult Gettbl_UserType(int id)
        {
            tbl_UserType tbl_usertype = db.tbl_UserType.Find(id);
            if (tbl_usertype == null)
            {
                return NotFound();
            }

            return Ok(tbl_usertype);
        }

        // PUT api/UserType/5
        public IHttpActionResult Puttbl_UserType(int id, tbl_UserType tbl_usertype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_usertype.UserTypeId)
            {
                return BadRequest();
            }

            db.Entry(tbl_usertype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_UserTypeExists(id))
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

        // POST api/UserType
        [ResponseType(typeof(tbl_UserType))]
        public IHttpActionResult Posttbl_UserType(tbl_UserType tbl_usertype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_UserType.Add(tbl_usertype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_usertype.UserTypeId }, tbl_usertype);
        }

        // DELETE api/UserType/5
        [ResponseType(typeof(tbl_UserType))]
        public IHttpActionResult Deletetbl_UserType(int id)
        {
            tbl_UserType tbl_usertype = db.tbl_UserType.Find(id);
            if (tbl_usertype == null)
            {
                return NotFound();
            }

            db.tbl_UserType.Remove(tbl_usertype);
            db.SaveChanges();

            return Ok(tbl_usertype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_UserTypeExists(int id)
        {
            return db.tbl_UserType.Count(e => e.UserTypeId == id) > 0;
        }
    }
}