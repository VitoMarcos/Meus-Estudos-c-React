using Microsoft.EntityFrameworkCore;
using Carros.Models;

namespace Banco.Models;
public class AppDataContext : DbContext
{
    public DbSet<Carro> carritos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=carro.db");
    }
}