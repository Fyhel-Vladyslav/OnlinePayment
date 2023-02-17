using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Interfaces
{
    public interface IItemsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
