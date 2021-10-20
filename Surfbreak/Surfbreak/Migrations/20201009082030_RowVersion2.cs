using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Surfbreak.Migrations
{
    public partial class RowVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Surfspots",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Surfspots");
        }
    }
}
