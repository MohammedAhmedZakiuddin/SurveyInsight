using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyAnalysis.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    cCode = table.Column<string>(maxLength: 4, nullable: false),
                    cName_E = table.Column<string>(maxLength: 45, nullable: false),
                    cName_A = table.Column<string>(maxLength: 45, nullable: false),
                    cNationality_E = table.Column<string>(maxLength: 20, nullable: false),
                    cNationality_A = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    orgCode = table.Column<int>(nullable: false),
                    orgName_E = table.Column<string>(maxLength: 45, nullable: false),
                    orgName_A = table.Column<string>(maxLength: 45, nullable: false),
                    partner = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpNo = table.Column<string>(nullable: false),
                    EmpName_E = table.Column<string>(maxLength: 50, nullable: false),
                    EmpName_A = table.Column<string>(nullable: true),
                    EmpEmail = table.Column<string>(maxLength: 80, nullable: false),
                    EmpNetID = table.Column<int>(nullable: false),
                    ManagerID = table.Column<int>(nullable: false),
                    OrgId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_EmpNetID",
                        column: x => x.EmpNetID,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Organizations_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmpNetID",
                table: "Employees",
                column: "EmpNetID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OrgId",
                table: "Employees",
                column: "OrgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
