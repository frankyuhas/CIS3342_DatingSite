using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS3342_TermProject.Models
{
    public class User
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public String EmailAddress { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public String Gender { get; set; }
        public String Bio { get; set; }
        public String Location { get; set; }
        public String Password { get; set; }
        public String imgFile { get; set; }
        public String SecAnswer1 { get; set; }
        public String SecAnswer2 { get; set; }
        public String SecAnswer3 { get; set; }
    }
}