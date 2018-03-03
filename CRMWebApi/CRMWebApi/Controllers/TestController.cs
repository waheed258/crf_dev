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
    public class TestController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Test
        public IQueryable<tbl_admin_User> Gettbl_admin_User()
        {
            return db.tbl_admin_User;
        }

        // GET api/Test/5
        [ResponseType(typeof(tbl_admin_User))]
        public IHttpActionResult Gettbl_admin_User(int id)
        {
            tbl_admin_User tbl_admin_user = db.tbl_admin_User.Find(id);
            if (tbl_admin_user == null)
            {
                return NotFound();
            }

            return Ok(tbl_admin_user);
        }

        // PUT api/Test/5
        public IHttpActionResult Puttbl_admin_User(int id, tbl_admin_User tbl_admin_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_admin_user.UserID)
            {
                return BadRequest();
            }

            db.Entry(tbl_admin_user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_admin_UserExists(id))
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

        // POST api/Test
        [ResponseType(typeof(tbl_admin_User))]
        public IHttpActionResult Posttbl_admin_User(tbl_admin_User tbl_admin_user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_admin_User.Add(tbl_admin_user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_admin_user.UserID }, tbl_admin_user);
        }

        // DELETE api/Test/5
        [ResponseType(typeof(tbl_admin_User))]
        public IHttpActionResult Deletetbl_admin_User(int id)
        {
            tbl_admin_User tbl_admin_user = db.tbl_admin_User.Find(id);
            if (tbl_admin_user == null)
            {
                return NotFound();
            }

            db.tbl_admin_User.Remove(tbl_admin_user);
            db.SaveChanges();

            return Ok(tbl_admin_user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_admin_UserExists(int id)
        {
            return db.tbl_admin_User.Count(e => e.UserID == id) > 0;
        }
    }
}