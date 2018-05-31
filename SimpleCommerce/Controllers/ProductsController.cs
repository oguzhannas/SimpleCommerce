using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(int categoryId)
        {
            ViewBag.ProductsCategories = _context.Categories.Include(c => c.Products).ToList();//include ile kategorilerdeki ürünlerin içindeki sayıyı yazıyor
            ViewBag.SelectedCategory = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            ViewBag.LatestProducts = _context.Products.OrderBy(o => o.CreateDate).Take(3).ToList();
            return View();
        }



    }
}
