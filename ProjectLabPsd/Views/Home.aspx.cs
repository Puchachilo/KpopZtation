using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;
namespace ProjectLabPsd.Views
{
    public partial class Home : System.Web.UI.Page
    {

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\timot\\OneDrive\\Documents\\ProjectLabPsd\\ProjectLabPsd\\App_Data\\KpopZtation.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        KpopZtationEntities6 db = new KpopZtationEntities6();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

            }
        }

        protected void artistInsertBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Insert.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            Session["ArtistId"] = id;
            Response.Redirect("Update.aspx");
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string name = btn.CommandArgument.ToString();

          using (SqlConnection connection = new SqlConnection(connectionString))
          {
                connection.Open();
                using(SqlCommand command = new SqlCommand("DELETE FROM Artist WHERE name=@name", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    int rowsAffected = command.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        notifLbl.Text = "Succesfully deleted";
                        artistRptr.DataBind();
                    }
                    else
                    {
                        notifLbl.Text = "Artist not found";
                    }
                }
                connection.Close();
                
          }
        }
        protected void selectbtn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int Id = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("~/Views/ArtistDetail.aspx?Id="+Id);
        }
        protected void artistRptr_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }
    }
}