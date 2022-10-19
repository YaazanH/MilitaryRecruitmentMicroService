using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarAssociationAPI.Migrations
{
    public partial class BarAssociationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarAssociationDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    graduationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    joinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trainstartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarAssociationDB", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarAssociationDB");
        }
    }
}
