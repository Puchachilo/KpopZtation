using ProjectLabPsd.Factories;
using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Repositories
{
    public class CustomerRepository
    {
        KpopZtationEntities6 db = Database.getDb();

        public bool isEmailUnique(string email)
        {
            return db.Customers.Count(c => c.Email == email) == 0;
        }

        public void addCustomer(string name, string email, string password, string gender, string address)
        {
            Customer customer = CustomerFactory.insertCustomer(name, email, password, gender, address);

            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}