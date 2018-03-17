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
    public class ClientServiceController : ApiController
    {
        private crm_dev_dbEntities db = new crm_dev_dbEntities();

        // GET api/ClientService
        public IQueryable<tbl_ClientService> Gettbl_ClientService()
        {
            return db.tbl_ClientService;
        }

        // GET api/ClientService/5
        [ResponseType(typeof(tbl_ClientService))]
        public IHttpActionResult Gettbl_ClientService(int id)
        {
            tbl_ClientService tbl_clientservice = db.tbl_ClientService.Find(id);
            if (tbl_clientservice == null)
            {
                return NotFound();
            }

            return Ok(tbl_clientservice);
        }

        // PUT api/ClientService/5
        public IHttpActionResult Puttbl_ClientService(int id, tbl_ClientService tbl_clientservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_clientservice.ServiceID)
            {
                return BadRequest();
            }

            db.Entry(tbl_clientservice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ClientServiceExists(id))
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

        // POST api/ClientService
        [ResponseType(typeof(tbl_ClientService))]
        public IHttpActionResult Posttbl_ClientService(tbl_ClientService tbl_clientservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tbl_ClientService.Add(tbl_clientservice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_clientservice.ServiceID }, tbl_clientservice);
        }

        // DELETE api/ClientService/5
        [ResponseType(typeof(tbl_ClientService))]
        public IHttpActionResult Deletetbl_ClientService(int id)
        {
            tbl_ClientService tbl_clientservice = db.tbl_ClientService.Find(id);
            if (tbl_clientservice == null)
            {
                return NotFound();
            }

            db.tbl_ClientService.Remove(tbl_clientservice);
            db.SaveChanges();

            return Ok(tbl_clientservice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_ClientServiceExists(int id)
        {
            return db.tbl_ClientService.Count(e => e.ServiceID == id) > 0;
        }
    }
}