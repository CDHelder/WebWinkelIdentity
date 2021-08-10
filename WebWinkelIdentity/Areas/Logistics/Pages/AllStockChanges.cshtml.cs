using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Web.Areas.Logistics.Pages
{
    public class AllStockChangesModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public AllStockChangesModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        //TODO: Maak rollback functie om gemaakte veranderingen terug te veranderen
        public IList<ProductStockChange> ProductStockChange { get;set; }

        public void OnGetAsync()
        {
            ProductStockChange = _productRepository.GetAllProductStockChanges();
        }
    }
}
