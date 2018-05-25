using System;
using System.Collections.Generic;
using System.Text;

namespace MomlyForms.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNr { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public DateTime DueDate { get; set; }
        public List<CheckListItem> CheckList { get; set; }

        public Account()
        {
            CheckList = new List<CheckListItem>();
        }
    }
}
