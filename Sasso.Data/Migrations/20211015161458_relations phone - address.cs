using Microsoft.EntityFrameworkCore.Migrations;

namespace Sasso.Data.Migrations
{
    public partial class relationsphoneaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_AddressID",
                table: "Phones",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Addresses_AddressID",
                table: "Phones",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Addresses_AddressID",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_AddressID",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Phones");
        }
    }
}
