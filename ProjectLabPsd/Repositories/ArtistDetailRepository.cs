using ProjectLabPsd.Factories;
using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Repositories
{
    public class ArtistDetailRepository
    {
        KpopZtationEntities6 db = Database.getDb();

        public bool isNameUnique(string name)
        {
            return db.Artists.Count(a => a.Name == name) == 0;
        }

        public void addtArtist(string name, byte[] image)
        {
            Artist artist = ArtistFactory.insertArtist(name, image);

            db.Artists.Add(artist);
            db.SaveChanges();
        }
    }

}
