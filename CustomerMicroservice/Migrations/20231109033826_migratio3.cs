using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class migratio3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PreferenceName",
                table: "CustomerPreferences");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email",
                table: "Customer",
                newName: "IX_Customer_Email");

            migrationBuilder.AddColumn<int>(
                name: "PreferenceId",
                table: "CustomerPreferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PreferenceName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_CustomerId",
                table: "CustomerPreferences",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_PreferenceId",
                table: "CustomerPreferences",
                column: "PreferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Customer_CustomerId",
                table: "CustomerPreferences",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Preference_PreferenceId",
                table: "CustomerPreferences",
                column: "PreferenceId",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Customer_CustomerId",
                table: "CustomerPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Preference_PreferenceId",
                table: "CustomerPreferences");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_CustomerId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_PreferenceId",
                table: "CustomerPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PreferenceId",
                table: "CustomerPreferences");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email",
                table: "Customers",
                newName: "IX_Customers_Email");

            migrationBuilder.AddColumn<string>(
                name: "PreferenceName",
                table: "CustomerPreferences",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerPreference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPreference_CustomerPreferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "CustomerPreferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreference_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreference_CustomerId",
                table: "CustomerPreference",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreference_PreferenceId",
                table: "CustomerPreference",
                column: "PreferenceId");
        }
    }
}
