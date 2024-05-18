using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/DeliveryStatuses")]
    [ApiController]
    public class DeliveryStatusesController : Controller
    {
        // GET: CategoriesController
        private readonly DeliveryStatusesContext _context;

        public DeliveryStatusesController(DeliveryStatusesContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryStatuses>>> GetDeliveryStatuses()
        {
            if (_context.DeliveryStatuses == null)
            {
                return NotFound();
            }
            return await _context.DeliveryStatuses.ToListAsync();
        }

        // GET: api/DeliveryStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryStatuses>> GetDeliveryStatus(Guid id)
        {
            if (_context.DeliveryStatuses == null)
            {
                return NotFound();
            }
            var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);

            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return deliveryStatus;
        }

        [HttpGet("/api/DeliveryStatuses/GetById/{id}")]
        public async Task<ActionResult<DeliveryStatuses>> GetDeliveryStatusById(Guid id)
        {
            if (_context.DeliveryStatuses == null)
            {
                return NotFound();
            }
            var deliveryStatus = await _context.DeliveryStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return deliveryStatus;
        }

        // PUT: api/DeliveryStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryStatus(Guid id, DeliveryStatuses deliveryStatus)
        {
            if (id != deliveryStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryStatusExists(id))
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

        // POST: api/DeliveryStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryStatuses>> PostDeliveryStatus(DeliveryStatuses deliveryStatus)
        {
            if (_context.DeliveryStatuses == null)
            {
                return Problem("Entity set is null.");
            }
            _context.DeliveryStatuses.Add(deliveryStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryStatusExists(deliveryStatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetDeliveryStatuses), new { id = deliveryStatus.Id }, deliveryStatus);
        }

        // DELETE: api/DeliveryStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryStatus(Guid id)
        {
            if (_context.DeliveryStatuses == null)
            {
                return NotFound();
            }
            var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);

            if (deliveryStatus == null)
            {
                return NotFound();
            }

            _context.DeliveryStatuses.Remove(deliveryStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryStatusExists(Guid id)
        {
            return (_context.DeliveryStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
