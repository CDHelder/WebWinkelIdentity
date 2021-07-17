using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
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
