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

    public class DBContent : IAllItems
    {

        private List<Items> allItems;
        private readonly IConfiguration config;

        public DBContent(IConfiguration _conf)
        {
            config = _conf;
        }
        public IEnumerable<Items> Items => GetCategoryItemsFromDB();
        public IEnumerable<Items> getFavItems => GetFavItems();

        public IEnumerable<Items> getCategoryItems(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Items getObjectItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("DefaultConnection"));
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
                while (reader.Read())
                    item = new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), Id, ((int)reader[9]));

                connection.Close();
                return item;
            }
        }
        private List<Items> GetCategoryItemsFromDB(int categoryId = 0)
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
        private List<Items> GetFavItems(int categoryId = 0)
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
    }
}
