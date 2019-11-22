using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing.Guide.Api.Infrastructure.Migrations
{
    public partial class LocationMandatory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Country_CountryId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Countries_CountryId",
                table: "Area",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Area_Countries_CountryId",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Area_Country_CountryId",
                table: "Area",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
