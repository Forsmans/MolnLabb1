using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.Data.Migrations
{
    /// <inheritdoc />
    public partial class _3ndmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_AboutDb_AboutId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_AboutDb_AboutId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_AboutDb_AboutId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_AboutId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_AboutId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Education",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_AboutId",
                table: "Education");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutDb",
                table: "AboutDb");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "AboutId",
                table: "Education");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Education",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "AboutDb",
                newName: "About");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "Education");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "AboutDb");

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Job",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AboutId",
                table: "Education",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Education",
                table: "Education",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutDb",
                table: "AboutDb",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AboutId",
                table: "Skills",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_AboutId",
                table: "Job",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_AboutId",
                table: "Education",
                column: "AboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_AboutDb_AboutId",
                table: "Education",
                column: "AboutId",
                principalTable: "AboutDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_AboutDb_AboutId",
                table: "Job",
                column: "AboutId",
                principalTable: "AboutDb",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_AboutDb_AboutId",
                table: "Skills",
                column: "AboutId",
                principalTable: "AboutDb",
                principalColumn: "Id");
        }
    }
}
