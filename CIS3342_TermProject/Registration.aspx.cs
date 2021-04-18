using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CIS3342_TermProject.Models;



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
            int result = 0;

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
                result = proxy.AddNewUser(newUser);
            }
            
            


            if(result == 0)
            {
                Response.Write("<h3>Worked?</h3>");
            }
            else
            {
                Response.Write("<h3>Nope</h3>");

            }

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

            if (phoneNumber.Length != 9)
            {
                flag = false;
            }

            return flag;
        }
    }
}