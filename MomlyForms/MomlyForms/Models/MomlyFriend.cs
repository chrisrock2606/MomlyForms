using System;
using System.Collections.Generic;
using System.Text;

namespace MomlyForms.Models
{
    public class MomlyFriend
    {
        public int MomlyFriendId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public int BabyAgeInMonth { get; set; }
        public DateTime PlannedWalk { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

    }
}
