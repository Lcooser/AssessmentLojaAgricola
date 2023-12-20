using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgricolaLoja.Migrations
{
    /// <inheritdoc />
    public partial class MigrationProdutoUsuarioId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Produtos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Produtos");
        }
    }
}
