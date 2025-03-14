using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShirtsApp.Api.Data.Database_Config;
using ShirtsApp.Api.Data.Models;

namespace ShirtsApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: Shirts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shirt>>> GetShirts()
        {
            return Ok(await db.Shirts.ToListAsync());
        }

        // GET: Shirts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shirt>> GetShirt(int id)
        {
            var shirt = await db.Shirts.FindAsync(id);
            if (shirt == null)
            {
                return NotFound();
            }

            return Ok(shirt);
        }

        // PUT: Shirts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShirt(int id,[FromBody] Shirt shirt)
        {
            if (id != shirt.ShirtID)
            {
                return BadRequest();
            }

            db.Entry(shirt).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShirtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Shirts
        [HttpPost]
        public async Task<ActionResult<Shirt>> PostShirt([FromBody] Shirt shirt)
        {
            db.Shirts.Add(shirt);
            await db.SaveChangesAsync();

            return Ok(); 
        }

        // DELETE: Shirts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShirt(int id)
        {
            var shirt = await db.Shirts.FindAsync(id);
            if (shirt == null)
            {
                return NotFound();
            }

            db.Shirts.Remove(shirt);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool ShirtExists(int id)
        {
            return db.Shirts.Any(e => e.ShirtID == id);
        }
    }
}
