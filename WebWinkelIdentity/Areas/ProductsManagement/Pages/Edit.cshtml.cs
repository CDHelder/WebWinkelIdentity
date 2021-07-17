using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    public class EditModel : PageModel
    {
        //TODO: Voorraad weergave van elke maat in elke winkel + mogelijkheid voorraad te wijzigen
        private readonly IProductRepository _productRepository;

        public EditModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);

            if (Product == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = new SelectList(_productRepository.GetAllBrands(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_productRepository.GetAllCategories(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
