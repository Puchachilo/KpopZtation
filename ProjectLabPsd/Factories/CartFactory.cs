using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Factories
{
    
    public class CartFactory
    {
        public static Cart createCart ( int customerid, int albumid, int qty)
        {
            Cart cart = new Cart();            
            cart.CustomerId = customerid;
            cart.AlbumId = albumid;
            cart.Qty = qty;

            return cart;
        }


    }
}