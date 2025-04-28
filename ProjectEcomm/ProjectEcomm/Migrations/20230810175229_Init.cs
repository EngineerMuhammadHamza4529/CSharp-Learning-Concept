using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectEcomm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookWriters",
                columns: table => new
                {
                    BookWriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookWriters", x => x.BookWriterID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    CategoryImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCovers",
                columns: table => new
                {
                    BookCoverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookWriterID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCovers", x => x.BookCoverID);
                    table.ForeignKey(
                        name: "FK_BookCovers_BookWriters_BookWriterID",
                        column: x => x.BookWriterID,
                        principalTable: "BookWriters",
                        principalColumn: "BookWriterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBNNUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookCoverID = table.Column<int>(type: "int", nullable: false),
                    BookWriterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_BookCovers_BookCoverID",
                        column: x => x.BookCoverID,
                        principalTable: "BookCovers",
                        principalColumn: "BookCoverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookWriters_BookWriterID",
                        column: x => x.BookWriterID,
                        principalTable: "BookWriters",
                        principalColumn: "BookWriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImagePath", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 1, null, new DateTime(2023, 8, 10, 22, 52, 28, 126, DateTimeKind.Local).AddTicks(5441), 1, "Samsung" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImagePath", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 2, null, new DateTime(2023, 8, 10, 22, 52, 28, 131, DateTimeKind.Local).AddTicks(1110), 2, "Xiomi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryImagePath", "CreatedDate", "DisplayOrder", "Title" },
                values: new object[] { 3, null, new DateTime(2023, 8, 10, 22, 52, 28, 131, DateTimeKind.Local).AddTicks(1181), 3, "Nokia" });

            migrationBuilder.CreateIndex(
                name: "IX_BookCovers_BookWriterID",
                table: "BookCovers",
                column: "BookWriterID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCoverID",
                table: "Books",
                column: "BookCoverID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookWriterID",
                table: "Books",
                column: "BookWriterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "BookCovers");

            migrationBuilder.DropTable(
                name: "BookWriters");
        }
    }
}
