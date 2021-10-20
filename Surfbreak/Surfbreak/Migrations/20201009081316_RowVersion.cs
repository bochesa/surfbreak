using Microsoft.EntityFrameworkCore.Migrations;

namespace Surfbreak.Migrations
{
    public partial class RowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Surfspots_SurfspotId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Surfspots_Locations_LocationId",
                table: "Surfspots");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Surfspots",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurfspotId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Surfspots_SurfspotId",
                table: "Comments",
                column: "SurfspotId",
                principalTable: "Surfspots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surfspots_Locations_LocationId",
                table: "Surfspots",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Surfspots_SurfspotId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Surfspots_Locations_LocationId",
                table: "Surfspots");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Surfspots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SurfspotId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Surfspots_SurfspotId",
                table: "Comments",
                column: "SurfspotId",
                principalTable: "Surfspots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surfspots_Locations_LocationId",
                table: "Surfspots",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
