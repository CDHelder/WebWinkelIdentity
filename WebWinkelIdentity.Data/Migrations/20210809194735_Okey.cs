using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class Okey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStockChanges_Products_ProductId",
                table: "ProductStockChanges");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductStockChanges",
                newName: "StoreProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStockChanges_ProductId",
                table: "ProductStockChanges",
                newName: "IX_ProductStockChanges_StoreProductId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3bbce7d1-8f6f-4f21-b3d3-3489502789a0", "AQAAAAEAACcQAAAAEKF3Fd7ktQLWLl1ooPJHjOK4b0wfO3pGgzt36dS9X5Arvx/nQS5g5BHAn0iqck/B/Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d56ed54-f021-4860-a4d8-e767fab793b4", "AQAAAAEAACcQAAAAENbvVDi7OErNrhMzPB9sij64qcWwMY27Pt2csW0CYjrpm3WsvNyuQ9fZK+gP/mHlYg==", "934e252e-ddc0-4da2-8c0e-15aceb9b3923" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStockChanges_StoreProducts_StoreProductId",
                table: "ProductStockChanges",
                column: "StoreProductId",
                principalTable: "StoreProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStockChanges_StoreProducts_StoreProductId",
                table: "ProductStockChanges");

            migrationBuilder.RenameColumn(
                name: "StoreProductId",
                table: "ProductStockChanges",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStockChanges_StoreProductId",
                table: "ProductStockChanges",
                newName: "IX_ProductStockChanges_ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStockChanges_Products_ProductId",
                table: "ProductStockChanges",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
