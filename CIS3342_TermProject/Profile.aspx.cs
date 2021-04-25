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
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using Utilities;

namespace CIS3342_TermProject
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EmailAddress"] != null)
                {
                    bindUser(int.Parse(Session["UserID"].ToString()));
                    showEdit(false);
                    ddlInterestedIn.Text = "Any";
                }
            }
        }

        public void bindUser(int UserID)
        {
            User user = GetUser(UserID);

            lblUserName.Text = user.UserName.ToString();
            lblAge.Text = CalculateAge(user.Birthday).ToString();
            lblGender.Text = user.Gender.ToString();
            lblLocation.Text = user.Location.ToString();
            lblBio.Text = user.Bio.ToString();
            profilePicture.Src = "ImageGrab.aspx?ID=" + UserID;

            txtUserName.Text = user.UserName.ToString();
            ddlState.SelectedValue = GetStateByName(user.Location.ToString());
            ddlGender.SelectedValue = user.Gender.ToString();
            txtBio.Text = user.Bio.ToString();

        }
        public String GetStateByName(string name)
        {
            switch (name.ToUpper())
            {
                case "ALABAMA":
                    return "AL";

                case "ALASKA":
                    return "AK";

                case "ARIZONA":
                    return "AZ";

                case "ARKANSAS":
                    return "AR";

                case "CALIFORNIA":
                    return "CA";

                case "COLORADO":
                    return "CO";

                case "CONNECTICUT":
                    return "CT";

                case "DELAWARE":
                    return "DE";

                case "DISTRICT OF COLUMBIA":
                    return "DC";

                case "FLORIDA":
                    return "FL";

                case "GEORGIA":
                    return "GA";

                case "HAWAII":
                    return "HI";

                case "IDAHO":
                    return "ID";

                case "ILLINOIS":
                    return "IL";

                case "INDIANA":
                    return "IN";

                case "IOWA":
                    return "IA";

                case "KANSAS":
                    return "KS";

                case "KENTUCKY":
                    return "KY";

                case "LOUISIANA":
                    return "LA";

                case "MAINE":
                    return "ME";

                case "MARYLAND":
                    return "MD";

                case "MASSACHUSETTS":
                    return "MA";

                case "MICHIGAN":
                    return "MI";

                case "MINNESOTA":
                    return "MN";

                case "MISSISSIPPI":
                    return "MS";

                case "MISSOURI":
                    return "MO";

                case "MONTANA":
                    return "MT";

                case "NEBRASKA":
                    return "NE";

                case "NEVADA":
                    return "NV";

                case "NEW HAMPSHIRE":
                    return "NH";

                case "NEW JERSEY":
                    return "NJ";

                case "NEW MEXICO":
                    return "NM";

                case "NEW YORK":
                    return "NY";

                case "NORTH CAROLINA":
                    return "NC";

                case "NORTH DAKOTA":
                    return "ND";

                case "OHIO":
                    return "OH";

                case "OKLAHOMA":
                    return "OK";

                case "OREGON":
                    return "OR";

                case "PALAU":
                    return "PW";

                case "PENNSYLVANIA":
                    return "PA";

                case "RHODE ISLAND":
                    return "RI";

                case "SOUTH CAROLINA":
                    return "SC";

                case "SOUTH DAKOTA":
                    return "SD";

                case "TENNESSEE":
                    return "TN";

                case "TEXAS":
                    return "TX";

                case "UTAH":
                    return "UT";

                case "VERMONT":
                    return "VT";

                case "VIRGIN ISLANDS":
                    return "VI";

                case "VIRGINIA":
                    return "VA";

                case "WASHINGTON":
                    return "WA";

                case "WEST VIRGINIA":
                    return "WV";

                case "WISCONSIN":
                    return "WI";

                case "WYOMING":
                    return "WY";
            }

            throw new Exception("Not Available");
        }

        public void showProfile(Boolean tf)
        {
            displayUser.Visible = tf;
        }

        public void showEdit(Boolean tf)
        {
            displayEdit.Visible = tf;
        }


        public User GetUser(int UserID)
        {
            WebRequest request = WebRequest.Create("https://localhost:44315/api/user/" + UserID);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            User user = js.Deserialize<User>(data);

            return user;
        }

        public Boolean EditUser()
        {


            return false;
        }

        protected void btnSaveEdit_Click(object sender, EventArgs e)
        {
            DatingAppWebService.User updateUser = new DatingAppWebService.User();
            int userID = int.Parse(Session["UserID"].ToString());

            User user = GetUser(userID);

            updateUser.UserID = userID;
            updateUser.UserName = txtUserName.Text;
            updateUser.Location = ddlState.SelectedItem.ToString();
            updateUser.Gender = ddlGender.SelectedItem.ToString();
            updateUser.Bio = txtBio.Text;

            DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
            proxy.UpdateUser(updateUser);

            updatePhotoToDB(userID);

            //showProfile(true);
            //showEdit(false);
            Response.Redirect("Profile.aspx");
        }


        protected int CalculateAge(DateTime Birthday)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(Birthday).Ticks).Days / 365.25);
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            showEdit(true);
            showProfile(false);
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            showEdit(false);
            showProfile(true);
        }

        public void updatePhotoToDB(int userID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, imageSize;
            string fileExtension, imageType, imageName;

            try
            {
                if (fileProfilePicture.HasFile)
                {
                    imageSize = fileProfilePicture.PostedFile.ContentLength;
                    byte[] imageData = new byte[imageSize];
                    fileProfilePicture.PostedFile.InputStream.Read(imageData, 0, imageSize);
                    imageName = fileProfilePicture.PostedFile.FileName;
                    imageType = fileProfilePicture.PostedFile.ContentType;


                    fileExtension = imageName.Substring(imageName.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                    {
                        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_UpdateUserPhoto";

                        objCommand.Parameters.AddWithValue("@ImageTitle", "user" + userID + "img");
                        objCommand.Parameters.AddWithValue("@ImageData", imageData);
                        objCommand.Parameters.AddWithValue("@ImageType", imageType);
                        objCommand.Parameters.AddWithValue("@ImageLength", imageData.Length);
                        objCommand.Parameters.AddWithValue("@UserID", userID);
                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                    }
                    else
                    {
                        Response.Write("<script>alert('Only jpg, bmp, and gif file formats supported.')</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error ocurred)</script>");
            }
        }

        protected void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = true;
            btnYes.Visible = true;
            btnNo.Visible = true;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            DatingAppWebService.User deleteUser = new DatingAppWebService.User();
            int userID = int.Parse(Session["UserID"].ToString());

            DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
            proxy.DeleteUser(userID);

            lblConfirm.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;

            Response.Redirect("Default.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            lblConfirm.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;
        }
    }
}