using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class fixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comedian_Agent_ComedianId",
                table: "Comedian");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_EventId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_Event_EventId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Comedian_ComedianId",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "ComedianShowId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ComedianShowId",
                table: "ComedianShow");

            migrationBuilder.DropColumn(
                name: "ComedianId",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "ComedianId",
                table: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_EventId",
                table: "Location",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comedian_AgentId",
                table: "Comedian",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comedian_Agent_AgentId",
                table: "Comedian",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Event_EventId",
                table: "Location",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comedian_Agent_AgentId",
                table: "Comedian");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Event_EventId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_Location_EventId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Comedian_AgentId",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "ComedianShowId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComedianShowId",
                table: "ComedianShow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComedianId",
                table: "Comedian",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComedianId",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventId",
                table: "Event",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comedian_ComedianId",
                table: "Comedian",
                column: "ComedianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comedian_Agent_ComedianId",
                table: "Comedian",
                column: "ComedianId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_EventId",
                table: "Event",
                column: "EventId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
