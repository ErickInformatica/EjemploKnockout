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
using System.Web.Http.Description;
using LoginKnockout.Models;

namespace LoginKnockout.Controllers
{
    public class OpinionsController : ApiController
    {
        private EntityKnockout db = new EntityKnockout();

        // GET: api/Opinions
        public IQueryable<Opinion> GetOpinion()
        {
            return db.Opinion;
        }

        // GET: api/Opinions/5
        [ResponseType(typeof(Opinion))]
        public async Task<IHttpActionResult> GetOpinion(int id)
        {
            Opinion opinion = await db.Opinion.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }

            return Ok(opinion);
        }

        // PUT: api/Opinions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOpinion(int id, Opinion opinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opinion.OpinionId)
            {
                return BadRequest();
            }

            db.Entry(opinion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpinionExists(id))
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

        // POST: api/Opinions
        [ResponseType(typeof(Opinion))]
        public async Task<IHttpActionResult> PostOpinion(Opinion opinion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Opinion.Add(opinion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = opinion.OpinionId }, opinion);
        }

        // DELETE: api/Opinions/5
        [ResponseType(typeof(Opinion))]
        public async Task<IHttpActionResult> DeleteOpinion(int id)
        {
            Opinion opinion = await db.Opinion.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }

            db.Opinion.Remove(opinion);
            await db.SaveChangesAsync();

            return Ok(opinion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OpinionExists(int id)
        {
            return db.Opinion.Count(e => e.OpinionId == id) > 0;
        }
    }
}