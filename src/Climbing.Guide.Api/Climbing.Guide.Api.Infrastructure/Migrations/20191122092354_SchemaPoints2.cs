using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing.Guide.Api.Infrastructure.Migrations
{
    public partial class SchemaPoints2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchemaPoint_Routes_RouteId",
                table: "SchemaPoint");

            migrationBuilder.AddColumn<double>(
                name: "X",
                table: "SchemaPoint",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Y",
                table: "SchemaPoint",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.DropColumn(
                name: "X",
                table: "SchemaPoint");

            migrationBuilder.DropColumn(
                name: "Y",
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
