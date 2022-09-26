using Microsoft.EntityFrameworkCore.Migrations;

namespace HighEduMinAPI.Migrations
{
    public partial class HighEduMinMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HighEduMinDBS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAStudent = table.Column<bool>(type: "bit", nullable: false),
                    StudyOutSide = table.Column<bool>(type: "bit", nullable: false),
                    GovSendToStudy = table.Column<bool>(type: "bit", nullable: false),
                    ChangeCert = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighEduMinDBS", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighEduMinDBS");
        }
    }
}
