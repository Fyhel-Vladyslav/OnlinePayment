using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace OnlineShop.Data.mocks
{
    public class MockItems : IAllItems
    {
        public MockItems(IConfiguration _conf)
        {
            dbContent = new DBContent( _conf);
        }

        private DBContent dbContent;
        private readonly IItemsCategory _categoryItems = new MockCategory();

        public IEnumerable<Items> Items
        {
            get
            {
                    return dbContent.GetItemsFromDB();
                { //return new List<Items>//test
                  //{
                  //new Items
                  //{ 
                  //    name = "Fado",
                  //    shortDesc = "Few better than micro",
                  //    longDesc = "The best(maybe)",
                  //    isFavourite = true, price = 150,
                  //    availiable = 1,
                  //    Category = _categoryItems.AllCategories.First() 
                  //},
                  //                    new Items
                  //{
                  //    name = "Kano",
                  //    shortDesc = "Few better than Fado",
                  //    longDesc = "The best",
                  //    isFavourite = true, price = 200,
                  //    availiable = 7,
                  //    Category = _categoryItems.AllCategories.First()
                  //}
                  //};
                }
            }
        }
        public IEnumerable<Items> getFavItems { get; set; }

        public Items getObjectItem(int itemId)
        {
            return dbContent.GetSimpleItemFromDB(itemId);
        }
        public IEnumerable<Items> getCategoryItems(int categoryId)
        { 
                return dbContent.GetItemsFromDB(categoryId); 
        }

        IEnumerable<Items> IAllItems.getFavItems { get => throw new NotImplementedException(); }


    }
}
