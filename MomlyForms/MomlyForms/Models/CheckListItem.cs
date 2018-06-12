using System;
using System.Collections.Generic;
using System.Text;

namespace MomlyForms.Models
{
    public class CheckListItem
    {
        public int CheckListItemId { get; set; }
        public bool Checked { get; set; }
        public string Description { get; set; }
    }
}
