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
                    displayUserInfo(false);
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

        

        protected void btnMessage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int rowIndex = gvr.RowIndex;
            int userID = Int32.Parse(gvMatches.DataKeys[rowIndex].Value.ToString());
            Response.Redirect("Messages.aspx?Id=" + userID);
        }

        public void displayUserInfo(Boolean tf)
        {
            displayUser.Visible = tf;
        }

        public void displaySelectedUser(int index)
        {

            //lblUserName.Text = userList[index].UserName.ToString();

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Users/pascucci/CIS3342/CoreWebAPI/api/teams/" + id);
            WebRequest request = WebRequest.Create("https://localhost:44315/api/user/" + index);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User user = js.Deserialize<User>(data);
            if (user.UserName != "")
            {
                lblUserName.Text = user.UserName;
            }
        }

        protected void gvMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayMatches(false);
            displayUserInfo(true);
            int selected = gvMatches.SelectedIndex;

            List<User> users = getAllUsers();

            lblUserName.Text = users[selected].UserName.ToString();
            lblAge.Text = CalculateAge(users[selected].Birthday).ToString();
            lblGender.Text = users[selected].Gender.ToString();
            lblLocation.Text = users[selected].Location.ToString();
            lblBio.Text = users[selected].Bio.ToString();
            profilePicture.Src = "ImageGrab.aspx?ID=" + users[selected].UserID;
        }

        public void displayMatches(Boolean tf)
        {
            gvMatches.Visible = tf;
        }


        public List<User> getAllUsers()
        {
            // This method will be used for getting the current list of users that the client has not liked or passed yet

            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/Users/pascucci/CIS3342/CoreWebAPI/api/teams/");
            WebRequest request = WebRequest.Create("https://localhost:44315/api/user");
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

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].UserID != int.Parse(Session["UserID"].ToString()))
                {
                    userList.Add(users[i]);
                }
            }
            return userList;
            //gv_Users.DataSource = dt;
            //gv_Users.DataBind();
        }
    }
}