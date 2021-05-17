using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.Database;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [Route("api/StoreItems")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StoreController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/StoreItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreModel>>> GetStoreItems()
        {
            return await _context.Store.ToListAsync();
        }

        // GET: api/StoreItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreModel>> GetStoreItems(long id)
        {
            var storeItems = await _context.Store.FindAsync(id);

            if (storeItems == null)
            {
                return NotFound();
            }

            return storeItems;
        }

        // PUT: api/StoreItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreItems(long id, StoreModel storeItems)
        {
            if (id != storeItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreItemsExists(id))
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

        // POST: api/StoreItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreModel>> PostStoreItems(StoreModel storeItems)
        {
            _context.Store.Add(storeItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStoreItems), new { id = storeItems.Id }, storeItems);
        }

        // DELETE: api/StoreItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreItems(long id)
        {
            var storeItems = await _context.Store.FindAsync(id);
            if (storeItems == null)
            {
                return NotFound();
            }

            _context.Store.Remove(storeItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreItemsExists(long id)
        {
            return _context.Store.Any(e => e.Id == id);
        }
    }
}
