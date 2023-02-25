using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data.mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public List<CartItem> listItems { get; set; }

        private readonly DBContent dBContent;
        
        public Cart(DBContent _dBContent)
        {
            dBContent = _dBContent;
        }


        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", shopCartId);

            return new Cart(context) { CartId = shopCartId };
        }

        public void AddToCart(Items item, int amount)
        {
            
        }

        public List<CartItem> GetCartItems()
        {
            return null;
        }
    }
}
