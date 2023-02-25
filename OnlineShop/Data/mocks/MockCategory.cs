using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.mocks
{
    public class MockCategory : IItemsCategory
    {
        public MockCategory(IConfiguration _conf)
        {
            dbContent = new DBContent("Categories", _conf);
        }
        public MockCategory()
        {
        }

        private DBContent dbContent;

        public IEnumerable<Category> AllCategories 
        {
            get
            {
                    return dbContent.GetCategoriesFromDB();
                {
                    //return new List<Category>//test
                    //{ 
                    //    new Category{ categoryName = "Крани", desc = "Шарові запорні крани" },
                    //    new Category{ categoryName = "Труби", desc = "труби всіх видів для проведення водопроводу" },
                    //};
                }
            }

        }

      
    }
}
