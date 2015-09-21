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
using System.Web.Services;

public partial class mypage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
                string connectionstring = ConfigurationManager.ConnectionStrings["connect"].ToString();
                SqlConnection cnn = new SqlConnection(connectionstring);
                cnn.Open();
                SqlCommand cmd2 = new SqlCommand("select TOP 1 enddate from invoice_details where project_id='" + Request.QueryString["id"] + "' order by enddate desc", cnn);
                //SqlCommand cmd2 = new SqlCommand("select enddate from invoice where id='" + idval + "' orderby enddate desc top 1", cnn);
                SqlCommand cmdtype = new SqlCommand("select type from project where id='" + Request.QueryString["id"] + "'", cnn);
                int projecttype = Convert.ToInt32(cmdtype.ExecuteScalar());
                DateTime prevdate = Convert.ToDateTime(cmd2.ExecuteScalar()).Date;
                SqlCommand cmd = new SqlCommand("select hourly_rate from project where id='" + Request.QueryString["id"] + "'", cnn);
                int value = Convert.ToInt32(cmd.ExecuteScalar());
                txthourlyrate.Text = value.ToString();
                SqlCommand date = new SqlCommand("select start_date from project where id='" + Request.QueryString["id"] + "'", cnn);
                DateTime startdate = Convert.ToDateTime(date.ExecuteScalar()).Date;

                cnn.Close();
                if (prevdate.Date == DateTime.Parse("01/01/0001").Date)
                {
                    txtstartdate.Text = startdate.Date.ToShortDateString();
                }
                else if (prevdate.DayOfWeek.ToString() == "Saturday")
                {
                    txtstartdate.Text = prevdate.AddDays(2).ToShortDateString();
                }
                else if (prevdate.DayOfWeek.ToString() == "Friday")
                {
                    txtstartdate.Text = prevdate.AddDays(3).ToShortDateString();
                }
                else
                {
                    txtstartdate.Text = prevdate.AddDays(1).ToShortDateString();
                }
                txtenddate.Text = DateTime.Now.Date.ToShortDateString();
                txtinvoicedate.Text = DateTime.Now.Date.ToShortDateString();
                if (projecttype == 0)
                {
                    txtcompletedhours.ReadOnly = false;
                    txthourlyrate.ReadOnly = true;
                    txthoursday.ReadOnly = true;
                }
                else if (projecttype == 1)
                {
                    txtcompletedhours.ReadOnly = true;
                    txthourlyrate.ReadOnly = true;
                    txthoursday.ReadOnly = true;
                    calculate();
                }
        
        }
    }

    protected int type()
    {
        SqlConnection cnn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        cnn1.Open();
        SqlCommand cmdtype = new SqlCommand("select type from project where id='" + Request.QueryString["id"] + "'", cnn1);
        int projecttype = Convert.ToInt32(cmdtype.ExecuteScalar());
        cnn1.Close();
        return projecttype;
    }

    protected int isInteger(string test)
    {
        int output;
        bool res = int.TryParse(test.ToString(), out output);
        return output;
    }

    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int hours = isInteger(txtcompletedhours.Text.ToString());
        int rate = isInteger(txthourlyrate.Text.ToString());
        int hoursofday = isInteger(txthoursday.Text.ToString());
        int holidays = isInteger(txtspecialholidays.Text.ToString());
        if (hours == 0 || rate == 0 || hoursofday == 0 )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid datas present. Kindly check the fields like completed hours , hourlyrate and hoursperday')", true);
        }
        else
        {
            int typevalue = type();
            if ((typevalue == 0) && (txtcompletedhours.Text.ToString() == ""))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data at completed hours fie')", true);
            }
            else
            {
                SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
                cnn.Open();
                try
                {
                    //pid
                    SqlCommand cmd = new SqlCommand("select * from invoice_details", cnn);
                    string query = "insert into invoice_details(project_id,startdate,enddate,invoicedate,hoursperday,completedhours,hourlyrate,totalpay,timesheet_name,status) values(@id,@startdate,@enddate,@invoicedate,@hoursperday,@completedhours,@hourlyrate,@totalpay,@sheetname,@status)";
                    SqlCommand com = new SqlCommand(query, cnn);
                    com.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                    com.Parameters.AddWithValue("@startdate", Convert.ToDateTime(txtstartdate.Text.ToString()).Date.ToShortDateString());
                    com.Parameters.AddWithValue("@enddate", Convert.ToDateTime(txtenddate.Text.ToString()).Date.ToShortDateString());
                    com.Parameters.AddWithValue("@hourlyrate", txthourlyrate.Text.ToString());
                    com.Parameters.AddWithValue("@invoicedate", Convert.ToDateTime(txtinvoicedate.Text.ToString()).Date.ToShortDateString());
                    com.Parameters.AddWithValue("@hoursperday", txthoursday.Text.ToString());
                    com.Parameters.AddWithValue("@completedhours", txtcompletedhours.Text.ToString());
                    com.Parameters.AddWithValue("@totalpay", txttotalpay.Text.ToString());
                    com.Parameters.AddWithValue("@status", "Pending");
                    com.Parameters.AddWithValue("@sheetname", fileupload());

                    com.ExecuteNonQuery();
                    cnn.Close();
                    //ScriptManager.RegisterStartupScript(this, this.GetType(),
                    //"alert",
                    //"alert('Invoice submitted sucessfully');window.location ='currentprojectdetails.aspx';",
                    //true);
                    Response.Redirect("currentprojectdetails.aspx?ID=" + Request.QueryString["id"]);
                }

                catch (Exception)
                {
                    cnn.Close();
                }
            }
            txtcompletedhours.Text = "";
            txttotalpay.Text = "";
        }
    }
   

    protected string fileupload()
    {
        string sowPath = "";
        if (futimesheet.PostedFile != null ? futimesheet.PostedFile.ContentLength > 0 : false)
        {
            try
            {

                string fileName = Path.GetFileName(futimesheet.PostedFile.FileName);
                string folder = Server.MapPath("~/Uploaded Files/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                futimesheet.PostedFile.SaveAs(Path.Combine(folder, fileName));
                sowPath = Path.Combine("/Uploaded Files/", fileName);
            }
            catch
            {
                sowPath = "";
            }

        }
        return sowPath;
    }

    public void calculate()
    {
        SqlConnection cnn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        cnn1.Open();
        SqlCommand cmdrate = new SqlCommand("select hourly_rate from project where id='" + Request.QueryString["id"] + "'", cnn1);
        int rate = Convert.ToInt32(cmdrate.ExecuteScalar());
        int typevalue = type();
        if (txthoursday.ReadOnly == true)
        {
            int val = 8;
            txthoursday.Text = val.ToString();
        }
        if (txthourlyrate.ReadOnly == true)
        {
            SqlCommand cmd = new SqlCommand("select hourly_rate from project where id='" + Request.QueryString["id"] + "'",cnn1);
            int value=Convert.ToInt32(cmd.ExecuteScalar());
            txthourlyrate.Text = value.ToString();
        }
        SqlCommand cmdresources = new SqlCommand("select resources from project where id='" + Request.QueryString["id"] + "'", cnn1);
        var resources = Convert.ToInt32(cmdresources.ExecuteScalar());
        resources = int.Parse(resources.ToString());
        cnn1.Close();
        if (typevalue == 0)
        {
            if (txtcompletedhours.Text.ToString() == string.Empty)
            {
                int val = 0;
                txtcompletedhours.Text = val.ToString();
            }
            if (txthourlyrate.Text.ToString() == string.Empty)
            {
                int val = 0;
                txthourlyrate.Text = val.ToString();
            }
            var hourday = Convert.ToUInt32(txtcompletedhours.Text.ToString());
            var hourrate = Convert.ToUInt32(txthourlyrate.Text.ToString());
            txttotalpay.Text = Convert.ToInt32(hourday * hourrate * resources).ToString();
        }
        else if (typevalue == 1)
        {
            txthourlyrate.ReadOnly = true;
            if (txthourlyrate.Text.ToString() == string.Empty)
            {
                int val = 0;
                txtcompletedhours.Text = val.ToString();
            }
            DateTime startdate;
            DateTime enddate;
            TimeSpan remaindate;
            startdate = DateTime.Parse(txtstartdate.Text).Date;
            var date = txtenddate.Text.ToString();
            enddate = DateTime.Parse(date).Date;
            remaindate = enddate - startdate;
            int dayseliminate = remaindate.Days;
            DateTime[] ameexHolidays = new DateTime[]
            {
                new DateTime(DateTime.Now.Year,1,26),
                new DateTime(DateTime.Now.Year,5,1),
                new DateTime(DateTime.Now.Year,7,3),
                new DateTime(DateTime.Now.Year,8,15),
                new DateTime(DateTime.Now.Year,9,7),
                new DateTime(DateTime.Now.Year,10,2)
            };
            int count = 0;
            for (int i = 0; i <= ameexHolidays.Length - 1; i++)
            {
                var index = Convert.ToInt32(i);
                if (ameexHolidays[i].Date >= startdate && ameexHolidays[i].Date <= enddate)
                {
                    if ((ameexHolidays[i].DayOfWeek.ToString() != "Sunday") && (ameexHolidays[i].DayOfWeek.ToString() != "Sunday"))
                    {
                        count++;
                    }
                }
            }
            for (var i = 0; i <= dayseliminate; i++)
            {
                var testDate = startdate.AddDays(i);
                switch (testDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        count += 1;
                        break;
                }
            }
            int spclholidays = 0;
            if (txtspecialholidays.ReadOnly == true)
            {
                spclholidays = 0;
            }
            else
            {
                int number;
                if (spclholidays.ToString() == string.Empty)
                {
                    spclholidays = 0;
                }
                else
                {
                    if (int.TryParse(txtspecialholidays.Text.ToString(), out number))
                    {
                        spclholidays = Convert.ToInt32(txtspecialholidays.Text.ToString());
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data at special holidays')", true);
                    }
                }
            }
            int days = Convert.ToInt32(remaindate.TotalDays);
            if (spclholidays >= days)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Special holidays must be less than no of days')", true);
            }
            else
            {
                days = days + 1 - (count + spclholidays);
                var hours = Convert.ToInt32(txthoursday.Text.ToString());
                txtcompletedhours.Text = (days * hours * resources).ToString();
                var complete = Convert.ToInt32(txtcompletedhours.Text.ToString());
                var hourrate = Convert.ToInt32(txthourlyrate.Text.ToString());
                txttotalpay.Text = Convert.ToInt32(complete * hourrate).ToString();
            }
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("currentprojectdetails.aspx?ID=" + Request.QueryString["id"]);
    }

    protected void txtcompletedhours_TextChanged(object sender, EventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours value in FTE Projects. Kindly select the dates')", true);
        }
        int number;
        if (int.TryParse(txtcompletedhours.Text, out number))
        {
            calculate();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in Completed hours')", true);
        }
    }
    protected void FTE_Load(object sender, EventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            calculate();
        }
    }
    protected void edittxthoursday_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hours of day in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txthoursday.ReadOnly = false;
        }
    }
    protected void edittxthourlyrate_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hourly rate in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txthourlyrate.ReadOnly = false;
        }
    }
    protected void edittxtcompletedhours_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txtcompletedhours.ReadOnly = false;
        }
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
    protected void edittxtspecialholidays_Click(object sender, ImageClickEventArgs e)
    {
        txtspecialholidays.ReadOnly = false;
    }
    protected void txthourlyrate_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hourly rate in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            if (int.TryParse(txthourlyrate.Text, out number))
            {
                calculate();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in hours rate field')", true);
            }
        }
    }
    protected void txthoursday_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours value in FTE Projects. Kindly select the dates')", true);
        }
        else if (int.TryParse(txthoursday.Text, out number))
        {
            calculate();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in hours per day field')", true);
        }
    }
    protected void txtspecialholidays_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (int.TryParse(txtspecialholidays.Text, out number))
        {
            if (typevalue == 1)
            {
                calculate();
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in holidays field')", true);
        }
    }

}