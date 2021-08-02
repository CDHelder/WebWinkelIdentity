using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class PricePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(38,2)",
                precision: 38,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)",
                oldPrecision: 38,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "961686ee-766f-457f-b971-72d983fb6eb6", "AQAAAAEAACcQAAAAEIksm09b31HZ1jorYlbAwhjJ9QWuRxN5Y6gXj8CEzNC6rlmvw9YADtLXi3VWYsxT+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b62dab-12a6-4805-a84e-3607b00037ba", "AQAAAAEAACcQAAAAEFJOlVPLrwwaV7L0D9/YLfL1JU/4BGBzX0Vy/xb3G4Akklr7vxxRwFeafEePbOZ32g==", "984b062f-8b4c-4886-a99f-5d7e4b51a2da" });
        }
    }
}
