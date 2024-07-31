using EfCore.Application.Contracts.Product;

namespace EfCore.Domain.ProductAgg;

public interface IProductRepository
{
    Product Get(int id);
    EditProduct GetDetails(int id);
    void Create(Product product);
    void SaveChanges();
    bool Exists(string name, int categoryId);
    List<ProductViewModel> Search(ProductSearchModel searchModel);
}