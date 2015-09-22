using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

public partial class recoverymail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         if (email.Text != "")
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("select * from user_details where mail_id=@username", con);
            com.Parameters.AddWithValue("@username", email.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string id = email.Text;
                Sendemail(id);
                Response.Redirect("password_change.aspx");
            }
            else
            {
                error.Visible = true;
            }
        }
        else
        {
            error.Visible = true;
        }
    }
    public void Sendemail(string id)
    {
        Random r = new Random();
        long otp = r.Next(7878, 99999);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand("update user_details set otp=@otp where mail_id=@username", con);
        com.Parameters.AddWithValue("@username", email.Text);
        com.Parameters.AddWithValue("@otp", otp);
        com.ExecuteNonQuery();
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("divyalakshmi.ameex@gmail.com", "otp");
            message.To.Add(id);
            message.Subject = "Verification Email";
            message.Body = "Your OTP  " + otp + " ";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("ananth.ameex@gmail.com", "jeyalakshmi");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            Response.Write("Could not send the e-mail - error: " + ex.Message);
        }
    }
    }