using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBU9QL_szerveroldali.Migrations
{
    public partial class bases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: "1275660f-2b81-4480-81d4-2edb870730f1");

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Destination", "Distance", "OwnerId", "StartingPoint" },
                values: new object[] { "d14b5b1f-21e7-4820-8bc2-13a1bed4b121", "Tiszaderzs", 15, "107887a9-4a29-4dca-adb1-adb179559207", "Abádszalók" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: "d14b5b1f-21e7-4820-8bc2-13a1bed4b121");

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Destination", "Distance", "OwnerId", "StartingPoint" },
                values: new object[] { "1275660f-2b81-4480-81d4-2edb870730f1", "Tiszaderzs", 15, "107887a9-4a29-4dca-adb1-adb179559207", "Abádszalók" });
        }
    }
}
