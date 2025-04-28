using Microsoft.EntityFrameworkCore.Migrations;

namespace asp.netcore1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentID",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student_Table");

            migrationBuilder.RenameTable(
                name: "StudentCourse",
                newName: "StudentCourse_Table");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course_Table");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_StudentID",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse_Table",
                newName: "IX_StudentCourse_Table_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseID",
                table: "StudentCourse_Table",
                column: "CourseID",
                principalTable: "Course_Table",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentID",
                table: "StudentCourse_Table",
                column: "StudentID",
                principalTable: "Student_Table",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Course_Table_CourseID",
                table: "StudentCourse_Table");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Table_Student_Table_StudentID",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourse_Table",
                table: "StudentCourse_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Table",
                table: "Student_Table");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course_Table",
                table: "Course_Table");

            migrationBuilder.RenameTable(
                name: "StudentCourse_Table",
                newName: "StudentCourse");

            migrationBuilder.RenameTable(
                name: "Student_Table",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Course_Table",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_StudentID",
                table: "StudentCourse",
                newName: "IX_StudentCourse_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourse_Table_CourseID",
                table: "StudentCourse",
                newName: "IX_StudentCourse_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourse",
                table: "StudentCourse",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseID",
                table: "StudentCourse",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentID",
                table: "StudentCourse",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
