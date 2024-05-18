using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SKLADApi.Models;

namespace SKLADApi.Controllers
{
    [Route("api/ReportTypes")]
    [ApiController]
    public class ReportTypesController : Controller
    {
        // GET: ReportTypesController
        private readonly ReportTypesContext _context;

        public ReportTypesController(ReportTypesContext context)
        {
            _context = context;
        }

        // GET: api/ReportTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportTypes>>> GetReportTypes()
        {
            if (_context.ReportTypes == null)
            {
                return NotFound();
            }
            return await _context.ReportTypes.ToListAsync();
        }

        // GET: api/ReportTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportTypes>> GetReportType(Guid id)
        {
            if (_context.ReportTypes == null)
            {
                return NotFound();
            }
            var report = await _context.ReportTypes.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // PUT: api/ReportTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportType(Guid id, ReportTypes reportType)
        {
            if (id != reportType.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportTypeExists(id))
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

        // POST: api/ReportTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportTypes>> PostReportType(ReportTypes reportType)
        {
            if (_context.ReportTypes == null)
            {
                return Problem("Entity set is null.");
            }
            _context.ReportTypes.Add(reportType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReportTypeExists(reportType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetReportTypes), new { id = reportType.Id }, reportType);
        }

        // DELETE: api/ReportTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportType(Guid id)
        {
            if (_context.ReportTypes == null)
            {
                return NotFound();
            }
            var order = await _context.ReportTypes.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.ReportTypes.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportTypeExists(Guid id)
        {
            return (_context.ReportTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
