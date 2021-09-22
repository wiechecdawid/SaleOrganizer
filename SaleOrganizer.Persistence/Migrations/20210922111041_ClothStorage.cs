using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class ClothStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailedStorageInfo",
                table: "Clothes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageInfo",
                table: "Clothes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedStorageInfo",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "StorageInfo",
                table: "Clothes");
        }
    }
}
