using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Authenticationforms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SUYPC214;Initial Catalog=School;Integrated Security=true");


            SqlCommand cmd = new SqlCommand("insert into tbl_Regist(Name,Password,email,RetryAttempts,Islocked) values(@username, @password,@email,0,0)", con);

             con.Open();
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}