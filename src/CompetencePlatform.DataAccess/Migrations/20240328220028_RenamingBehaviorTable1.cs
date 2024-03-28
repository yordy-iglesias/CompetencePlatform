using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetencePlatform.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamingBehaviorTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviorId",
                table: "BehavioursDictionaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behaviours",
                table: "Behaviours");

            migrationBuilder.RenameTable(
                name: "Behaviours",
                newName: "Behaviors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behaviors",
                table: "Behaviors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioursDictionaries_Behaviors_BehaviorId",
                table: "BehavioursDictionaries",
                column: "BehaviorId",
                principalTable: "Behaviors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BehavioursDictionaries_Behaviors_BehaviorId",
                table: "BehavioursDictionaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Behaviors",
                table: "Behaviors");

            migrationBuilder.RenameTable(
                name: "Behaviors",
                newName: "Behaviours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Behaviours",
                table: "Behaviours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BehavioursDictionaries_Behaviours_BehaviorId",
                table: "BehavioursDictionaries",
                column: "BehaviorId",
                principalTable: "Behaviours",
                principalColumn: "Id");
        }
    }
}
