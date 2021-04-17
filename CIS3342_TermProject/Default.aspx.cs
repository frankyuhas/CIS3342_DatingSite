using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CIS3342_TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        SqlCommand objCommand = new SqlCommand();
        DBConnect dBConnect = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_signin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != null && txtPassword.Text != null)
            {
                DataSet mydata = getLoginData(txtEmail.Text, txtPassword.Text);

                int size = mydata.Tables[0].Rows.Count;
                if (size > 0)
                {
                    Session["UserID"] = dBConnect.GetField("UserID", 0);
                    Response.Redirect("DatingClient.aspx");
                }
                else
                {
                    lblError.Text = "Incorrect Username or Password";
                }
            }

        }

        protected void btnCreate_Account_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        public DataSet getLoginData(String email, String password)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LoginCheck";

            SqlParameter inputEmailAddress = new SqlParameter("@emailAddress", email);
            inputEmailAddress.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputEmailAddress);

            SqlParameter inputPassword = new SqlParameter("@password", password);
            inputPassword.Direction = ParameterDirection.Input;
            objCommand.Parameters.Add(inputPassword);

            DataSet mydata = dBConnect.GetDataSetUsingCmdObj(objCommand);
            return mydata;
        }

    }
}