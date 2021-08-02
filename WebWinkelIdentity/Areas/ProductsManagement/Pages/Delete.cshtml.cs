using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public DeleteModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        public List<Product> ProductVariations { get; set; }
        public bool CurrentStock { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            ProductVariations = _productRepository.GetAllProductsVariations(Product);
            CurrentStock = false;

            foreach (var product in ProductVariations)
            {
                if (product.RotterdamStock > 0 || product.HaarlemStock > 0)
                {
                    CurrentStock = true;
                }
            }

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isDeleted = _productRepository.DeleteProduct(id);

            if (isDeleted == true)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
