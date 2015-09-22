using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class change_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        string query = "select pwd from user_details where emp_id=" + Session["empid"];
        SqlCommand squery = new SqlCommand(query, con);
        var j = squery.ExecuteScalar().ToString();
        var k = txtoldpwd.Text.ToString();
        if (j == k)
        {
            SqlCommand cmd = new SqlCommand(" UPDATE user_details SET pwd=@password where pwd=@old and emp_id=" + Session["empid"], con);


            cmd.Parameters.AddWithValue("@password", txtconfrmpwd.Text);
            cmd.Parameters.AddWithValue("@old", txtoldpwd.Text);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully change password')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Old password should be match so please give correct password')", true);

        }
        con.Close();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("findashboard.aspx?ID=" +Request.QueryString["ID"]);
    }
}