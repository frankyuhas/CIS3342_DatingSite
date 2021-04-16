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
        ArrayList UserList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowUsers_Click(object sender, EventArgs e)
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

            gv_Users.DataSource = users;
            gv_Users.DataBind();
        }

        protected int CalculateAge(DateTime Birthday)
        {
            return (int)((double)new TimeSpan(DateTime.Now.Subtract(Birthday).Ticks).Days / 365.25);
        }
    }
}