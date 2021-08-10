using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.Areas.Logistics.Pages
{
    public class AddStockModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public AddStockModel(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            this._productRepository = productRepository;
            this._storeRepository = storeRepository;
        }

        [BindProperty]
        public string AllText { get; set; }
        [BindProperty]
        public string SelectedStoreId { get; set; }
        public List<SelectListItem> AllStores { get; set; }

        [TempData]
        public int StoreId { get; set; }
        [TempData]
        public string FormResult { get; set; }
        [TempData]
        public string AllTextData { get; set; }

        public IActionResult OnGet()
        {
            AllText = null;
            AllStores = _storeRepository.GetAllStores().Select(s =>
            new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Address.City
            }).ToList();

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
            if (SelectedStoreId == null)
            {
                FormResult = "Please select a store";
                return Page();
            }

            AllText = AllText.Replace("\r", "");
            var list = AllText.Split("\n");

            var store = _storeRepository.GetStoreInfo(int.Parse(SelectedStoreId));
            if (store == null)
            {
                FormResult = $"Error: Couldn't find store with id: {SelectedStoreId}";
            }

            foreach (var productId in list)
            {
                var product = _productRepository.GetStoreProduct(int.Parse(productId));
                if (product == null)
                {
                    FormResult = $"Error: Couldnt find product with id:{productId} in the database";
                    return Page();
                }
            }

            AllTextData = AllText;
            StoreId = int.Parse(SelectedStoreId);

            return RedirectToPage("/ConfirmAddStock");

        }
    }
}
