using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Web.Security;

public partial class Abandant_projects : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    SqlConnection con;
    SqlDataAdapter adapt;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empid"] == null)
        {
            Response.Redirect("login.aspx");
        }
  
        if (!IsPostBack)
        {
            ShowData();
            grdabandantprojects.DataBind();
        }
    }

    protected void ShowData()
    {
        dt = new DataTable();
        con = new SqlConnection(cs);
        con.Open();

        adapt = new SqlDataAdapter(@"Select p.id,p.name,p.technology,p.type,p.start_date,p.end_date,p.total_hours,p.hourly_rate,p.total_budget,p.project_status
                                    from project p inner join user_details u on u.emp_id=p.emp_id where p.project_status=2 and p.emp_id='" +Request.QueryString["ID"]+"'", con);
        adapt.Fill(dt);
        int count = (dt.Rows.Count)-1;
        if (dt.Rows.Count > 0)
        {
            for (int i =count; i >= 0; i--)
            {
                int status = Convert.ToInt32(dt.Rows[i]["project_status"]);
                if (status == 0)
                {
                    dt.Rows[i]["project_status"] = "Current";
                }
                else if (status == 1)
                {
                    dt.Rows[i]["project_status"] = "Completed";
                }
                else if (status == 2)
                {
                    dt.Rows[i]["project_status"] = "Abandoned";
                }
            }
            grdabandantprojects.DataSource = dt;
            grdabandantprojects.DataBind();
        }
        int TotalRecords = grdabandantprojects.Rows.Count;
        lblnoofprojects.Text = TotalRecords.ToString();
    }
    protected void btnbac_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx?ID="+Request.QueryString["ID"]);
    }
    protected void Edit(object sender, GridViewEditEventArgs e)
    {
        grdabandantprojects.EditIndex = e.NewEditIndex;
        ShowData();
    }

    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdabandantprojects.EditIndex = -1;
        ShowData();
    }
    protected void Update(object sender, GridViewUpdateEventArgs e)
    {
        string projectId = grdabandantprojects.DataKeys[e.RowIndex].Value.ToString();
        using (SqlConnection con = new SqlConnection(cs))
        {
            string query = "update project set project_status= @project_status where Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                DropDownList ddl= (DropDownList)grdabandantprojects.Rows[e.RowIndex].FindControl("dwstatus");
                int value= ddl.SelectedIndex;
                cmd.Parameters.AddWithValue("@project_status", value);
                cmd.Parameters.AddWithValue("@Id", projectId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();;
                Response.Redirect(Request.RawUrl);
            }
        }
    }
    protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdabandantprojects.PageIndex = e.NewPageIndex;
        ShowData();
    }
    protected void imgbtnlogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}