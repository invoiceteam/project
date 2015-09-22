using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System;
using System.Collections.Generic;

public partial class Dashboardpm : System.Web.UI.Page
{
    private string SearchString = "";
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
  
    [WebMethod]
    public static List<string> search(string searchtext)
    {
        List<string> result = new List<string>();
        if (!string.IsNullOrEmpty(searchtext))
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["abConnectionString"].ConnectionString;
            try
            {
                con.Open();
                var cmd = new SqlCommand("select name from project where name like '%" + searchtext + "%'", con);
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
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Action")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("Edit.aspx?ID=" + id);
        }


    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        SearchString = textbox1.Text;
    }
}