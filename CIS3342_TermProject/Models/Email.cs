using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS3342_TermProject.Models
{
    public class Email
    {
        public String SendTo { get; set; }
        public String FromWho { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
    }
}