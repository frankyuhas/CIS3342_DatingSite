using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace DatingAPI.Controllers
{
    [Route("api/message")]
    
    public class MessagesController : Controller
    {
        DBConnect dbConnect = new DBConnect();

        [HttpGet("getMessages/{UserID}/{UserID2}")]
        public List<Message> Get(int UserID, int UserID2)
        {
            
            List<Message> messages = new List<Message>();
            DataSet myMessages = dbConnect.GetDataSet("SELECT * FROM TP_Messages WHERE SenderID=" + UserID + " AND ReceiverID=" + UserID2);
            DataSet myMessages2 = dbConnect.GetDataSet("SELECT * FROM TP_Messages WHERE ReceiverID=" + UserID + " AND SenderID=" + UserID2);
            myMessages.Merge(myMessages2);
            //myMessages.Tables[0].DefaultView.Sort = "SentDate desc";


            DataSet names1 = dbConnect.GetDataSet("SELECT UserName FROM TP_Users WHERE UserID=" + UserID);
            String senderName = names1.Tables[0].Rows[0]["UserName"].ToString();

            DataSet names2 = dbConnect.GetDataSet("SELECT UserName FROM TP_Users WHERE UserID=" + UserID2);
            String receiverName = names2.Tables[0].Rows[0]["UserName"].ToString();

            foreach(DataRow record in myMessages.Tables[0].Rows)
            {
                Message message = new Message();

                message.ReceiverID = int.Parse(record["ReceiverID"].ToString());
                message.SenderID = int.Parse(record["SenderID"].ToString());
                message.Content = record["Content"].ToString();
                message.DateSent = DateTime.Parse(record["SentDate"].ToString());
                if(message.ReceiverID == UserID)
                {
                    message.SenderName = receiverName;
                }
                else
                {
                    message.SenderName = senderName;
                }
                
                messages.Add(message);
            }

            List<Message> orderedMessages = messages.OrderBy(m => m.DateSent).ToList();

            return orderedMessages;
        }


        [HttpPost]
        public Boolean Post([FromBody] Message message)
        {
            DBConnect objDB = new DBConnect();
            string strSQL = "INSERT INTO TP_Messages(SenderID, ReceiverID, Content, SentDate) " +
                            "VALUES ('" + message.SenderID + "', '" + message.ReceiverID + "', '" + message.Content + "', '" + message.DateSent + "')";
            int result = objDB.DoUpdate(strSQL);

            if(result > 0)
            {
                return true;
            }
            return false;
        }

    }
}