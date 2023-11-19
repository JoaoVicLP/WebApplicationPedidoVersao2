using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationPedido.Migrations
{
    /// <inheritdoc />
    public partial class alteradarelacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condimento_Produto_ProdutoId",
                table: "Condimento");

            migrationBuilder.DropIndex(
                name: "IX_Condimento_ProdutoId",
                table: "Condimento");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Condimento");

            migrationBuilder.AddColumn<int>(
                name: "ListaId",
                table: "Produto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CondimentoProduto",
                columns: table => new
                {
                    CondimentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondimentoProduto", x => new { x.CondimentoId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_CondimentoProduto_Condimento_CondimentoId",
                        column: x => x.CondimentoId,
                        principalTable: "Condimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondimentoProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    SomaTotal = table.Column<float>(type: "REAL", nullable: true),
                    MesaId = table.Column<int>(type: "INTEGER", nullable: true),
                    DescontoId = table.Column<int>(type: "INTEGER", nullable: true),
                    TaxaId = table.Column<int>(type: "INTEGER", nullable: true),
                    PagamentoId = table.Column<int>(type: "INTEGER", nullable: true),
                    GarcomId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lista_Desconto_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "Desconto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lista_Garcom_GarcomId",
                        column: x => x.GarcomId,
                        principalTable: "Garcom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lista_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lista_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lista_Taxa_TaxaId",
                        column: x => x.TaxaId,
                        principalTable: "Taxa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ListaId",
                table: "Produto",
                column: "ListaId");

            migrationBuilder.CreateIndex(
                name: "IX_CondimentoProduto_ProdutosId",
                table: "CondimentoProduto",
                column: "ProdutosId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_ClienteId",
                table: "Lista",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_DescontoId",
                table: "Lista",
                column: "DescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_GarcomId",
                table: "Lista",
                column: "GarcomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_MesaId",
                table: "Lista",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_PagamentoId",
                table: "Lista",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_TaxaId",
                table: "Lista",
                column: "TaxaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Lista_ListaId",
                table: "Produto",
                column: "ListaId",
                principalTable: "Lista",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Lista_ListaId",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "CondimentoProduto");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ListaId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ListaId",
                table: "Produto");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Condimento",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Condimento_ProdutoId",
                table: "Condimento",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condimento_Produto_ProdutoId",
                table: "Condimento",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}
