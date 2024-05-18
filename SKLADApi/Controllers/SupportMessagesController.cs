using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/SupportMessages")]
    [ApiController]
    public class SupportMessagesController : Controller
    {
        // GET: SupportMessagesController
        private readonly SupportMessagesContext _context;

        public SupportMessagesController(SupportMessagesContext context)
        {
            _context = context;
        }

        // GET: api/SupportMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportMessages>>> GetSupportMessages()
        {
            if (_context.SupportMessages == null)
            {
                return NotFound();
            }
            return await _context.SupportMessages.ToListAsync();
        }

        // GET: api/SupportMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupportMessages>> GetSupportMessage(Guid id)
        {
            if (_context.SupportMessages == null)
            {
                return NotFound();
            }
            var supportMessage = await _context.SupportMessages.FindAsync(id);

            if (supportMessage == null)
            {
                return NotFound();
            }

            return supportMessage;
        }

        // PUT: api/SupportMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupportMessage(Guid id, SupportMessages supportMessage)
        {
            if (id != supportMessage.Id)
            {
                return BadRequest();
            }

            _context.Entry(supportMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportMessagesExists(id))
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

        // POST: api/SupportMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reports>> PostSupportMessage(SupportMessages supportMessage)
        {
            if (_context.SupportMessages == null)
            {
                return Problem("Entity set is null.");
            }
            _context.SupportMessages.Add(supportMessage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupportMessagesExists(supportMessage.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetSupportMessages), new { id = supportMessage.Id }, supportMessage);
        }

        // DELETE: api/SupportMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportMessage(Guid id)
        {
            if (_context.SupportMessages == null)
            {
                return NotFound();
            }
            var supportMessage = await _context.SupportMessages.FindAsync(id);

            if (supportMessage == null)
            {
                return NotFound();
            }

            _context.SupportMessages.Remove(supportMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportMessagesExists(Guid id)
        {
            return (_context.SupportMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
