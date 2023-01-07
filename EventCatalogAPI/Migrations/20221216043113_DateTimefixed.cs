using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventCatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class DateTimefixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEndDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventEndTime",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventStartTime",
                table: "Events",
                newName: "EventStartDateTime");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Events",
                newName: "EventEndDateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventStartDateTime",
                table: "Events",
                newName: "EventStartTime");

            migrationBuilder.RenameColumn(
                name: "EventEndDateTime",
                table: "Events",
                newName: "EventStartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventEndDate",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EventEndTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
