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
using WebApi210940320091;

namespace WebApi210940320091.Controllers
{
    public class WebApiController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/WebApi
        public IQueryable<Product_tbl> GetProduct_tbl()
        {
            return db.Product_tbl;
        }

        // GET: api/WebApi/5
        [ResponseType(typeof(Product_tbl))]
        public IHttpActionResult GetProduct_tbl(int id)
        {
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            if (product_tbl == null)
            {
                return NotFound();
            }

            return Ok(product_tbl);
        }

        // PUT: api/WebApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct_tbl(int id, Product_tbl product_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_tbl.ProductId)
            {
                return BadRequest();
            }

            db.Entry(product_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_tblExists(id))
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

        // POST: api/WebApi
        [ResponseType(typeof(Product_tbl))]
        public IHttpActionResult PostProduct_tbl(Product_tbl product_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Product_tbl.Add(product_tbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Product_tblExists(product_tbl.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product_tbl.ProductId }, product_tbl);
        }

        // DELETE: api/WebApi/5
        [ResponseType(typeof(Product_tbl))]
        public IHttpActionResult DeleteProduct_tbl(int id)
        {
            Product_tbl product_tbl = db.Product_tbl.Find(id);
            if (product_tbl == null)
            {
                return NotFound();
            }

            db.Product_tbl.Remove(product_tbl);
            db.SaveChanges();

            return Ok(product_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Product_tblExists(int id)
        {
            return db.Product_tbl.Count(e => e.ProductId == id) > 0;
        }
    }
}