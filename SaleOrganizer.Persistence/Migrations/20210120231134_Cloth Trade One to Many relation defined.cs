using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class ClothTradeOnetoManyrelationdefined : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Purchases_Clothes_ClothId",
            //    table: "Purchases");
            migrationBuilder.Sql("ALTER TABLE Purchases DROP FOREIGN KEY FK_Purchases_Clothes_ClothId");

            migrationBuilder.DropTable(
                name: "Offerings");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_Purchases",
            //    table: "Purchases");
            migrationBuilder.Sql("ALTER TABLE Purchases DROP CONSTRAINT PK_Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Trade");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_ClothId",
                table: "Trade",
                newName: "IX_Trade_ClothId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Trade",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "OfferingDate",
                table: "Trade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderedDate",
                table: "Trade",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendDate",
                table: "Trade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Trade",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trade",
                table: "Trade",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_Clothes_ClothId",
                table: "Trade",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trade_Clothes_ClothId",
                table: "Trade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trade",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "OfferingDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "OrderedDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "SendDate",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Trade");

            migrationBuilder.RenameTable(
                name: "Trade",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Trade_ClothId",
                table: "Purchases",
                newName: "IX_Purchases_ClothId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                table: "Purchases",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClothId = table.Column<int>(type: "INTEGER", nullable: false),
                    DeliveryType = table.Column<int>(type: "INTEGER", nullable: false),
                    OfferingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReferenceLink = table.Column<string>(type: "TEXT", nullable: true),
                    SendDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TradeType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offerings_Clothes_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_ClothId",
                table: "Offerings",
                column: "ClothId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Clothes_ClothId",
                table: "Purchases",
                column: "ClothId",
                principalTable: "Clothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
