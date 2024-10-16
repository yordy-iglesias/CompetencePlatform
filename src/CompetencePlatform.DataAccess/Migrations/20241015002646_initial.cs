using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityEmployeesByTemplate = table.Column<int>(type: "int", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizacionId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ScreenAutoLockMinutes = table.Column<int>(type: "int", nullable: false),
                    CultureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeZoneId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Organizations_OrganizacionId",
                        column: x => x.OrganizacionId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Behaviors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Behaviors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Behaviors_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Behaviors_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DegreeCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeCompetences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DegreeCompetences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    HierarchyLevel = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departaments_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departaments_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Departaments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Knowledges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Knowledges_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Knowledges_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motiviations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motiviations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motiviations_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Motiviations_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PreferenceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferenceTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PreferenceTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillTypes_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SkillTypes_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RoleId1 = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetenceTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    DegreeCompetenceId = table.Column<int>(type: "int", nullable: true),
                    BehaviorId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehavioursDictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_Behaviors_BehaviorId",
                        column: x => x.BehaviorId,
                        principalTable: "Behaviors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BehavioursDictionaries_DegreeCompetences_DegreeCompetenceId",
                        column: x => x.DegreeCompetenceId,
                        principalTable: "DegreeCompetences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolutionDomains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionDomains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionDomains_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionDomains_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionDomains_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreferenceTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Preferences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    SkillTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Skills_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Skills_SkillTypes_SkillTypeId",
                        column: x => x.SkillTypeId,
                        principalTable: "SkillTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetenceDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    BehaviorDictionaryId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceDictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviorDictionaryId",
                        column: x => x.BehaviorDictionaryId,
                        principalTable: "BehavioursDictionaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceDictionaries_Competences_CompetenceId",
                        column: x => x.CompetenceId,
                        principalTable: "Competences",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SolutionDomainId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProfiles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProfiles_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProfiles_SolutionDomains_SolutionDomainId",
                        column: x => x.SolutionDomainId,
                        principalTable: "SolutionDomains",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SolutionDomainCompetence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolutionDomainId = table.Column<int>(type: "int", nullable: true),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionDomainCompetence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolutionDomainCompetence_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolutionDomainCompetence_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "TechnicalSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InitialTechnicalProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolutionDomainId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalSheets_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalSheets_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalSheets_SolutionDomains_SolutionDomainId",
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
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    KnowledgeId = table.Column<int>(type: "int", nullable: true),
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    MotivationId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competence_Skill_Motivation_Knowledge_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competence_Skill_Motivation_Knowledge_Preferences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    CompetenceDictionaryId = table.Column<int>(type: "int", nullable: true),
                    EmployeeProfileId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetenceProfiles_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompetenceProfiles_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLastSurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    EmployeeProfileId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    TechnicalSheetId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_TechnicalSheets_TechnicalSheetId",
                        column: x => x.TechnicalSheetId,
                        principalTable: "TechnicalSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSheetCompose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeProfileId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TechnicalSheetId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSheetCompose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalSheetCompose_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalSheetCompose_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalSheetCompose_EmployeeProfiles_EmployeeProfileId",
                        column: x => x.EmployeeProfileId,
                        principalTable: "EmployeeProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalSheetCompose_TechnicalSheets_TechnicalSheetId",
                        column: x => x.TechnicalSheetId,
                        principalTable: "TechnicalSheets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Responsability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CompetenceProfileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsability_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responsability_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responsability_CompetenceProfiles_CompetenceProfileId",
                        column: x => x.CompetenceProfileId,
                        principalTable: "CompetenceProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCompetences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CompetenceId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCompetences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCompetences_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeCompetences_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTeams_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTeams_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTeams_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId1",
                table: "AspNetUserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizacionId",
                table: "AspNetUsers",
                column: "OrganizacionId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Behaviors_CreatedBy",
                table: "Behaviors",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Behaviors_UpdatedBy",
                table: "Behaviors",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_BehaviorId",
                table: "BehavioursDictionaries",
                column: "BehaviorId");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_CreatedBy",
                table: "BehavioursDictionaries",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_DegreeCompetenceId",
                table: "BehavioursDictionaries",
                column: "DegreeCompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BehavioursDictionaries_UpdatedBy",
                table: "BehavioursDictionaries",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_CompetenceId",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_CreatedBy",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "CreatedBy");

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
                name: "IX_Competence_Skill_Motivation_Knowledge_Preferences_UpdatedBy",
                table: "Competence_Skill_Motivation_Knowledge_Preferences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_BehaviorDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviorDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_CompetenceId",
                table: "CompetenceDictionaries",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_CreatedBy",
                table: "CompetenceDictionaries",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_UpdatedBy",
                table: "CompetenceDictionaries",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_CompetenceDictionaryId",
                table: "CompetenceProfiles",
                column: "CompetenceDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_CreatedBy",
                table: "CompetenceProfiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_EmployeeProfileId",
                table: "CompetenceProfiles",
                column: "EmployeeProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceProfiles_UpdatedBy",
                table: "CompetenceProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_CompetenceTypeId",
                table: "Competences",
                column: "CompetenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_CreatedBy",
                table: "Competences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_UpdatedBy",
                table: "Competences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceTypes_CreatedBy",
                table: "CompetenceTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceTypes_UpdatedBy",
                table: "CompetenceTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeCompetences_CreatedBy",
                table: "DegreeCompetences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeCompetences_UpdatedBy",
                table: "DegreeCompetences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_CreatedBy",
                table: "Departaments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_OrganizationId",
                table: "Departaments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_UpdatedBy",
                table: "Departaments",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_CompetenceId",
                table: "EmployeeCompetences",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_CreatedBy",
                table: "EmployeeCompetences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_EmployeeId",
                table: "EmployeeCompetences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCompetences_UpdatedBy",
                table: "EmployeeCompetences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProfiles_CreatedBy",
                table: "EmployeeProfiles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProfiles_SolutionDomainId",
                table: "EmployeeProfiles",
                column: "SolutionDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProfiles_UpdatedBy",
                table: "EmployeeProfiles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedBy",
                table: "Employees",
                column: "CreatedBy");

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
                name: "IX_Employees_UpdatedBy",
                table: "Employees",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_CreatedBy",
                table: "Knowledges",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Knowledges_UpdatedBy",
                table: "Knowledges",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Motiviations_CreatedBy",
                table: "Motiviations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Motiviations_UpdatedBy",
                table: "Motiviations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_CreatedBy",
                table: "Preferences",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_PreferenceTypeId",
                table: "Preferences",
                column: "PreferenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UpdatedBy",
                table: "Preferences",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceTypes_CreatedBy",
                table: "PreferenceTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceTypes_UpdatedBy",
                table: "PreferenceTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatedBy",
                table: "Projects",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TechnicalSheetId",
                table: "Projects",
                column: "TechnicalSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UpdatedBy",
                table: "Projects",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_CreatedBy",
                table: "ProjectTeams",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_ProjectId",
                table: "ProjectTeams",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_TeamId",
                table: "ProjectTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTeams_UpdatedBy",
                table: "ProjectTeams",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Responsability_CompetenceProfileId",
                table: "Responsability",
                column: "CompetenceProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsability_CreatedBy",
                table: "Responsability",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Responsability_UpdatedBy",
                table: "Responsability",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CreatedBy",
                table: "Skills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillTypeId",
                table: "Skills",
                column: "SkillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UpdatedBy",
                table: "Skills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypes_CreatedBy",
                table: "SkillTypes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTypes_UpdatedBy",
                table: "SkillTypes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_CompetenceId",
                table: "SolutionDomainCompetence",
                column: "CompetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_CreatedBy",
                table: "SolutionDomainCompetence",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_SolutionDomainId",
                table: "SolutionDomainCompetence",
                column: "SolutionDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomainCompetence_UpdatedBy",
                table: "SolutionDomainCompetence",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomains_CreatedBy",
                table: "SolutionDomains",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomains_DepartamentId",
                table: "SolutionDomains",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionDomains_UpdatedBy",
                table: "SolutionDomains",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatedBy",
                table: "Teams",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_UpdatedBy",
                table: "Teams",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheetCompose_CreatedBy",
                table: "TechnicalSheetCompose",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheetCompose_EmployeeProfileId",
                table: "TechnicalSheetCompose",
                column: "EmployeeProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheetCompose_TechnicalSheetId",
                table: "TechnicalSheetCompose",
                column: "TechnicalSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheetCompose_UpdatedBy",
                table: "TechnicalSheetCompose",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheets_CreatedBy",
                table: "TechnicalSheets",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheets_SolutionDomainId",
                table: "TechnicalSheets",
                column: "SolutionDomainId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheets_UpdatedBy",
                table: "TechnicalSheets",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Competence_Skill_Motivation_Knowledge_Preferences");

            migrationBuilder.DropTable(
                name: "EmployeeCompetences");

            migrationBuilder.DropTable(
                name: "ProjectTeams");

            migrationBuilder.DropTable(
                name: "Responsability");

            migrationBuilder.DropTable(
                name: "SolutionDomainCompetence");

            migrationBuilder.DropTable(
                name: "TechnicalSheetCompose");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Knowledges");

            migrationBuilder.DropTable(
                name: "Motiviations");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "CompetenceProfiles");

            migrationBuilder.DropTable(
                name: "PreferenceTypes");

            migrationBuilder.DropTable(
                name: "SkillTypes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TechnicalSheets");

            migrationBuilder.DropTable(
                name: "CompetenceDictionaries");

            migrationBuilder.DropTable(
                name: "EmployeeProfiles");

            migrationBuilder.DropTable(
                name: "BehavioursDictionaries");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "SolutionDomains");

            migrationBuilder.DropTable(
                name: "Behaviors");

            migrationBuilder.DropTable(
                name: "DegreeCompetences");

            migrationBuilder.DropTable(
                name: "CompetenceTypes");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
