using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class migration4444564 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Customers_CustomerId",
                table: "CustomerPreferences");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPreferences_CustomerId",
                table: "CustomerPreferences");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPreference");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_CustomerId",
                table: "CustomerPreferences",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Customers_CustomerId",
                table: "CustomerPreferences",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
