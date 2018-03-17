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
    public class ProvinceController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/Province
        public IQueryable<tbl_Province> Gettbl_Province()
        {
            return db.tbl_Province;
        }

        // GET api/Province/5
        [ResponseType(typeof(tbl_Province))]
        public IHttpActionResult Gettbl_Province(int id)
        {
            tbl_Province tbl_province = db.tbl_Province.Find(id);
            if (tbl_province == null)
            {
                return NotFound();
            }

            return Ok(tbl_province);
        }

        // PUT api/Province/5
        public IHttpActionResult Puttbl_Province(int id, tbl_Province tbl_province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_province.ProvinceID)
            {
                return BadRequest();
            }

            db.Entry(tbl_province).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ProvinceExists(id))
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

        // POST api/Province
        [ResponseType(typeof(tbl_Province))]
        public IHttpActionResult Posttbl_Province(tbl_Province tbl_province)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_Province.Add(tbl_province);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_province.ProvinceID }, tbl_province);
        }

        // DELETE api/Province/5
        [ResponseType(typeof(tbl_Province))]
        public IHttpActionResult Deletetbl_Province(int id)
        {
            tbl_Province tbl_province = db.tbl_Province.Find(id);
            if (tbl_province == null)
            {
                return NotFound();
            }

            db.tbl_Province.Remove(tbl_province);
            db.SaveChanges();

            return Ok(tbl_province);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ProvinceExists(int id)
        {
            return db.tbl_Province.Count(e => e.ProvinceID == id) > 0;
        }
    }
}