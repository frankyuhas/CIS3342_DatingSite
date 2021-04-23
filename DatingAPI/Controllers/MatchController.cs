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
    public class MatchController : Controller
    {

       
        DBConnect dBConnect = new DBConnect();
        // GET: api/Match
        [HttpGet("getMatches/{UserID}")]
        public List<User> Get(int UserID)
        {
            List<User> matches = new List<User>();
            DataSet myMatches1 = dBConnect.GetDataSet("SELECT * FROM TP_Users u FULL JOIN TP_Matches m ON u.UserID = m.UserID2 WHERE UserID1 = " + UserID);
            DataSet myMatches2 = dBConnect.GetDataSet("SELECT * FROM TP_Users u FULL JOIN TP_Matches m ON u.UserID = m.UserID1 WHERE UserID2 = " + UserID);

            myMatches1.Merge(myMatches2);

            myMatches1.Tables[0].Columns.Add("imgFile");
            foreach (DataRow tempRow in myMatches1.Tables[0].Rows)
            {
                tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["UserID"];
            }

            foreach (DataRow record in myMatches1.Tables[0].Rows)
            {
                
                User user = new User();

                user.UserID = int.Parse(record["UserID"].ToString());
                user.UserName = record["UserName"].ToString();
                //user.EmailAddress = record["EmailAddress"].ToString();
                //user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Birthday = DateTime.Parse(record["Birthday"].ToString());
                user.Gender = record["Gender"].ToString();
                user.Bio = record["Bio"].ToString();
                user.Location = record["Location"].ToString();
                //user.Password = record["Password"].ToString();
                user.imgFile = record["imgFile"].ToString();

                matches.Add(user);
               

            }



            return matches;


        }

        // GET: api/Match/5
        //[HttpGet("{id}", Name = "GetMatches")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Match
        [HttpPost]
        public Boolean Post([FromBody] Match match)
        {
            DBConnect objDB = new DBConnect();
            string strSQL = "INSERT INTO TP_Matches (UserID1, UserID2, MatchDate) " +
                           "VALUES ('" + match.UserID1 + "', '" + match.UserID2 + "', '" + match.MatchDate + "')";
            int result = objDB.DoUpdate(strSQL);

            if (result > 0)
                return true;

            return false;
        }

        // PUT: api/Match/5
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
