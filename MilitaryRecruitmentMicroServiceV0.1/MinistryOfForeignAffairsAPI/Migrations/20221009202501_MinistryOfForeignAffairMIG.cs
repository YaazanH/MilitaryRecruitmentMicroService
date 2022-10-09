using Microsoft.EntityFrameworkCore.Migrations;

namespace MinistryOfForeignAffairsAPI.Migrations
{
    public partial class MinistryOfForeignAffairMIG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinistryOfForeignAffairsDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyMemberOutsideTheCountry = table.Column<bool>(type: "bit", nullable: false),
                    ServedInAnotherArmy = table.Column<bool>(type: "bit", nullable: false),
                    Inside = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryOfForeignAffairsDB", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MinistryOfForeignAffairsDB");
        }
    }
}
