using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Surfbreak.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surfspots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsSecret = table.Column<bool>(nullable: false),
                    LocationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surfspots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surfspots_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    SurfspotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Surfspots_SurfspotId",
                        column: x => x.SurfspotId,
                        principalTable: "Surfspots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    WaveHeight = table.Column<double>(nullable: false),
                    WavePeriod = table.Column<int>(nullable: false),
                    WindSpeed = table.Column<int>(nullable: false),
                    SeaTemperatur = table.Column<int>(nullable: false),
                    SurfspotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_Surfspots_SurfspotId",
                        column: x => x.SurfspotId,
                        principalTable: "Surfspots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SurfspotId",
                table: "Comments",
                column: "SurfspotId");

            migrationBuilder.CreateIndex(
                name: "IX_Surfspots_LocationId",
                table: "Surfspots",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_SurfspotId",
                table: "WeatherConditions",
                column: "SurfspotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "Surfspots");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
