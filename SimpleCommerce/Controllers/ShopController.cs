using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce.Data;
using SimpleCommerce.Models;

namespace SimpleCommerce.Controllers
{
    public class ShopController : ControllerBase
    {
        public ShopController(ApplicationDbContext context) : base(context)
        {
         
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart(int productId)
        {
            string owner = User.Identity.Name;
            if(string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }
            Cart cart = GetCart(owner);
            CartItem cartItem = cart.CartItems.Where(c => c.ProductId == productId).FirstOrDefault();
            if(cartItem ==null)
            {
                cartItem = new CartItem();
                cartItem.ProductId = productId;
                cartItem.Quantity = 1;
                cart.CartItems.Add(cartItem);

            }
            else
            {
                cartItem.Quantity += 1;
            }
            _context.SaveChanges();
            return Json(true);
        }

    }
}