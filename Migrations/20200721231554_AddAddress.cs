using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace msa_p1_data.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    streetNumber = table.Column<string>(maxLength: 1000, nullable: true),
                    street = table.Column<string>(maxLength: 1000, nullable: true),
                    suburb = table.Column<string>(maxLength: 1000, nullable: false),
                    city = table.Column<string>(maxLength: 1000, nullable: false),
                    postcode = table.Column<string>(maxLength: 1000, nullable: false),
                    country = table.Column<string>(maxLength: 1000, nullable: false),
                    timeCreated = table.Column<DateTime>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
