using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/Warehouses")]
    [ApiController]
    public class WarehousesController : Controller
    {
        // GET: WarehousesController
        private readonly WarehousesContext _context;

        public WarehousesController(WarehousesContext context)
        {
            _context = context;
        }

        // GET: api/Warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouses>>> GetWarehouses()
        {
            if (_context.Warehouses == null)
            {
                return NotFound();
            }
            return await _context.Warehouses.ToListAsync();
        }

        // GET: api/Warehouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouses>> GetWarehouse(Guid id)
        {
            if (_context.Warehouses == null)
            {
                return NotFound();
            }
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        [HttpGet("/api/Warehouses/GetById/{id}")]
        public async Task<ActionResult<Warehouses>> GetWarehouseById(Guid id)
        {
            if (_context.Warehouses == null)
            {
                return NotFound();
            }
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(c => c.Id == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return warehouse;
        }

        // PUT: api/Warehouses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(Guid id, Warehouses warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(warehouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Warehouses>> PostWarehouse(Warehouses warehouse)
        {
            if (_context.Warehouses == null)
            {
                return Problem("Entity set is null.");
            }
            _context.Warehouses.Add(warehouse);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WarehouseExists(warehouse.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetWarehouses), new { id = warehouse.Id }, warehouse);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            if (_context.Warehouses == null)
            {
                return NotFound();
            }
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WarehouseExists(Guid id)
        {
            return (_context.Warehouses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
