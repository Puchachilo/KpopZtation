using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLabPsd.Factories
{
    public class AlbumFactory
    {
        public static Album InsertAlbum(int id,string name, string description, int price, int stock, string image)
        {
            Album abl = new Album();
            abl.ArtistId = id;
            abl.Name = name;
            abl.Description = description;
            abl.Price = price;
            abl.Stock = stock;
            abl.Image = image;

            return abl;
        }
    }
}