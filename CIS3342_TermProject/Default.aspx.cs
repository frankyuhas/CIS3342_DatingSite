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
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;


namespace CIS3342_TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        SqlCommand objCommand = new SqlCommand();
        DBConnect dBConnect = new DBConnect();

        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_signin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != null && txtPassword.Text != null)
            {
                String plainTextPassword = txtPassword.Text;
                String encryptedPassword;

                UTF8Encoding encoder = new UTF8Encoding();
                Byte[] textBytes;
                textBytes = encoder.GetBytes(plainTextPassword);

                RijndaelManaged rmEncryption = new RijndaelManaged();
                MemoryStream myMemoryStream = new MemoryStream();
                CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                myEncryptionStream.Write(textBytes, 0, textBytes.Length);
                myEncryptionStream.FlushFinalBlock();

                myMemoryStream.Position = 0;
                Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
                myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

                myEncryptionStream.Close();
                myMemoryStream.Close();

                encryptedPassword = Convert.ToBase64String(encryptedBytes);


                DataSet mydata = getLoginData(txtEmail.Text, encryptedPassword);

                int size = mydata.Tables[0].Rows.Count;
                if (size > 0)
                {
                    Session["UserID"] = dBConnect.GetField("UserID", 0);
                    Session["EmailAddress"] = dBConnect.GetField("EmailAddress", 0);
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

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ResetPassword.aspx");
        }
    }
}