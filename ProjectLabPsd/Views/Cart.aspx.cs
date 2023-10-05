using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ProjectLabPsd.Model;
using ProjectLabPsd.Repositories;

namespace ProjectLabPsd.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        AlbumRepository arepo = new AlbumRepository();
        CartRepository repoc = new CartRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie rememberMeCookie = Request.Cookies["RememberMe"];
            int customer_id = Convert.ToInt32(rememberMeCookie.Value);
            
            List<Album> albumlist = arepo.getalbumlist();
            
            List<ProjectLabPsd.Model.Cart> cartlist = repoc.getcartlist();


            List<Album> albummatch = albumlist.Where(album => cartlist.Any(cart => cart.AlbumId == album.Id)).ToList();
            List<ProjectLabPsd.Model.Cart> cartmatch = cartlist.Where(cart => albumlist.Any(album => album.Id == cart.AlbumId)&& cart.CustomerId == customer_id).ToList();
           
            

            ProjectLabPsd.Model.Cart checkcart = repoc.CheckCart(customer_id);

            var combinedDatalist = albummatch.Join(cartmatch, album => album.Id, cart => cart.AlbumId, (album, cart) => new
            {
                Image = album.Image,
                Name = album.Name,
                Qty = cart.Qty,
                Price = album.Price,
                AlbumId  = cart.AlbumId
            }).ToList();


            Repeater2.DataSource = combinedDatalist;
            Repeater2.DataBind();
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int albumid = Convert.ToInt32(button.CommandArgument);

            repoc.deletecart(albumid);
            Response.Redirect("Cart.aspx");
        }

        protected void coBtn_Click(object sender, EventArgs e)
        {
            HttpCookie rememberMeCookie = Request.Cookies["RememberMe"];
            int customer_id = Convert.ToInt32(rememberMeCookie.Value);

            repoc.checkoutbtn(customer_id);
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}