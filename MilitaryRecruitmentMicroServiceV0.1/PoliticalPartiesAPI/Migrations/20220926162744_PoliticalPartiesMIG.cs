using Microsoft.EntityFrameworkCore.Migrations;

namespace PoliticalPartiesAPI.Migrations
{
    public partial class PoliticalPartiesMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliticalPartiesDBS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GetIsAWorker = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalPartiesDBS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliticalPartiesDBS");
        }
    }
}
