using EfCore.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore_UseCase.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            this._productApplication = productApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
        }
    }
}
