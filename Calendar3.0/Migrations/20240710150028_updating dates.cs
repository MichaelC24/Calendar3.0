﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calendar3._0.Migrations
{
    /// <inheritdoc />
    public partial class updatingdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Calendar",
                newName: "Dates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dates",
                table: "Calendar",
                newName: "DateTime");
        }
    }
}
