using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using rgpharmacyy.Models;

namespace rgpharmacyy.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Health_careController : ApiController
    {
        private rgEntities db = new rgEntities();

        // GET: api/Health_care
        public IQueryable<Health_care> GetHealth_care()
        {
            return db.Health_care;
        }

        // GET: api/Health_care/5
        [ResponseType(typeof(Health_care))]
        public IHttpActionResult GetHealth_care(int id)
        {
            Health_care health_care = db.Health_care.Find(id);
            if (health_care == null)
            {
                return NotFound();
            }

            return Ok(health_care);
        }

        // PUT: api/Health_care/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHealth_care(int id, Health_care health_care)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != health_care.pid)
            {
                return BadRequest();
            }

            db.Entry(health_care).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Health_careExists(id))
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

        // POST: api/Health_care
        [ResponseType(typeof(Health_care))]
        public IHttpActionResult PostHealth_care(Health_care health_care)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Health_care_insert(health_care.p_name,health_care.c_name,health_care.manufacture_date,health_care.expiry_date,health_care.price,health_care.quantity,health_care.img,health_care.des);

            return CreatedAtRoute("DefaultApi", new { id = health_care.pid }, health_care);
        }

        // DELETE: api/Health_care/5
        [ResponseType(typeof(Health_care))]
        public IHttpActionResult DeleteHealth_care(int id)
        {
            Health_care health_care = db.Health_care.Find(id);
            if (health_care == null)
            {
                return NotFound();
            }

            db.Health_care.Remove(health_care);
            db.SaveChanges();

            return Ok(health_care);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Health_careExists(int id)
        {
            return db.Health_care.Count(e => e.pid == id) > 0;
        }
    }
}