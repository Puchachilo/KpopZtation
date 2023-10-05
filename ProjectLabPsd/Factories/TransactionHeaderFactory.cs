using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Model;
namespace ProjectLabPsd.Factories
{
    public class TransactionHeaderFactory
    {
        public TransactionHeader createheader (DateTime date, int customerid)
        {
            return new TransactionHeader
            {
                Date = date,
                CustomerId = customerid
            };
        }
    }
}