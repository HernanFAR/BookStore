using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthorInfraestructure.EntityFrameworkCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Author_Schema");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Author_Schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Subname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                schema: "Author_Schema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: false),
                    University = table.Column<string>(type: "nvarchar(126)", maxLength: 126, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => new { x.AuthorId, x.Id });
                    table.ForeignKey(
                        name: "FK_AcademicDegree_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Author_Schema",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicDegree",
                schema: "Author_Schema");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Author_Schema");
        }
    }
}
