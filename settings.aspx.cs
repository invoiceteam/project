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

        SqlConnection con;
        DataSet ds = new DataSet();


        if (ConfigurationManager.ConnectionStrings != null)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);


            string poiv = "select period_of_invoice from invoice_period where id=0";

            SqlDataAdapter adaptt = new SqlDataAdapter(poiv, con);
            DataTable dat = new DataTable();
            adaptt.Fill(dat);
            periodinvoice.DataSource = dat;
            periodinvoice.DataTextField = "period_of_invoice";
            periodinvoice.DataValueField = "period_of_invoice";
            periodinvoice.DataBind();





            string poc = "select * from type_of_project";

                SqlDataAdapter adapt = new SqlDataAdapter(poc, con);
                DataTable type1 = new DataTable();
                adapt.Fill(type1);
                tpesofproject.DataSource = type1;
                typesofproject.DataSource = type1;
                tpesofproject.DataTextField = "type";
                tpesofproject.DataValueField = "type";
                typesofproject.DataTextField = "type";
                typesofproject.DataValueField = "id";
                typesofproject.DataBind();
                tpesofproject.DataBind();

            string cmd = "select technology from technology";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dropdown.DataSource = dt;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();

            string type = "select type from type_of_project";
            SqlDataAdapter adpt1 = new SqlDataAdapter(type, con);
            DataTable dwt = new DataTable();
            adpt1.Fill(dwt);
            DropDownList1.DataSource = dwt;
            DropDownList1.DataTextField = "type";
            DropDownList1.DataValueField = "type";
            DropDownList1.DataBind();

            //string poi = "select period_of_invoice from period_of_invoice";

            //SqlDataAdapter poc1 = new SqlDataAdapter(poi, con);
            //DataTable dat = new DataTable();
            //poc1.Fill(dat);
            //DropDownList2.DataSource = dat;
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
        SqlCommand cmd = new SqlCommand(" UPDATE user_details SET pwd=@password where pwd=@old", con);


        cmd.Parameters.AddWithValue("@password", TextBox3.Text);
        cmd.Parameters.AddWithValue("@old", TextBox1.Text);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully change password')", true);
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
       if (!string.IsNullOrWhiteSpace(TextBox4.Text))
       {
           SqlCommand cmd = new SqlCommand("INSERT INTO technology (technology) VALUES (@technology)", con);
           cmd.Parameters.AddWithValue("@technology", TextBox4.Text);

           cmd.ExecuteNonQuery();
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Technology added Successfully')", true);
            
        }
        else
       {

           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot leave this empty ')", true);
        }
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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Technology removed Successfully')", true);
        con.Close();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (!string.IsNullOrWhiteSpace(TextBox5.Text))
       {
        SqlCommand cmd = new SqlCommand("INSERT INTO type_of_project (type) VALUES (@type)", con);
        cmd.Parameters.AddWithValue("@type", TextBox5.Text);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Types of project added Successfully')", true);

       }
         else
         {

             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot leave this empty ')", true);
         }
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM type_of_project WHERE type=@type", con);
        cmd.Parameters.AddWithValue("@type", DropDownList1.Text);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Removed Successfully')", true);
        con.Close();
    }


    protected void typesofproject_SelectedIndexChanged(object sender, EventArgs e)
    {
        String qry = "select period_of_invoice  from invoice_period   where id=" + typesofproject.SelectedValue;
        SqlDataAdapter adpt = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        periodinvoice.DataSource = dt;
        periodinvoice.DataTextField = "period_of_invoice";
        periodinvoice.DataValueField = "period_of_invoice";
        periodinvoice.DataBind();
    }

    protected void addperiodinvoice_Click(object sender, EventArgs e)
    {
       
       
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (!string.IsNullOrWhiteSpace(txtnewinvoice.Text))
        {
        SqlCommand cmd = new SqlCommand("INSERT INTO invoice_period (id,period_of_invoice) VALUES (@id,@period_of_invoice)", con);


        cmd.Parameters.AddWithValue("@period_of_invoice", txtnewinvoice.Text);
        cmd.Parameters.AddWithValue("@id", typesofproject.SelectedValue);
        cmd.ExecuteNonQuery();
         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Period of invoice added Successfully')", true);
            
        }
        else
       {

           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot leave this empty ')", true);
        }
        con.Close();

    }
    protected void removepinvoice_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM invoice_period WHERE period_of_invoice=@period_of_invoice", con);
        cmd.Parameters.AddWithValue("@period_of_invoice", periodinvoice.SelectedValue);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Removed Successfully')", true);
        con.Close();
    }

    protected void reload_Click(object sender, EventArgs e)
    {
        Response.Write(Request.RawUrl.ToString());
    }
}