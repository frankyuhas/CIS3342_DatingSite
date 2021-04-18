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
    [ApiController]
    public class MatchController : ControllerBase
    {
        DBConnect dBConnect = new DBConnect();
        // GET: api/Match
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Match/5
        [HttpGet("{id}", Name = "GetMatches")]
        public string Get(int id)
        {
            return "value";
        }

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
