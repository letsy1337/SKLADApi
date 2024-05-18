using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/OrderStatuses")]
    [ApiController]
    public class OrderStatusesController : Controller
    {
        // GET: CategoriesController
        private readonly OrderStatusesContext _context;

        public OrderStatusesController(OrderStatusesContext context)
        {
            _context = context;
        }

        // GET: api/OrderStatuses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderStatuses>>> GetOrderStatuses()
        {
            if (_context.OrderStatuses == null)
            {
                return NotFound();
            }
            return await _context.OrderStatuses.ToListAsync();
        }

        // GET: api/OrderStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatuses>> GetOrderStatus(Guid id)
        {
            if (_context.OrderStatuses == null)
            {
                return NotFound();
            }
            var orderStatus = await _context.OrderStatuses.FindAsync(id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            return orderStatus;
        }

        [HttpGet("/api/OrderStatuses/GetById/{id}")]
        public async Task<ActionResult<OrderStatuses>> GetOrderStatusById(Guid id)
        {
            if (_context.OrderStatuses == null)
            {
                return NotFound();
            }
            var orderStatus = await _context.OrderStatuses.FirstOrDefaultAsync(c => c.Id == id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            return orderStatus;
        }

        // PUT: api/OrderStatuses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderStatus(Guid id, OrderStatuses orderStatus)
        {
            if (id != orderStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderStatusExists(id))
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

        // POST: api/OrderStatuses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderStatuses>> PostOrderStatus(OrderStatuses orderStatus)
        {
            if (_context.OrderStatuses == null)
            {
                return Problem("Entity set is null.");
            }
            _context.OrderStatuses.Add(orderStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderStatusExists(orderStatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetOrderStatuses), new { id = orderStatus.Id }, orderStatus);
        }

        // DELETE: api/OrderStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatus(Guid id)
        {
            if (_context.OrderStatuses == null)
            {
                return NotFound();
            }
            var orderStatus = await _context.OrderStatuses.FindAsync(id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            _context.OrderStatuses.Remove(orderStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderStatusExists(Guid id)
        {
            return (_context.OrderStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
