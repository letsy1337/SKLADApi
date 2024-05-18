using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/DeliveryPoints")]
    [ApiController]
    public class DeliveryPointsController : Controller
    {
        // GET: DeliveryPointsController
        private readonly DeliveryPointsContext _context;

        public DeliveryPointsController(DeliveryPointsContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryPoints>>> GetDeliveryPoints()
        {
            if (_context.DeliveryPoints == null)
            {
                return NotFound();
            }
            return await _context.DeliveryPoints.ToListAsync();
        }

        // GET: api/DeliveryPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryPoints>> GetDeliveryPoint(Guid id)
        {
            if (_context.DeliveryPoints == null)
            {
                return NotFound();
            }
            var deliveryPoint = await _context.DeliveryPoints.FindAsync(id);

            if (deliveryPoint == null)
            {
                return NotFound();
            }

            return deliveryPoint;
        }

        // PUT: api/DeliveryPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryPoint(Guid id, DeliveryPoints deliveryPoint)
        {
            if (id != deliveryPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryPointExists(id))
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
        public async Task<ActionResult<DeliveryPoints>> PostDeliveryPoint(DeliveryPoints deliveryPoint)
        {
            if (_context.DeliveryPoints == null)
            {
                return Problem("Entity set is null.");
            }
            _context.DeliveryPoints.Add(deliveryPoint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryPointExists(deliveryPoint.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetDeliveryPoints), new { id = deliveryPoint.Id }, deliveryPoint);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryPoint(Guid id)
        {
            if (_context.DeliveryPoints == null)
            {
                return NotFound();
            }
            var deliveryPoint = await _context.DeliveryPoints.FindAsync(id);

            if (deliveryPoint == null)
            {
                return NotFound();
            }

            _context.DeliveryPoints.Remove(deliveryPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryPointExists(Guid id)
        {
            return (_context.DeliveryPoints?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
