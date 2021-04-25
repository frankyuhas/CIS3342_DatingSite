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
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int receiver = Int32.Parse(Request.QueryString["Id"]);
                getMessages(receiver);
            }
            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Message newMessage = new Message();

            newMessage.SenderID = int.Parse(Session["UserID"].ToString());
            newMessage.ReceiverID = Int32.Parse(Request.QueryString["Id"]);
            newMessage.Content = txtMessage.Text;
            newMessage.DateSent = DateTime.Now;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonMessage = js.Serialize(newMessage);

            try
            {
                WebRequest request = WebRequest.Create("https://localhost:44315/api/message/");
                request.Method = "POST";

                request.ContentLength = jsonMessage.Length;
                request.ContentType = "application/json";

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(jsonMessage);
                writer.Flush();
                writer.Close();

                WebResponse response = request.GetResponse();
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                if (data == "true")
                    lblMessageSent.Text = "Message Sent";
                else
                    lblMessageSent.Text = "Message Not Sent";
            }
            catch(Exception ex)
            {
                lblMessageSent.Text = "Error: " + ex.Message;
            }

            Response.Redirect("Messages.aspx?Id=" + Int32.Parse(Request.QueryString["Id"]));

        }

        public void getMessages(int receiver)
        {
            List<Message> messagesList = new List<Message>();

            int senderID = Int32.Parse(Session["UserID"].ToString());

            WebRequest request = WebRequest.Create("https://localhost:44315/api/message/getMessages/" + senderID + "/" + receiver);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Message[] messagesArr = js.Deserialize<Message[]>(data);

            for(int i = 0; i < messagesArr.Length; i++)
            {
                messagesList.Add(messagesArr[i]);
            }

            rptMessages.DataSource = messagesList;
            rptMessages.DataBind();
        }
    }
}