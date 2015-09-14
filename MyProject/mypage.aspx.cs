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

public partial class mypage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            txtstartdate.Text = d.ToShortDateString(); 
            txtenddate.Text = DateTime.Now.Date.ToShortDateString();
            txtinvoicedate.Text = DateTime.Now.Date.ToShortDateString();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (dropdown.SelectedValue.ToString() == " Fixed ")
        {
            if (txtcompletedhours.Text.ToString() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invoice submitted successfully...!')", true);
            }
        }
        try
        {

            SqlConnection cnn = new SqlConnection("Data Source=AMX-535-PC;Initial Catalog=invoice;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from invoice", cnn);
            SqlCommand com = new SqlCommand("insert into invoice(startdate,enddate,invoicedate,hoursperday,completedhours,hourlyrate,totalpay,timesheet_name,timesheet_content,resources) values(@startdate,@enddate,@invoicedate,@hoursperday,@completedhours,@hourlyrate,@totalpay,@sheetname,@sheetdata,@resources) ", cnn);
            com.Parameters.AddWithValue("@startdate", Convert.ToDateTime(txtstartdate.Text.ToString()).Date);
            com.Parameters.AddWithValue("@enddate", Convert.ToDateTime(txtenddate.Text.ToString()).Date);
            com.Parameters.AddWithValue("@hourlyrate", txthourlyrate.Text.ToString());
            com.Parameters.AddWithValue("@invoicedate", Convert.ToDateTime(txtinvoicedate.Text.ToString()).Date);
            com.Parameters.AddWithValue("@hoursperday", txthoursday.Text.ToString());
            com.Parameters.AddWithValue("@completedhours", txtcompletedhours.Text.ToString());
            com.Parameters.AddWithValue("@totalpay", txttotalpay.Text.ToString());
            com.Parameters.AddWithValue("@resources", 5);

            string filePathsheet = futimesheet.PostedFile.FileName;
            string filenamesheet = Path.GetFileName(filePathsheet);

            Stream fs1 = futimesheet.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(fs1);
            Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);

            com.Parameters.Add("@sheetname", SqlDbType.NVarChar).Value = filenamesheet;
            com.Parameters.Add("@sheetdata", SqlDbType.Binary).Value = bytes1;

            com.ExecuteNonQuery();
            cnn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invoice submitted successfully...!')", true);
            Response.Redirect("Default.aspx");
        }

        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Something wrong.. Db cant be accessed...!')", true);
        }
        txtcompletedhours.Text = "";
        txttotalpay.Text = "";
    }
    public void calculate()
    {
        var resources = 5;
        if (dropdown.SelectedValue.ToString() == " Fixed ")
        {
            var hourday=Convert.ToUInt32(txtcompletedhours.Text.ToString());
            var hourrate=Convert.ToUInt32(txthourlyrate.Text.ToString());
            txttotalpay.Text = Convert.ToInt32(hourday * hourrate * resources).ToString();
        }
        else if (dropdown.SelectedValue.ToString() == " FTE ")
        {
            txthourlyrate.ReadOnly = true;
            DateTime startdate;
            DateTime enddate;
            TimeSpan remaindate;
            startdate = DateTime.Parse(txtstartdate.Text).Date;
            var date = txtenddate.Text.ToString();
            enddate =DateTime.Parse(date).Date;
            remaindate = enddate - startdate;
            int dayseliminate = remaindate.Days;
            int count=0;
            for (var i = 0; i <= dayseliminate; i++)
            {
                var testDate = startdate.AddDays(i);
                switch (testDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        count+=1;
                        break;
                }
            }
            int days = Convert.ToInt32(remaindate.TotalDays);
            days = days + 1 - count;
            var hours = Convert.ToInt32(txthoursday.Text.ToString());
            txtcompletedhours.Text = (days *hours*resources).ToString();
            var complete = Convert.ToInt32(txtcompletedhours.Text.ToString());
            var hourrate=Convert.ToUInt32(txthourlyrate.Text.ToString());
            txttotalpay.Text=Convert.ToUInt32(complete*hourrate).ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
    }
    protected void txtcompletedhours_TextChanged(object sender, EventArgs e)
    {
        int number;
        if (int.TryParse(txtcompletedhours.Text, out number))
        {
            calculate();
        }
    }
    protected void dropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropdown.SelectedValue.ToString() == " Fixed ")
        {
            txtcompletedhours.ReadOnly = false;
            txthourlyrate.ReadOnly = true;
            txthoursday.ReadOnly = true;
        }
        else if (dropdown.SelectedValue.ToString() == " FTE ")
        {
            txtcompletedhours.ReadOnly = true;
            txthourlyrate.ReadOnly = true;
            txthoursday.ReadOnly = true;
        }
    }
    protected void FTE_Load(object sender, EventArgs e)
    {
        if (dropdown.SelectedValue.ToString() == " FTE ")
        {
            calculate();
        }
    }
    protected void edittxthoursday_Click(object sender, ImageClickEventArgs e)
    {
        txthoursday.ReadOnly = false;
    }
    protected void edittxthourlyrate_Click(object sender, ImageClickEventArgs e)
    {
        txthourlyrate.ReadOnly = false;
    }
    protected void edittxtcompletedhours_Click(object sender, ImageClickEventArgs e)
    {
        txtcompletedhours.ReadOnly = false;
    }
    protected void txtinvoicedate_Load(object sender, EventArgs e)
    {
        DateTime d1 = Convert.ToDateTime(txtstartdate.Text.ToString());
        DateTime d2 = Convert.ToDateTime(txtenddate.Text.ToString());
        if (d1 > d2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Start date must be less than end date')", true);
        }
    }
}