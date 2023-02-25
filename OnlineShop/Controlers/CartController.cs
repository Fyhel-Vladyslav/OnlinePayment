using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.mocks;
using OnlineShop.Data.Models;
using OnlineShop.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controlers
{
    public class CartController : Controller
    {
        private readonly Cart _cart;
        private readonly DBContent dbContent;
        private IAllItems _itemRep;


        public CartController(Cart cart, IConfiguration config)
        {
            _cart = cart;
            dbContent= new DBContent(config);
        }


        public ViewResult Index()
        {
            var items = _cart.GetCartItems();
            _cart.listItems = items;

            var obj = new CartViewModel
            {
                cart = _cart
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = dbContent.GetSimpleItemFromDB(id);
            if (item != null)
                _cart.AddToCart(item);

            return RedirectToAction("Index");
        }
    }
}
