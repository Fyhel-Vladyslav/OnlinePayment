using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controlers
{
    public class CategoriesController : Controller
    {     
        private readonly IItemsCategory _allCategories;
        public IActionResult IndexCategories()
        {
            var categories = _allCategories.AllCategories;
            return View(categories);
        }          


        public CategoriesController( IItemsCategory iItemsCategory)
        {
            _allCategories = iItemsCategory;
        }
        public ViewResult List()
        {
            var categories = _allCategories.AllCategories;
            return View(categories);
        }
}   }


