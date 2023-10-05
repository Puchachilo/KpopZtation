using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Repositories;
using ProjectLabPsd.Factories;

namespace ProjectLabPsd.Views
{

    public partial class AlbumInsert : System.Web.UI.Page
    {
        AlbumRepository repo = new AlbumRepository();
        AlbumFactory fac = new AlbumFactory();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            //if (imageUp.HasFile)
            //{
                int id = Convert.ToInt32(artistTxt.Text);
                string name = nameTxt.Text;
                string description = descTxt.Text;
                int price =  Convert.ToInt32(priceTxt.Text);
                int stock = Convert.ToInt32(stockTxt.Text);
                string image = imageUp.FileName;
                repo.AddAlbum(id,name, description, price, stock, image);
            //}
            Response.Redirect("Home.aspx");
        }
    }
}