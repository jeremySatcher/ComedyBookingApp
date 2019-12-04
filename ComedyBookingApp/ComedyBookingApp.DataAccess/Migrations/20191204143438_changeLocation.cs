using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class changeLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationContact_Location_Location Managed",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_Location Managed",
                table: "LocationContact");

            migrationBuilder.DropColumn(
                name: "Location Managed",
                table: "LocationContact");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "LocationContact");

            migrationBuilder.AddColumn<int>(
                name: "Location Contact Person",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationContactId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "LocationContactId",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "Location Managed",
                table: "LocationContact",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "LocationContact",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_Location Managed",
                table: "LocationContact",
                column: "Location Managed");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationContact_Location_Location Managed",
                table: "LocationContact",
                column: "Location Managed",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
