using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestAllergies",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    AllergyId = table.Column<int>(type: "int", nullable: false),
                    AllergyId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestAllergies", x => new { x.GuestId, x.AllergyId });
                    table.ForeignKey(
                        name: "FK_GuestAllergies_Allergies_AllergyId1",
                        column: x => x.AllergyId1,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestAllergies_Guests_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    GuestId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestEvents", x => new { x.EventId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestEvents_Events_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestEvents_Guests_GuestId1",
                        column: x => x.GuestId1,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_AllergyType",
                table: "Allergies",
                column: "AllergyType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventName",
                table: "Events",
                column: "EventName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestAllergies_AllergyId",
                table: "GuestAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAllergies_AllergyId1",
                table: "GuestAllergies",
                column: "AllergyId1");

            migrationBuilder.CreateIndex(
                name: "IX_GuestEvents_GuestId",
                table: "GuestEvents",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestEvents_GuestId1",
                table: "GuestEvents",
                column: "GuestId1");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_Email",
                table: "Guests",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestAllergies");

            migrationBuilder.DropTable(
                name: "GuestEvents");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Guests");
        }
    }
}
