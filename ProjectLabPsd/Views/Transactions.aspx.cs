using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Views
{
    public partial class Transactions : System.Web.UI.Page
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie rememberMeCookie = Request.Cookies["RememberMe"];
            int customer_id = Convert.ToInt32(rememberMeCookie.Value);

            Customer customer = db.Customers.Where(x => x.Id == customer_id).FirstOrDefault();

            SqlDataSource1.SelectCommand = "SELECT td.TransactionDetailId, th.Date, cs.Name, al.Image, al.Name, al.Stock, al.Price FROM (((TransactionDetail AS td INNER JOIN Album AS al ON td.AlbumId = al.Id) INNER JOIN TransactionHeader AS th ON  th.Id = td.TransactionId) INNER JOIN Customer AS cs ON th.CustomerId = cs.Id) WHERE cs.Id = " +customer_id;


        }
    }
}