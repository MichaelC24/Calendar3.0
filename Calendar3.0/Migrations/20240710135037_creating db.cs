using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calendar3._0.Migrations
{
    /// <inheritdoc />
    public partial class creatingdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recurring = table.Column<bool>(type: "bit", nullable: false),
                    DaysBetween = table.Column<int>(type: "int", nullable: false),
                    MultipleDays = table.Column<bool>(type: "bit", nullable: false),
                    HowManyDays = table.Column<int>(type: "int", nullable: false),
                    Appointment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calendar");
        }
    }
}
