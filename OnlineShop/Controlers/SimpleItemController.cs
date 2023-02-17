using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controlers
{
    public class SimpleItemController : Controller
    {    
        private readonly IAllItems _allItems;

    public SimpleItemController(IAllItems iAllItems)
    {
        _allItems = iAllItems;

    }
        public ViewResult List()
        {
            var items = _allItems.Items;
            return View(items);
        }

        public IActionResult IndexSItem(int id=0)
        {
            return View(_allItems.getObjectItem(id));
        }
    }
}
