using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIS3342_TermProject.Models;
using Utilities;

namespace CIS3342_TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DatingAppWebService.User newUser = new DatingAppWebService.User();
            int userId = 0;

            Boolean formComplete = isComplete();
            Boolean validPhoneNumber = validPhone();
            //checks if passwords match, then creates a new user object
            if (formComplete == false)
            {
                Response.Write("<script>alert('Please Fill out the Form Completely')</script>");
                
            }
            else if(validPhoneNumber == false){
                Response.Write("<script>alert('Please Enter a Valid Phone Number')</script>");
            }
            else
            {
                newUser.UserName = txtName.Text;
                newUser.Birthdate = DateTime.Parse(inputDate.Text);
                newUser.EmailAddress = txtEmail.Text;
                newUser.PhoneNumber = txtPhone.Text;
                newUser.Gender = ddlGender.SelectedItem.ToString();
                newUser.Bio = txtBio.Text;
                newUser.Location = ddlState.SelectedItem.ToString();
                newUser.Password = txtPassword.Text;
                DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
                userId = proxy.AddNewUser(newUser);
            }

            uploadPhotoToDB(userId);


            //if(userId == 0)
            //{
            //    Response.Write("<h3>Worked?</h3>");
            //}
            //else
            //{
            //    Response.Write("<h3>Nope</h3>");

            //}

        }

        public Boolean isComplete()
        {
            Boolean flag = true;

            if(txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtBio.Text == "" || txtPassword.Text == "")
            {
                flag = false;
            }

          
            

            return flag;
        }

        public Boolean validPhone()
        {
            Boolean flag = true;
            String phoneNumber = txtPhone.Text;

            if (phoneNumber.Length != 10)
            {
                flag = false;
            }

            return flag;
        }

        public void uploadPhotoToDB(int userID)
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

                    if(fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                    {
                        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_AddUserPhoto";

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
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error ocurred)</script>");
            }
        }
    }
}