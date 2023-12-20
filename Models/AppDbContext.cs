using AgricolaLoja.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoLojaAgricola.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
        base(options)
    {
    }

    public DbSet<ProdutosModel> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ContatoMap());
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        
        UpdateTimeStamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        
        UpdateTimeStamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimeStamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is ProdutosModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entityEntry in entities)
        {
            var entity = (ProdutosModel)entityEntry.Entity;
            var now = DateTime.UtcNow;

            
            entity.DataDeLancamento = now;
        }
    }

}
