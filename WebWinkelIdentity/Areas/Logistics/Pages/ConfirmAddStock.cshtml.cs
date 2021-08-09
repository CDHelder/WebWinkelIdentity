using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.Areas.Logistics.Pages
{
    public class ConfirmAddStockModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public ConfirmAddStockModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [BindProperty]
        public List<Product> Products { get; set; }
        [BindProperty]
        public List<int> AllTextDataList { get; set; }

        [TempData]
        public int StoreId { get; set; }
        [TempData]
        public string FormResult { get; set; }
        [TempData]
        public string AllTextData { get; set; }


        public IActionResult OnGet()
        {
            //TODO: Vervang Products door List<StoreProduct> die je vindt via productId van AllTextDataList en StoreId
            var AllTextDataArray = AllTextData.Split("\n");
            Array.Sort(AllTextDataArray);

            AllTextDataList = AllTextDataArray.Select(x => int.Parse(x)).ToList();
            Products = _productRepository.GetAllProducts(AllTextDataList);

            return Page();
        }

        public IActionResult OnPost()
        {
            foreach (var product in Products)
            {
                //product.Quantity += AllTextDataList.Count(adat => adat == foundProduct.Id);
                //if (_productRepository.UpdateStoreProduct(foundProduct) == false)
                //{
                //    FormResult = $"Error: Couldnt save product with id:{foundProduct.Id} in the database";
                //    return Page();
                //}

                //TODO: Connect hier de StoreProduct aan de hand van StoreId en ProductId
                ProductStockChange PSC = new ProductStockChange
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier.ToString()),
                    DateChanged = DateTime.Now,
                    //StoreProductId = product.Id && Store.Id,
                    StockChange = AllTextDataList.Count(adat => adat == product.Id)
                };
                if (_productRepository.CreateProductStockChange(PSC) == false)
                {
                    FormResult = $"Error: Couldnt log the stock changes made to product with id:{product.Id}";
                    return Page();
                }
            }

            AllTextData = string.Join("\n", AllTextDataList);
            return RedirectToPage("/SuccesfullyAddedStock");
        }
    }
}
