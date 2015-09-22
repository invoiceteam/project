using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
     
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into user_details(type,emp_id,name,mail_id,pwd) values('" + dropdown.SelectedIndex + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", con);
        cmd.ExecuteNonQuery();
       ScriptManager.RegisterStartupScript(this, this.GetType(),
        "alert",
        "alert('User details saved sucessfully');window.location ='login.aspx';",
        true);
    }
}