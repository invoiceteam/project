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
            periodinvoice.Items.Insert(0, new ListItem("--Select period of invoice--", "0"));




            string poc = "select * from type_of_project";

                SqlDataAdapter adapt = new SqlDataAdapter(poc, con);
                DataTable type1 = new DataTable();
                adapt.Fill(type1);
                ddltpesofproject.DataSource = type1;
                ddltypesofproject.DataSource = type1;
                ddltpesofproject.DataTextField = "type";
                ddltpesofproject.DataValueField = "type";
                ddltypesofproject.DataTextField = "type";
                ddltypesofproject.DataValueField = "id";
                ddltypesofproject.DataBind();
                ddltpesofproject.DataBind();
                ddltpesofproject.Items.Insert(0, new ListItem("--Types of projects--", "0"));
            
            string cmd = "select technology from technology";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddltechnology.DataSource = dt;
            ddltechnology.DataTextField = "technology";
            ddltechnology.DataValueField = "technology";
            ddltechnology.DataBind();
            ddltechnology.Items.Insert(0, new ListItem("--Select remove technology--", "0"));
            string type = "select type from type_of_project";
            SqlDataAdapter adpt1 = new SqlDataAdapter(type, con);
            DataTable dwt = new DataTable();
            adpt1.Fill(dwt);
            ddlremovetype.DataSource = dwt;
            ddlremovetype.DataTextField = "type";
            ddlremovetype.DataValueField = "type";
            ddlremovetype.DataBind();
            ddlremovetype.Items.Insert(0, new ListItem("--Select remove project--", "0"));
            


        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            con.Open();
            string query = "select pwd from user_details where emp_id="+Session["empid"];
            SqlCommand squery = new SqlCommand(query, con);
            var j=squery.ExecuteScalar().ToString();
            var k = txtoldpassword.Text.ToString();
            if (j == k)
            {
                SqlCommand cmd = new SqlCommand(" UPDATE user_details SET pwd=@password where pwd=@old and emp_id=" + Session["empid"], con);


                cmd.Parameters.AddWithValue("@password", txtconfirmpwd.Text);
                cmd.Parameters.AddWithValue("@old", txtoldpassword.Text);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully change password')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Old password should be match so please give correct password')", true);
               
            }
                con.Close();
           
    }
    protected void btntech_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (!string.IsNullOrWhiteSpace(txttechnology.Text))
       {
           SqlCommand cmd = new SqlCommand("INSERT INTO technology (technology) VALUES (@technology)", con);
           cmd.Parameters.AddWithValue("@technology", txttechnology.Text);

           cmd.ExecuteNonQuery();
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Technology added Successfully')", true);
            
        }
        else
       {

           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot leave this empty ')", true);
        }
        con.Close();
    }
    protected void btnremovetech_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (ddltechnology.SelectedItem.ToString() == "--Select remove technology--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the technology')", true);
        }
        else
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM technology WHERE technology=@technology", con);


            cmd.Parameters.AddWithValue("@technology", ddltechnology.Text);

            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Technology removed Successfully')", true);
        }
        con.Close();
    }
    protected void btntype_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (!string.IsNullOrWhiteSpace(txtaddtype.Text))
       {
        SqlCommand cmd = new SqlCommand("INSERT INTO type_of_project (type) VALUES (@type)", con);
        cmd.Parameters.AddWithValue("@type", txtaddtype.Text);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Types of project added Successfully')", true);

       }
         else
         {

             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You cannot leave this empty ')", true);
         }
        con.Close();
    }
    protected void btnremovetype_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        if (ddlremovetype.SelectedItem.ToString() == "--Select remove project--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the project type')", true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM type_of_project WHERE type=@type", con);
            cmd.Parameters.AddWithValue("@type", ddlremovetype.Text);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Removed Successfully')", true);
        }
        con.Close();
    }


    protected void typesofproject_SelectedIndexChanged(object sender, EventArgs e)
    {
        String qry = "select period_of_invoice  from invoice_period   where id=" + ddltypesofproject.SelectedValue;
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
        cmd.Parameters.AddWithValue("@id", ddltypesofproject.SelectedValue);
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
        if (periodinvoice.SelectedItem.ToString() == "--Select period of invoice--")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select the period of invoice')", true);
        }
        else
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM invoice_period WHERE period_of_invoice=@period_of_invoice", con);
            cmd.Parameters.AddWithValue("@period_of_invoice", periodinvoice.SelectedValue);
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Removed Successfully')", true);
        }
        con.Close();
    }

    protected void reload_Click(object sender, EventArgs e)
    {
        Response.Write(Request.RawUrl.ToString());
    }
   
    protected void imbback_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Dashboard.aspx?ID=" + Request.QueryString["ID"]);
    }
}