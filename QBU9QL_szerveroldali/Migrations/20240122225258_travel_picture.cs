using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBU9QL_szerveroldali.Migrations
{
    public partial class travel_picture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: "d14b5b1f-21e7-4820-8bc2-13a1bed4b121");

            migrationBuilder.CreateTable(
                name: "Galery",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galery", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galery");

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Destination", "Distance", "OwnerId", "StartingPoint" },
                values: new object[] { "d14b5b1f-21e7-4820-8bc2-13a1bed4b121", "Tiszaderzs", 15, "107887a9-4a29-4dca-adb1-adb179559207", "Abádszalók" });
        }
    }
}
