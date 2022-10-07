using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestAllergies_Allergies_AllergyId1",
                table: "GuestAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestAllergies_Guests_AllergyId",
                table: "GuestAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestEvents_Events_GuestId",
                table: "GuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestEvents_Guests_GuestId1",
                table: "GuestEvents");

            migrationBuilder.DropIndex(
                name: "IX_GuestEvents_GuestId1",
                table: "GuestEvents");

            migrationBuilder.DropIndex(
                name: "IX_GuestAllergies_AllergyId1",
                table: "GuestAllergies");

            migrationBuilder.DropColumn(
                name: "GuestId1",
                table: "GuestEvents");

            migrationBuilder.DropColumn(
                name: "AllergyId1",
                table: "GuestAllergies");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAllergies_Allergies_AllergyId",
                table: "GuestAllergies",
                column: "AllergyId",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAllergies_Guests_GuestId",
                table: "GuestAllergies",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestEvents_Events_EventId",
                table: "GuestEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestEvents_Guests_GuestId",
                table: "GuestEvents",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestAllergies_Allergies_AllergyId",
                table: "GuestAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestAllergies_Guests_GuestId",
                table: "GuestAllergies");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestEvents_Events_EventId",
                table: "GuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestEvents_Guests_GuestId",
                table: "GuestEvents");

            migrationBuilder.AddColumn<int>(
                name: "GuestId1",
                table: "GuestEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AllergyId1",
                table: "GuestAllergies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GuestEvents_GuestId1",
                table: "GuestEvents",
                column: "GuestId1");

            migrationBuilder.CreateIndex(
                name: "IX_GuestAllergies_AllergyId1",
                table: "GuestAllergies",
                column: "AllergyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAllergies_Allergies_AllergyId1",
                table: "GuestAllergies",
                column: "AllergyId1",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestAllergies_Guests_AllergyId",
                table: "GuestAllergies",
                column: "AllergyId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestEvents_Events_GuestId",
                table: "GuestEvents",
                column: "GuestId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestEvents_Guests_GuestId1",
                table: "GuestEvents",
                column: "GuestId1",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
