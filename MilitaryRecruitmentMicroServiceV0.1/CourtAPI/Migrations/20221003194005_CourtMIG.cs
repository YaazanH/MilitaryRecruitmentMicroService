using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtAPI.Migrations
{
    public partial class CourtMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourtDBS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verdict = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerdictDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourtDBS", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourtDBS");
        }
    }
}
