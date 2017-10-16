using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SeeMoreInventory.Migrations
{
    public partial class RemoveAxis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Axis",
                table: "LensHistory");

            migrationBuilder.DropColumn(
                name: "Axis",
                table: "Lenses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Axis",
                table: "LensHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Axis",
                table: "Lenses",
                nullable: true);
        }
    }
}
