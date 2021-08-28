using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class PhotoEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoId",
                table: "Clothes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_PhotoId",
                table: "Clothes",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Photos_PhotoId",
                table: "Clothes",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Photos_PhotoId",
                table: "Clothes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_PhotoId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Clothes");
        }
    }
}
