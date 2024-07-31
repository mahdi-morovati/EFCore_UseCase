using EfCore.Application.Contracts.Product;
using EfCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Infrastructure.EfCore.Repository;

public class ProductRepository:IProductRepository
{
    private readonly EfContext _context;

    public ProductRepository(EfContext context)
    {
        _context = context;
    }

    public Product Get(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public EditProduct GetDetails(int id)
    {
        return _context.Products.Select(x => new EditProduct
        {
            Id = x.Id,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            CategoryId = x.CategoryId,
        }).FirstOrDefault(x => x.Id == id);
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public bool Exists(string name, int categoryId)
    {
        return _context.Products.Any(x => x.Name == name && x.CategoryId == categoryId);
    }

    public List<ProductViewModel> Search(ProductSearchModel searchModel)
    {
        var query = _context.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel
        {
            Id = x.Id,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            IsRemoved = x.IsRemoved,
            // CreationDate = x.CreationDate,
            Category = x.ProductCategory.Name
        });

        if (searchModel.IsRemoved == true)
            query = query.Where(x => x.IsRemoved == true);

        if (!string.IsNullOrWhiteSpace(searchModel.Name))
            query = query.Where(x => x.Name.Contains(searchModel.Name));

        return query.OrderByDescending(x => x.Id).AsNoTracking().ToList();
    }
}