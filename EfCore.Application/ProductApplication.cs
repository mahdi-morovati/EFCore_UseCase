using EfCore.Application.Contracts.Product;
using EfCore.Domain.ProductAgg;

namespace EfCore.Application;

public class ProductApplication : IProductApplication
{
    private readonly IProductRepository _productRepository;

    public ProductApplication(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Create(CreateProduct command)
    {
        if (_productRepository.Exists(command.Name, command.CategoryId))
            return;
        var product = new Product(command.Name, command.UnitPrice, command.CategoryId);
        _productRepository.Create(product);
        _productRepository.SaveChanges();
    }

    public void Edit(EditProduct command)
    {
        // here use repository so change tracker can save model data
        var product = _productRepository.Get(command.Id);
        if (product == null)
            return;

        product.Edit(command.Name, command.UnitPrice, command.CategoryId);

        // because we used repository its data exists in change tracker so when we call SaveChanges() it will be saved in database.
        _productRepository.SaveChanges();
    }

    public void Remove(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
            return;
        product.Remove();
        _productRepository.SaveChanges();
    }

    public void Restore(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
            return;
        product.Restore();
        _productRepository.SaveChanges();
    }

    public EditProduct? GetDetails(int id)
    {
        return _productRepository.GetDetails(id);
    }

    public List<ProductViewModel> Search(ProductSearchModel searchModel)
    {
        return _productRepository.Search(searchModel);
    }
}