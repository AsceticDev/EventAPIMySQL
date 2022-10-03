using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventAPIMySQL.Migrations
{
    public partial class someMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AllergyType",
                table: "Allergies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventName",
                table: "Events",
                column: "EventName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_AllergyType",
                table: "Allergies",
                column: "AllergyType",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Events_EventName",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Allergies_AllergyType",
                table: "Allergies");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AllergyType",
                table: "Allergies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
