using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Repositories
{
    
    public class LoginRepository
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        public Customer login(string email, string password)
        {
            Customer customer = db.Customers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return customer;
        }
    }
}