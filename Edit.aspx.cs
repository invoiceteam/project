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
            //string que1 = @"select  id from project OUTPUT INSERTED.ID";
            //SqlCommand comd = new SqlCommand(que1, con);
            // var projectID = comd.ExecuteScalar();
            //comd.Parameters.AddWithValue("@project_id", SqlDbType.Int).Value = projectID;

            string cmd = "select distinct  period_of_invoice from project";
            SqlDataAdapter adpt = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "period_of_invoice";
            DropDownList1.DataValueField = "period_of_invoice";
            DropDownList1.DataBind();

            string cmd2 = "select technology from project where id=5";
            SqlCommand command12 = new SqlCommand(cmd2, con);
            string tech1 = "select technology from technology";
            SqlDataAdapter adpte1 = new SqlDataAdapter(tech1, con);
            DataTable dte1 = new DataTable();
            adpte1.Fill(dte1);
            dropdown.DataSource = dte1;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.SelectedValue = command12.ExecuteScalar().ToString();
            dropdown.DataBind();

            string tec = "select technology from technology";
            SqlDataAdapter sadt = new SqlDataAdapter(tec, con);
            DataTable dtab = new DataTable();
            sadt.Fill(dtab);
            dropdown.DataSource = dtab;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();
            dropdown.Items.Insert(0, new ListItem("--Select technology--", "0"));

            string poc = "select   poc_name from sample where project_id=" + 6;
            SqlDataAdapter adapt = new SqlDataAdapter(poc, con);
            DataTable dat = new DataTable();
            adapt.Fill(dat);
            DropDownList4.DataSource = dat;
            DropDownList4.DataTextField = "poc_name";
            DropDownList4.DataValueField = "poc_name";
            DropDownList4.DataBind();

            string sqlquery = "SELECT name FROM project WHERE hourly_rate = " + 12;
            SqlCommand command = new SqlCommand(sqlquery, con);
            TextBox2.Text = command.ExecuteScalar().ToString();
            TextBox2.DataBind();
            string sqlquery1 = "SELECT description FROM project WHERE hourly_rate = " + 12;
            SqlCommand command1 = new SqlCommand(sqlquery1, con);
            desc.Text = command1.ExecuteScalar().ToString();
            desc.DataBind();

            //string sqlquery5 = "SELECT tech FROM project WHERE p_name = " + @pname;

            //SqlDataAdapter adpt8 = new SqlDataAdapter(sqlquery5, con);

            //DataTable dt11 = new DataTable();
            //adpt8.Fill(dt11);
            //dropdown.DataSource = dt11;
            //dropdown.DataTextField = "technology";
            //dropdown.DataValueField = "technology";
            //dropdown.DataBind();
            string cmd1 = "select technology from project where id=5";

            SqlDataAdapter adpt1 = new SqlDataAdapter(cmd1, con);
            DataTable dt1 = new DataTable();
            adpt1.Fill(dt1);
            dropdown.DataSource = dt1;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();

            string assgn = "select finance_assignee from project where id=5";

            SqlDataAdapter adapt1 = new SqlDataAdapter(assgn, con);
            DataTable dt2 = new DataTable();
            adapt1.Fill(dt2);
            DropDownList3.DataSource = dt2;
            DropDownList3.DataTextField = "finance_assignee";
            DropDownList3.DataValueField = "finance_assignee";
            DropDownList3.DataBind();

            string sqlquery2 = "SELECT start_date FROM project WHERE  id="+5;
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            start.Text = command2.ExecuteScalar().ToString();
            start.DataBind();

            string sqlquery3 = "SELECT end_date FROM project WHERE id=5";
            SqlCommand command3 = new SqlCommand(sqlquery3, con);
            enddate.Text = command3.ExecuteScalar().ToString();
            enddate.DataBind();

            string sqlquery4 = "SELECT total_hours FROM project WHERE id=5 ";
            SqlCommand command4 = new SqlCommand(sqlquery4, con);
            thours.Text = command4.ExecuteScalar().ToString();
            thours.DataBind();

            string sqlquery15 = "SELECT hourly_rate FROM project WHERE  id=5";//fNameTemp
            SqlCommand command5 = new SqlCommand(sqlquery15, con);
            rate.Text = command5.ExecuteScalar().ToString();
            rate.DataBind();



            con.Close();

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        String qry = "select distinct period_of_invoice from project  where type=" + DropDownList2.SelectedValue;
        SqlDataAdapter adpt = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "period_of_invoice";
        DropDownList1.DataValueField = "period_of_invoice";
        DropDownList1.DataBind();

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);


        sqlConn.Open();
        string query = @"UPDATE project SET name=@name,technology=@technology, type=@type, description=@description,period_of_invoice=@period_of_invoice, finance_assignee=@finance_assignee,start_date=@start_date, end_date=@end_date,total_hours=@total_rate,hourly_rate=@hourly_rate,project_status=@project_status,total_budget=@total_budget OUTPUT INSERTED.ID WHERE id=5 ";
        SqlCommand command = new SqlCommand(query, sqlConn);
        command.Parameters.AddWithValue("@name", TextBox2.Text);
        command.Parameters.AddWithValue("@technology", dropdown.Text);
        command.Parameters.AddWithValue("@type", DropDownList2.Text);
        command.Parameters.AddWithValue("@description", desc.Text);
        command.Parameters.AddWithValue("@period_of_invoice", DropDownList1.Text);
        command.Parameters.AddWithValue("@finance_assignee", DropDownList3.Text);
        command.Parameters.AddWithValue("@start_date", start.Text);
        command.Parameters.AddWithValue("@end_date", enddate.Text);
        command.Parameters.AddWithValue("@total_rate", thours.Text);
        command.Parameters.AddWithValue("@hourly_rate", rate.Text);
        command.Parameters.AddWithValue("@project_status", status.Text);
        int hours;
        hours = Convert.ToInt32(thours.Text.ToString());
        hours = int.Parse(thours.Text.ToString());

        int hrate = Convert.ToInt32(rate.Text.ToString());
        hrate = int.Parse(rate.Text.ToString());

        int total = hours * hrate;
        command.Parameters.AddWithValue("@total_budget", total);
        command.ExecuteNonQuery();
        var projectID = command.ExecuteScalar();
        command.Parameters.AddWithValue("@project_id", SqlDbType.Int).Value = projectID;


        sqlConn.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Dashboard.aspx");

    }
}