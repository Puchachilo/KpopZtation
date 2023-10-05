using ProjectLabPsd.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Repositories;

namespace ProjectLabPsd.Views
{
    public partial class Login : System.Web.UI.Page
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\timot\\OneDrive\\Documents\\ProjectLabPsd\\ProjectLabPsd\\App_Data\\KpopZtation.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        LoginRepository cusrepo = new LoginRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string password = passwordTxt.Text;
            Customer customer = cusrepo.login(email , password);

            if (IsValidUser( email, password))
            {
                if (rememberChk.Checked)
                {
                    HttpCookie rememberMeCookie = new HttpCookie("RememberMe");
                    rememberMeCookie.Value = customer.Id.ToString();
                    rememberMeCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(rememberMeCookie);
                }

                Response.Redirect("Home.aspx");

            }else  if(email == "" || password == "")
            {
                errorLbl.Text = "Email and password cannot be empty";
            }
            else
            {
                errorLbl.Text = "Invalid Email or Password";
            }

        }

        private bool IsValidUser(string email, string password)
        {
            bool isValid = false;
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Customer WHERE Email=@Email AND Password=@Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                

                if (count == 1)
                {
                    isValid = true;
                    query = "SELECT Role FROM Customer WHERE Email=@Email";
                    command.CommandText = query;
                    string role = (string)command.ExecuteScalar();
                    Session["Role"] = role;
                    Session["Email"] = email;
                }
                connection.Close();
            }

            return isValid;
        }

    }
}