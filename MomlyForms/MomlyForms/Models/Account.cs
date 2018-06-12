using System;
using System.Collections.Generic;
using System.Text;

namespace MomlyForms.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Key { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNr { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public int BabyAgeInMonth { get; set; }
        public DateTime DueDate { get; set; }
        public List<CheckListItem> CheckList { get; set; }
        public List<MomlyFriend> MomlyFriends { get; set; }


        public Account()
        {
            CheckList = new List<CheckListItem>();
            MomlyFriends = new List<MomlyFriend>();
        }
    }
}
