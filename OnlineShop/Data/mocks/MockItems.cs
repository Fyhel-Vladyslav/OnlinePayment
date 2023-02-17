using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;

namespace OnlineShop.Data.mocks
{
    public class MockItems : IAllItems
    {
        public MockItems(IConfiguration _conf)
        {
            config = _conf;
        }


        private readonly IItemsCategory _categoryItems = new MockCategory();
        private List<Items> allItems;
        private readonly IConfiguration config;

        public IEnumerable<Items> Items
        {
            get
            {
                    return GetItemsFromDB();
                //return new List<Items>//test
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
        public IEnumerable<Items> getFavItems { get; set; }

        public Items getObjectItem(int itemId)
        {
            return GetSimpleItemFromDB(itemId);
        }
        public IEnumerable<Items> getCategoryItems(int categoryId)
        { 
                return GetItemsFromDB(categoryId); 
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("DefaultConnection"));
            }
        }

        IEnumerable<Items> IAllItems.getFavItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private List<Items> GetItemsFromDB(int categoryId = 0)
        {
            using (SqlConnection connection = Connection)
            {
                List<Items> allItems = new List<Items>();
                Items tempItem = new Items();
                connection.Open();
                allItems.Clear();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                if (categoryId != 0)
                    com.CommandText = $"select * from Items WHERE categoryID = {categoryId}";
                else
                    com.CommandText = "select * from Items";
                SqlDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        allItems.Add(new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), categoryId, ((int)reader[9])));
                    }

                connection.Close();

                this.allItems = allItems;
                return allItems;
            }
        }
        private Items GetSimpleItemFromDB(int Id = 0)
        {
            using (SqlConnection connection = Connection)
            {
                Items item = new Items();
                connection.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
             
                        com.CommandText = $"select * from Items WHERE id = {Id}";
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                item = new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), Id, ((int)reader[9]));

                connection.Close();
                return item;
            }
        }

    }
}
