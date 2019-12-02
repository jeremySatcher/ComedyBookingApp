using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class diffEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComedianShowId",
                table: "Event",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComedianShowId",
                table: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
