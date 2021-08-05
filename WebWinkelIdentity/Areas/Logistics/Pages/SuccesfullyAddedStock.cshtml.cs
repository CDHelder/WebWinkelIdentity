using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.Areas.Logistics.Pages
{
    public class SuccesfullyAddedStockModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public SuccesfullyAddedStockModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public List<Product> Products { get; set; }

        [TempData]
        public string AllTextData { get; set; }
        public List<int> AllTextDataList { get; set; }

        public IActionResult OnGet()
        {
            //TODO: Vervang Products door List<StoreProduct> die je vindt via productId van AllTextDataList en StoreId
            var AllTextDataArray = AllTextData.Split("\n");
            Array.Sort(AllTextDataArray);

            AllTextDataList = AllTextDataArray.Select(x => int.Parse(x)).ToList();
            Products = _productRepository.GetAllProducts(AllTextDataList);

            return Page();
        }

    }
}
