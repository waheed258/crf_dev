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
    public class AccountTypeController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/AccountType
        public IQueryable<tbl_AccountType> Gettbl_AccountType()
        {
            return db.tbl_AccountType;
        }

        // GET api/AccountType/5
        [ResponseType(typeof(tbl_AccountType))]
        public IHttpActionResult Gettbl_AccountType(int id)
        {
            tbl_AccountType tbl_accounttype = db.tbl_AccountType.Find(id);
            if (tbl_accounttype == null)
            {
                return NotFound();
            }

            return Ok(tbl_accounttype);
        }

        // PUT api/AccountType/5
        public IHttpActionResult Puttbl_AccountType(int id, tbl_AccountType tbl_accounttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_accounttype.AccountTypeID)
            {
                return BadRequest();
            }

            db.Entry(tbl_accounttype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_AccountTypeExists(id))
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

        // POST api/AccountType
        [ResponseType(typeof(tbl_AccountType))]
        public IHttpActionResult Posttbl_AccountType(tbl_AccountType tbl_accounttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_AccountType.Add(tbl_accounttype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_accounttype.AccountTypeID }, tbl_accounttype);
        }

        // DELETE api/AccountType/5
        [ResponseType(typeof(tbl_AccountType))]
        public IHttpActionResult Deletetbl_AccountType(int id)
        {
            tbl_AccountType tbl_accounttype = db.tbl_AccountType.Find(id);
            if (tbl_accounttype == null)
            {
                return NotFound();
            }

            db.tbl_AccountType.Remove(tbl_accounttype);
            db.SaveChanges();

            return Ok(tbl_accounttype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_AccountTypeExists(int id)
        {
            return db.tbl_AccountType.Count(e => e.AccountTypeID == id) > 0;
        }
    }
}