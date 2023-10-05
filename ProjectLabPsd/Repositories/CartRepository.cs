using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Factories;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Repositories
{
    public class CartRepository
    {
        KpopZtationEntities6 db = Database.getDb();
        TransactionHeaderFactory tfact = new TransactionHeaderFactory();
        TransactionFactorycs mahi = new TransactionFactorycs();
        public void AddCart(int customerid, int albumid, int qty)
        {
            Cart cart = CartFactory.createCart(customerid, albumid, qty);

            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public List<Cart> getcartlist()
        {
            List<Cart> cartlist = db.Carts.ToList();
            return cartlist;
        }

        public Cart CheckCart (int id)
        {
            Cart checkcart = db.Carts.Where(x => x.CustomerId == id).FirstOrDefault();
            return checkcart;
        }

        public void deletecart(int albumid)
        {
            Cart crt = db.Carts.Where(x => x.AlbumId == albumid).FirstOrDefault();
            db.Carts.Remove(crt);
            db.SaveChanges();
        }

        public void checkoutbtn(int customerid)
        {
            List<Cart> cartlist = db.Carts.ToList();
            List<Album> albumlist = db.Albums.ToList();

            DateTime currentDate = DateTime.Now;

            TransactionHeader theader = tfact.createheader(currentDate, customerid);
            db.TransactionHeaders.Add(theader);
            db.SaveChanges();

            List<TransactionHeader> transactionHeaderDataList = db.TransactionHeaders.Where(x => x.CustomerId == customerid).ToList();
            List<Album> albummatchingid = albumlist.Where(album => cartlist.Any(cart => cart.AlbumId == album.Id)).ToList();
            List<Cart> cartmatchingid = cartlist.Where(cart => albumlist.Any(album => album.Id == cart.AlbumId) && cart.CustomerId == customerid).ToList();

            foreach (TransactionHeader transactionHeaderData in transactionHeaderDataList)
            {
                foreach (Cart cartData in cartmatchingid)
                {

                    int subtotal = 0;

                    foreach (Album albumData in albummatchingid)
                    {
                        subtotal = (albumData.Price * cartData.Qty);
                    }

                    bool isTransactionIDUsed = db.TransactionDetails.Any(td => td.TransactionId == transactionHeaderData.Id);

                    if (!isTransactionIDUsed)
                    {
                        TransactionDetail transactionDetail = mahi.createtransactionDetail(transactionHeaderData.Id, cartData.AlbumId, cartData.Qty, subtotal);
                        db.TransactionDetails.Add(transactionDetail);
                    }
                }
            }
            List<Cart> deletecart = db.Carts.Where(x => x.CustomerId == customerid).ToList();

            db.Carts.RemoveRange(deletecart);
            db.SaveChanges();
        }


    }
}

