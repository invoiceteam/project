using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Edit : System.Web.UI.Page
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
            con.Open();
            string poin = "select period_of_invoice from project where id = " + Request.QueryString["id"];
            SqlCommand scamd = new SqlCommand(poin, con);
            string period = "select period_of_invoice from invoice_period ";
            SqlDataAdapter periodadapt = new SqlDataAdapter(period, con);
            DataTable techtabl = new DataTable();
            periodadapt.Fill(techtabl);
            ddlpoi.DataSource = techtabl;
            ddlpoi.DataTextField = "period_of_invoice";
            ddlpoi.DataValueField = "period_of_invoice";
            ddlpoi.SelectedValue = scamd.ExecuteScalar().ToString();

            ddlpoi.DataBind();


            string top = "select type from project where id = " + Request.QueryString["id"];
            SqlCommand scmd = new SqlCommand(top, con);
            string techft = "select * from type_of_project";
            SqlDataAdapter adaptee1 = new SqlDataAdapter(techft, con);
            DataTable techtab = new DataTable();
            adaptee1.Fill(techtab);
            ddltype.DataSource = techtab;
            ddltype.DataTextField = "type";
            ddltype.DataValueField = "id";
            ddltype.SelectedValue = scmd.ExecuteScalar().ToString();
            ddltype.DataBind();

            string cmde2 = "select technology from project where id = " + Request.QueryString["id"];
            SqlCommand command12e = new SqlCommand(cmde2, con);
            string cmd1e = "select technology from technology";
            SqlDataAdapter adptee1 = new SqlDataAdapter(cmd1e, con);
            DataTable dt1e = new DataTable();
            adptee1.Fill(dt1e);
            ddltech.DataSource = dt1e;
            ddltech.DataTextField = "technology";
            ddltech.DataValueField = "technology";
            ddltech.SelectedValue = command12e.ExecuteScalar().ToString();
            ddltech.DataBind();

            string poc = "select   poc_name from sample where project_id=" +Request.QueryString["id"];
            SqlDataAdapter adapt = new SqlDataAdapter(poc, con);
            DataTable dat = new DataTable();
            adapt.Fill(dat);
            ddlpoc.DataSource = dat;
            ddlpoc.DataTextField = "poc_name";
            ddlpoc.DataValueField = "poc_name";
            ddlpoc.DataBind();

            string sqlquery = "SELECT name FROM project WHERE id = " + Request.QueryString["id"];
            SqlCommand command = new SqlCommand(sqlquery, con);
            txtname.Text = command.ExecuteScalar().ToString();
            txtname.DataBind();

            string resource = "SELECT resources FROM project WHERE id = " + Request.QueryString["id"];
            SqlCommand rescmd = new SqlCommand(resource, con);
            txtresources1.Text = rescmd.ExecuteScalar().ToString();
            txtresources1.DataBind();

            string sqlquery1 = "SELECT description FROM project WHERE id = " + Request.QueryString["id"];
            SqlCommand command1 = new SqlCommand(sqlquery1, con);
            txtdesc.Text = command1.ExecuteScalar().ToString();
            txtdesc.DataBind();

            string assgn = "select finance_assignee from project where id = " + Request.QueryString["id"];
            SqlCommand sslassg = new SqlCommand(assgn, con);
            string fassgn = "select name from user_details where type=1";
            SqlDataAdapter adapt1 = new SqlDataAdapter(fassgn, con);
            DataTable dt2 = new DataTable();
            adapt1.Fill(dt2);
            ddlassignee.DataSource = dt2;
            ddlassignee.DataTextField = "name";
            ddlassignee.DataValueField = "name";
            ddlassignee.SelectedValue = sslassg.ExecuteScalar().ToString();
            ddlassignee.DataBind();

            string sqlquery2 = "SELECT start_date FROM project WHERE  id = " +Request.QueryString["id"];
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            txtstart.Text = command2.ExecuteScalar().ToString();
            txtstart.DataBind();

            string sqlquery3 = "SELECT end_date FROM project WHERE id = " + Request.QueryString["id"];
            SqlCommand command3 = new SqlCommand(sqlquery3, con);
            txtenddate.Text = command3.ExecuteScalar().ToString();
            txtenddate.DataBind();

            string sqlquery4 = "SELECT total_hours FROM project WHERE id = " + Request.QueryString["id"];
            SqlCommand command4 = new SqlCommand(sqlquery4, con);
            txthours.Text = command4.ExecuteScalar().ToString();
            txthours.DataBind();

            string sqlquery15 = "SELECT hourly_rate FROM project WHERE  id = " + Request.QueryString["id"];//fNameTemp
            SqlCommand command5 = new SqlCommand(sqlquery15, con);
            txtrate.Text = command5.ExecuteScalar().ToString();
            txtrate.DataBind();



            con.Close();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        String qry = "select period_of_invoice  from invoice_period   where id=" + ddltype.SelectedValue;
        SqlDataAdapter adpt = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        ddlpoi.DataSource = dt;
        ddlpoi.DataTextField = "period_of_invoice";
        ddlpoi.DataValueField = "period_of_invoice";
        ddlpoi.DataBind();

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);


        sqlConn.Open();
        string query = @"UPDATE project SET name=@name,technology=@technology, type=@type, description=@description,period_of_invoice=@period_of_invoice, finance_assignee=@finance_assignee,start_date=@start_date, end_date=@end_date,total_hours=@total_rate,hourly_rate=@hourly_rate,project_status=@project_status,total_budget=@total_budget OUTPUT INSERTED.ID WHERE id="+ Request.QueryString["id"];
        SqlCommand command = new SqlCommand(query, sqlConn);
        command.Parameters.AddWithValue("@name", txtname.Text);
        command.Parameters.AddWithValue("@technology", ddltech.Text);
        command.Parameters.AddWithValue("@type", ddltype.Text);
        command.Parameters.AddWithValue("@description", txtdesc.Text);
        command.Parameters.AddWithValue("@period_of_invoice", ddlpoi.Text);
        command.Parameters.AddWithValue("@finance_assignee", ddlassignee.Text);
        command.Parameters.AddWithValue("@start_date", txtstart.Text);
        command.Parameters.AddWithValue("@end_date", txtenddate.Text);
        command.Parameters.AddWithValue("@total_rate", txthours.Text);
        command.Parameters.AddWithValue("@hourly_rate", txtrate.Text);
        command.Parameters.AddWithValue("@project_status", ddlstatus.SelectedValue);
        int hours;
        hours = Convert.ToInt32(txthours.Text.ToString());
        hours = int.Parse(txthours.Text.ToString());

        int hrate = Convert.ToInt32(txtrate.Text.ToString());
        hrate = int.Parse(txtrate.Text.ToString());

        int total = hours * hrate;
        command.Parameters.AddWithValue("@total_budget", total);
        command.ExecuteNonQuery();
        var projectID = command.ExecuteScalar();
        command.Parameters.AddWithValue("@project_id", SqlDbType.Int).Value = projectID;
        
        ScriptManager.RegisterStartupScript(this, this.GetType(),
       "alert",
       "alert('Project details saved sucessfully');window.location ='currentprojectdetails.aspx'",
       true);
        Response.Redirect("currentprojectdetails.aspx?id=" + Request.QueryString["id"]);
        sqlConn.Close();

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("currentprojectdetails.aspx?id="+Request.QueryString["id"]);
    }
    protected void status_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}