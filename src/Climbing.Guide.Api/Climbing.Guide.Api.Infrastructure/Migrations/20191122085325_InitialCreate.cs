using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing.Guide.Api.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Code2 = table.Column<string>(maxLength: 2, nullable: false),
                    Code3 = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Location_Latitude = table.Column<double>(nullable: false),
                    Location_Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Info = table.Column<string>(type: "ntext", nullable: true),
                    Approach = table.Column<string>(type: "ntext", nullable: true),
                    Descent = table.Column<string>(type: "ntext", nullable: true),
                    History = table.Column<string>(type: "ntext", nullable: true),
                    Ethics = table.Column<string>(type: "ntext", nullable: true),
                    Accomodations = table.Column<string>(type: "ntext", nullable: true),
                    Restrictions = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: false),
                    ApprovedById = table.Column<string>(nullable: true),
                    Location_Latitude = table.Column<double>(nullable: false),
                    Location_Longitude = table.Column<double>(nullable: false),
                    Revision = table.Column<int>(nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(nullable: true),
                    AreasContainerId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Area_AreasContainerId",
                        column: x => x.AreasContainerId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Area_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedById = table.Column<string>(nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: false),
                    ApprovedById = table.Column<string>(nullable: true),
                    Location_Latitude = table.Column<double>(nullable: false),
                    Location_Longitude = table.Column<double>(nullable: false),
                    AreaId = table.Column<string>(nullable: false),
                    Difficulty = table.Column<float>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Info = table.Column<string>(type: "ntext", nullable: true),
                    Approach = table.Column<string>(type: "ntext", nullable: true),
                    History = table.Column<string>(type: "ntext", nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(nullable: true),
                    Revision = table.Column<int>(nullable: false),
                    RoutesContainerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Area_RoutesContainerId",
                        column: x => x.RoutesContainerId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchemaPoint",
                columns: table => new
                {
                    RouteId = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaPoint", x => new { x.RouteId, x.Id });
                    table.ForeignKey(
                        name: "FK_SchemaPoint_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_ApprovedById",
                table: "Area",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Area_AreasContainerId",
                table: "Area",
                column: "AreasContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CountryId",
                table: "Area",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CreatedById",
                table: "Area",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Area_ParentId",
                table: "Area",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_UpdatedById",
                table: "Area",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApprovedById",
                table: "Routes",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_AreaId",
                table: "Routes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CreatedById",
                table: "Routes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RoutesContainerId",
                table: "Routes",
                column: "RoutesContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UpdatedById",
                table: "Routes",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchemaPoint");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
