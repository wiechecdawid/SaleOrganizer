﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleOrganizer.Persistence.Migrations
{
    public partial class ClothStatusUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Clothes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clothes");
        }
    }
}
