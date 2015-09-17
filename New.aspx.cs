using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class New : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Invoice.User CurrentUser = Invoice.User.getCurrentUser();
            if (CurrentUser != null ? CurrentUser.Type == Invoice.User.userType.Manager : false)
            {
            BindData();
            }
            else
            {
                mngView.Visible = false;
                message.Text = "Sorry, Manager only can Add Project";
            }
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
            string poc = "select * from type_of_project";

            SqlDataAdapter adapt = new SqlDataAdapter(poc, con);
            DataTable dat = new DataTable();
            adapt.Fill(dat);
            DropDownList2.DataSource = dat;
            DropDownList2.DataTextField = "type";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();

            string tec = "select technology from technology";

            SqlDataAdapter sadt = new SqlDataAdapter(tec, con);
            DataTable dtab = new DataTable();
            sadt.Fill(dtab);
            dropdown.DataSource = dtab;
            dropdown.DataTextField = "technology";
            dropdown.DataValueField = "technology";
            dropdown.DataBind();
            dropdown.Items.Insert(0, new ListItem("--Select technology--", "0"));


            string poiv = "select period_of_invoice from invoice_period where id=0";

            SqlDataAdapter adaptt = new SqlDataAdapter(poiv, con);
            DataTable data = new DataTable();
            adaptt.Fill(data);
            DropDownList1.DataSource = data;
            DropDownList1.DataTextField = "period_of_invoice";
            DropDownList1.DataValueField = "period_of_invoice";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select period if invoice--", "0"));

            string fassignee = "select name from user_details where type=1";
            SqlDataAdapter fass = new SqlDataAdapter(fassignee, con);
            DataTable assgnname = new DataTable();
            fass.Fill(assgnname);
            DropDownList3.DataSource = assgnname;
            DropDownList3.DataTextField = "name";
            DropDownList3.DataValueField = "name";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("--Select the assigneename--", "0"));


            con.Close();
        }
    }




    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        String qry = "select period_of_invoice  from invoice_period   where id=" + DropDownList2.SelectedValue;
        SqlDataAdapter adpt = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["connect"].ConnectionString);
        DataTable dt = new DataTable();
        adpt.Fill(dt);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
        DropDownList1.DataTextField = "period_of_invoice";
        DropDownList1.DataValueField = "period_of_invoice";
        DropDownList1.DataBind();
        if (DropDownList2.SelectedValue == "0")
        {
            start.Enabled = false;
            enddate.Enabled = false;
            thours.Enabled = true;
        }
        else if (DropDownList2.SelectedValue == "1")
        {
            start.Enabled = false;
            enddate.Enabled = false;
            thours.Enabled = false;
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {



        SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString);

        Invoice.User CurrentUser = Invoice.User.getCurrentUser();
        sqlConn.Open();

        string query = @"INSERT INTO project (name,technology,type,description,period_of_invoice,finance_assignee,start_date,end_date,total_hours,hourly_rate,project_status,sow_path,emp_id,total_budget)
        OUTPUT INSERTED.ID
        values (@name,@technology,@type,@description,@period_of_invoice,@finance_assignee,@sdate,@edate,@thours,@hrate,@project_status,@sow_path,@emp_id,@total_budget)";
        SqlCommand command = new SqlCommand(query, sqlConn);
        command.Parameters.AddWithValue("@name", TextBox2.Text);
        command.Parameters.AddWithValue("@technology", dropdown.Text);
        command.Parameters.AddWithValue("@type", DropDownList2.Text);
        command.Parameters.AddWithValue("@description", desc.Text);
        command.Parameters.AddWithValue("@period_of_invoice", DropDownList1.Text);
        command.Parameters.AddWithValue("@finance_assignee", DropDownList3.Text);
        command.Parameters.AddWithValue("@sdate", start.Text);
        command.Parameters.AddWithValue("@edate", enddate.Text);
        command.Parameters.AddWithValue("@thours", thours.Text);
        command.Parameters.AddWithValue("@hrate", rate.Text);
        int hours;
        hours = Convert.ToInt32(thours.Text.ToString());
        hours = int.Parse(thours.Text.ToString());

        int hrate = Convert.ToInt32(rate.Text.ToString());
        hrate = int.Parse(rate.Text.ToString());

        int total = hours * hrate;
        command.Parameters.AddWithValue("@total_budget", total);

        command.Parameters.AddWithValue("@project_status", 0);
        command.Parameters.AddWithValue("@sow_path", fileupload());
        command.Parameters.AddWithValue("@emp_id", CurrentUser != null ? CurrentUser.EmpId : 0);
        var projectID = command.ExecuteScalar();
        Session["id"] = projectID;
        string s = Request.Form["pocName[]"];
        string t = Request.Form["pocEmail[]"];
        string[] words = s.Split(',');
        string[] emails = t.Split(',');
        //foreach (string word in words)
        for (int i = 0; i < words.Length; i++)
        {
            string que = "INSERT INTO sample (poc_name,Email_id,project_id) values (@name,@email,@project_id)";
            SqlCommand myCommand = new SqlCommand(que, sqlConn);
            myCommand.Parameters.AddWithValue("@name", words[i]);
            myCommand.Parameters.AddWithValue("@email", emails[i]);
            myCommand.Parameters.AddWithValue("@project_id", SqlDbType.Int).Value = projectID;
            myCommand.ExecuteNonQuery();
        }
        sqlConn.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(),
        "alert",
        "alert('Project details saved sucessfully');window.location ='Dashboardpm.aspx';",
        true);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Dashboard.aspx");
    }
    protected string fileupload()
    {
        string sowPath = "";
        if (sowupload.PostedFile != null ? sowupload.PostedFile.ContentLength > 0 : false)
        {
            try
            {

                string fileName = Path.GetFileName(sowupload.PostedFile.FileName);
                string folder = Server.MapPath("~/Uploaded Files/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                sowupload.PostedFile.SaveAs(Path.Combine(folder, fileName));
                sowPath = Path.Combine("/Uploaded Files/", fileName);
            }
            catch
            {
                sowPath = "";
            }

        }
        return sowPath;
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        start.Enabled = true;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        thours.Enabled = true;
    }
    protected void imgbutton_Click1(object sender, ImageClickEventArgs e)
    {
        enddate.Enabled = true;
    }
}