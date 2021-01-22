using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using rgpharmacyy.Models;

namespace rgpharmacyy.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BrandController : ApiController
    {
        private rgEntities db = new rgEntities();

        // GET: api/Brand
        public IQueryable<Health_care> GetHealth_care()
        {
            return db.Health_care;
        }

        // GET: api/Brand/5
        [ResponseType(typeof(brand_Result))]
        public ObjectResult<brand_Result> GetHealth_care(string id)
        {
            return db.brand(id);

        }

        // PUT: api/Brand/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHealth_care(int id, Health_care health_care)
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
                await db.SaveChangesAsync();
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

        // POST: api/Brand
        [ResponseType(typeof(Health_care))]
        public async Task<IHttpActionResult> PostHealth_care(Health_care health_care)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Health_care.Add(health_care);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = health_care.pid }, health_care);
        }

        // DELETE: api/Brand/5
        [ResponseType(typeof(Health_care))]
        public async Task<IHttpActionResult> DeleteHealth_care(int id)
        {
            Health_care health_care = await db.Health_care.FindAsync(id);
            if (health_care == null)
            {
                return NotFound();
            }

            db.Health_care.Remove(health_care);
            await db.SaveChangesAsync();

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