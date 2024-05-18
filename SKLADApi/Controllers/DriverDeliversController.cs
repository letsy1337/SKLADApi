using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/DriverDelivers")]
    [ApiController]
    public class DriverDeliversController : Controller
    {
        // GET: OrdersController
        private readonly DriverDeliversContext _context;

        public DriverDeliversController(DriverDeliversContext context)
        {
            _context = context;
        }

        // GET: api/DriverDelivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDelivers>>> GetDriverDelivers()
        {
            if (_context.DriverDelivers == null)
            {
                return NotFound();
            }
            return await _context.DriverDelivers.ToListAsync();
        }

        // GET: api/DriverDelivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDelivers>> GetDriverDeliver(Guid id)
        {
            if (_context.DriverDelivers == null)
            {
                return NotFound();
            }
            var driverDeliver = await _context.DriverDelivers.FindAsync(id);

            if (driverDeliver == null)
            {
                return NotFound();
            }

            return driverDeliver;
        }

        // PUT: api/DriverDelivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverDeliver(Guid id, DriverDelivers driverDeliver)
        {
            if (id != driverDeliver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driverDeliver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverDeliverExists(id))
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

        // POST: api/DriverDelivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverDelivers>> PostDriverDeliver(DriverDelivers driverDeliver)
        {
            if (_context.DriverDelivers == null)
            {
                return Problem("Entity set is null.");
            }
            _context.DriverDelivers.Add(driverDeliver);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriverDeliverExists(driverDeliver.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetDriverDelivers), new { id = driverDeliver.Id }, driverDeliver);
        }

        // DELETE: api/DriverDelivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (_context.DriverDelivers == null)
            {
                return NotFound();
            }
            var driverDeliver = await _context.DriverDelivers.FindAsync(id);

            if (driverDeliver == null)
            {
                return NotFound();
            }

            _context.DriverDelivers.Remove(driverDeliver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverDeliverExists(Guid id)
        {
            return (_context.DriverDelivers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
