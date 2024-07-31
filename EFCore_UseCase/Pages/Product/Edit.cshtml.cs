// using EfCore.Application.Contracts.Product;
// using EfCore.Application.Contracts.ProductCategory;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;

using EfCore.Application.Contracts.Product;
using EfCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore_UseCase.Pages.Product
{
    public class EditModel : PageModel
    {
        public EditProduct Command;
        public SelectList ProductCategories;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication, IProductApplication productApplication)
        {
            this._productCategoryApplication = productCategoryApplication;
            this._productApplication = productApplication;
        }

        public void OnGet(int id)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
            Command = _productApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditProduct command)
        {
            _productApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
