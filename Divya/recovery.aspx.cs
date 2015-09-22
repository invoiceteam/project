using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class recovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var se=Session["email"];
        if ( se== null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString;
            con.Open();
            var cmd = new SqlCommand("select name from user_details where mail_id= '" + Session["email"] + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            var s = cmd.ExecuteScalar();
            TextBox1.Text = s.ToString();
        }
    }
}