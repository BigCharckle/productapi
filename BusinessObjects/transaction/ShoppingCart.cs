using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.culture; 
namespace Models.transaction
{
    public class ShoppingCart
    {
        public ShoppingCart(List<CartItem> items, Country country)
        {
            this.cartItems = items;
            this.country = country;
        }

        public int id { get; set; }
        
        public decimal itemsprice{
            get{
                return this.cartItems.Sum(x => x.itemsprice);
                } 
        }
        public decimal shippingprice
        {
            get
            {
                return (itemsprice > 50 ? 20 : 10);
            }
        }
        public decimal totalprice
        {
            get
            {
                return itemsprice + shippingprice;

            }
        }
        public Country country { get; set; }

        public List<CartItem> cartItems { get; set; }

    }
}
