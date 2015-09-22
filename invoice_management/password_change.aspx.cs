using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class password_change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["emailid"]==null)
        {
            Response.Redirect("login.aspx");
        }
       
        if (!Page.IsPostBack)
        {
            BindData();
        }

    }
    protected void BindData()
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds = new DataSet();
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        //SqlCommand cmd = new SqlCommand("loaddata", con);
        SqlCommand cmd = new SqlCommand("select * from user_details", con);
        cmd.Connection = con;
        da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        con.Open();
        cmd.ExecuteReader();
        con.Close();
    }
    protected void btnclick(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        con.Open();
        var com = new SqlCommand("select mail_id from user_details  where otp=@otp", con);
        com.Parameters.AddWithValue("@otp", otp.Text);
        SqlDataAdapter da = new SqlDataAdapter(com);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            var s = com.ExecuteScalar();
            string a = s.ToString();
            SqlCommand cmd = new SqlCommand("update user_details set pwd=@otpp where mail_id=@username", con);
            cmd.Parameters.AddWithValue("@username", a);
            cmd.Parameters.AddWithValue("@otpp", TextBox3.Text);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
         "alert",
         "alert('Password changed sucessfully');window.location ='login.aspx';",
         true);
        }
        else
        {
            error.Visible = true;
        }

    }
}