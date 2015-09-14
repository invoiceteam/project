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

public partial class Dashboard : System.Web.UI.Page
{
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
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from StudentRecord");

            //cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@Filter", ViewState["Filter"].ToString());

            cmd.Connection = con;

            sda.SelectCommand = cmd;

            sda.Fill(dt);

            GridView1.DataSource = dt;

            GridView1.DataBind();
        }
    }
}