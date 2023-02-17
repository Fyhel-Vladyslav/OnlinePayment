using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Category
    {
        public Category(int _id , string _categoryName, string _desc, string _img)
        {
            id = _id;
            categoryName = _categoryName;
            desc = _desc;
            img = _img;

    }
    public int id { set; get; }

        public string categoryName { set; get; }

        public string desc { set; get; }

        public string img { set; get; }

        public List<Items> items { set; get; }
    }
}
