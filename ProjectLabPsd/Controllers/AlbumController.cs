using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Repositories;

namespace ProjectLabPsd.Controllers
{
    public class AlbumController
    {
        AlbumRepository  repo;
        
        public AlbumController()
        {
            repo = new AlbumRepository();
        }

        public void  validate (string name, string image , string description, int price, int stock)
        {
            if(name.Length >= 50)
            {
                throw new Exception("Name must be filled with less than 50 characters");
            }
            if(description.Length >= 255)
            {
                throw new Exception("Descriptoin must be filled with less than 50 characters");
            }
            if (stock < 0)
            {
                throw new Exception("Stock must not empty");
            }
            if(price < 100000 || price > 1000000)
            {
                throw new Exception("Price must be in range 100,000 - 1,000,000");    
            }
            
        }
    }
}