using EfCore.Application.Contracts.ProductCategory;

namespace EfCore.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository
{
    void SaveChanges();
    bool Exists(string name);
    void Create(ProductCategory productCategory);
    ProductCategory Get(int id);
    List<ProductCategoryViewModel> Search(string name);
}
