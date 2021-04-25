using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace CIS3342_TermProject
{
    public partial class Verification : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["UserName"].ToString();
        }

        protected void btnSubmitVerification_Click(object sender, EventArgs e)
        {
            String codeEntered = txtVerify.Text;
            WebRequest request = WebRequest.Create("https://localhost:44315/api/user/GetVerificationCode/" + Session["UserName"]);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string code = data;

            if (codeEntered == code)
            {
                DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
                Boolean result = proxy.updateVerification(username);

                if (result)
                {
                    string strSql = "SELECT UserID FROM TP_Users WHERE UserName='" + username + "'";
                    DataSet myData = dBConnect.GetDataSet(strSql);
                    int userID = int.Parse(myData.Tables[0].Rows[0][0].ToString());
                    Session["UserID"] = userID;
                    Response.Redirect("DatingClient.aspx");
                }
                else
                {
                    lblError.Text = "Error verifying Account";
                }

            }
            else
            {
                lblError.Text = "Verification code is incorrect";
            }

        }
    }
}