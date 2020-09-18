using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.EfCore.Migrations
{
    public partial class AlterTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduto",
                table: "PedidosItens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosItens_Produtos_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropIndex(
                name: "IX_PedidosItens_IdProduto",
                table: "PedidosItens");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "PedidosItens");
        }
    }
}
