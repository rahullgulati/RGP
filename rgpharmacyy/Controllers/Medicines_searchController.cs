using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class Medicines_searchController : ApiController
    {
        private rgEntities db = new rgEntities();

        // GET: api/Medicines_search
        public IQueryable<Medicine> GetMedicines(string name)
        {
            return (from m in db.Medicines where m.m_name.Contains(name)select m);
        }

        //// GET: api/Medicines_search/5
        //[ResponseType(typeof(Medicine))]
        ////public async Task<IHttpActionResult> GetMedicine(int id)
        ////{
        //  //  Medicine medicine = await db.Medicines.FindAsync(id);
        //    //if (medicine == null)
        //    //{
        //     //   return NotFound();
        //    }

        //    return Ok(medicine);
        //}

        // PUT: api/Medicines_search/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.mid)
            {
                return BadRequest();
            }

            db.Entry(medicine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
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

        // POST: api/Medicines_search
        [ResponseType(typeof(Medicine))]
        public async Task<IHttpActionResult> PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicines.Add(medicine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medicine.mid }, medicine);
        }

        // DELETE: api/Medicines_search/5
        [ResponseType(typeof(Medicine))]
        public async Task<IHttpActionResult> DeleteMedicine(int id)
        {
            Medicine medicine = await db.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            db.Medicines.Remove(medicine);
            await db.SaveChangesAsync();

            return Ok(medicine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicineExists(int id)
        {
            return db.Medicines.Count(e => e.mid == id) > 0;
        }
    }
}