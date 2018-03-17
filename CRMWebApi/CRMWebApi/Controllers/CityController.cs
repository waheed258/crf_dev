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
    public class CityController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/City
        public IQueryable<tbl_City> Gettbl_City()
        {
            return db.tbl_City;
        }

        // GET api/City/5
        [ResponseType(typeof(tbl_City))]
        public IHttpActionResult Gettbl_City(int id)
        {
            tbl_City tbl_city = db.tbl_City.Find(id);
            if (tbl_city == null)
            {
                return NotFound();
            }

            return Ok(tbl_city);
        }

        // PUT api/City/5
        public IHttpActionResult Puttbl_City(int id, tbl_City tbl_city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_city.CityID)
            {
                return BadRequest();
            }

            db.Entry(tbl_city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_CityExists(id))
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

        // POST api/City
        [ResponseType(typeof(tbl_City))]
        public IHttpActionResult Posttbl_City(tbl_City tbl_city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_City.Add(tbl_city);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbl_CityExists(tbl_city.CityID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbl_city.CityID }, tbl_city);
        }

        // DELETE api/City/5
        [ResponseType(typeof(tbl_City))]
        public IHttpActionResult Deletetbl_City(int id)
        {
            tbl_City tbl_city = db.tbl_City.Find(id);
            if (tbl_city == null)
            {
                return NotFound();
            }

            db.tbl_City.Remove(tbl_city);
            db.SaveChanges();

            return Ok(tbl_city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_CityExists(int id)
        {
            return db.tbl_City.Count(e => e.CityID == id) > 0;
        }
    }
}