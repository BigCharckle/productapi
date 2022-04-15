using System;
using System.Collections.Generic;
using System.Text;

namespace Models.transaction
{
    public class CartItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal itemsprice
        {
             get
                    { return this.price * this.quantity; } 
            
        }
    }
}
