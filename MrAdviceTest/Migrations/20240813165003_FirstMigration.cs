using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MrAdviceTest.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "featuretoggles",
                columns: table => new
                {
                    ToggleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Toggle = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_featuretoggles", x => x.ToggleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "featuretoggles");
        }
    }
}
