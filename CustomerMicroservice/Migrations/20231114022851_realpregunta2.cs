using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class realpregunta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferencesId",
                table: "CustomerPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences");

            migrationBuilder.RenameTable(
                name: "Preferences",
                newName: "Preference");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preference",
                table: "Preference",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Preference_PreferencesId",
                table: "CustomerPreference",
                column: "PreferencesId",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Preference_PreferencesId",
                table: "CustomerPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preference",
                table: "Preference");

            migrationBuilder.RenameTable(
                name: "Preference",
                newName: "Preferences");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferencesId",
                table: "CustomerPreference",
                column: "PreferencesId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
