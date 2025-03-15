using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MogulyServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StatePersistence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Boards");
        }
    }
}
