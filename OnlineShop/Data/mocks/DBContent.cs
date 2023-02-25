using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.mocks
{

    public class DBContent:DbContext
    {
        private string table;
        private readonly IConfiguration config;


        public DBContent(IConfiguration _conf)
        {
            config = _conf;
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

        public Items GetSimpleItemFromDB(int Id = 0)
        {
            table = "Items";
            using (SqlConnection connection = Connection)
            {
                Items item = new Items();
                connection.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;

                com.CommandText = $"select * from {table} WHERE id = {Id}";
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                    item = new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), Id, ((int)reader[9]));

                connection.Close();
                return item;
            }
        }
        public List<Items> GetItemsFromDB(int categoryId = 0)
        {
            table = "Items";
            using (SqlConnection connection = Connection)
            {
                List<Items> allItems = new List<Items>();
                Items tempItem = new Items();
                connection.Open();
                allItems.Clear();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                if (categoryId != 0)
                    com.CommandText = $"select * from {table} WHERE categoryID = {categoryId}";
                else
                    com.CommandText = $"select * from {table}";
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    allItems.Add(new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), categoryId, ((int)reader[9])));
                }

                connection.Close();

                return allItems;
            }
        }
        public List<Items> GetFavItems(int categoryId = 0)
        {
            table = "Items";
            using (SqlConnection connection = Connection)
            {
                List<Items> allItems = new List<Items>();
                Items tempItem = new Items();
                connection.Open();
                allItems.Clear();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                if (categoryId != 0)
                    com.CommandText = $"select * from {table} WHERE categoryID = {categoryId}";
                else
                    com.CommandText = $"select * from {table}";
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    allItems.Add(new Items((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3], "", (double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), categoryId, ((int)reader[9])));
                }

                connection.Close();

                return allItems;
            }
        }

        public List<CartItem> GetCartItemsFromDB()
        {
            table = "Cart";
            using (SqlConnection connection = Connection)
            {
                List<CartItem> allItems = new List<CartItem>();
                connection.Open();
                allItems.Clear();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                    com.CommandText = $"select * from {table} WHERE categoryID = ";
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    allItems.Add(new CartItem((int)reader[0], (string)reader[1], (double)reader[2], (string)reader[3]));
                }

                connection.Close();

                return allItems;
            }
        }


        public List<Category> GetCategoriesFromDB()
        {
            table = "Category";
            using (SqlConnection connection = Connection)
            {
                List<Category> allCategories = new List<Category>();
                connection.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = connection;
                com.CommandText = "select * from Categories";
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    allCategories.Add(new Category((int)reader[0], (string)reader[1], null, (string)reader[2]));
                }
                connection.Close();

                return allCategories;
            }
        }
    }
}
