﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticationforms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(txtusername.Text, txtpwd.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtusername.Text, chkBoxRememberMe.Checked);
            }
        }
    }
}