using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleDeContatos.Migrations
{
    public partial class AdicionadoColunaExcluidoModelProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Produtos",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Produtos");
        }
    }
}
