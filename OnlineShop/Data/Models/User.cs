using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class User
    {
        public User(int _id , string _Email, string _Password, string _AllCartID, string _FavouriteID)
        {
            List<string> tempListCart = new List<string>();
            List<string> tempListFav = new List<string>();
            string tempStr="";
            int n = 0;

            id = _id;
            Email = _Email;
            Password = _Password;
            foreach(var i in _AllCartID)
            {
                 tempStr += i;
                n++;
                if (n % 6 == 0)
                    tempListCart.Add(tempStr);
            }
            AllCartID = tempListCart;

            tempStr = "";
            n = 0;

            foreach (var i in _FavouriteID)
            {
                tempStr += i;
                n++;
                if (n % 6 == 0)
                    tempListFav.Add(tempStr);
            }
            AllFavouriteID = tempListFav;
        }
    public int id { set; get; }

        public string Email { set; get; }

        public string Password { set; get; }

        public IEnumerable<string> AllCartID { set; get; }

        public IEnumerable<string> AllFavouriteID { set; get; }
    }
}
