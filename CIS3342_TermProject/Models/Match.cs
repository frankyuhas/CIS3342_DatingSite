using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS3342_TermProject.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int UserID1 { get; set; }
        public int UserID2 { get; set; }
        public DateTime MatchDate { get; set; }
    }
}