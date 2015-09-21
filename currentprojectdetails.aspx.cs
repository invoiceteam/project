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

public partial class currentprojectdetails : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["connect"].ToString();
    SqlConnection con;
    SqlDataAdapter adapt;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["empid"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}
        string empid = Request.QueryString["ID"]; 
        if (!IsPostBack)
        {
            
            ShowData();
            GridView1.DataBind();
        }
    }
    protected void ShowData()
    {
        dt = new DataTable();
        con = new SqlConnection(cs);
        con.Open();

        adapt = new SqlDataAdapter("Select invoicenumber,project_id,startdate,enddate,invoicedate,completedhours,totalpay,status from invoice_details where project_id='" + Request.QueryString["id"] + "'", con);

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        try
        {
            //getting id of the project
            SqlCommand id = new SqlCommand("SELECT id  FROM project where name='HFMA'", con);
            var temp = Convert.ToInt32(id.ExecuteScalar());

            //getting name of the project
            SqlCommand name = new SqlCommand("SELECT name  FROM project where id=" + Request.QueryString["id"], con);
            string str = "- " + Convert.ToString(name.ExecuteScalar());
            lblprojectname.Text = str.ToString();
            lblnote.Text = "Invoice Details of project - " + str.ToString();

            //getting technology of the project
            SqlCommand technology = new SqlCommand("SELECT technology  FROM project where id=" + Request.QueryString["id"], con);
            str = "- " + Convert.ToString(technology.ExecuteScalar());
            lbltechnology.Text = str.ToString();

            //getting type of the project
            SqlCommand type = new SqlCommand("SELECT type  FROM project where id=" + Request.QueryString["id"], con);
            int str2 = Convert.ToInt32(type.ExecuteScalar());
            if (str2 == 1)
            {
                lblprojecttype.Text = "- " + "FTE";
            }
            else if(str2==0) { 
                lblprojecttype.Text = "- " + "Fixed";
            }

            //getting totalhours of the project
            SqlCommand totalhours = new SqlCommand("SELECT total_hours  FROM project", con);
            temp = Convert.ToInt32(totalhours.ExecuteScalar());
            lbltotalhours.Text = temp.ToString();

            //getting totalpay for the project
            SqlCommand totalpay = new SqlCommand("SELECT total_budget FROM project", con);
            temp = Convert.ToInt32(totalpay.ExecuteScalar());
            lbltotalpay.Text = temp.ToString();

            SqlCommand sumCompletedHours = new SqlCommand("SELECT SUM(completedhours)  FROM invoice_details where project_id=" + Request.QueryString["id"], con);
            temp = Convert.ToInt32(sumCompletedHours.ExecuteScalar());
            lblchrs.Text = temp.ToString();
            SqlCommand sumCompletedAmount = new SqlCommand("SELECT SUM(totalpay)  FROM invoice_details where project_id=" + Request.QueryString["id"], con);
            temp = Convert.ToInt32(sumCompletedAmount.ExecuteScalar());
            lblcompletedbudjet.Text = temp.ToString();
        }
        catch
        {
            con.Close();
        }
    }

    protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ShowData();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //NewEditIndex property used to determine the index of the row being edited. 
        con = new SqlConnection(cs);
        con.Open();
        GridView1.EditIndex = e.NewEditIndex;
        Label invoicenumber = GridView1.Rows[e.NewEditIndex].FindControl("lbl_invoicenumber") as Label;
        int invoice = Convert.ToInt32(invoicenumber.Text.ToString());
        Session["invoicekey"] = invoice;
        SqlCommand cmdstatus = new SqlCommand("select status from invoice_details where invoicenumber='" + invoicenumber.Text + "'", con);
        var status = cmdstatus.ExecuteScalar();
        if (Convert.ToString(status) == "Sent")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "alert('You are not allowed to edit.. Invoice sent already...!')", true);
        }
        else if (Convert.ToString(status) == "Pending")
        {
            Response.Redirect("editinvoice.aspx?ID="+Request.QueryString["id"]);
        }
        con.Close();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        ShowData();
    }
    protected void btnnewinvoice_Click(object sender, EventArgs e)
    {
        Response.Redirect("newinvoice.aspx?ID="+ Request.QueryString["id"]);
    }
    protected void logout(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        string confirmationValue = Request.Form["confirmValue"];
        if (confirmationValue == "Yes")
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            // get the project id code---

            SqlCommand cmd = new SqlCommand("update invoice_details set status=2 where project_id='" + Request.QueryString["id"] + "'", con);
            Response.Redirect("dashboard.aspx?ID=" + Request.QueryString["id"]);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edit.aspx?id=" + Request.QueryString["id"]);
    }
}