﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using SimpleCommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce.Controllers
{
    public class ProductsController:ControllerBase
    {

        public ProductsController(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IActionResult> Index(int categoryId =0, string order="date-asc", int page=1,string sortExpression ="CreateDate")
        {
            ViewBag.ProductsCategories = _context.Categories.Include(c => c.Products).ToList();//include ile kategorilerdeki ürünlerin içindeki sayıyı yazıyor
            ViewBag.SelectedCategory = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            ViewBag.LatestProducts = _context.Products.Where(k=> k.IsPublished ==true).OrderBy(o => o.CreateDate).Take(3).ToList();
            
            var products = _context.Products.Where(c =>( categoryId!=0?c.CategoryId == categoryId:true) && c.IsPublished == true);
            switch (order){
                case "date-asc":
                    products = products.OrderBy(o => o.CreateDate);
                    break;
                case "date-desc":
                    products = products.OrderByDescending(o => o.CreateDate);
                    break;
                case "price-asc":
                    products = products.OrderBy(o => o.Price);
                    break;
                case "price-desc":
                    products = products.OrderByDescending(o => o.Price);
                    break;

            }
            var model = await PagingList.CreateAsync(products, 9, page, sortExpression, "CreateDate");
            model.RouteValue = new RouteValueDictionary { { "categoryId", categoryId }, { "order", order } };
            
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(i=>i.Category).Where(p => p.IsPublished == true && p.Id == id).FirstOrDefault();
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Summary(int id)
        {
            var product = _context.Products.Include(i => i.Category).Where(p => p.IsPublished == true && p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        
    }
}
