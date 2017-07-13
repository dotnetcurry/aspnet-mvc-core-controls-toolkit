using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MvcctExample.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 64, nullable: false),
                    ContactName = table.Column<string>(maxLength: 128, nullable: false),
                    ContactTitle = table.Column<string>(maxLength: 64, nullable: true),
                    Country = table.Column<string>(maxLength: 64, nullable: false),
                    Fax = table.Column<string>(maxLength: 32, nullable: true),
                    Phone = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDiscontinued = table.Column<bool>(nullable: false),
                    Package = table.Column<string>(maxLength: 32, nullable: false),
                    ProductName = table.Column<string>(maxLength: 64, nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_IsDiscontinued",
                table: "Foods",
                column: "IsDiscontinued");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_ProductName",
                table: "Foods",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_SupplierId",
                table: "Foods",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UnitPrice",
                table: "Foods",
                column: "UnitPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyName",
                table: "Suppliers",
                column: "CompanyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
