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
        public List<int> AllTextDataArrayTest { get; set; }
        //public int[] AddedStockValues { get; set; }

        public IActionResult OnGet()
        {
            var AllTextDataArray = AllTextData.Split("\n");
            Array.Sort(AllTextDataArray);

            AllTextDataArrayTest = AllTextDataArray.Select(x => int.Parse(x)).ToList();

            var ListData = AllTextDataArray.Select(x => int.Parse(x)).ToList();
            Products = _productRepository.GetAllProducts(ListData);

            //AddedStockValues = CreateAddedStockValues(ListData.ToArray(), AllTextDataArray.Distinct().Count());

            return Page();
        }

        //public int[] CreateAddedStockValues(int[] productIdsValue, int distinctArrayLength)
        //{
        //    HashSet<int> productIds = new();
        //    int[] stocks = new int[distinctArrayLength];
        //    int iteration = -1;
        //    foreach (var Id in productIdsValue)
        //    {
        //        if (productIds.Add(Id) == true)
        //        {
        //            iteration += 1;
        //            stocks[iteration] = 1;
        //        }
        //        else if (productIds.Add(Id) == false)
        //        {
        //            stocks[iteration] += 1;
        //        }
        //    }
        //    return stocks;
        //}
    }
}
