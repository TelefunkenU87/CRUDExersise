using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDExersise.Migrations
{
    public partial class AlteredAssignmentRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumns: new[] { "EmployeeId", "ClientId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "Assignments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "AssignmentId");

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "ClientId", "EmployeeId", "EndDate", "Role", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Dev", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 1, null, "Senior Dev", new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 2, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Dev", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, 2, null, "Senior Dev", new DateTime(2019, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 3, null, "Manager", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, 3, null, "Manager", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, 3, null, "Manager", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EmployeeId",
                table: "Assignments",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EmployeeId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "Assignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                columns: new[] { "EmployeeId", "ClientId" });
        }
    }
}
