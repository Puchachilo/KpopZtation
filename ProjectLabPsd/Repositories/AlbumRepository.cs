using ProjectLabPsd.Factories;
using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Repositories
{
    public class AlbumRepository
    {
        KpopZtationEntities6 db = Database.getDb();
        

        public void AddAlbum(int id,string name, string description, int price, int stock, string image)
        {
            //Album alb = AlbumFactory.InsertAlbum(name, description, price, stock, image);
            
            db.Albums.Add(AlbumFactory.InsertAlbum(id,name, description, price, stock, image));
            db.SaveChanges();

        }

        public List<Album> getalbumlist()
        {
            List<Album> albumlist = db.Albums.ToList();
            return albumlist;
        }
    }
}