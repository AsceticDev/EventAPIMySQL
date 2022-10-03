using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    public partial class GuestEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergyGuest_Allergies_AllergiesId",
                table: "AllergyGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergyGuest_Guests_GuestsId",
                table: "AllergyGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGuest_Events_EventsId",
                table: "EventGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGuest_Guests_GuestsId",
                table: "EventGuest");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Guests",
                newName: "GuestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "GuestsId",
                table: "EventGuest",
                newName: "GuestsGuestId");

            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "EventGuest",
                newName: "EventsEventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventGuest_GuestsId",
                table: "EventGuest",
                newName: "IX_EventGuest_GuestsGuestId");

            migrationBuilder.RenameColumn(
                name: "GuestsId",
                table: "AllergyGuest",
                newName: "GuestsGuestId");

            migrationBuilder.RenameColumn(
                name: "AllergiesId",
                table: "AllergyGuest",
                newName: "AllergiesAllergyId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergyGuest_GuestsId",
                table: "AllergyGuest",
                newName: "IX_AllergyGuest_GuestsGuestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Allergies",
                newName: "AllergyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergyGuest_Allergies_AllergiesAllergyId",
                table: "AllergyGuest",
                column: "AllergiesAllergyId",
                principalTable: "Allergies",
                principalColumn: "AllergyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergyGuest_Guests_GuestsGuestId",
                table: "AllergyGuest",
                column: "GuestsGuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGuest_Events_EventsEventId",
                table: "EventGuest",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGuest_Guests_GuestsGuestId",
                table: "EventGuest",
                column: "GuestsGuestId",
                principalTable: "Guests",
                principalColumn: "GuestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllergyGuest_Allergies_AllergiesAllergyId",
                table: "AllergyGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_AllergyGuest_Guests_GuestsGuestId",
                table: "AllergyGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGuest_Events_EventsEventId",
                table: "EventGuest");

            migrationBuilder.DropForeignKey(
                name: "FK_EventGuest_Guests_GuestsGuestId",
                table: "EventGuest");

            migrationBuilder.RenameColumn(
                name: "GuestId",
                table: "Guests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GuestsGuestId",
                table: "EventGuest",
                newName: "GuestsId");

            migrationBuilder.RenameColumn(
                name: "EventsEventId",
                table: "EventGuest",
                newName: "EventsId");

            migrationBuilder.RenameIndex(
                name: "IX_EventGuest_GuestsGuestId",
                table: "EventGuest",
                newName: "IX_EventGuest_GuestsId");

            migrationBuilder.RenameColumn(
                name: "GuestsGuestId",
                table: "AllergyGuest",
                newName: "GuestsId");

            migrationBuilder.RenameColumn(
                name: "AllergiesAllergyId",
                table: "AllergyGuest",
                newName: "AllergiesId");

            migrationBuilder.RenameIndex(
                name: "IX_AllergyGuest_GuestsGuestId",
                table: "AllergyGuest",
                newName: "IX_AllergyGuest_GuestsId");

            migrationBuilder.RenameColumn(
                name: "AllergyId",
                table: "Allergies",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllergyGuest_Allergies_AllergiesId",
                table: "AllergyGuest",
                column: "AllergiesId",
                principalTable: "Allergies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AllergyGuest_Guests_GuestsId",
                table: "AllergyGuest",
                column: "GuestsId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGuest_Events_EventsId",
                table: "EventGuest",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventGuest_Guests_GuestsId",
                table: "EventGuest",
                column: "GuestsId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
