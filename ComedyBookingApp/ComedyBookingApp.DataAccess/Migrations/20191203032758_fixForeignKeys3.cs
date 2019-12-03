using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class fixForeignKeys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Event_EventId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_EventId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Location_EventId",
                table: "Location",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Event_EventId",
                table: "Location",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
