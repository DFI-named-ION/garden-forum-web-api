using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GardenForumWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Removecommentsstuff2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_likes");

            migrationBuilder.DropTable(
                name: "comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
