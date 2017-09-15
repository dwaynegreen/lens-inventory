using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SeeMoreInventory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialType",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialType", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Lenses",
                columns: table => new
                {
                    ProductLabel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AntiReflectiveCoating = table.Column<bool>(type: "bit", nullable: false),
                    Axis = table.Column<int>(type: "int", nullable: true),
                    Cylinder = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LowInventoryWarning = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    RemainingCount = table.Column<int>(type: "int", nullable: true),
                    Sphere = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Transitions = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenses", x => x.ProductLabel);
                    table.ForeignKey(
                        name: "FK_Lenses_MaterialType_MaterialId1",
                        column: x => x.MaterialId,
                        principalTable: "MaterialType",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LensHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AntiReflectiveCoating = table.Column<bool>(type: "bit", nullable: false),
                    Axis = table.Column<int>(type: "int", nullable: true),
                    Cylinder = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    ProductLabel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RemainingCount = table.Column<int>(type: "int", nullable: true),
                    Sphere = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Transitions = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LensHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LensHistory_MaterialType_MaterialId1",
                        column: x => x.MaterialId,
                        principalTable: "MaterialType",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lenses_MaterialId1",
                table: "Lenses",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_LensHistory_MaterialId1",
                table: "LensHistory",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lenses");

            migrationBuilder.DropTable(
                name: "LensHistory");

            migrationBuilder.DropTable(
                name: "MaterialType");
        }
    }
}
