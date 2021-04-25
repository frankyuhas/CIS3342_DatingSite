using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIS3342_TermProject.Models;
using Utilities;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;

namespace CIS3342_TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };
        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String plainTextPassword = txtPassword.Text;
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
                newUser.Password = encryptedPassword;
                newUser.SecAnswer1 = txtSecQuestion1.Text;
                newUser.SecAnswer2 = txtSecQuestion2.Text;
                newUser.SecAnswer3 = txtSecQuestion3.Text;


                DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
                

                userId = proxy.AddNewUser(newUser);

                if(userId != -1)
                {
                    Boolean email = generateVerification(txtName.Text, txtEmail.Text);
                }
            }


            Session["UserName"] = txtName.Text;
            Session["EmailAddress"] = txtEmail.Text;

            uploadPhotoToDB(userId);

            
            Response.Redirect("Verification.aspx");

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

            if(txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtBio.Text == "" || txtPassword.Text == "" || fileProfilePicture.HasFile == false)
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
                else
                {
                    Response.Write("<script>Please Upload a Profie Photo</script>");
                    return;
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Error ocurred)</script>");
            }
        }

        public Boolean generateVerification(string username, string email)
        {
            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();

            for(int i = 0; i < 7; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }

            DatingAppWebService.DatingApp proxy = new DatingAppWebService.DatingApp();
            Boolean result = proxy.generateVerification(username, str);

            //Email newEmail = new Email();
            String strTo = email;
            String strFrom = "lovefinderdating@gmail.com";
            String strSubject = "Verifcation for Love Finder account";
            String strMessage = "Your Verification Code is " + str + ". Please enter it on the application.";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(strFrom, "BigPassword123!");
            smtp.Timeout = 20000;

            try
            {
                MailMessage message = new MailMessage(strFrom, strTo);
                message.Subject = strSubject;
                message.Body = strMessage;
                smtp.Send(message);
            }
            catch(Exception ex)
            {
                lblError.Text = "The email failed to send.";
                return false;
            }


            return true;
        }
    }
}