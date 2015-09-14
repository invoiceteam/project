using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class newinvoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void days()
    {
        DateTime startdate;
        DateTime enddate;
        TimeSpan remaindate;
        startdate = DateTime.Parse(txtstartdate.Text).Date;
        enddate = DateTime.Parse(txtenddate.Text).Date;
        remaindate = enddate - startdate;
        int days = Convert.ToInt32(remaindate.TotalDays);
        days = days + 1;
        int completed = Convert.ToInt32(txtcompletedhours.Text.ToString());
        int hourrate;
        if (txthourlyrate.ReadOnly == false)
        {
            hourrate = Convert.ToInt32(txthourlyrate.Text.ToString());
        }
        else
            hourrate = 8;
        int final = days * hourrate*completed;
        txttotalpay.Text=(final).ToString();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection cnn = new SqlConnection("Data Source=AMX-535-PC;Initial Catalog=bpop;Integrated Security=True");
        cnn.Open();
        SqlCommand cmd = new SqlCommand("select * from invoice", cnn);
        SqlCommand com = new SqlCommand("insert into invoice(projectid,startdate,enddate,invoicedate,completedhours,hourlyrate,totalpay,timesheetname,timesheetdata) values(@projectid,@startdate,@enddate,@invoicedate,@completedhours,@hourlyrate,@totalpay,@sheetname,@sheetdata) ", cnn);
        com.Parameters.AddWithValue("@startdate", txtstartdate.Text.ToString());
        com.Parameters.AddWithValue("@enddate", txtenddate.Text.ToString());
        if (txthourlyrate.ReadOnly == false)
        {
            com.Parameters.AddWithValue("@hourlyrate", txthourlyrate.Text.ToString());
        }
        else
        {
            var rate = 8;
            com.Parameters.AddWithValue("@hourlyrate", rate);
        }
        com.Parameters.AddWithValue("@projectid", txtinvoicedate.Text.ToString());
        com.Parameters.AddWithValue("@projectid", txtinvoicedate.Text.ToString());
        com.Parameters.AddWithValue("@invoicedate", txtinvoicedate.Text.ToString());
        com.Parameters.AddWithValue("@completedhours", txtcompletedhours.Text.ToString());
        com.Parameters.AddWithValue("@totalpay", txttotalpay.Text.ToString());

            string filePathsheet = futimesheet.PostedFile.FileName;
            string filenamesheet = Path.GetFileName(filePathsheet);

            Stream fs1 = futimesheet.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(fs1);
            Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);

            com.Parameters.Add("@sheetname", SqlDbType.VarChar).Value = filenamesheet;
            com.Parameters.Add("@sheetdata", SqlDbType.Binary).Value = bytes1;
 
        com.ExecuteNonQuery();
        cnn.Close();
        Response.Redirect("Default.aspx");
    }
    protected void Unnamed1_Click(object sender, ImageClickEventArgs e)
    {
        txthourlyrate.ReadOnly = false;

    }
    protected void txthourlyrate_TextChanged(object sender, EventArgs e)
    {
        days();
    }
    protected void txtcompletedhours_TextChanged(object sender, EventArgs e)
    {
        days();
    }
}