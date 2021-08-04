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
            //if (AllText == null)
            //{
            //    FormResult = "Please enter a product id";
            //    return Page();
            //}

            AllText = AllText.Replace("\r", "");
            //var list = AllText.Split("\n");

            ////TODO: verplaats de Update Functionaliteit naar de SuccesfullyAddedStock pagina
            ////Zo hebben werknemers een extra overzicht van alles voordat ze de producten toevoegen
            //foreach (var productId in list)
            //{
            //    var product = _productRepository.GetStoreProduct(Int32.Parse(productId));
            //    if (product == null)
            //    {
            //        FormResult = $"Error: Couldnt find product with id:{productId} in the database";
            //        return Page();
            //    }
            //
            //    product.Quantity += 1;
            //    if (_productRepository.UpdateStoreProduct(product) == false)
            //    {
            //        FormResult = $"Error: Couldnt save product with id:{productId} in the database";
            //        return Page();
            //    }
            //}

            AllTextData = AllText;
            return RedirectToPage("/SuccesfullyAddedStock");

        }
    }
}
