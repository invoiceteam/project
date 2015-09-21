using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Services;
using System.Web.Security;
[System.Web.Script.Services.ScriptService]

public partial class Dashboard : System.Web.UI.Page
{

 
    private string SearchString = "";
    protected void Page_Load()
    {

        if (Session["empid"] == null)
        {
            Response.Redirect("login.aspx");
        }
       
        chartbar();
        
    string empid = Request.QueryString["ID"]; 
        if (!Page.IsPostBack)
        {
            BindData();

        }
    }

    protected void chartbar()
    {
        status = ddldwnproject.SelectedValue;
        DataSet ds = new DataSet("project");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlDataAdapter dataAdapter = new SqlDataAdapter("Select e.name,e.total_hours,sum((case WHEN  i.completedhours is NULL then 0 else i.completedhours end)) as [completedhours] from project e left join invoice_details i on e.id=i.project_id where e.project_status='"+status+"' and  e.emp_id='"+Session["empid"]+"' group by name,total_hours", con);
        con.Open();
        dataAdapter.Fill(ds);
       if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        int total = Convert.ToInt32(ds.Tables[0].Rows[i]["total_hours"].ToString().Trim());
                        int completed = Convert.ToInt32(ds.Tables[0].Rows[i]["completedhours"].ToString().Trim());
                        string pending = (total - completed).ToString();
                        MobileSalesChart.Series["pending"].Points.Add(new DataPoint(i, pending));
                       
                            MobileSalesChart.Series["completed"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["completedhours"].ToString().Trim()));    
                        MobileSalesChart.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["name"].ToString().Trim();
                    }
                }
           
    }
    protected void BindData()
    {
        string empval = "select emp_id from project where emp_id="+Session["empid"];
        string invoiceval = "select p.id from project p inner join invoice_details i on p.id=i.project_id where i.status='pending' and emp_id=" + Session["empid"];
        string invoiceval1 = "select p.id from project p inner join invoice_details i on p.id=i.project_id where i.status='sent' and emp_id=" + Session["empid"];
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();

        SqlCommand val = new SqlCommand(empval, con);
        SqlCommand val1 = new SqlCommand(invoiceval, con);
        SqlCommand val2 = new SqlCommand(invoiceval1, con);
        var j = val.ExecuteScalar();
        var k = val1.ExecuteScalar();
        var l = val2.ExecuteScalar();
        if (j == null)
        {
            lblwelcome1.Visible = true;

        }
        else
        {
            dashboard();
        }
        if (k == null)
        {
            pnlpending.Visible = true;
        }
        else
        {
            pending1();
        }
        if (l == null)
        {
            pnlraised.Visible = true;
        }
        else
        {
            raised1();
        }
      
    }
    protected void dashboard()
    {
        if (ConfigurationManager.ConnectionStrings != null)
        {
            dtgproject.DataSource = getData(@"Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,sum((case WHEN  s.completedhours is NULL then 0 else s.completedhours end)) as completedhours,sum((case WHEN  s.totalpay is NULL then 0 else s.totalpay end)) as totalpay
            From project e LEFT JOIN invoice_details s on e.id = project_id where e.project_status=0 and emp_id='" + Session["empid"] + "' group by id, name,total_hours,hourly_rate,total_budget,project_status");

            dtgproject.DataBind();

        }
    }

    protected void pending1()
    {
        if (ConfigurationManager.ConnectionStrings != null)
        {
            dtgpending.DataSource = getData(@"Select e.invoicenumber,e.project_id,s.name from invoice_details e inner join project s on e.project_id=s.id where e.status='pending' and s.emp_id=" + Session["empid"]);

            dtgpending.DataBind();

        }
    }
    protected void raised1()
    {
        if (ConfigurationManager.ConnectionStrings != null)
        {
            dtgraisedinvoice.DataSource = getData(@"Select e.invoicenumber,e.project_id,s.name from invoice_details e inner join project s on e.project_id=s.id where e.status='sent' and s.emp_id='" + Session["empid"] + "'");

            dtgraisedinvoice.DataBind();

        }
    }
    protected DataTable getData(string query) 
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand(query);
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        return dt;
        
    }

    public void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        status = ddldwnproject.SelectedValue;
        dtgproject.DataSource = getData(@"Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,sum((case WHEN  s.completedhours is NULL then 0 else s.completedhours end)) as completedhours,sum((case WHEN  s.totalpay is NULL then 0 else s.totalpay end)) as totalpay
            From project e LEFT JOIN invoice_details s on e.id = project_id where emp_id= '"+ Session["empid"]+"' and e.project_status='"+ status+"' group by id, name,total_hours,hourly_rate,total_budget,project_status" );
        dtgproject.DataBind();
     
    }
     [WebMethod]
    public static List<string> search(string searchtext)
    {
        List<string> result = new List<string>();
        if (!string.IsNullOrEmpty(searchtext))
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            try
            {
                con.Open();
                var cmd = new SqlCommand("select distinct p.name from project p left join invoice_details i on p.id=i.project_id where p.project_status=@status AND p.emp_id='" + HttpContext.Current.Session["empid"] + "' and (name like '%" + searchtext + "%')", con);
                cmd.Parameters.AddWithValue("@status",status);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add(dr["name"].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }

        }
        return result;
    }
    
    protected void btn_search_Click(object sender, EventArgs e)
    {
        SearchString = txtsearch.Text;
        dtgproject.DataSource = getData(string.Format(@"Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,sum((case WHEN  s.completedhours is NULL then 0 else s.completedhours end)) as completedhours,
sum((case WHEN  s.totalpay is NULL then 0 else s.totalpay end)) as totalpay From project e LEFT JOIN invoice_details s on e.id=s.project_id where e.emp_id ='" + Session["empid"] + "' and e.project_status={0} and e.name like '%{1}%' group by id, name,total_hours,hourly_rate,total_budget,project_status ", ddldwnproject.SelectedValue, SearchString));
        dtgproject.DataBind();
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
            if (e.CommandName == "Action")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("currentprojectdetails.aspx?ID=" + id);
            }
          
       

    }
    protected void logout(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    public static object status { get; set; }
    protected void add_project_Click(object sender, EventArgs e)
    {
        Response.Redirect("New.aspx?ID="+Session["empid"] );
    }


    protected void dtgproject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    
    dtgproject.PageIndex = e.NewPageIndex;
    BindData();
    }
    protected void Imgsettings1_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("settings.aspx?ID=" + Session["empid"]);
    }
    protected void btnabort_Click(object sender, EventArgs e)
    {
        Response.Redirect("abandoned-projects.aspx?ID=" + Session["empid"]);
    }
}