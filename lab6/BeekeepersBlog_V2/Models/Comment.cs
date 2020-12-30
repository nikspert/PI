using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeekeepersBlog_V2.Models
{
    public class Comment
    {
        public String comentText { get; set;}
        public DateTime CreateTime { get; set; }
        public ApplicationUser User { get; set; }

    }
}