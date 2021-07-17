using Microsoft.EntityFrameworkCore.Migrations;

namespace WebWinkelIdentity.Data.Migrations
{
    public partial class AddStoreAndProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_WeekOpeningTimes_WeekOpeningTimesId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_WeekOpeningTimesId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "WeekOpeningTimesId",
                table: "Stores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CustomerId", "HouseNumber", "PostalCode", "Streetname", "SupplierId" },
                values: new object[] { 5, "Haarlem", "Netherlands", null, 18, "2756 IK", "Zijlstraat", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cc05a810-c44d-46ca-858b-7fe4e01cb227", "71c93a2b-77e9-44b2-8f41-c00fd788ba7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e7e9947c-8b6a-42ff-8e0f-b2be946f484d", "59619e87-158c-4d39-8a9d-bd1fd77c0fc1" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AddressId", "WeekOpeningTimesId" },
                values: new object[] { 2, 5, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AmountInStock", "BrandId", "CategoryId", "Color", "Description", "Fabric", "Name", "Price", "Size", "StoreId" },
                values: new object[,]
                {
                    { 17, 1, 1, 2, "White", "Witte kleur met gucci logo", "100% Cotton", "Gucci T-shirt", 39.95m, "S", 2 },
                    { 31, 2, 2, 1, "Dark-Blue", "Donkere broek met versace logo", "100% Cotton", "Versace Broek", 69.95m, "L", 2 },
                    { 30, 2, 2, 1, "Dark-Blue", "Donkere broek met versace logo", "100% Cotton", "Versace Broek", 69.95m, "M", 2 },
                    { 29, 1, 2, 1, "Dark-Blue", "Donkere broek met versace logo", "100% Cotton", "Versace Broek", 69.95m, "S", 2 },
                    { 28, 2, 2, 2, "Light-Yellow", "Licht shirt met versace logo", "100% Cotton", "Versace T-shirt", 45.95m, "XL", 2 },
                    { 27, 2, 2, 2, "Light-Yellow", "Licht shirt met versace logo", "100% Cotton", "Versace T-shirt", 45.95m, "L", 2 },
                    { 26, 2, 2, 2, "Light-Yellow", "Licht shirt met versace logo", "100% Cotton", "Versace T-shirt", 45.95m, "M", 2 },
                    { 32, 2, 2, 1, "Dark-Blue", "Donkere broek met versace logo", "100% Cotton", "Versace Broek", 69.95m, "XL", 2 },
                    { 25, 1, 2, 2, "Light-Yellow", "Licht shirt met versace logo", "100% Cotton", "Versace T-shirt", 45.95m, "S", 2 },
                    { 23, 2, 1, 1, "Light-Blue", "Lichte broek met gucci logo", "100% Cotton", "Gucci Broek", 59.95m, "L", 2 },
                    { 22, 2, 1, 1, "Light-Blue", "Lichte broek met gucci logo", "100% Cotton", "Gucci Broek", 59.95m, "M", 2 },
                    { 21, 1, 1, 1, "Light-Blue", "Lichte broek met gucci logo", "100% Cotton", "Gucci Broek", 59.95m, "S", 2 },
                    { 20, 2, 1, 2, "White", "Witte kleur met gucci logo", "100% Cotton", "Gucci T-shirt", 39.95m, "XL", 2 },
                    { 19, 2, 1, 2, "White", "Witte kleur met gucci logo", "100% Cotton", "Gucci T-shirt", 39.95m, "L", 2 },
                    { 18, 2, 1, 2, "White", "Witte kleur met gucci logo", "100% Cotton", "Gucci T-shirt", 39.95m, "M", 2 },
                    { 24, 2, 1, 1, "Light-Blue", "Lichte broek met gucci logo", "100% Cotton", "Gucci Broek", 59.95m, "XL", 2 }
                });

            migrationBuilder.InsertData(
                table: "StoreEmployees",
                columns: new[] { "Id", "EmployeeId", "StoreId" },
                values: new object[] { 2, "7036d951-7cc8-488f-b95b-10c2e96c31c9", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_WeekOpeningTimesId",
                table: "Stores",
                column: "WeekOpeningTimesId",
                unique: true,
                filter: "[WeekOpeningTimesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_WeekOpeningTimes_WeekOpeningTimesId",
                table: "Stores",
                column: "WeekOpeningTimesId",
                principalTable: "WeekOpeningTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_WeekOpeningTimes_WeekOpeningTimesId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_WeekOpeningTimesId",
                table: "Stores");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "StoreEmployees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "WeekOpeningTimesId",
                table: "Stores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52a5d716-a649-4476-b316-108d96c56112",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07fb72b6-4852-40aa-8c7e-f1973a897f09", "24fcaee8-3b22-4fb9-a89a-796b2cd2f8d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7036d951-7cc8-488f-b95b-10c2e96c31c9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f6a7e85-165a-4be4-ba1c-cec67c13687a", "5fe13a67-b78b-4c7f-a7d6-87a0d499dde1" });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_WeekOpeningTimesId",
                table: "Stores",
                column: "WeekOpeningTimesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_WeekOpeningTimes_WeekOpeningTimesId",
                table: "Stores",
                column: "WeekOpeningTimesId",
                principalTable: "WeekOpeningTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
