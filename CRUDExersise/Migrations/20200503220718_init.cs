using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExersise.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAlias = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Office = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmailAlias", "FirstName", "LastName", "MiddleName", "Office", "Region" },
                values: new object[,]
                {
                    { 1, "lheinschke", "Stewart", "Heinschke", "Lucilia", "Miami", "South" },
                    { 2, "apietesch", "Shayna", "Pietesch", "Archaimbaud", "DC", "East" },
                    { 3, "pfarrow", "Phelia", "Farrow", "Pavlov", "Lexington", "Central" },
                    { 4, "skembley", "Sharron", "Kembley", "Sherry", "Phoenix", "West" },
                    { 5, "wmunroe", "Willard", "Munroe", "Wally", "Bozeman", "North" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
