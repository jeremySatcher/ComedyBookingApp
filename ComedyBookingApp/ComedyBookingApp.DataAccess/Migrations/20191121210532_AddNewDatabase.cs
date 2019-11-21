using Microsoft.EntityFrameworkCore.Migrations;

namespace ComedyBookingApp.DataAccess.Migrations
{
    public partial class AddNewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Comedian_ComedianId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Comedian_ComedianId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact");

            migrationBuilder.DropIndex(
                name: "IX_Event_ComedianId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Agent_ComedianId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "ComedianId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "ExpereinceYears",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "ComedianId",
                table: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Comedian",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComedianId",
                table: "Comedian",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienceYears",
                table: "Comedian",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComedianShow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComedianId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    ComedianShowId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComedianShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComedianShow_Comedian_ComedianId",
                        column: x => x.ComedianId,
                        principalTable: "Comedian",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComedianShow_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId",
                unique: true,
                filter: "[LocationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventId",
                table: "Event",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comedian_ComedianId",
                table: "Comedian",
                column: "ComedianId");

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_ComedianId",
                table: "ComedianShow",
                column: "ComedianId");

            migrationBuilder.CreateIndex(
                name: "IX_ComedianShow_EventId",
                table: "ComedianShow",
                column: "EventId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comedian_Agent_ComedianId",
                table: "Comedian");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_EventId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "ComedianShow");

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
                name: "EventId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "ComedianId",
                table: "Comedian");

            migrationBuilder.DropColumn(
                name: "ExperienceYears",
                table: "Comedian");

            migrationBuilder.AddColumn<int>(
                name: "ComedianId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpereinceYears",
                table: "Comedian",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComedianId",
                table: "Agent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationContact_LocationId",
                table: "LocationContact",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ComedianId",
                table: "Event",
                column: "ComedianId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Agent_ComedianId",
                table: "Agent",
                column: "ComedianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Comedian_ComedianId",
                table: "Agent",
                column: "ComedianId",
                principalTable: "Comedian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Comedian_ComedianId",
                table: "Event",
                column: "ComedianId",
                principalTable: "Comedian",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
