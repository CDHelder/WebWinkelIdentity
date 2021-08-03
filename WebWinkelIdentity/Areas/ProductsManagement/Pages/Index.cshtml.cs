using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin,Employee")]
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IndexModel(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IList<Product> Product { get;set; }

        public void OnGetAsync()
        {
            Product = _productRepository.GetAllProducts();
        }
    }
}
