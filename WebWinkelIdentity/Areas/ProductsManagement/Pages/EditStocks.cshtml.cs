﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebWinkelIdentity.Core;
using WebWinkelIdentity.Core.StoreEntities;
using WebWinkelIdentity.Data.Service.Interfaces;

namespace WebWinkelIdentity.Areas.ProductsManagement.Pages
{
    [Authorize(Roles = "Admin")]
    public class EditStocksModel : PageModel
    {
 
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public EditStocksModel(IProductRepository productRepository, IStoreRepository storeRepository)
        {
            this._productRepository = productRepository;
            this._storeRepository = storeRepository;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<Product> ProductVariations { get; set; }

        public List<StoreProduct> ProductStocks { get; set; }
        public List<Store> Stores { get; set; }
        public bool CurrentStock { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _productRepository.GetProduct(id);
            ProductVariations = _productRepository.GetAllProductsVariations(Product);
            ProductStocks = _productRepository.GetAllStoreProducts(ProductVariations);
            Stores = _storeRepository.GetAllStores();

            CurrentStock = false;
            foreach (var productStock in ProductStocks)
            {
                if (productStock.Quantity > 0)
                {
                    CurrentStock = true;
                }
            }

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(_productRepository.UpdateStoreProducts(ProductStocks) == true)
            {
                return LocalRedirect($"/ProductsManagement/Details?id={Product.Id}");
            }

            return Page();

        }
    }
}
