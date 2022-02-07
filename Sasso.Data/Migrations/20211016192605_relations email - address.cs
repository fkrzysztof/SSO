using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasso.Data.Migrations
{
    public partial class relationsemailaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AddressID",
                table: "Emails",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Addresses_AddressID",
                table: "Emails",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Addresses_AddressID",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_AddressID",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Emails");
        }
    }
}
