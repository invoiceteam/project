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
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString);
            con.Open();
            string cmd = "select distinct  p_invoice from project";

            SqlDataAdapter adpt = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "p_invoice";
            DropDownList1.DataValueField = "p_invoice";
            DropDownList1.DataBind();
            
            string sqlquery = "SELECT p_name FROM project WHERE h_rate = " + 8;
            SqlCommand command = new SqlCommand(sqlquery, con);
            TextBox2.Text = command.ExecuteScalar().ToString();
            TextBox2.DataBind();
            string sqlquery1 = "SELECT p_desc FROM project WHERE h_rate = " + 8;
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

            string cmd1 = "select technology from technology";

            SqlDataAdapter adpt1 = new SqlDataAdapter(cmd1, con);
            DataTable dt1 = new DataTable();
            adpt1.Fill(dt1);
            dropdown.DataSource = dt1;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();
          
            string sqlquery2 = "SELECT s_date FROM project WHERE h_rate = " + 8;
            SqlCommand command2 = new SqlCommand(sqlquery2, con);
            start.Text = command2.ExecuteScalar().ToString();
            start.DataBind();

            string sqlquery3 = "SELECT e_date FROM project WHERE h_rate = " + 8;
            SqlCommand command3 = new SqlCommand(sqlquery3, con);
            enddate.Text = command3.ExecuteScalar().ToString();
            enddate.DataBind();

            string sqlquery4 = "SELECT t_hours FROM project WHERE h_rate = " + 8;
            SqlCommand command4 = new SqlCommand(sqlquery4, con);
            thours.Text = command4.ExecuteScalar().ToString();
            thours.DataBind();

            string sqlquery15 = "SELECT h_rate FROM project WHERE h_rate = " + 8;//fNameTemp
            SqlCommand command5 = new SqlCommand(sqlquery15, con);
            rate.Text = command5.ExecuteScalar().ToString();
            rate.DataBind();
            con.Close();

        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        String qry = "select distinct p_invoice from project  where p_types=" + DropDownList2.SelectedValue;
        SqlDataAdapter adpt = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "p_invoice";
        DropDownList1.DataValueField = "p_invoice";
        DropDownList1.DataBind();
        
    }



    //protected void btnsubmit_Click(object sender, EventArgs e)
    //{
    //    DateTime d1 = Convert.ToDateTime(start.Text.ToString());
    //    DateTime d2 = Convert.ToDateTime(enddate.Text.ToString());
    //    if (d1 > d2)
    //    {

    //        ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('Start date must be less than end date')", true);
    //    }
    //}
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConn = new SqlConnection(@"Server=AMX-523-PC; Database=Employee_details; User Id=sa; password= sa5");


        sqlConn.Open();
        while (Request.Form["pocName[]"] != null)
        {
            int i = 0;
            string s = Request.Form["pocName[]"];

            string[] words = s.Split(',');
            foreach (string word in words)
            {
                string que = "INSERT INTO poc(poc1) values (@name)";
                SqlCommand myCommand = new SqlCommand(que, sqlConn);
                myCommand.Parameters.AddWithValue("@name", word);


                myCommand.ExecuteNonQuery();
            }
        }



        string query = "INSERT INTO project (p_name,p_types,p_desc,p_invoice,f_assignee,s_date,e_date,t_hours,h_rate) values (@pname,@ptypes,@pdesc,@pinvoice,@assignee,@sdate,@edate,@thours,@hrate)";
        SqlCommand command = new SqlCommand(query, sqlConn);
        command.Parameters.AddWithValue("@pname", TextBox2.Text);
        command.Parameters.AddWithValue("@ptypes", DropDownList2.Text);
        command.Parameters.AddWithValue("@pdesc", desc.Text);
        command.Parameters.AddWithValue("@pinvoice", DropDownList1.Text);
        command.Parameters.AddWithValue("@assignee", DropDownList3.Text);
        command.Parameters.AddWithValue("@sdate", start.Text);
        command.Parameters.AddWithValue("@edate", enddate.Text);
        command.Parameters.AddWithValue("@thours", thours.Text);
        command.Parameters.AddWithValue("@hrate", rate.Text);
        //command.Parameters.AddWithValue("@sow", sowupload.Text);
        command.ExecuteNonQuery();
        sqlConn.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("Default.aspx");

    }

    
}