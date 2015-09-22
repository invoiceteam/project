﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var User = Invoice.User.getCurrentUser();
        if (User!=null)
        {
            lblUserInfo.Text = "Welcome " + User.Name;
        }
    }
}