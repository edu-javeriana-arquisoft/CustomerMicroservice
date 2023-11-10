using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class migrationRR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreferences_Customers_Id",
                table: "CustomerPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerPreferences",
                table: "CustomerPreferences");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPreferences");

            migrationBuilder.RenameTable(
                name: "CustomerPreferences",
                newName: "Preferences");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Preferences",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerPreference",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreference", x => new { x.CustomerId, x.PreferenceId });
                    table.ForeignKey(
                        name: "FK_CustomerPreference_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreference_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preferences",
                table: "Preferences");

            migrationBuilder.RenameTable(
                name: "Preferences",
                newName: "CustomerPreferences");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CustomerPreferences",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerPreferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerPreferences",
                table: "CustomerPreferences",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreferences_Customers_Id",
                table: "CustomerPreferences",
                column: "Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
