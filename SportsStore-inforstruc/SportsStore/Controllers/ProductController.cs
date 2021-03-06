﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult List(int productPage = 1)
            => View(new ProductListViewModel
            {
                Products=repository.Products.OrderBy(p=>p.ProductID).Skip((productPage-1)*PageSize)
                .Take(PageSize),
                PagingInfo=new PagingInfo
                {
                    CurrentPage=productPage,
                    ItemsPerPage=PageSize,
                    TotalItems=repository.Products.Count()
                }
            });
    }
}