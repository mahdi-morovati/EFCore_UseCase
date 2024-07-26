using EfCore.Application.Contracts.ProductCategory;
using EfCore.Domain.ProductCategoryAgg;

namespace EfCore.Infrastructure.EfCore.Repository;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly EfContext _efContext;

    public ProductCategoryRepository(EfContext efContext)
    {
        _efContext = efContext;
    }

    public ProductCategory Get(int id)
    {
        return _efContext.ProductsCategories.FirstOrDefault(x => x.Id == id);
    }

    public bool Exists(string name)
    {
        return _efContext.ProductsCategories.Any(x => x.Name == name);
    }

    public void Create(ProductCategory productCategory)
    {
        _efContext.ProductsCategories.Add(productCategory);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _efContext.SaveChanges();
    }

    public List<ProductCategoryViewModel> Search(string name)
    {
        var query = _efContext.ProductsCategories
            .Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate
            });

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        return query.OrderByDescending(x => x.Id).ToList();
    }
}