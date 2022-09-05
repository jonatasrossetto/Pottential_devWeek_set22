// https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<Person> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>(tabela =>
        {
            tabela.HasKey(e => e.Id);
            tabela.HasMany(e => e.Contratos).WithOne().HasForeignKey(c => c.PessoaId);
        });

        builder.Entity<Contrato>(tabela =>
        {
            tabela.HasKey(e => e.Id);
        });
    }

}