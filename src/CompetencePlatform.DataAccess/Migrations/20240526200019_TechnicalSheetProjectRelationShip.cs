using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TechnicalSheetProjectRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalSheets_Projects_ProjectId",
                table: "TechnicalSheets");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalSheets_ProjectId",
                table: "TechnicalSheets");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TechnicalSheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheets_ProjectId",
                table: "TechnicalSheets",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalSheets_Projects_ProjectId",
                table: "TechnicalSheets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalSheets_Projects_ProjectId",
                table: "TechnicalSheets");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalSheets_ProjectId",
                table: "TechnicalSheets");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TechnicalSheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalSheets_ProjectId",
                table: "TechnicalSheets",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalSheets_Projects_ProjectId",
                table: "TechnicalSheets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
