using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnowlwdgeId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KnowlwdgeId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                type: "int",
                nullable: true);
        }
    }
}
