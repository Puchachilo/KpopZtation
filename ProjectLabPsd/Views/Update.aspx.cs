using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPsd.Views
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string name = nameTxt.Text;
            byte[] image = imageUp.FileBytes;
            int id = (int)Session["ArtistId"];

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ArtistConnection"].ConnectionString))
            {
                connection.Open();

                string sql = "UPDATE Artist SET Name = @Name, Image = @Image WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Image", image);
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        notifLbl.Text = "Update successful";
                    }
                    else
                    {
                        notifLbl.Text = "Update failed";
                    }
                }
            }
        }
    }
}