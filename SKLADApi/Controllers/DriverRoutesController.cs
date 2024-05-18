using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/DriverRoutes")]
    [ApiController]
    public class DriverRoutesController : Controller
    {
        // GET: DriverRoutesController
        private readonly DriverRoutesContext _context;

        public DriverRoutesController(DriverRoutesContext context)
        {
            _context = context;
        }

        // GET: api/DriverRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverRoutes>>> GetDriverRoutes()
        {
            if (_context.DriverRoutes == null)
            {
                return NotFound();
            }
            return await _context.DriverRoutes.ToListAsync();
        }

        // GET: api/DriverRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverRoutes>> GetDriverRoute(Guid id)
        {
            if (_context.DriverRoutes == null)
            {
                return NotFound();
            }
            var driverRoute = await _context.DriverRoutes.FindAsync(id);

            if (driverRoute == null)
            {
                return NotFound();
            }

            return driverRoute;
        }

        // PUT: api/DriverRoutes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverDeliver(Guid id, DriverRoutes driverRoute)
        {
            if (id != driverRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(driverRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverRouteExists(id))
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

        // POST: api/DriverRoutes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverRoutes>> PostDriverDeliver(DriverRoutes driverRoute)
        {
            if (_context.DriverRoutes == null)
            {
                return Problem("Entity set is null.");
            }
            _context.DriverRoutes.Add(driverRoute);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DriverRouteExists(driverRoute.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetDriverRoutes), new { id = driverRoute.Id }, driverRoute);
        }

        // DELETE: api/DriverRoutes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (_context.DriverRoutes == null)
            {
                return NotFound();
            }
            var driverRoute = await _context.DriverRoutes.FindAsync(id);

            if (driverRoute == null)
            {
                return NotFound();
            }

            _context.DriverRoutes.Remove(driverRoute);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverRouteExists(Guid id)
        {
            return (_context.DriverRoutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
