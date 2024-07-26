using EfCore.Domain.ProductCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Infrastructure.EfCore.Mapping;

public class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategory>
{
    
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");
        builder.HasKey("Id");
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

        builder.HasMany(x => x.Products)
            .WithOne(x => x.ProductCategory)
            .HasForeignKey(x => x.CategoryId);
    }
}