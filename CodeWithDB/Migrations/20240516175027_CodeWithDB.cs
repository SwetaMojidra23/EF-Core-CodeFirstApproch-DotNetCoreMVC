using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWithDB.Migrations
{
    /// <inheritdoc />
    public partial class CodeWithDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(name: "Student Name", type: "varchar(40)", nullable: false),
                    StudentGender = table.Column<string>(name: "Student Gender", type: "varchar(20)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Standard = table.Column<int>(type: "int", nullable: false),
                    StudentHobbies = table.Column<string>(name: "Student Hobbies", type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
