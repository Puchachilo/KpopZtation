using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;
namespace ProjectLabPsd.Views
{
    public partial class UpdateProfile : System.Web.UI.Page
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
            HttpCookie rememberMeCookie = Request.Cookies["RememberMe"];
            int id = Convert.ToInt32(rememberMeCookie.Value);

            string name = nameTxt.Text;
            string email = emailTxt.Text;
            string gender = genderRadio.SelectedValue.ToString();
            string address = addTxt.Text;
            string password = passTxt.Text;

            Customer cust = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            cust.Name = name;
            cust.Email = email;
            cust.Gender = gender;
            cust.Address = address;
            cust.Password = password;

            db.SaveChanges();
            
            Response.Redirect("Home.aspx");

        }
    }
}