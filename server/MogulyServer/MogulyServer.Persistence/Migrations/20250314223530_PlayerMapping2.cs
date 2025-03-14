using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MogulyServer.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PlayerMapping2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BoardId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Players_BoardId",
                table: "Players",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Boards_BoardId",
                table: "Players",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Boards_BoardId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_BoardId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Players");
        }
    }
}
