using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/SystemRoles")]
    [ApiController]
    public class SystemRolesController : Controller
    {
        // GET: SystemRolesController
        private readonly SystemRolesContext _context;

        public SystemRolesController(SystemRolesContext context)
        {
            _context = context;
        }

        // GET: api/SystemRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemRoles>>> GetSystemRoles()
        {
            if (_context.SystemRoles == null)
            {
                return NotFound();
            }
            return await _context.SystemRoles.ToListAsync();
        }

        // GET: api/SystemRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemRoles>> GetSystemRole(Guid id)
        {
            if (_context.SystemRoles == null)
            {
                return NotFound();
            }
            var systemRole = await _context.SystemRoles.FindAsync(id);

            if (systemRole == null)
            {
                return NotFound();
            }

            return systemRole;
        }

        // PUT: api/SystemRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemRole(Guid id, SystemRoles systemRole)
        {
            if (id != systemRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemRoleExists(id))
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

        // POST: api/SystemRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemRoles>> PostSystemRole(SystemRoles systemRole)
        {
            if (_context.SystemRoles == null)
            {
                return Problem("Entity set is null.");
            }
            _context.SystemRoles.Add(systemRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SystemRoleExists(systemRole.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetSystemRoles), new { id = systemRole.Id }, systemRole);
        }

        // DELETE: api/SystemRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemRole(Guid id)
        {
            if (_context.SystemRoles == null)
            {
                return NotFound();
            }
            var systemRole = await _context.SystemRoles.FindAsync(id);

            if (systemRole == null)
            {
                return NotFound();
            }

            _context.SystemRoles.Remove(systemRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemRoleExists(Guid id)
        {
            return (_context.SystemRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
