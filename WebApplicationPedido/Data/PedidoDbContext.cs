using Pedido.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace Pedido.Data;
public class PedidoDbContext : DbContext
{
    public DbSet<Cliente>? Cliente { get; set; }
    public DbSet<Condimento>? Condimento { get; set; }
    public DbSet<Desconto>? Desconto { get; set; }
    public DbSet<Garcom>? Garcom { get; set; }
    public DbSet<Mesa>? Mesa { get; set; }
    public DbSet<Pagamento>? Pagamento { get; set; }
    public DbSet<Produto>? Produto { get; set; }
    public DbSet<Taxa>? Taxa { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=pedido.db;Cache=Shared");
    }

}