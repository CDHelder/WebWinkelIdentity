using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.Areas.Logistics.Pages
{
    public class AddStockModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public AddStockModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public string AllText { get; set; }

        [TempData]
        public string FormResult { get; set; }

        [TempData]
        public string AllTextData { get; set; }

        public IActionResult OnGet()
        {
            AllText = null;
            return Page();
        }

        public IActionResult OnPost()
        {
            //TODO: geef de storeid mee en sla deze op in de ProductStockChange in de latere paginas
            if (AllText == null)
            {
                FormResult = "Please enter a product id";
                return Page();
            }

            AllText = AllText.Replace("\r", "");
            var list = AllText.Split("\n");

            foreach (var productId in list)
            {
                var product = _productRepository.GetStoreProduct(Int32.Parse(productId));
                if (product == null)
                {
                    FormResult = $"Error: Couldnt find product with id:{productId} in the database";
                    return Page();
                }
            }

            AllTextData = AllText;
            return RedirectToPage("/ConfirmAddStock");

        }
    }
}
