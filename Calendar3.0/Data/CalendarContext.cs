using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Calendar3._0.Model;

namespace Calendar3._0.Data
{
    public class CalendarContext : DbContext
    {
        public CalendarContext (DbContextOptions<CalendarContext> options)
            : base(options)
        {
        }

        public DbSet<Calendar3._0.Model.Calendar> Calendar { get; set; } = default!;
    }
}
