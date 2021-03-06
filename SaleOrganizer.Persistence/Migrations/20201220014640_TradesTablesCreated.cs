﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class TradesTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClothId = table.Column<int>(nullable: false),
                    ReferenceLink = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    TradeType = table.Column<int>(nullable: false),
                    DeliveryType = table.Column<int>(nullable: false),
                    OfferingDate = table.Column<DateTime>(nullable: false),
                    OrderedDate = table.Column<DateTime>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClothId = table.Column<int>(nullable: false),
                    ReferenceLink = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    TradeType = table.Column<int>(nullable: false),
                    DeliveryType = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Clothes_ClothId",
                        column: x => x.ClothId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offerings_ClothId",
                table: "Offerings",
                column: "ClothId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClothId",
                table: "Purchases",
                column: "ClothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offerings");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
