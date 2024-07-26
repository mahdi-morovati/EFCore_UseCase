using EfCore.Domain.ProductAgg;
using EfCore.Domain.ProductCategoryAgg;
using EfCore.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Infrastructure.EfCore;

public class EfContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }

    public EfContext(DbContextOptions<EfContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ProductMapping());
        // modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
        /*
         * Equals to above code
         */
        var assembly = typeof(ProductMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}