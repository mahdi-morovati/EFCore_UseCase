namespace EfCore.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository
{
    ProductCategory Get(int id);
    void Create(ProductCategory productCategory);
}
