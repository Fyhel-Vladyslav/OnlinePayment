using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class CartItem
    {

        public CartItem(int _id,string _longDesc, double _price, string _CartId)
        {
            id = _id;
            longDesc = _longDesc;
            price = _price;
            CartId = _CartId;
        }
        public int id { get; set; }
        public string longDesc { get; set; }
        public double price { get; set; }
        public string CartId { get; set; }
        
    }

}
