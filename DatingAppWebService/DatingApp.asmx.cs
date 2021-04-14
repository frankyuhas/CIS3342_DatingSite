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

                int result = objDB.DoUpdateUsingCmdObj(addUserCmd);

                if(result == 0)
                {
                    return 0;
                }
            }

            return -1;
        }
    }
}
