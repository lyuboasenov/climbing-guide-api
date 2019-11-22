using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing.Guide.Api.Infrastructure.Migrations
{
    public partial class LocationMandatory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint");

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
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint");

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
