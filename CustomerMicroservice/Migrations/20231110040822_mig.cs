using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Customers_CustomerId",
                table: "CustomerPreference");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferenceId",
                table: "CustomerPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "PreferenceId",
                table: "CustomerPreference",
                newName: "PreferencesId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerPreference",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPreference_PreferenceId",
                table: "CustomerPreference",
                newName: "IX_CustomerPreference_PreferencesId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_Email",
                table: "Customer",
                newName: "IX_Customer_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Customer_CustomersId",
                table: "CustomerPreference",
                column: "CustomersId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferencesId",
                table: "CustomerPreference",
                column: "PreferencesId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Customer_CustomersId",
                table: "CustomerPreference");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferencesId",
                table: "CustomerPreference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "PreferencesId",
                table: "CustomerPreference",
                newName: "PreferenceId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerPreference",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerPreference_PreferencesId",
                table: "CustomerPreference",
                newName: "IX_CustomerPreference_PreferenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_Email",
                table: "Customers",
                newName: "IX_Customers_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Customers_CustomerId",
                table: "CustomerPreference",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPreference_Preferences_PreferenceId",
                table: "CustomerPreference",
                column: "PreferenceId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
