using ProjectLabPsd.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace ProjectLabPsd.Controllers
{
    public class ArtistController
    {
        ArtistRepository repo;
        public ArtistController()
        {
            repo = new ArtistRepository();
        }

        public void validate(string name, byte[] image)
        {
            if (!repo.isNameUnique(name))
            {
                throw new Exception("Name Already Exist");
            }

           


            repo.addtArtist(name, image);
        }
    }
}