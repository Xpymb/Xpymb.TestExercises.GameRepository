using Microsoft.EntityFrameworkCore.Migrations;

namespace Xpymb.TestExercises.GameRepository.Data.Migrations
{
    public partial class RenameGameTagTypesToGameTagsInGameInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameTagTypes",
                table: "GamesInfo",
                newName: "GameTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameTags",
                table: "GamesInfo",
                newName: "GameTagTypes");
        }
    }
}
