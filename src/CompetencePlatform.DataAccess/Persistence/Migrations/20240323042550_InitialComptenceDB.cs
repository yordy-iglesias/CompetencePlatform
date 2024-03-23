using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N_Tier.DataAccess.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialComptenceDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.CreateTable(
                name: "Behaviours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreeCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeCompetences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motiviations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motiviations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreferenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialTechnicalProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetenceType = table.Column<int>(type: "int", nullable: false),
                    CompetenceTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competences_CompetenceTypes_CompetenceTypeId",
                        column: x => x.CompetenceTypeId,
                        principalTable: "CompetenceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BehavioursDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDegreeCompetence = table.Column<int>(type: "int", nullable: false),
                    DegreeCompetenceId = table.Column<int>(type: "int", nullable: true),
                    IdBehaviour = table.Column<int>(type: "int", nullable: false),
                    BehaviourId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehavioursDictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_Behaviours_BehaviourId",
                        column: x => x.BehaviourId,
                        principalTable: "Behaviours",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_DegreeCompetences_DegreeCompetenceId",
                        column: x => x.DegreeCompetenceId,
                        principalTable: "DegreeCompetences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departaments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolutionDomains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionDomains_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPreferenceType = table.Column<int>(type: "int", nullable: false),
                    PreferenceTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferences_PreferenceTypes_PreferenceTypeId",
                        column: x => x.PreferenceTypeId,
                        principalTable: "PreferenceTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSkillType = table.Column<int>(type: "int", nullable: false),
                    SkillTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillTypes_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "SkillTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TodoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItem_TodoList_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenceDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetence = table.Column<int>(type: "int", nullable: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    IdBehavoiurDictionary = table.Column<int>(type: "int", nullable: false),
                    BehaviourDictionaryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceDictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviourDictionaryId",
                        column: x => x.BehaviourDictionaryId,
                        principalTable: "BehavioursDictionaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDepartament = table.Column<int>(type: "int", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    IdEmployeeProfile = table.Column<int>(type: "int", nullable: false),
                    EmployeeProfileId = table.Column<int>(type: "int", nullable: true),
                    IdTeam = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeProfiles_EmployeeProfileId",
                        column: x => x.EmployeeProfileId,
                        principalTable: "EmployeeProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSolutionDomain = table.Column<int>(type: "int", nullable: false),
                    SolutionDomainId = table.Column<int>(type: "int", nullable: true),
                    IdTechnicalSheet = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_SolutionDomains_SolutionDomainId",
                        column: x => x.SolutionDomainId,
                        principalTable: "SolutionDomains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_TechnicalSheets_IdTechnicalSheet",
                        column: x => x.IdTechnicalSheet,
                        principalTable: "TechnicalSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolutionDomainCompetence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSolutionDomain = table.Column<int>(type: "int", nullable: false),
                    SolutionDomainId = table.Column<int>(type: "int", nullable: true),
                    IdCompetence = table.Column<int>(type: "int", nullable: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionDomainCompetence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionDomainCompetence_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionDomainCompetence_SolutionDomains_SolutionDomainId",
                        column: x => x.SolutionDomainId,
                        principalTable: "SolutionDomains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competence_Skill_Motivation_Knowledge_Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetence = table.Column<int>(type: "int", nullable: true),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    IdKnowlwdge = table.Column<int>(type: "int", nullable: true),
                    KnowledgeId = table.Column<int>(type: "int", nullable: true),
                    IdPreference = table.Column<int>(type: "int", nullable: true),
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
                    IdSkill = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    IdMotivation = table.Column<int>(type: "int", nullable: true),
                    MotivationId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competence_Skill_Motivation_Knowledge_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_Knowledges_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalTable: "Knowledges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_Motiviations_MotivationId",
                        column: x => x.MotivationId,
                        principalTable: "Motiviations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetenceProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompetenceDictionary = table.Column<int>(type: "int", nullable: false),
                    CompetenceDictionaryId = table.Column<int>(type: "int", nullable: true),
                    IdEmployeeProfile = table.Column<int>(type: "int", nullable: false),
                    EmployeeProfileId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceProfiles_CompetenceDictionaries_CompetenceDictionaryId",
                        column: x => x.CompetenceDictionaryId,
                        principalTable: "CompetenceDictionaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceProfiles_EmployeeProfiles_EmployeeProfileId",
                        column: x => x.EmployeeProfileId,
                        principalTable: "EmployeeProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    IdCompetence = table.Column<int>(type: "int", nullable: false),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetences_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeCompetences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeams_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_BehaviourId",
                table: "BehavioursDictionaries",
                column: "BehaviourId");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_DegreeCompetenceId",
                table: "BehavioursDictionaries",
                column: "DegreeCompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_CompetenceId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_KnowledgeId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_MotivationId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "MotivationId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_PreferenceId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_SkillId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_BehaviourDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviourDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_CompetenceId",
                table: "CompetenceDictionaries",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_CompetenceDictionaryId",
                table: "CompetenceProfiles",
                column: "CompetenceDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_EmployeeProfileId",
                table: "CompetenceProfiles",
                column: "EmployeeProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_CompetenceTypeId",
                table: "Competences",
                column: "CompetenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_OrganizationId",
                table: "Departaments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_CompetenceId",
                table: "EmployeeCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_EmployeeId",
                table: "EmployeeCompetences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartamentId",
                table: "Employees",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeProfileId",
                table: "Employees",
                column: "EmployeeProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamId",
                table: "Employees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_PreferenceTypeId",
                table: "Preferences",
                column: "PreferenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_IdTechnicalSheet",
                table: "Projects",
                column: "IdTechnicalSheet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SolutionDomainId",
                table: "Projects",
                column: "SolutionDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_ProjectId",
                table: "ProjectTeams",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_TeamId",
                table: "ProjectTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillTypeId",
                table: "Skills",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_CompetenceId",
                table: "SolutionDomainCompetence",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_SolutionDomainId",
                table: "SolutionDomainCompetence",
                column: "SolutionDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomains_OrganizationId",
                table: "SolutionDomains",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_ListId",
                table: "TodoItem",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competence_Skill_Motivation_Knowledge_Preferences");

            migrationBuilder.DropTable(
                name: "CompetenceProfiles");

            migrationBuilder.DropTable(
                name: "EmployeeCompetences");

            migrationBuilder.DropTable(
                name: "ProjectTeams");

            migrationBuilder.DropTable(
                name: "SolutionDomainCompetence");

            migrationBuilder.DropTable(
                name: "TodoItem");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Motiviations");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "CompetenceDictionaries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropTable(
                name: "PreferenceTypes");

            migrationBuilder.DropTable(
                name: "SkillTypes");

            migrationBuilder.DropTable(
                name: "BehavioursDictionaries");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "EmployeeProfiles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "SolutionDomains");

            migrationBuilder.DropTable(
                name: "TechnicalSheets");

            migrationBuilder.DropTable(
                name: "Behaviours");

            migrationBuilder.DropTable(
                name: "DegreeCompetences");

            migrationBuilder.DropTable(
                name: "CompetenceTypes");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");
        }
    }
}
