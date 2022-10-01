using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscordBotAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detail",
                columns: table => new
                {
                    discorduserid = table.Column<string>(type: "text", nullable: false),
                    onecguid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail", x => x.discorduserid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detail");
        }
    }
}
