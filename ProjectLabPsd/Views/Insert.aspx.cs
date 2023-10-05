using ProjectLabPsd.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectLabPsd.Views
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            ArtistController control = new ArtistController();
            string name = nameTxt.Text;
            byte[] image = null;

            if (imageUp.HasFile)
            {
                using (var ms = new MemoryStream())
                {
                    imageUp.PostedFile.InputStream.CopyTo(ms);
                    image = ms.ToArray();

                    
                    var ext = Path.GetExtension(imageUp.FileName);

                    
                    if (!ext.Equals(".jpg", StringComparison.OrdinalIgnoreCase)&& !ext.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) && !ext.Equals(".png", StringComparison.OrdinalIgnoreCase) && !ext.Equals(".jfif", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception("Invalid image format. Only JPEG, PNG, and JFIF formats are supported.");
                    }
                }
            }


            try
            {
                control.validate(name, image);
                Response.Redirect("Home.aspx");
            }
            catch(Exception ex)
            {
                errorLbl.Text = ex.Message;
            }
        }
    }
}