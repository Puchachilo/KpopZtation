using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Views
{
    public partial class UpdateAlbum : System.Web.UI.Page
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id2"]);

            string name = nameTxt.Text;
            imageUp.SaveAs(Server.MapPath("~") + "/Assets/Albums/" + imageUp.FileName);
            string image = imageUp.FileName;
            int price = Convert.ToInt32(priceTxt.Text);
            int stock = Convert.ToInt32(stockTxt.Text);
            string desc = descTxt.Text;

            Album alb = db.Albums.Where(x => x.Id == id).FirstOrDefault();
            alb.Name = name;
            alb.Image = image;
            alb.Price = price;
            alb.Stock = stock;
            alb.Description = desc;

            db.SaveChanges();


            Response.Redirect("Home.aspx");
        }
    }
}