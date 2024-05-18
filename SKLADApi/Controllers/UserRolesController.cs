using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/UserRoles")]
    [ApiController]
    public class UserRolesController : Controller
    {
        // GET: UserRolesController
        private readonly UserRolesContext _context;

        public UserRolesController(UserRolesContext context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            return await _context.UserRoles.ToListAsync();
        }

        // GET: api/UserRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoles>> GetUserRole(Guid id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRole = await _context.UserRoles.FindAsync(id);

            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }

        [HttpGet("/api/UserRoles/GetByUserId/{user_id}")]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRolesByUserId(Guid user_id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRole = await _context.UserRoles.Where(u => u.User_id == user_id).ToListAsync();

            if (userRole == null || !userRole.Any())
            {
                return NotFound();
            }
            else
            {
                return userRole;
            }
        }

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(Guid id, UserRoles userRole)
        {
            if (id != userRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
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

        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoles>> PostUserRole(UserRoles userRole)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set is null.");
            }
            _context.UserRoles.Add(userRole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRoleExists(userRole.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetUserRoles), new { id = userRole.Id }, userRole);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRole(Guid id)
        {
            if (_context.UserRoles == null)
            {
                return NotFound();
            }
            var userRole = await _context.UserRoles.FindAsync(id);

            if (userRole == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoleExists(Guid id)
        {
            return (_context.UserRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}