using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV.Data.Migrations
{
    /// <inheritdoc />
    public partial class _2ndmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_About_AboutId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_About_AboutId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_About_AboutId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "AboutDb");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_AboutId",
                table: "Skills",
                newName: "IX_Skills_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutDb",
                table: "AboutDb",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutDb",
                table: "AboutDb");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "AboutDb",
                newName: "About");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_AboutId",
                table: "Skill",
                newName: "IX_Skill_AboutId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_About_AboutId",
                table: "Education",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_About_AboutId",
                table: "Job",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_About_AboutId",
                table: "Skill",
                column: "AboutId",
                principalTable: "About",
                principalColumn: "Id");
        }
    }
}
