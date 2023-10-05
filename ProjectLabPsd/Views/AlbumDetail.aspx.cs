using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;
using ProjectLabPsd.Repositories;
namespace ProjectLabPsd.Views
{
    public partial class AlbumDetail : System.Web.UI.Page
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        CartRepository repoc = new CartRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["albumid"]);
            Album alb = db.Albums.Where(x => x.Id == id).FirstOrDefault();

            Image1.ImageUrl = "~/Assets/Albums/" + alb.Image;
            nameLbl.Text = alb.Name;
            priceLbl.Text = Convert.ToInt32(alb.Price).ToString();
            stockLbl.Text = Convert.ToInt32(alb.Stock).ToString();
            descLbl.Text = alb.Description;
        }

        

       

        public string quantity(string Quantity, int id)
        {
            string notif = "";

            Album alb2 = db.Albums.Where(x => x.Id == id).FirstOrDefault();
            int stock = alb2.Stock;

            if (Quantity.Equals(""))
            {
                notif = "Quantity must be filled";
            }
            else if(!int.TryParse(Quantity, out int Quantities))
            {
                notif = "Must use right format";
            }
            else if (Quantities > stock)
            {
                notif = "Quantity must not more than Stock";
            }
            
            return notif;
        }
        protected void atcBtn_Click(object sender, EventArgs e)
        {
            HttpCookie rememberMeCookie = Request.Cookies["RememberMe"];
            int customer_id = Convert.ToInt32(rememberMeCookie.Value);
            int albumid = Convert.ToInt32(Request.QueryString["albumid"]);
            int qty = Convert.ToInt32(qtyTxt.Text);
            repoc.AddCart(customer_id, albumid  ,qty);

            Response.Redirect("Cart.aspx");
        }
    }
}