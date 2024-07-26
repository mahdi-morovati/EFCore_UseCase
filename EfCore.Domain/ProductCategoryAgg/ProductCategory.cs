using EfCore.Domain.ProductAgg;

namespace EfCore.Domain.ProductCategoryAgg;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public DateTime CreationDate { get; set; }
    public List<Product> Products { get; set; }

    public void ProductCategory(string name)
    {
        Name = name;
        CreationDate = DateTime.Now;
        Products = new List<Product>();creat
    }

    public void Edit(string name)
    {
        Name = name;
    }
}