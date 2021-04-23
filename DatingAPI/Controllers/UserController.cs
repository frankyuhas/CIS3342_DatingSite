﻿using System;
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
    public class UserController : Controller
    {
        DBConnect dBConnect = new DBConnect();

        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            List<User> userList = new List<User>();
            DataSet mydata = dBConnect.GetDataSet("SELECT * FROM TP_Users");

            mydata.Tables[0].Columns.Add("imgFile");
            foreach(DataRow tempRow in mydata.Tables[0].Rows)
            {
                tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["UserID"];
            }

            foreach (DataRow record in mydata.Tables[0].Rows)
            {
                User user = new User();

                user.UserID = int.Parse(record["UserID"].ToString());
                user.UserName = record["UserName"].ToString();
                user.EmailAddress = record["EmailAddress"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Birthday = DateTime.Parse(record["Birthday"].ToString());
                user.Gender = record["Gender"].ToString();
                user.Bio = record["Bio"].ToString();
                user.Location = record["Location"].ToString();
                user.Password = record["Password"].ToString();
                user.imgFile = record["imgFile"].ToString();

                userList.Add(user);

            }

            return userList;
        }

        // GET: api/User/5
        [HttpGet("{UserID}", Name = "Get")]
        public User Get(int UserID)
        {
            DataSet mydata = dBConnect.GetDataSet("SELECT * FROM TP_Users WHERE UserID = " + UserID);
            User user = new User();

            mydata.Tables[0].Columns.Add("imgFile");
            foreach (DataRow tempRow in mydata.Tables[0].Rows)
            {
                tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["UserID"];
            }

            if (mydata.Tables[0].Rows.Count > 0)
            {
                DataRow record = mydata.Tables[0].Rows[0];
                user.UserName = record["UserName"].ToString();
                user.EmailAddress = record["EmailAddress"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Birthday = DateTime.Parse(record["Birthday"].ToString());
                user.Gender = record["Gender"].ToString();
                user.Bio = record["Bio"].ToString();
                user.Location = record["Location"].ToString();
                user.Password = record["Password"].ToString();
                user.imgFile = record["imgFile"].ToString();
            }

            return user;

        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/User/5
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
