using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Factories
{
    public class ArtistDetailFactory
    {
        public static Artist insertArtist(int id,string name, byte[] image)
        {
            Artist art = new Artist();
            art.Id = id;
            art.Name = name;
            art.Image = image;

            return art;
        }
    }
}