using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Data.Models;

//using Microsoft.Extensions.Configuration;
//using Dapper;
//using Microsoft.Data.SqlClient;


namespace OnlineShop.Controlers
{
    public class ItemsController : Controller
    {      
      
        private readonly IAllItems _allItems;

        public ItemsController(IAllItems iAllItems)
        {
            _allItems = iAllItems;

        }
        public ViewResult List()
        {
            var items =_allItems.Items;
            return View(items);
        }

        public ViewResult IndexItems(int id)
        {
            var items = _allItems.getCategoryItems(id);
            return View(items);
        }


        /// SQL

        //private readonly IConfiguration _config;
        //public SqlConnection Connection
        //{
        //    get
        //    {
        //        return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        //    }
        //}

        //private List<Items> GetItemsFromDB()
        //{
        //    using (SqlConnection connection = Connection)
        //    {
        //        List<Items> allItems= new List<Items>();
        //        string rez = "";
        //        Items tempItem = new Items();
        //        connection.Open();
        //        SqlCommand com = new SqlCommand();
        //        com.Connection = connection;
        //        com.CommandText = "select * from Items";
        //        SqlDataReader reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            //tempItem.price = (double)reader[5];

        //            allItems.Add(new Items((int)reader[0],(string) reader[1],"","","",(double)reader[5], Convert.ToBoolean((byte)reader[6]), ((int)reader[7]), (int)reader[8]));

        //            //
        //        }
        //        connection.Close();

        //        //var result = db.Query<User1>("SELECT id, name FROM Items;").ToList();

        //        return allItems;
        //    }
        //}

        /// /SQL
    }
}
