using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Web.Security;

public partial class findashboard : System.Web.UI.Page
{
    private string SearchString = "";
    public static object status { get; set; }
    public static int a; 

    protected void Page_Load(object sender, EventArgs e)
    {
      
        a = Convert.ToInt32(dropdown.SelectedValue); 
        string empid = Request.QueryString["ID"]; 
        if (!Page.IsPostBack)
        {
            BindData();
    
        }
    }
    protected void BindData()
    {
        status = dropdown.SelectedValue;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        con.Open();
       
        string name = "select name from user_details where emp_id="+Request.QueryString["ID"];
        SqlCommand cmd = new SqlCommand(name, con);
        var data = cmd.ExecuteScalar().ToString();
        
        if (ConfigurationManager.ConnectionStrings != null)
        {
            dtgproject.DataSource = getData(@"select u.name as [name], p.name as [projectName],p.total_hours as [total_hours],
                                    (case WHEN  i.completedhours is NULL then 0 else i.completedhours end) as [completedHours],
                                     (case WHEN  p.total_budget is NULL then 0 else p.total_budget end) as [total_budget],
                                     (case WHEN i.totalpay is NULL then 0 else i.totalpay end) as [totalpay],
                                     (case WHEN p.hourly_rate is NULL then 0 else p.hourly_rate end) as [hourly_rate],
                                     p.id as [id],
                                         (case WHEN i.invoicenumber is NULL then 0 else i.invoicenumber end) as [invoicenumber],
                                         i.status as [invoicestatus]
                                     from user_details u inner join project p
                                      on u.emp_id=p.emp_id 
                                     left outer join invoice_details i on  p.id=i.project_id  where p.finance_assignee='"+data+"'  and   p.project_status="+status);
            dtgproject.DataBind();
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
       int status =Convert.ToInt32( dropdown.SelectedValue);
       if (status == 1)
       {
           dtgproject.Columns[10].Visible = false;
       }
       else
       {
           dtgproject.Columns[10].Visible = true;
       }
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
       con.Open();
       string name = "select name from user_details where emp_id="+Request.QueryString["ID"];
       SqlCommand cmd = new SqlCommand(name, con);
       var data = cmd.ExecuteScalar();
       con.Close();
       dtgproject.DataSource = getData(@"select u.name as [name], p.name as [projectName],p.total_hours as [total_hours],
                                    (case WHEN  i.completedhours is NULL then 0 else i.completedhours end) as [completedHours],
                                     (case WHEN  p.total_budget is NULL then 0 else p.total_budget end) as [total_budget],
                                     (case WHEN i.totalpay is NULL then 0 else i.totalpay end) as [totalpay],
                                     (case WHEN p.hourly_rate is NULL then 0 else p.hourly_rate end) as [hourly_rate],
                                     p.id as [id],
                                         (case WHEN i.invoicenumber is NULL then 0 else i.invoicenumber end) as [invoicenumber],
                                         i.status as [invoicestatus]
                                     from user_details u inner join project p
                                      on u.emp_id=p.emp_id 
                                     left outer join invoice_details i on  p.id=i.project_id  where p.finance_assignee='" + data + "'  and   p.project_status=" + status);
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
                string name = "select name from user_details where emp_id=" + HttpContext.Current.Request.QueryString["ID"];
                SqlCommand cmd1 = new SqlCommand(name, con);
                var data = cmd1.ExecuteScalar();
                var cmd = new SqlCommand("select p.name from project p left join invoice_details i on p.id=i.project_id where p.finance_assignee='" + data + "'  and p.project_status=@status and (p.name like '%" + searchtext + "%')", con);
                cmd.Parameters.AddWithValue("@status", a);
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
        SearchString = textbox1.Text;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        con.Open();
        string name = "select name from user_details where emp_id=" + Request.QueryString["ID"];
        SqlCommand cmd = new SqlCommand(name, con);
        var data = cmd.ExecuteScalar();
        con.Close();
        dtgproject.DataSource = getData(string.Format(@"select u.name as [name], p.name as [projectName],p.total_hours as [total_hours],
                                    (case WHEN  i.completedhours is NULL then 0 else i.completedhours end) as [completedHours],
                                     (case WHEN  p.total_budget is NULL then 0 else p.total_budget end) as [total_budget],
                                     (case WHEN i.totalpay is NULL then 0 else i.totalpay end) as [totalpay],
                                     (case WHEN p.hourly_rate is NULL then 0 else p.hourly_rate end) as [hourly_rate],
                                     p.id as [id],
                                         (case WHEN i.invoicenumber is NULL then 0 else i.invoicenumber end) as [invoicenumber],
                                         i.status as [invoicestatus]
                                     from user_details u inner join project p
                                      on u.emp_id=p.emp_id 
                                     left outer join invoice_details i on  p.id=i.project_id  where p.finance_assignee='" + data + "' and p.project_status={0} and p.name like '%{1}%'", dropdown.SelectedValue, SearchString));
        dtgproject.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dtgproject.EditIndex = e.NewEditIndex;
        BindData();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userid = Convert.ToInt32(dtgproject.DataKeys[e.RowIndex].Value.ToString());
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        GridViewRow row = (GridViewRow)dtgproject.Rows[e.RowIndex];
        Label lblID = (Label)row.FindControl("lblstatus");
        DropDownList statusinvoice = (DropDownList)row.FindControl("invoicestatusdrop");

        string status = statusinvoice.SelectedValue.ToString();
        dtgproject.EditIndex = -1;
        con.Open();

        SqlCommand cmd = new SqlCommand("update invoice_details set status=@status where invoicenumber=@invoicenumber  ", con);
        cmd.Parameters.AddWithValue("@status", status);
        cmd.Parameters.AddWithValue("@invoicenumber", userid);
        cmd.ExecuteNonQuery();
        con.Close();
        BindData();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dtgproject.EditIndex = -1;
        BindData();
    }
    protected void dtgproject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dtgproject.PageIndex = e.NewPageIndex;
        BindData();
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }

    protected void lnkpwd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("change_password.aspx?ID="+Request.QueryString["ID"]);
    }
}