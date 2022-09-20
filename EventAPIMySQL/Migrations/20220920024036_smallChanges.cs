using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    public partial class smallChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allergy_Guests_GuestId",
                table: "Allergy");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_EventId",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy");

            migrationBuilder.DropIndex(
                name: "IX_Allergy_GuestId",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Allergy");

            migrationBuilder.RenameTable(
                name: "Allergy",
                newName: "Allergies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AllergyGuest",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false),
                    GuestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergyGuest", x => new { x.AllergiesId, x.GuestsId });
                    table.ForeignKey(
                        name: "FK_AllergyGuest_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergyGuest_Guests_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGuest",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    GuestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGuest", x => new { x.EventsId, x.GuestsId });
                    table.ForeignKey(
                        name: "FK_EventGuest_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGuest_Guests_GuestsId",
                        column: x => x.GuestsId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergyGuest_GuestsId",
                table: "AllergyGuest",
                column: "GuestsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGuest_GuestsId",
                table: "EventGuest",
                column: "GuestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergyGuest");

            migrationBuilder.DropTable(
                name: "EventGuest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Allergies",
                table: "Allergies");

            migrationBuilder.RenameTable(
                name: "Allergies",
                newName: "Allergy");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Guests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Allergy",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Allergy",
                table: "Allergy",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_EventId",
                table: "Guests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Allergy_GuestId",
                table: "Allergy",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allergy_Guests_GuestId",
                table: "Allergy",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Events_EventId",
                table: "Guests",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
