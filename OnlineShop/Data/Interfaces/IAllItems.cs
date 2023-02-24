using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Interfaces
{
    public interface IAllItems
    {

        IEnumerable<Items> Items { get;}

        IEnumerable<Items> getFavItems { get;}

        IEnumerable<Items> getCategoryItems(int categoryId);

        Items getObjectItem(int itemId);
    }
}
