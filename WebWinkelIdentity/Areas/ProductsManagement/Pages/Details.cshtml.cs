﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin,Employee")]
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public DetailsModel(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            this._productRepository = productRepository;
            this._storeRepository = storeRepository;
        }

        public Product Product { get; set; }
        public List<Store> StoresWithProduct { get; set; }
        public List<Product> ProductVariations { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            StoresWithProduct = _storeRepository.GetAllStores(Product);
            ProductVariations = _productRepository.GetAllProductsVariations(Product);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
