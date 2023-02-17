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
            config = _conf;
        }
        public MockCategory()
        {
        }

        private List<Category> allCategories;
        private readonly IConfiguration config;


        public IEnumerable<Category> AllCategories 
        {
            get
            {
                if (allCategories != null)
                    return allCategories;
                else
                    return GetCategoriesFromDB();


                //return new List<Category>//test
                //{ 
                //    new Category{ categoryName = "Крани", desc = "Шарові запорні крани" },
                //    new Category{ categoryName = "Труби", desc = "труби всіх видів для проведення водопроводу" },
                //};

            }

        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(config.GetConnectionString("DefaultConnection"));
            }
        }

        private List<Category> GetCategoriesFromDB()
        {
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

                this.allCategories = allCategories;
                return allCategories;
            }
        }
    }
}
