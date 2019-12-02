using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class comedianShowBetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Comedian_ComedianId",
                table: "ComedianShow");

            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Event_EventId",
                table: "ComedianShow");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationContact",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "ComedianShow",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComedianId",
                table: "ComedianShow",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Comedian_ComedianId",
                table: "ComedianShow");

            migrationBuilder.DropForeignKey(
                name: "FK_ComedianShow_Event_EventId",
                table: "ComedianShow");

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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "ComedianShow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ComedianId",
                table: "ComedianShow",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Comedian_ComedianId",
                table: "ComedianShow",
                column: "ComedianId",
                principalTable: "Comedian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComedianShow_Event_EventId",
                table: "ComedianShow",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationContact_Location_LocationId",
                table: "LocationContact",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
