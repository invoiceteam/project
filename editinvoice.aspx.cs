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
public partial class editinvoice : System.Web.UI.Page
{  
    protected void Page_Load(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
        SqlConnection cnn = new SqlConnection(cs);
        cnn.Open();
        SqlDataAdapter adapt;
        DataTable dt;

        dt = new DataTable();
        cnn = new SqlConnection(cs);
        cnn.Open();
        if (!IsPostBack)
        {
            adapt = new SqlDataAdapter("Select * from invoice_details where invoicenumber='" + Session["invoicekey"] + "'", cnn);
            adapt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txteditstartdate.Text = dt.Rows[0]["startdate"].ToString();
                txteditenddate.Text = dt.Rows[0]["enddate"].ToString();
                txteditcompletedhours.Text = dt.Rows[0]["completedhours"].ToString();
                txtedithourlyrate.Text = dt.Rows[0]["hourlyrate"].ToString();
                txtedithoursday.Text = dt.Rows[0]["hoursperday"].ToString();
                txteditinvoicedate.Text = dt.Rows[0]["invoicedate"].ToString();
                txteditspecialholidays.Text = dt.Rows[0]["holidays"].ToString();
                txtedittotalpay.Text = dt.Rows[0]["totalpay"].ToString();
                //fuedittimesheet= dt.Rows[0]["timesheet_name"].ToString();
            }
            SqlCommand cmdtype = new SqlCommand("select type from project where id='" + Request.QueryString["id"] + "'", cnn);
            int projecttype = Convert.ToInt32(cmdtype.ExecuteScalar());

            if (projecttype == 0)
            {
                txteditcompletedhours.ReadOnly = false;
                txtedithourlyrate.ReadOnly = true;
                txtedithoursday.ReadOnly = true;
            }
            else if (projecttype == 1)
            {
                txteditcompletedhours.ReadOnly = true;
                txtedithourlyrate.ReadOnly = true;
                txtedithoursday.ReadOnly = true;
            }
        }
        cnn.Close();
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

