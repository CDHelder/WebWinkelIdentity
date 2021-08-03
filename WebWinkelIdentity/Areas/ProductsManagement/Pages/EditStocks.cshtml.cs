using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditStocksModel : PageModel
    {
 
        private readonly IProductRepository _productRepository;

        public EditStocksModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<Product> ProductVariations { get; set; }

        public bool SuccesfullySaved { get; set; }

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

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SuccesfullySaved = false;

            if(_productRepository.UpdateProducts(ProductVariations) == true)
            {
                return LocalRedirect($"/ProductsManagement/Details?id={Product.Id}");
            }

            return Page();

        }
    }
}
