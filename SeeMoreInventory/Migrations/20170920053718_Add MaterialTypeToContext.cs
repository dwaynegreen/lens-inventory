using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SeeMoreInventory.Migrations
{
    public partial class AddMaterialTypeToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lenses_MaterialType_MaterialId",
                table: "Lenses");

            migrationBuilder.DropForeignKey(
                name: "FK_LensHistory_MaterialType_MaterialId",
                table: "LensHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType");

            migrationBuilder.RenameTable(
                name: "MaterialType",
                newName: "Materials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materials",
                table: "Materials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lenses_Materials_MaterialId",
                table: "Lenses",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LensHistory_Materials_MaterialId",
                table: "LensHistory",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lenses_Materials_MaterialId",
                table: "Lenses");

            migrationBuilder.DropForeignKey(
                name: "FK_LensHistory_Materials_MaterialId",
                table: "LensHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materials",
                table: "Materials");

            migrationBuilder.RenameTable(
                name: "Materials",
                newName: "MaterialType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialType",
                table: "MaterialType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lenses_MaterialType_MaterialId",
                table: "Lenses",
                column: "MaterialId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LensHistory_MaterialType_MaterialId",
                table: "LensHistory",
                column: "MaterialId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
