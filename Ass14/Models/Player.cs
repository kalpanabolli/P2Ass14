using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ass14.Models
{
    public class Player
    {
        public int PId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
    }
}