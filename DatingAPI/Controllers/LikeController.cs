using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Utilities;
using System.Data;
using DatingAPI.Models;

namespace DatingAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class LikeController : Controller
    {
        DBConnect dBConnect = new DBConnect();
        // GET: api/Like
        [HttpGet("{userID}", Name = "Getlikes")]
        public List<Like> Get(int userID)
        {
            //used to remove already voted on accounts from view
            List<Like> userLikes = new List<Like>();
            DataSet mydata = dBConnect.GetDataSet("SELECT * FROM TP_Likes WHERE UserID = " + userID);

            foreach (DataRow record in mydata.Tables[0].Rows)
            {
                Like like = new Like();
                like.UserID = int.Parse(record["UserID"].ToString());
                like.LikedUserID = int.Parse(record["LikedUserID"].ToString());
                like.LikePass = record["LikePass"].ToString();

                userLikes.Add(like);
            }

            return userLikes;
        }

        // GET: api/Like/5
        [HttpGet("{userID}/{likedUserID}", Name = "Getlike")]
        public Like Get(int userID, int likedUserID)
        {
            //this method will be used to check if the liked user likes the user back
            DataSet mydata = dBConnect.GetDataSet("SELECT * FROM TP_Likes WHERE LikedUserID = " + userID + "AND UserID = " + likedUserID);

            Like like = new Like();
            if (mydata.Tables[0].Rows.Count > 0)
            {
                DataRow record = mydata.Tables[0].Rows[0];
                like.UserID = int.Parse(record["UserID"].ToString());
                like.LikedUserID = int.Parse(record["LikedUserID"].ToString());
                like.LikePass = record["LikePass"].ToString();

                return like;
            }
            return like;
        }

        // POST: api/Like
        [HttpPost]
        public Boolean Post([FromBody] Like like)
        {
            DBConnect objDB = new DBConnect();
            string strSQL = "INSERT INTO TP_Likes (UserID, LikedUserID, LikePass) " +
                           "VALUES ('" + like.UserID + "', '" + like.LikedUserID + "', '" + like.LikePass + "')";
            int result = objDB.DoUpdate(strSQL);

            if (result > 0)
                return true;

            return false;
        }

        // PUT: api/Like/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
