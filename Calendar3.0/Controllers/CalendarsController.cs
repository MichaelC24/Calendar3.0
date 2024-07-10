using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calendar3._0.Data;
using Calendar3._0.Model;
using NuGet.Versioning;

namespace Calendar3._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarsController : ControllerBase
    {
        private readonly CalendarContext _context;

        public CalendarsController(CalendarContext context)
        {
            _context = context;
        }

        // GET: api/Calendars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendar()
        {
            return await _context.Calendar.ToListAsync();
        }

        // GET: api/Calendars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendar>> GetCalendar(int id)
        {
            var calendar = await _context.Calendar.FindAsync(id);

            if (calendar == null)
            {
                return NotFound();
            }

            return calendar;
        }
        [HttpPut("appointment")]

        public async Task<IActionResult> NewAppointment(Calendar calendar)
        {
            var dateExists = await _context.Calendar.FindAsync(calendar.Dates);

            if (dateExists != null)
            {
                var date = await _context.Calendar.FindAsync(calendar.Id);

                var end = date.Dates.AddDays(calendar.HowManyDays ?? 0);

                if (calendar.MultipleDays == true)
                {
                    for (var i = date.Dates; i <= end; i = i.AddDays(1))
                    {
                        var newCalendar = new Calendar
                        {
                            Dates = i,
                            //Recurring = calendar.Recurring,
                            //DaysBetween = calendar.DaysBetween,
                            MultipleDays = calendar.MultipleDays,
                            HowManyDays = calendar.HowManyDays,
                            Appointment = calendar.Appointment
                        };
                        _context.Calendar.Add(newCalendar);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (calendar.Recurring == true)
                {
                    var daysBetween = calendar.DaysBetween ?? 1; // Default to 1 if DaysBetween is null
                    for (var i = date.Dates; i <= end; i = i.AddDays(daysBetween))
                    {
                        var newCalendar = new Calendar
                        {
                            Dates = i,
                            Recurring = calendar.Recurring,
                            DaysBetween = calendar.DaysBetween,
                            Appointment = calendar.Appointment
                        };
                        _context.Calendar.Add(newCalendar);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    _context.Calendar.Add(calendar);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest("test");
        }

        // PUT: api/Calendars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendar(int id, Calendar calendar)
        {
            if (id != calendar.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(id))
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

        // POST: api/Calendars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calendar>> PostCalendar(Calendar calendar)
        {
            _context.Calendar.Add(calendar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendar", new { id = calendar.Id }, calendar);
        }

        // DELETE: api/Calendars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendar(int id)
        {
            var calendar = await _context.Calendar.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

            _context.Calendar.Remove(calendar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarExists(int id)
        {
            return _context.Calendar.Any(e => e.Id == id);
        }
    }
}
