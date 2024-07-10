using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Calendar3._0.Model
{
    public class Calendar
    {
        public int Id { get; set; }

        public DateTime Dates { get; set; }

        [Column(TypeName = "bit")]
        public bool? Recurring { get; set; } = false;

        public int? DaysBetween { get; set; } = null;

        [Column(TypeName = "bit")]
        public bool? MultipleDays { get; set; } = false;

        public int? HowManyDays { get; set; } = null;

        [StringLength(200)]
        public string? Appointment { get; set; } = string.Empty;
    }
}
