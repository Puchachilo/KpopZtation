using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Factories
{
    public class CustomerFactory
    {
        public static Customer insertCustomer(string name, string email, string password, string gender, string address)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Email = email;
            customer.Password = password;
            customer.Gender = gender;
            customer.Address = address;
            customer.Role = "user";

            return customer;
        }
    }
}