using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    public class EditStocksModel : PageModel
    {
        //TODO: Voorraad weergave van elke maat in elke winkel (VAN ALLEEN DIT PRODUCT) + mogelijkheid voorraad te wijzigen
        private readonly IProductRepository _productRepository;

        public EditStocksModel(IProductRepository productRepository)
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

//#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
//            if (_productRepository.AddProduct(Product) != 0)
//#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
//            {
//                return RedirectToPage($"./Details/{Product.Id}");
//            }

            return Page();
        }
    }
}
