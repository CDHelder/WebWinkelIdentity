using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        //TODO: ~A~ Voeg ProductDetails toe aan Create, Delete, Detail en Edit
        //TODO: Views voor Product of ProductDetails?
        private readonly IProductRepository _productRepository;

        public CreateModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandId"] = new SelectList(_productRepository.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_productRepository.GetAllCategories(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_productRepository.AddProduct(Product) != null)
            {
                return RedirectToPage($"./Details/{Product.Id}");
            }

            return Page();
        }
    }
}
