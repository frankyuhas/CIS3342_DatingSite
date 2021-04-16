using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CIS3342_TermProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_signin_Click(object sender, EventArgs e)
        {
            Response.Redirect("DatingClient.aspx"); 
        }

        protected void btnCreate_Account_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}