using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordAdminstrationAPI.Migrations
{
    public partial class RecordAdminstrationMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MinistryOfForeignAffairsDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FathersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Death = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryOfForeignAffairsDB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BrothersDB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personid = table.Column<int>(type: "int", nullable: false),
                    BrotherId = table.Column<int>(type: "int", nullable: false),
                    RecordsAdminstrationid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrothersDB", x => x.id);
                    table.ForeignKey(
                        name: "FK_BrothersDB_MinistryOfForeignAffairsDB_RecordsAdminstrationid",
                        column: x => x.RecordsAdminstrationid,
                        principalTable: "MinistryOfForeignAffairsDB",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrothersDB_RecordsAdminstrationid",
                table: "BrothersDB",
                column: "RecordsAdminstrationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrothersDB");

            migrationBuilder.DropTable(
                name: "MinistryOfForeignAffairsDB");
        }
    }
}
