using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class DataSeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaarlemStock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InTransport",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RotterdamStock",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InTransport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "StoreProducts",
                columns: new[] { "Id", "InTransport", "ProductId", "Quantity", "StoreId" },
                values: new object[,]
                {
                    { 31, false, 16, 2, 1 },
                    { 30, false, 15, 2, 2 },
                    { 29, false, 15, 2, 1 },
                    { 28, false, 14, 2, 2 },
                    { 19, false, 10, 2, 1 },
                    { 26, false, 13, 2, 2 },
                    { 25, false, 13, 1, 1 },
                    { 24, false, 12, 2, 2 },
                    { 23, false, 12, 1, 1 },
                    { 22, false, 11, 2, 2 },
                    { 21, false, 11, 2, 1 },
                    { 20, false, 10, 2, 2 },
                    { 32, false, 16, 1, 2 },
                    { 27, false, 14, 2, 1 },
                    { 18, false, 9, 1, 2 },
                    { 16, false, 8, 1, 2 },
                    { 2, false, 1, 1, 2 },
                    { 3, false, 2, 2, 1 },
                    { 4, false, 2, 2, 2 },
                    { 5, false, 3, 2, 1 },
                    { 6, false, 3, 2, 2 },
                    { 7, false, 4, 1, 1 },
                    { 17, false, 9, 2, 1 },
                    { 8, false, 4, 2, 2 },
                    { 10, false, 5, 2, 2 },
                    { 11, false, 6, 2, 1 },
                    { 12, false, 6, 2, 2 },
                    { 13, false, 7, 2, 1 },
                    { 14, false, 7, 2, 2 },
                    { 15, false, 8, 2, 1 },
                    { 9, false, 5, 1, 1 },
                    { 1, false, 1, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_ProductId",
                table: "StoreProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_StoreId",
                table: "StoreProducts",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.AddColumn<int>(
                name: "HaarlemStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InTransport",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RotterdamStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "891d98dc-d24c-4ff1-a5ee-3a736fb791a0", "AQAAAAEAACcQAAAAEEmoQtOs3T2buYPc9ph+5Flu/W07W6XGjfvJVY8JOnV6g1bah8rPzKuiqE7LXoz1HA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "043bb5bb-6c58-4ce9-8795-381d470bb9dc", "AQAAAAEAACcQAAAAEGnq63uRanDtV5K2lNZSAqHMNjmpPb8UXf8uXicVQzjZnGCSzuHglT4pXp9sUrR6Og==", "4916857e-a601-43b8-96c3-c44124c1cdc9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "HaarlemStock", "RotterdamStock" },
                values: new object[] { 2, 1 });
        }
    }
}
