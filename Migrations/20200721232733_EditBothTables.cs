using Microsoft.EntityFrameworkCore.Migrations;

namespace msa_p1_data.Migrations
{
    public partial class EditBothTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
