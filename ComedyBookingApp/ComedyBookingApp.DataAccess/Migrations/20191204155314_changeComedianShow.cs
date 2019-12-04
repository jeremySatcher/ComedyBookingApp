using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class changeComedianShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Comedian_Comedian on Show",
                table: "ComedianShow");

            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Event_Event comedian is on",
                table: "ComedianShow");

            migrationBuilder.DropIndex(
                name: "IX_ComedianShow_Comedian on Show",
                table: "ComedianShow");

            migrationBuilder.DropIndex(
                name: "IX_ComedianShow_Event comedian is on",
                table: "ComedianShow");

            migrationBuilder.DropColumn(
                name: "Comedian on Show",
                table: "ComedianShow");

            migrationBuilder.DropColumn(
                name: "Event comedian is on",
                table: "ComedianShow");

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_ComedianId",
                table: "ComedianShow",
                column: "ComedianId");

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_EventId",
                table: "ComedianShow",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Comedian_ComedianId",
                table: "ComedianShow",
                column: "ComedianId",
                principalTable: "Comedian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Event_EventId",
                table: "ComedianShow",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Comedian_ComedianId",
                table: "ComedianShow");

            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Event_EventId",
                table: "ComedianShow");

            migrationBuilder.DropIndex(
                name: "IX_ComedianShow_ComedianId",
                table: "ComedianShow");

            migrationBuilder.DropIndex(
                name: "IX_ComedianShow_EventId",
                table: "ComedianShow");

            migrationBuilder.AddColumn<int>(
                name: "Comedian on Show",
                table: "ComedianShow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Event comedian is on",
                table: "ComedianShow",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_Comedian on Show",
                table: "ComedianShow",
                column: "Comedian on Show");

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_Event comedian is on",
                table: "ComedianShow",
                column: "Event comedian is on");

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Comedian_Comedian on Show",
                table: "ComedianShow",
                column: "Comedian on Show",
                principalTable: "Comedian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Event_Event comedian is on",
                table: "ComedianShow",
                column: "Event comedian is on",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
