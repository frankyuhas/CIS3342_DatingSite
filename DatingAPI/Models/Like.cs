using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPI.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int LikedUserID { get; set; }
        public String LikePass { get; set; }
    }
}
