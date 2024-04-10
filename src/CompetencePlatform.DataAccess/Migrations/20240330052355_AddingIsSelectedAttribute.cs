using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsSelectedAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "TechnicalSheets",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "TechnicalSheetCompose",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Teams",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "SolutionDomains",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "SolutionDomainCompetence",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "SkillTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Skills",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Responsability",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "ProjectTeams",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Projects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "PreferenceTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Preferences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Organizations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Motiviations",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Knowledges",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Employees",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EmployeeProfiles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EmployeeCompetences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Departaments",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "DegreeCompetences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "CompetenceTypes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Competences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "CompetenceProfiles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "CompetenceDictionaries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "BehavioursDictionaries",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Behaviors",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "TechnicalSheets");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "TechnicalSheetCompose");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "SolutionDomains");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "SolutionDomainCompetence");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "SkillTypes");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Responsability");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "ProjectTeams");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "PreferenceTypes");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Preferences");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Motiviations");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Knowledges");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EmployeeProfiles");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EmployeeCompetences");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Departaments");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "DegreeCompetences");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "CompetenceTypes");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "CompetenceProfiles");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "CompetenceDictionaries");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Competence_Skill_Motivation_Knowledge_Preferences");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "BehavioursDictionaries");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Behaviors");
        }
    }
}
