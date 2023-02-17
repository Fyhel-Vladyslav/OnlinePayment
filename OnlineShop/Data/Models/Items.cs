using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Items
    {
        public Items()
        {

        }
        public Items(int _id, string _name, string _shortDesc, string _longDesc, string _img,double _price, bool _isFavourite, int _availiable, int _categoryID, int _rating)
        {
            id = _id;
            name = _name;
            shortDesc = _shortDesc;
            longDesc = _longDesc;
            img = _img;
            price = _price;
            isFavourite = _isFavourite;
            availiable = _availiable;
            categoryID = _categoryID;
            rating = _rating;
        }
        public int id { set; get; }

        public string name { set; get; }

        public string shortDesc { set; get; }

        public string longDesc { set; get; }

        public string img { set; get; }

        public double price { set; get; }

        public bool isFavourite { set; get; }

        public int availiable { set; get; }

        public int categoryID { set; get; }

        public int rating { set; get; }
        public virtual Category Category { set; get; }
    }
}
