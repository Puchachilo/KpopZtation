using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;
using System.Linq;
using System.Collections.Generic;
using System.Web;

namespace ProjectLabPsd.Views

{
    public partial class ArtistDetail : System.Web.UI.Page
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\timot\\OneDrive\\Documents\\ProjectLabPsd\\ProjectLabPsd\\App_Data\\KpopZtation.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        KpopZtationEntities6 db = new KpopZtationEntities6();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            Artist art = db.Artists.Where(x => x.Id == id).FirstOrDefault();
            artistimg.ImageUrl = "~/Assets/Artists/" + art.Image;
            idLbl.Text = art.Id.ToString();
            nameLbl.Text = art.Name;


            Album abl = db.Albums.Where(x => x.ArtistId == id).FirstOrDefault();
            if (abl == null)
            {
                if (User.IsInRole("Admin"))
                {
                    Response.Redirect("AlbumInsert.aspx");
                }
               
            }

            else
            {
                List<Album> tot = db.Albums.Where(x => x.ArtistId == id).ToList();
                Repeater1.DataSource = tot;
                Repeater1.DataBind();

            }

    }

        protected void artistDetailInsertBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("AlbumInsert.aspx");
        }

        protected void UpdateAlbumBtn_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            Label ids = (Label)item.FindControl("idsLbl");
            string id2 = ids.Text;
            Response.Redirect("UpdateAlbum.aspx?id2="+id2);
            

        }

        protected void DeleteAlbumBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.CommandArgument.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Album WHERE name=@name", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        
                        Repeater1.DataBind();
                    }
                    else
                    {
                        
                    }
                }
                connection.Close();

            }
        }

        protected void selectbtn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int albumId = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("~/Views/AlbumDetail.aspx?albumid=" + albumId);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
           
        }
    }
}