using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
        
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", shopCartId);

            return new Cart() { CartId = shopCartId };
        }

        public void AddToCart(Items item, int amount)
        {
            
        }
    }

    internal class AppDbContent
    {
    }
}
