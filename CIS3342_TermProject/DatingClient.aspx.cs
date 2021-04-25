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
using System.Reflection;
using System.Data;

namespace CIS3342_TermProject
{
    public partial class DatingClient : System.Web.UI.Page
    {
        List<User> userList = new List<User>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmailAddress"] != null)
                {
                    displayUserInfo(false);
                    getAllUsers();
                }
            }
        }

        protected void btnShowUsers_Click(object sender, EventArgs e)
        {
            List<User> users = getAllUsers();
            displayUserInfo(false);
            gv_Users.DataSource = users;
            gv_Users.DataBind();
        }

        public void bindUsers()
        {
            List<User> users = getAllUsers();

            gv_Users.DataSource = users;
            gv_Users.DataBind();
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

            //userList = users;
            //ListtoDataTableConverter converter = new ListtoDataTableConverter();
            //DataTable dt = converter.ToDataTable(userList);

            List<User> userList = new List<User>();
            int userID = int.Parse(Session["UserID"].ToString());

            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].UserID != int.Parse(Session["UserID"].ToString()))
                {
                    if (checkLike(userID, users[i].UserID) == true)
                    {
                        //yeehaw
                    }
                    else
                    {
                        if (ddlState.SelectedValue == "ANY")
                        {
                            if(ddlGender.SelectedValue == "Any")
                            {
                                userList.Add(users[i]);
                            }
                            else if(ddlGender.SelectedValue == users[i].Gender)
                            {
                                userList.Add(users[i]);
                            }
                        }
                        else if (ddlState.SelectedItem.ToString() == users[i].Location)
                        {

                            if (ddlGender.SelectedValue == "Any")
                            {
                                userList.Add(users[i]);
                            }
                            else if (ddlGender.SelectedValue == users[i].Gender)
                            {
                                userList.Add(users[i]);
                            }
                        }
                    }
                }
            }

            //foreach(DataRow tempRow in dt.Rows)
            //{
            //    tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["UserID"];
            //}

            return userList;
            //gv_Users.DataSource = dt;
            //gv_Users.DataBind();
        }

        public List<Like> GetLikes(int UserID)
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/like/" + int.Parse(Session["UserID"].ToString()));
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Like[] likes = js.Deserialize<Like[]>(data);

            List<Like> likesList = new List<Like>();
            for (int i = 0; i < likes.Length; i++)
            {
                likesList.Add(likes[i]);
            }

            return likesList;

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

            List<User> users = getAllUsers();

            lblUserName.Text = users[selected].UserName.ToString();
            lblAge.Text = CalculateAge(users[selected].Birthday).ToString();
            lblGender.Text = users[selected].Gender.ToString();
            lblLocation.Text = users[selected].Location.ToString();
            lblBio.Text = users[selected].Bio.ToString();
            profilePicture.Src = "ImageGrab.aspx?ID=" + users[selected].UserID;

            //String index = (gv_Users.Rows[selected].Cells[6].Text).ToString();

            //displaySelectedUser(selected);
        }

        public void displayUsers(Boolean tf)
        {
            gv_Users.Visible = tf;
            btnShowUsers.Visible = tf;
            lblState2.Visible = tf;
            ddlState.Visible = tf;
            lblGender2.Visible = tf;
            ddlGender.Visible = tf;
        }

        public void displayUserInfo(Boolean tf)
        {
            //lblUserName.Visible = tf;
            //lblAge.Visible = tf;
            //lblBio.Visible = tf;
            //lblGender.Visible = tf;
            //lblLocation.Visible = tf;
            //profilePicture.Visible = tf;
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

        protected void btnLike_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int index = gvr.RowIndex;
            List<User> users = getAllUsers();

            int userID = int.Parse(Session["UserID"].ToString());
            int likedUserID = users[index].UserID;

            Like like = new Like();
            like.UserID = userID;
            like.LikedUserID = likedUserID;
            String likes = "Like";
            like.LikePass = likes;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonTeam = js.Serialize(like);

            try
            {
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44315/api/like/");
                request.Method = "POST";

                request.ContentLength = jsonTeam.Length;
                request.ContentType = "application/json";

                // Write the JSON data to the Web Request

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonTeam);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                    lblLikedName.Text = "The like was successfully saved to the database.";

                else
                    lblLikedName.Text = "The like wasn't saved to the database.";
            }
            catch (Exception ex)
            {
                lblLikedName.Text = "Error: " + ex.Message;
            }

            if(checkMatch(userID, likedUserID) == true)
            {
                lblMatch.Text = "Match!";
                createMatch(likedUserID, userID);
            }
            bindUsers();
        }

        public Boolean createMatch(int UserID1, int UserID2)
        {
            Match match = new Match();
            match.UserID1 = UserID1;
            match.UserID2 = UserID2;
            match.MatchDate = DateTime.Now;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonTeam = js.Serialize(match);

            try
            {
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44315/api/match/");
                request.Method = "POST";

                request.ContentLength = jsonTeam.Length;
                request.ContentType = "application/json";

                // Write the JSON data to the Web Request

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonTeam);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                {
                    lblLikedName.Text = "The match was successfully saved to the database.";
                    return true;
                }

                else
                    lblLikedName.Text = "The match wasn't saved to the database.";
            }
            catch (Exception ex)
            {
                lblLikedName.Text = "Error: " + ex.Message;
            }
            return false;
        }

        public Boolean checkMatch(int UserID, int LikedUserID)
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/like/" + UserID + "/" + LikedUserID);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Like like = js.Deserialize<Like>(data);

            if(like.LikePass == "Like")
            {
                return true;
            }

            return false;
        }

        public Boolean checkLike(int UserID, int LikedUserID)
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/like/" + LikedUserID + "/" + UserID);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            Like like = js.Deserialize<Like>(data);

            if (like.LikePass == "Like" || like.LikePass == "Pass")
            {
                return true;
            }

            return false;
        }

        protected void BtnPass_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            int index = gvr.RowIndex;
            List<User> users = getAllUsers();

            int userID = int.Parse(Session["UserID"].ToString());
            int likedUserID = users[index].UserID;

            Like like = new Like();
            like.UserID = userID;
            like.LikedUserID = likedUserID;
            String likes = "Pass";
            like.LikePass = likes;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonTeam = js.Serialize(like);

            try
            {
                // Setup an HTTP POST Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("https://localhost:44315/api/like/");
                request.Method = "POST";

                request.ContentLength = jsonTeam.Length;
                request.ContentType = "application/json";

                // Write the JSON data to the Web Request

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonTeam);
                writer.Flush();
                writer.Close();

                // Read the data from the Web Response, which requires working with streams.

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                    lblLikedName.Text = "The pass was successfully saved to the database.";

                else
                    lblLikedName.Text = "The pass wasn't saved to the database.";
            }
            catch (Exception ex)
            {
                lblLikedName.Text = "Error: " + ex.Message;
            }
            bindUsers();

        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = getAllUsers();
            displayUserInfo(false);
            gv_Users.DataSource = users;
            gv_Users.DataBind();
        }

        protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = getAllUsers();
            displayUserInfo(false);
            gv_Users.DataSource = users;
            gv_Users.DataBind();
        }

        //public class ListtoDataTableConverter
        //{
        //    public DataTable ToDataTable<T>(List<T> items)
        //    {
        //        DataTable dataTable = new DataTable(typeof(T).Name);

        //        PropertyInfo[] Props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        //        foreach(PropertyInfo prop in Props)
        //        {
        //            dataTable.Columns.Add(prop.Name);
        //        }
        //        foreach (T item in items)
        //        {
        //            var values = new object[Props.Length];
        //            for (int i = 0; i < Props.Length; i++)
        //            {
        //                //inserting property values to datatable rows
        //                values[i] = Props[i].GetValue(item, null);
        //            }
        //            dataTable.Rows.Add(values);
        //        }
        //        //put a breakpoint here and check datatable
        //        return dataTable;
        //    }
        //}
    }
}