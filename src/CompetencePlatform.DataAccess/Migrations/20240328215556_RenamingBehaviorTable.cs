using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamingBehaviorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviourId",
                table: "BehavioursDictionaries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviourDictionaryId",
                table: "CompetenceDictionaries");

            migrationBuilder.DropIndex(
                name: "IX_CompetenceDictionaries_BehaviourDictionaryId",
                table: "CompetenceDictionaries");

            migrationBuilder.DropColumn(
                name: "BehaviourDictionaryId",
                table: "CompetenceDictionaries");

            migrationBuilder.RenameColumn(
                name: "BehavoiurDictionaryId",
                table: "CompetenceDictionaries",
                newName: "BehaviorDictionaryId");

            migrationBuilder.RenameColumn(
                name: "BehaviourId",
                table: "BehavioursDictionaries",
                newName: "BehaviorId");

            migrationBuilder.RenameIndex(
                name: "IX_BehavioursDictionaries_BehaviourId",
                table: "BehavioursDictionaries",
                newName: "IX_BehavioursDictionaries_BehaviorId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_BehaviorDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviorDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviorId",
                table: "BehavioursDictionaries",
                column: "BehaviorId",
                principalTable: "Behaviours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviorDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviorDictionaryId",
                principalTable: "BehavioursDictionaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviorId",
                table: "BehavioursDictionaries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviorDictionaryId",
                table: "CompetenceDictionaries");

            migrationBuilder.DropIndex(
                name: "IX_CompetenceDictionaries_BehaviorDictionaryId",
                table: "CompetenceDictionaries");

            migrationBuilder.RenameColumn(
                name: "BehaviorDictionaryId",
                table: "CompetenceDictionaries",
                newName: "BehavoiurDictionaryId");

            migrationBuilder.RenameColumn(
                name: "BehaviorId",
                table: "BehavioursDictionaries",
                newName: "BehaviourId");

            migrationBuilder.RenameIndex(
                name: "IX_BehavioursDictionaries_BehaviorId",
                table: "BehavioursDictionaries",
                newName: "IX_BehavioursDictionaries_BehaviourId");

            migrationBuilder.AddColumn<int>(
                name: "BehaviourDictionaryId",
                table: "CompetenceDictionaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceDictionaries_BehaviourDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviourDictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviourId",
                table: "BehavioursDictionaries",
                column: "BehaviourId",
                principalTable: "Behaviours",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceDictionaries_BehavioursDictionaries_BehaviourDictionaryId",
                table: "CompetenceDictionaries",
                column: "BehaviourDictionaryId",
                principalTable: "BehavioursDictionaries",
                principalColumn: "Id");
        }
    }
}
