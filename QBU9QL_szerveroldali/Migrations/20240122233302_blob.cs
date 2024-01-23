using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QBU9QL_szerveroldali.Migrations
{
    public partial class blob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoData",
                table: "Galery");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "Galery",
                newName: "PhotoUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Galery",
                newName: "ContentType");

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoData",
                table: "Galery",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
