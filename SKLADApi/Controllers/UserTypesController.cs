using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/UserTypes")]
    [ApiController]
    public class UserTypesController : Controller
    {
        // GET: CategoriesController
        private readonly UserTypesContext _context;

        public UserTypesController(UserTypesContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTypes>>> GetUserTypes()
        {
            if (_context.UserTypes == null)
            {
                return NotFound();
            }
            return await _context.UserTypes.ToListAsync();
        }

        // GET: api/UserTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTypes>> GetUserType(Guid id)
        {
            if (_context.UserTypes == null)
            {
                return NotFound();
            }
            var userType = await _context.UserTypes.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        [HttpGet("/api/UserTypes/GetById/{id}")]
        public async Task<ActionResult<UserTypes>> GetUserTypeById(Guid id)
        {
            if (_context.UserTypes == null)
            {
                return NotFound();
            }
            var userType = await _context.UserTypes.FirstOrDefaultAsync(c => c.Id == id);

            if (userType == null)
            {
                return NotFound();
            }

            return userType;
        }

        // PUT: api/UserTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserType(Guid id, UserTypes userType)
        {
            if (id != userType.Id)
            {
                return BadRequest();
            }

            _context.Entry(userType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTypeExists(id))
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

        // POST: api/UserTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTypes>> PostUserTypes(UserTypes userType)
        {
            if (_context.UserTypes == null)
            {
                return Problem("Entity set is null.");
            }
            _context.UserTypes.Add(userType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserTypeExists(userType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetUserTypes), new { id = userType.Id }, userType);
        }

        // DELETE: api/UserTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserType(Guid id)
        {
            if (_context.UserTypes == null)
            {
                return NotFound();
            }
            var userType = await _context.UserTypes.FindAsync(id);

            if (userType == null)
            {
                return NotFound();
            }

            _context.UserTypes.Remove(userType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTypeExists(Guid id)
        {
            return (_context.UserTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
