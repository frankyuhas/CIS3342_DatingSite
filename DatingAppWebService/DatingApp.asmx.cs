using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;


namespace DatingAppWebService
{
    /// <summary>
    /// Summary description for DatingApp
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DatingApp : System.Web.Services.WebService
    {

        [WebMethod]
        public int AddNewUser(User newUser) //web service method to add user to db using stored procedure
        {
            DBConnect objDB = new DBConnect();

            if (newUser != null)
            {
                SqlCommand addUserCmd = new SqlCommand();

                addUserCmd.CommandType = System.Data.CommandType.StoredProcedure;
                addUserCmd.CommandText = "TP_AddUser";

                addUserCmd.Parameters.AddWithValue("@userName", newUser.UserName);
                addUserCmd.Parameters.AddWithValue("@email", newUser.EmailAddress);
                addUserCmd.Parameters.AddWithValue("@phoneNumber", newUser.PhoneNumber);
                addUserCmd.Parameters.AddWithValue("@birthDate", newUser.Birthdate);
                addUserCmd.Parameters.AddWithValue("@gender", newUser.Gender);
                addUserCmd.Parameters.AddWithValue("@location", newUser.Location);
                addUserCmd.Parameters.AddWithValue("@bio", newUser.Bio);
                addUserCmd.Parameters.AddWithValue("@password", newUser.Password);
                addUserCmd.Parameters.AddWithValue("@secAnswer1", newUser.SecAnswer1);
                addUserCmd.Parameters.AddWithValue("@secAnswer2", newUser.SecAnswer2);
                addUserCmd.Parameters.AddWithValue("@secAnswer3", newUser.SecAnswer3);
                addUserCmd.Parameters.AddWithValue("@isVerified", 0);

                DataSet data = objDB.GetDataSetUsingCmdObj(addUserCmd);

                int userId = Int32.Parse(data.Tables[0].Rows[0][0].ToString());

                if(userId < 0)
                {
                    return -1;
                }

                return userId;
            }

            return -1;
        }

        [WebMethod]
        public Boolean UpdateUser(User newUser) //web service method to update user to db using stored procedure
        {
            DBConnect objDB = new DBConnect();


            if (newUser != null)
            {
                SqlCommand UpdateUserCmd = new SqlCommand();

                UpdateUserCmd.CommandType = System.Data.CommandType.StoredProcedure;
                UpdateUserCmd.CommandText = "TP_UpdateUser";

                UpdateUserCmd.Parameters.AddWithValue("@userID", newUser.UserID);
                UpdateUserCmd.Parameters.AddWithValue("@userName", newUser.UserName);
                UpdateUserCmd.Parameters.AddWithValue("@gender", newUser.Gender);
                UpdateUserCmd.Parameters.AddWithValue("@location", newUser.Location);
                UpdateUserCmd.Parameters.AddWithValue("@bio", newUser.Bio);

                DataSet data = objDB.GetDataSetUsingCmdObj(UpdateUserCmd);

                return true;
            }

            return false;
        }

        [WebMethod]
        public Boolean DeleteUser(int userID) //web service method to delete user to db using stored procedure
        {
            DBConnect objDB = new DBConnect();

            try
            {
                SqlCommand DeleteUserCmd = new SqlCommand();

                DeleteUserCmd.CommandType = System.Data.CommandType.StoredProcedure;
                DeleteUserCmd.CommandText = "TP_DeleteUser";

                DeleteUserCmd.Parameters.AddWithValue("@userID", userID);

                DataSet data = objDB.GetDataSetUsingCmdObj(DeleteUserCmd);

                return true;
            }
            catch
            {
                return false;
            }

                
        }

        [WebMethod]
        public Boolean generateVerification(string username, string verifyCode)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand verifyCmd = new SqlCommand();

            verifyCmd.CommandType = CommandType.StoredProcedure;
            verifyCmd.CommandText = "TP_GenerateVerification";

            verifyCmd.Parameters.AddWithValue("@username", username);
            verifyCmd.Parameters.AddWithValue("@code", verifyCode);

            int success = objDB.DoUpdateUsingCmdObj(verifyCmd);

            if(success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [WebMethod]
        public Boolean updateVerification(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand update = new SqlCommand();

            update.CommandType = CommandType.StoredProcedure;
            update.CommandText = "TP_UpdateVerified";
            update.Parameters.AddWithValue("@username", username);

            int success = objDB.DoUpdateUsingCmdObj(update);

            if(success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
