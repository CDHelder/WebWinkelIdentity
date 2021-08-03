using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {

        private readonly IProductRepository _productRepository;

        public EditModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public List<Product> ProductVariations { get; set; }

        //TODO: Fix decimal input mag ook decimale waardes geven en niet alleen hele
        //VB = Input: 15,95 Veranderd naar: 1595
        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            ProductVariations = _productRepository.GetAllProductsVariations(Product);

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = new SelectList(_productRepository.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_productRepository.GetAllCategories(), "Id", "Name");
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_productRepository.UpdateProductProperties(Product, ProductVariations) == true)
            {
                return LocalRedirect($"/ProductsManagement/Details?id={Product.Id}");
            }

            return Page();
        }
    }
}
