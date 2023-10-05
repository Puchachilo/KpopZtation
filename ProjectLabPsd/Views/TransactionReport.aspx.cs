using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLabPsd.Reporting;
using ProjectLabPsd.Model;

namespace ProjectLabPsd.Views
{
    public partial class TransactionReport1 : System.Web.UI.Page
    {
        KpopZtationEntities6 db = new KpopZtationEntities6();
        protected void Page_Load(object sender, EventArgs e)
        {

            CrystalReport1 cr = new CrystalReport1();
            CrystalReportViewer1.ReportSource = cr;
            List<TransactionDetail> cok = db.TransactionDetails.ToList();
            DataSet1 alex = cinta(cok);
            cr.SetDataSource(alex);

        }

        private DataSet1 cinta(List<TransactionDetail> satijan)
        {
            DataSet1 buri = new DataSet1();
            var headtable = buri.TransactionDetail;
            var detailtable = buri.TransactionHeader;
            var album = buri.Album;
            foreach (TransactionDetail tr in satijan)
            {
                var row = headtable.NewRow();
                row["TransactionId"] = tr.TransactionId;
                row["Qty"] = tr.Qty;
                row["SubTotal"] = tr.SubTotal;
                headtable.Rows.Add(row);

                var row2 = detailtable.NewRow();
                row2["Id"] = tr.TransactionId;
                TransactionHeader th = db.TransactionHeaders.Where(x => x.Id == tr.TransactionId).FirstOrDefault();
                row2["Date"] = th.Date;
                row2["CustomerId"] = th.CustomerId;
                detailtable.Rows.Add(row2);

                var row3 = album.NewRow();
                Album al = db.Albums.Where(x => x.Id == tr.AlbumId).FirstOrDefault();
                row3["Name"] = al.Name;
                row3["Price"] = al.Price;
                album.Rows.Add(row3);
            }
            return buri;
        }
    }
}
