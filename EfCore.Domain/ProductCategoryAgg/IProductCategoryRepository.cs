using EfCore.Application.Contracts.ProductCategory;

namespace EfCore.Domain.ProductCategoryAgg;

public interface IProductCategoryRepository
{
    void SaveChanges();
    bool Exists(string name);
    void Create(ProductCategory productCategory);
    EditProductCategory? GetDetails(int id);
    ProductCategory Get(int id);
    List<ProductCategoryViewModel> Search(string name);
}
