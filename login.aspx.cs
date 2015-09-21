using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;


public partial class _Default : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }
  
  

  protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from user_details where mail_id =@mail_id and pwd=@pwd", con);
        cmd.Parameters.AddWithValue("@mail_id", u_name.Text);
        cmd.Parameters.AddWithValue("@pwd", p_word.Text);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        //Invoice.User.removeSession();
        if (dt.Rows.Count > 0)
        {
        //    Invoice.User user = new Invoice.User()
        //    {
        //        EmailId = dt.Rows[0]["mail_id"].ToString(),
        //        Name = dt.Rows[0]["name"].ToString(),
             int EmpId = int.Parse(dt.Rows[0]["emp_id"].ToString());
            //    Type = dt.Rows[0]["type"].ToString() == "0" ? Invoice.User.userType.Manager : Invoice.User.userType.Finance
            //};
            //Invoice.User.setSession();
            if (dt.Rows[0].Field<string>(0).Equals("0"))
            {
                Session["empid"] = EmpId;
                Response.Redirect("Dashboard.aspx?ID="+EmpId);
            }
            else if (dt.Rows[0].Field<string>(0).Equals("1"))
            {
                
                Response.Redirect("findashboard.aspx?ID="+EmpId);
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("recoverymail.aspx");
    }
}
