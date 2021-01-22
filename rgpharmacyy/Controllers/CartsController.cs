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
    public class CartsController : ApiController
    {
        private rgEntities db = new rgEntities();

        // GET: api/Carts
        public IQueryable<Cart> GetCarts()
        {
            return db.Carts;
        }

        // GET: api/Carts/5
        
        public ObjectResult<cart_display_Result>GetCart(string id)
        {
            return db.cart_display(id);

           
        }

        // PUT: api/Carts/5
        
        public ObjectResult<cart_display_Result> PutCart( login_Result login)
        {
            return db.cart_display(login.email);

        }

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cart_insert(cart.email, cart.mid, cart.pid, cart.oid, cart.total_price, cart.quantity);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cart.cid }, cart);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> DeleteCart(int id)
        {
            Cart cart = await db.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            await db.SaveChangesAsync();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.cid == id) > 0;
        }
    }
}