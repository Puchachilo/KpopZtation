using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Factories
{
    
    public class TransactionFactorycs
    {
        public TransactionDetail createtransactionDetail(int transactionid, int albumid, int qty, int subtotal )
        {
            TransactionDetail tdetail = new TransactionDetail();
            tdetail.TransactionId = transactionid;
            tdetail.AlbumId = albumid;
            tdetail.Qty = qty;
            tdetail.SubTotal = subtotal;

            return tdetail;
        }
    }
}