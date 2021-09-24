using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class UserClothesRelationDefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clothes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_UserId",
                table: "Clothes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_AspNetUsers_UserId",
                table: "Clothes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_AspNetUsers_UserId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_UserId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clothes");
        }
    }
}
