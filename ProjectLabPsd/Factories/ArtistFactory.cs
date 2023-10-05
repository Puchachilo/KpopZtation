using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Factories
{
    public class ArtistFactory
    {
        public static Artist insertArtist(string name, byte[] image)
        {
            Artist art = new Artist();
            art.Name = name;
            art.Image = image;

            return art;
        }
    }
}