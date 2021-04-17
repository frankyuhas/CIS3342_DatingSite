using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Script.Serialization;  // needed for JSON serializers
using System.IO;                        // needed for Stream and Stream Reader
using System.Net;                       // needed for the Web Request
using CIS3342_TermProject.Models;
using System.Collections;

namespace CIS3342_TermProject
{
    public partial class DatingClient : System.Web.UI.Page
    {
        ArrayList userList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmailAddress"] != null)
                {

                }
            }
        }

        protected void btnShowUsers_Click(object sender, EventArgs e)
        {
            User[] users = getAllUsers();

            gv_Users.DataSource = users;
            gv_Users.DataBind();
        }

        public User[] getAllUsers()
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
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

            return users;
        }

        protected int CalculateAge(DateTime Birthday)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(Birthday).Ticks).Days / 365.25);
        }

        protected void gv_Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayUsers(false);
            displayUserInfo(true);
            int selected = gv_Users.SelectedIndex;

            User[] users = getAllUsers();

            lblUserName.Text = users[selected].UserName.ToString();
            lblAge.Text = CalculateAge(users[selected].Birthday).ToString();
            lblGender.Text = users[selected].Gender.ToString();
            lblLocation.Text = users[selected].Location.ToString();
            lblBio.Text = users[selected].Bio.ToString();

            //String index = (gv_Users.Rows[selected].Cells[6].Text).ToString();

            //displaySelectedUser(selected);
        }

        public void displayUsers(Boolean tf)
        {
            gv_Users.Visible = tf;
            btnShowUsers.Visible = tf;
        }

        public void displayUserInfo(Boolean tf)
        {
            lblUserName.Visible = tf;
            lblAge.Visible = tf;
            lblBio.Visible = tf;
            lblGender.Visible = tf;
            lblLocation.Visible = tf;
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

        protected void btnLike_Click(object sender, EventArgs e)
        {
            int index = gv_Users.SelectedIndex;

        }
    }
}