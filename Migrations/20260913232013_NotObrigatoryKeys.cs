using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atividade_API.Migrations
{
    /// <inheritdoc />
    public partial class NotObrigatoryKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nivel",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nivel",
                table: "Pessoa");
        }
    }
}