    protected string fileupload()
    {
        string sowPath = "";
        if (fuedittimesheet.PostedFile != null ? fuedittimesheet.PostedFile.ContentLength > 0 : false)
        {
            try
            {

                string fileName = Path.GetFileName(fuedittimesheet.PostedFile.FileName);
                string folder = Server.MapPath("~/Uploaded Files/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                fuedittimesheet.PostedFile.SaveAs(Path.Combine(folder, fileName));
                sowPath = Path.Combine("/Uploaded Files/", fileName);
            }
            catch
            {
                sowPath = "";
            }
        }
        return sowPath;
    }
    protected int isInteger(string test)
    {
        int output;
        bool res = int.TryParse(test.ToString(), out output);
        return output;
    }

    protected void btneditinvoice_Click(object sender, EventArgs e)
    {
        DateTime d1 = Convert.ToDateTime(txteditstartdate.Text.ToString());
        DateTime d2 = Convert.ToDateTime(txteditenddate.Text.ToString());
        if (d1 > d2)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Start date must be less than end date')", true);
        }

        int hours = isInteger(txteditcompletedhours.Text.ToString());
        int rate = isInteger(txtedithourlyrate.Text.ToString());
        int hoursofday=isInteger(txtedithoursday.Text.ToString());
        int holidays = isInteger(txteditspecialholidays.Text.ToString());
        if (hours == 0 || rate == 0 || hoursofday == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid datas present. Kindly check the fields like completed hours , hourlyrate, holidays and hoursperday')", true);
        }
        else{
            string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
            SqlConnection cnn = new SqlConnection(cs);
            cnn.Open();
            string startDate = Convert.ToDateTime(txteditstartdate.Text.ToString()).Date.ToShortDateString();
            string endDate = Convert.ToDateTime(txteditenddate.Text.ToString()).Date.ToShortDateString();
            string invoiceDate = Convert.ToDateTime(txteditinvoicedate.Text.ToString()).Date.ToShortDateString();
            int number;
            int spclholidays = 0;
            if (txteditspecialholidays.ReadOnly == true)
            {
                spclholidays = 0;
            }
            else if (int.TryParse(txteditspecialholidays.Text, out number))
            {
                spclholidays = Convert.ToInt32(txteditspecialholidays.Text.ToString());
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data at holidays field..')", true);
            }
            int hoursPerDay = Convert.ToInt32(txtedithoursday.Text.ToString());
            hoursPerDay = int.Parse(txtedithoursday.Text.ToString());

            int hourlyRate = Convert.ToInt32(txtedithourlyrate.Text.ToString());
            hourlyRate = int.Parse(txtedithourlyrate.Text.ToString());

            int completedHours = Convert.ToInt32(txteditcompletedhours.Text.ToString());
            completedHours = int.Parse(txteditcompletedhours.Text.ToString());

            int totalPay = Convert.ToInt32(txtedittotalpay.Text.ToString());
            totalPay = int.Parse(txtedittotalpay.Text.ToString());

            int typevalue = type();
            if ((typevalue == 0) && (txteditcompletedhours.Text.ToString() == ""))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data at completed hours fie')", true);
            }
            else
            {
                string query = "update invoice_details set startdate='" + startDate + "',enddate='" + endDate + "', invoicedate='" + invoiceDate + "',hoursperday='" + hoursPerDay + "',completedhours='" + completedHours + "',hourlyrate='" + hourlyRate + "',totalpay='" + totalPay + "',holidays='" + spclholidays + "',timesheet_name='" + fileupload()+ "' where invoicenumber='" + Session["invoicekey"] + "'";
                SqlCommand update = new SqlCommand(query, cnn);
                update.ExecuteNonQuery();
            }
            cnn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invoice updated successfully')", true);
            Response.Redirect("currentprojectdetails.aspx?ID=" + Request.QueryString["id"]);
        }
    }
    public void calculate()
    {
        SqlConnection cnn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ToString());
        cnn1.Open();
        SqlCommand cmdrate = new SqlCommand("select hourly_rate from project where id='" + Request.QueryString["id"] + "'", cnn1);
        int rate = Convert.ToInt32(cmdrate.ExecuteScalar());
        int typevalue = type();
        if (txtedithoursday.ReadOnly == true)
        {
            int val = 8;
            txtedithoursday.Text = val.ToString();
        }
        if (txtedithourlyrate.ReadOnly == true)
        {
            txtedithourlyrate.Text = rate.ToString();
        }

        SqlCommand cmdresources = new SqlCommand("select resources from project where id='" + Request.QueryString["id"] + "'", cnn1);
        var resources = Convert.ToInt32(cmdresources.ExecuteScalar());
        cnn1.Close();
        if (typevalue == 0)
        {
            if (txteditcompletedhours.Text.ToString() == string.Empty)
            {
                int val = 0;
                txteditcompletedhours.Text = val.ToString();
            }
            if (txtedithourlyrate.Text.ToString() == string.Empty)
            {
                int val = 0;
                txtedithourlyrate.Text = val.ToString();
            }
            var hourday = Convert.ToUInt32(txteditcompletedhours.Text.ToString());
            var hourrate = Convert.ToUInt32(txtedithourlyrate.Text.ToString());
            txtedittotalpay.Text = Convert.ToInt32(hourday * hourrate * resources).ToString();
        }
        else if (typevalue == 1)
        {
            txtedithourlyrate.ReadOnly = true;
            if (txtedithourlyrate.Text.ToString() == string.Empty)
            {
                int val = 0;
                txteditcompletedhours.Text = val.ToString();
            }
            DateTime startdate;
            DateTime enddate;
            TimeSpan remaindate;
            startdate = DateTime.Parse(txteditstartdate.Text).Date;
            var date = txteditenddate.Text.ToString();
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
            if (txteditspecialholidays.ReadOnly == true)
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
                    if (int.TryParse(txteditspecialholidays.Text.ToString(), out number))
                    {
                        spclholidays = Convert.ToInt32(txteditspecialholidays.Text.ToString());
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
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Special holidays must be less than days')", true);
            }
            else
            {
                days = days + 1 - (count + spclholidays);
                var hours = Convert.ToInt32(txtedithoursday.Text.ToString());
                txteditcompletedhours.Text = (days * hours * resources).ToString();
                var complete = Convert.ToInt32(txteditcompletedhours.Text.ToString());
                var hourrate = Convert.ToInt32(txtedithourlyrate.Text.ToString());
                txtedittotalpay.Text = Convert.ToInt32(complete * hourrate).ToString();
            }
        }
    }

    protected void txteditinvoicedate_Load(object sender, EventArgs e)
    {
        try
        {
            DateTime d1 = Convert.ToDateTime(txteditstartdate.Text.ToString());
            DateTime d2 = Convert.ToDateTime(txteditenddate.Text.ToString());
            if (d1 > d2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Start date must be less than end date')", true);
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid datas present')", true);
        }
    }

    protected void btnEditInvoiceCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("currentprojectdetails.aspx?ID=" + Request.QueryString["id"]);
    }
    protected void imgedittxtspecialholidays_Click(object sender, ImageClickEventArgs e)
    {
        txteditspecialholidays.ReadOnly = false;
    }
    protected void imgedittxthoursday_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1 )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hours of day in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txtedithoursday.ReadOnly = false;
        }
    }
    protected void imgedittxthourlyrate_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hourly rate in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txtedithourlyrate.ReadOnly = false;
        }
    }
    protected void imgedittxtcompletedhours_Click(object sender, ImageClickEventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            txteditcompletedhours.ReadOnly = false;
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
    protected void txteditcompletedhours_TextChanged(object sender, EventArgs e)
    {
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours value in FTE Projects. Kindly select the dates')", true);
        }
        int number;
        if (int.TryParse(txteditcompletedhours.Text, out number))
        {
            calculate();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in Completed hours')", true);
        }
    }
    protected void txtedithourlyrate_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the hourly rate in FTE Projects. Kindly select the dates')", true);
        }
        else
        {
            if (int.TryParse(txtedithourlyrate.Text, out number))
            {
                calculate();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in hours rate field')", true);
            }
        }
    }
    protected void txtedithoursday_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (typevalue == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You cant change the completed hours value in FTE Projects. Kindly select the dates')", true);
        }
        else if (int.TryParse(txtedithoursday.Text, out number))
        {
            calculate();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Invalid data in hours per day field')", true);
        }
    }
    protected void txteditspecialholidays_TextChanged(object sender, EventArgs e)
    {
        int number;
        int typevalue = type();
        if (int.TryParse(txteditspecialholidays.Text, out number))
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