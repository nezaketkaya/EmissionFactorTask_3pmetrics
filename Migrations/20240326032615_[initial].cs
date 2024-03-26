using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmissionFactorTask_3pmetrics.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catalogName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmissionFactor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emissionFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emissionIDHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emissionFactorTittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catalogID = table.Column<int>(type: "int", nullable: false),
                    effectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    effectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionFactor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmissionMapping",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sourceID = table.Column<int>(type: "int", nullable: false),
                    pointID = table.Column<int>(type: "int", nullable: false),
                    pointUnitID = table.Column<int>(type: "int", nullable: false),
                    emissionFactorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionMapping", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmissionPoint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pointIDHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pointName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pointDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionPoint", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmissionSource",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sourceIDHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionSource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmissionSourcesUnit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitIDHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pointID = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmissionSourcesUnit", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "EmissionFactor");

            migrationBuilder.DropTable(
                name: "EmissionMapping");

            migrationBuilder.DropTable(
                name: "EmissionPoint");

            migrationBuilder.DropTable(
                name: "EmissionSource");

            migrationBuilder.DropTable(
                name: "EmissionSourcesUnit");
        }
    }
}
