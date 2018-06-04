﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SimpleCommerce.Data;
using SimpleCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCommerce.Controllers
{
    public class ControllerBase:Controller
    {
        protected readonly ApplicationDbContext _context;
        public ControllerBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller; //nesneyi sınıfa dönüştürüo(controller)as yapıyor
            controller.ViewBag.Categories = _context.Categories.ToList();
            //sepetteki ürün sayısını belirle
            string owner = User.Identity.Name;
            if (string.IsNullOrEmpty(owner))
            {
                owner = HttpContext.Session.Id;
            }

            controller.ViewBag.CartItemCount = GetCart(owner).CartItems.Sum(c => c.Quantity);


            base.OnActionExecuting(context);
        }
        protected Cart GetCart(string owner)
        {
            Cart cart = _context.Carts.Include(i => i.CartItems).Where(c => c.Owner == owner).FirstOrDefault();
            if (cart == null)
            {
                cart = new Cart();
                cart.Owner = owner;
                _context.Carts.Add(cart);
            }
            return cart;
        }
    }
}
