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
[System.Web.Script.Services.ScriptService]

public partial class Dashboard : System.Web.UI.Page
{
    private string SearchString = "";
    protected void Page_Load()
    {
        DataSet ds = new DataSet("pchart");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from pchart", con);
        con.Open();
        dataAdapter.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                MobileSalesChart.Series["samsung"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["Totalhours"].ToString().Trim()));
                MobileSalesChart.Series["nokia"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["remainghours"].ToString().Trim()));
                // MobileSalesChart.Series["htc"].Points.Add(new DataPoint(i, ds.Tables[0].Rows[i]["htc"].ToString().Trim()));
                MobileSalesChart.Series[0].Points[i].AxisLabel = ds.Tables[0].Rows[i]["project"].ToString().Trim();
            }
        }

        if (!Page.IsPostBack)
        {
            //BindData();
        }
    }

    //protected void BindData()
    //{
    //    SqlDataAdapter da;
    //    SqlConnection con;
    //    DataSet ds = new DataSet();


    //    if (ConfigurationManager.ConnectionStrings != null)
    //    {
    //        con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        DataTable dt = new DataTable();
    //        SqlCommand cmd = new SqlCommand("Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,s.completedhours,s.totalpay From project e LEFT JOIN invoice_details s on e.id = project_id where e.project_status=1 ");
    //        cmd.Connection = con;
    //        sda.SelectCommand = cmd;
    //        sda.Fill(dt);
    //       dtgproject.DataSource = dt;
    //        dtgproject.DataBind();
    //    }
    //}
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        SqlDataAdapter da;
        SqlConnection con;
        DataSet ds = new DataSet();

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        SqlDataAdapter sda = new SqlDataAdapter();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand("Select e.id, e.name, e.total_hours, e.hourly_rate, e.total_budget,e.project_status,s.completedhours,s.totalpay From project e LEFT JOIN invoice_details s on e.id = project_id where e.project_status=" + dwnproject.SelectedValue);
        cmd.Connection = con;
        sda.SelectCommand = cmd;
        sda.Fill(dt);
        //dtgproject.DataSource = dt;
        //dtgproject.DataBind();
    
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
                var cmd = new SqlCommand("select name from project where project_status=1 AND (name like '%" + searchtext + "%')", con);
                //cmd.Parameters.AddWithValue("@Searchtext", searchtext);
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
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Action")
        {
           int id = Convert.ToInt32(e.CommandArgument.ToString());
           Response.Redirect("projectedit.aspx?ID="+id);
        }


    }
}