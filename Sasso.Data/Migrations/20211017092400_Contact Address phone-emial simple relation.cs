using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasso.Data.Migrations
{
    public partial class ContactAddressphoneemialsimplerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Contacts_ContactID",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ContactID",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ContactID",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Emails");

            migrationBuilder.AddColumn<bool>(
                name: "HeadOffice",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadOffice",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ContactID",
                table: "Phones",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactID",
                table: "Emails",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Contacts_ContactID",
                table: "Phones",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
