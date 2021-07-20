using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditStocksModel : PageModel
    {
        //TODO: Voorraad weergave van elke maat in elke winkel (VAN ALLEEN DIT PRODUCT) + mogelijkheid voorraad te wijzigen
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public EditStocksModel(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            this._productRepository = productRepository;
            this._storeRepository = storeRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<Store> StoresWithProduct { get; set; }

        public List<Product> ProductVariations { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            StoresWithProduct = _storeRepository.GetAllStores(Product);
            ProductVariations = _productRepository.GetAllProductsVariations(Product);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        //TODO: MaakUpdate Stock + In repository
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_storeRepository.UpdateStoreProductsStock(StoresWithProduct) == true)
            {
                return RedirectToPage($"./Details/{Product.Id}");
            }

            return Page();
        }
    }
}
