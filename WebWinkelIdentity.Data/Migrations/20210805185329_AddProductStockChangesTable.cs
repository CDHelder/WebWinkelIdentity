using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class AddProductStockChangesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStockChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockChange = table.Column<int>(type: "int", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockChanges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStockChanges_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc5f1aa5-808d-427a-8f4c-161b2bcae475", "AQAAAAEAACcQAAAAELaZ4DNQfgQBjXIuFvxb/+zXIJf+owRN8/DBnlDDncxQix6cNCNVJCDwG+4W5ZiV7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7f8778e-d41f-4f31-9cb9-f8d8dfcb5c09", "AQAAAAEAACcQAAAAEKW4fSFDuGasDoBRm3JdllByvCUAUYNzoKJ+7wShOzGQjuNIeJS5U++dtsK4s02I9g==", "b5eab4fb-0134-4def-b340-5a74b637fa5b" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockChanges_ProductId",
                table: "ProductStockChanges",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockChanges_UserId",
                table: "ProductStockChanges",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStockChanges");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "befea43e-5495-43f6-936e-747fc2d4f9ca", "AQAAAAEAACcQAAAAEMdO/r3yMY8GmXoavZ1zcLIolQggnl6wwq7HsIGmeZYbXE1z+i23zePf5dK2f/hUmA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fed53149-a88d-44db-becf-3968fec9397c", "AQAAAAEAACcQAAAAEH8iwO1Dodqw2jG7K1qdwLu7weTmzCFE33fsB+fWmrQOhHYuHCtDCug0bMUeNLdSqw==", "5235ab6b-d344-4ec9-a3d4-6c10ed465f1f" });
        }
    }
}
