using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class changeLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_LocationContact_Location Contact Person",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_Location Contact Person",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Location Contact Person",
                table: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationContactId",
                table: "Location",
                column: "LocationContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_LocationContact_LocationContactId",
                table: "Location",
                column: "LocationContactId",
                principalTable: "LocationContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_LocationContact_LocationContactId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_LocationContactId",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "Location Contact Person",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Location Contact Person",
                table: "Location",
                column: "Location Contact Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_LocationContact_Location Contact Person",
                table: "Location",
                column: "Location Contact Person",
                principalTable: "LocationContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
