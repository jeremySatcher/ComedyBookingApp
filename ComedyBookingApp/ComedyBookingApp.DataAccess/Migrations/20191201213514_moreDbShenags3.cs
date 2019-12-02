using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class moreDbShenags3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComedianShowId",
                table: "Comedian");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComedianShowId",
                table: "Comedian",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
