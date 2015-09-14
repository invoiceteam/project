using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class popup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //public string name{ get; set; };
        SqlConnection cnn = new SqlConnection("Data Source=AMX-535-PC;Initial Catalog=bpop;Integrated Security=True");
        cnn.Open();
        SqlCommand cmd = new SqlCommand("select * from Table_1", cnn);
        SqlCommand com = new SqlCommand("insert into Table_1 values(@name)", cnn);
        com.Parameters.AddWithValue("@name", txtname.Text.ToString());
        com.ExecuteNonQuery();
        cnn.Close();  
    }
}