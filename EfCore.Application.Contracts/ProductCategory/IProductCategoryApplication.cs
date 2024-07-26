namespace EfCore.Application.Contracts.ProductCategory;

public interface IProductCategoryApplication
{
    void Create (CreateProductCategory command);
    void Edit (CreateProductCategory command);
    List<ProductCategoryViewModel> Search(string name);
    
}