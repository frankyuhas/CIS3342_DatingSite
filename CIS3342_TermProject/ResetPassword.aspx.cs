using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;

namespace CIS3342_TermProject
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSecurityQuestion.Visible = false;
                txtSecAnswer.Visible = false;
                dividingLine.Visible = false;
                lblError.Visible = false;
                btnAnswerSecQuestion.Visible = false;
                lblNewPassword.Visible = false;
                txtNewPassword.Visible = false;
                btnSubmitNewPass.Visible = false;
                dividingLine2.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                lblSecurityQuestion.Visible = true;
                txtSecAnswer.Visible = true;
                dividingLine.Visible = true;
                btnAnswerSecQuestion.Visible = true;
                String question1 = "What town were you born in?";
                String question2 = "What is the name of your first pet?";
                String question3 = "What high school did you attend?";

                Random rnd = new Random();

                int num = rnd.Next(1, 4);
                Session.Add("QuestionNum", num);

                if (num == 1)
                {
                    lblSecurityQuestion.Text = question1;
                }
                else if (num == 2)
                {
                    lblSecurityQuestion.Text = question2;
                }
                else
                {
                    lblSecurityQuestion.Text = question3;
                }


            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Please enter an Email.";
            }

        }

        protected void btnAnswerSecQuestion_Click(object sender, EventArgs e)
        {
            String userEmail = txtEmail.Text;
            int questionNum = Int32.Parse(Session["QuestionNum"].ToString());
            String answer = txtSecAnswer.Text;

            DBConnect objDB = new DBConnect();

            String sqlStr = "SELECT SecAnswer1, SecAnswer2, SecAnswer3 FROM TP_Users WHERE EmailAddress= '" + userEmail + "'";
            DataSet myData = objDB.GetDataSet(sqlStr);

            String correctAnswer = myData.Tables[0].Rows[0][questionNum - 1].ToString();

            if (answer == correctAnswer)
            {
                lblError.Visible = true;
                lblError.Text = "Correct";
                lblNewPassword.Visible = true;
                txtNewPassword.Visible = true;
                btnSubmitNewPass.Visible = true;
                dividingLine2.Visible = true;
            }

        }

        protected void btnSubmitNewPass_Click(object sender, EventArgs e)
        {
            String userEmail = txtEmail.Text;

            String plainTextPassword = txtNewPassword.Text;
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





            DBConnect objDB = new DBConnect();
            String sqlStr = "UPDATE TP_Users SET Password='" + encryptedPassword + "' WHERE EmailAddress='" + userEmail + "'";
            int result = objDB.DoUpdate(sqlStr);

            if (result == -1)
            {
                lblError.Visible = true;
                lblError.Text = "Error";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}