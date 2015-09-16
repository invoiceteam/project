using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class settings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }
    public void BindData()
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds = new DataSet();


        if (ConfigurationManager.ConnectionStrings != null)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

            string cmd = "select technology from technology";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dropdown.DataSource = dt;
            dropdown.DataBind();
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();
            string type = "select type from types_of_project";

            SqlDataAdapter adpt1 = new SqlDataAdapter(type, con);
            adpt1.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "type";
            DropDownList1.DataValueField = "type";
            DropDownList1.DataBind();

            //string poi = "select period_of_invoice from period_of_invoice";

            //SqlDataAdapter poc1 = new SqlDataAdapter(poi, con);
            //poc1.Fill(dt);
            //DropDownList2.DataSource = dt;
            //DropDownList2.DataBind();
            //DropDownList2.DataTextField = "period_of_invoice";
            //DropDownList2.DataValueField = "period_of_invoice";
            //DropDownList2.DataBind();


        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
      
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand(" UPDATE change_pwd SET password=@password where password=@old",con);
       
            
            cmd.Parameters.AddWithValue("@password", TextBox3.Text);
            cmd.Parameters.AddWithValue("@old",  TextBox1.Text);
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO technology (technology) VALUES (@technology)", con);


        cmd.Parameters.AddWithValue("@technology", TextBox4.Text);
        
        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM technology WHERE technology=@technology", con);


        cmd.Parameters.AddWithValue("@technology", dropdown.Text);

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO types_of_project (type) VALUES (@type)", con);


        cmd.Parameters.AddWithValue("@type", TextBox5.Text);

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM types_of_project WHERE type=@type", con);


        cmd.Parameters.AddWithValue("@type", DropDownList1.Text);

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO period_of_invoice (period_of_invoice) VALUES (@period_of_invoice)", con);


        cmd.Parameters.AddWithValue("@period_of_invoice", TextBox6.Text);

        cmd.ExecuteNonQuery();
        con.Close();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM period_of_invoice WHERE period_of_invoice=@invoice", con);


        cmd.Parameters.AddWithValue("@invoice", DropDownList2.Text);

        cmd.ExecuteNonQuery();
        con.Close();
    }
}