using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            //    if (FormsAuthentication.Authenticate(txtusername.Text, txtpwd.Text))
            //    {
            //        FormsAuthentication.RedirectFromLoginPage(txtusername.Text, chkBoxRememberMe.Checked);
            //    }

            var name = txtusername.Text;
            var password = txtpwd.Text;
            SqlConnection conn = new SqlConnection("Data Source=SUYPC214;Initial Catalog=School;Integrated Security=true");
            conn.Open();
            SqlCommand command = new SqlCommand("select * from tbl_Regist where Name='" + name + "' and Password='" + password + "'", conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Server.Transfer("Welcome.aspx");
                    }

                    return;
                }
            }

            //Create the SqlCommand object
            SqlCommand cmd = new SqlCommand("CountAttempts", conn);

            //Specify that the SqlCommand is a stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Add the input parameters to the command object
            cmd.Parameters.AddWithValue("@uname", txtusername.Text);


            //Add the output parameter to the command object
            
            cmd.Parameters.Add(new SqlParameter
                ("@counttime", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            });
            //Open the connection and execute the query
            // conn.Open();
            cmd.ExecuteNonQuery();
            int attempts;
                        
            if (cmd.Parameters["@counttime"].Value != DBNull.Value)
            {
                //Retrieve the value of the output parameter
                attempts = (int)cmd.Parameters["@counttime"].Value;
                if (attempts == 5)
                {
                    Label4.Text = "Your account is locked";
                }
                else
                {
                    Label4.Text =  attempts + " Chance finished Out of 5 ";
                }
            }
            else
            {
                Label4.Text = "Ïnvalid User";
            }
        }
    }
}
