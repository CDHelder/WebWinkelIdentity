using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class y : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InTransport",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTransport",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b888187-bb23-4a8f-82f6-a35881c9d587", "AQAAAAEAACcQAAAAEAIrNm32kqQNLlZG7ID42dYUKTiTkjPxNE/ZcyslEtH6RzLj1Fj5Z/YfCfJBB0yVjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "beacb3f8-6110-4de4-b89a-db4ba08f006f", "AQAAAAEAACcQAAAAEOgjWZDfJW0XIYV9IR0z733UBOT290Btq/CiTDuiDMXYIotgyf2q/LmeJa8upghW+g==", "c94d01df-6366-4dd5-acfc-622afe7a7f6d" });
        }
    }
}
