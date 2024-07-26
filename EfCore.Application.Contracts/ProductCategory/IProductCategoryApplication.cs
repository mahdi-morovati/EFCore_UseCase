namespace EfCore.Application.Contracts.ProductCategory;

public interface IProductCategoryApplication
{
    void Create (CreateProductCategory command);
    void Edit (EditProductCategory command);
    List<ProductCategoryViewModel> Search(string name);
    
}