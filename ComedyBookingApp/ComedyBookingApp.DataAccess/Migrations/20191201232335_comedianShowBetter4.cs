using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class comedianShowBetter4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationContact",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationContact",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
