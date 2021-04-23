using CIS3342_TermProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class Matches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmailAddress"] != null)
                {
                    
                    getAllMatches();
                }
            }
        }

        public void getAllMatches()
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/match/getMatches/" + Session["UserID"]);
            WebResponse response = request.GetResponse();


            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);

            List<User> userList = new List<User>();
            int userID = int.Parse(Session["UserID"].ToString());

            for(int i = 0; i < users.Length; i++)
            {
                userList.Add(users[i]);
            }

            gvMatches.DataSource = userList;
            String[] usersArr = new String[1];
            usersArr[0] = "UserID";
            gvMatches.DataKeyNames = usersArr;
            gvMatches.DataBind();


        }

        protected int CalculateAge(DateTime Birthday)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(Birthday).Ticks).Days / 365.25);
        }

        

        protected void gvMatches_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int userID = Int32.Parse(gvMatches.DataKeys[rowIndex].Value.ToString());
            Response.Redirect("Messages.aspx?Id=" + userID);
        }
    }
}