using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class locationfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_LocationContact_LocationContactId",
                table: "Location");

            migrationBuilder.DropTable(
                name: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_Location_LocationContactId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "LocationContactId",
                table: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationContactId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LocationContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationContact", x => x.Id);
                });

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
    }
}
