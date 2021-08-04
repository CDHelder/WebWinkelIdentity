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

        public Dictionary<Product, int> ProductsAndStockAdded { get; set; }

        public List<Product> Products { get; set; }

        [TempData]
        public string AllTextData { get; set; }
        [TempData]
        public string[] AllTextDataArray { get; set; }
        public int[] AddedStockValues { get; set; }

        public IActionResult OnGet()
        {
            AllTextDataArray = AllTextData.Split("\n");
            Array.Sort(AllTextDataArray);

            HashSet<int> productIds = new();
            foreach (var Id in AllTextDataArray)
            {
                var x = Int32.Parse(Id);
                var product = _productRepository.GetProduct(x);
                if (productIds.Add(product.Id) == true)
                {
                    ProductsAndStockAdded.Add(product, 1);
                }
                else if(productIds.Add(product.Id) == false)
                {
                    //ProductsAndStockAdded.FirstOrDefault(pasd => pasd.Key.Id == x).K += 1;
                    //ProductsAndStockAdded[product] = 
                }
            }

            return Page();
        }
    }
}
