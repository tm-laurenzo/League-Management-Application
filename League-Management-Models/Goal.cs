using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Goal
    {
        public Team Team { get; set; }
        public Player Scorer { get; set; }
        public Player AssistProvider { get; set; }
        public bool Penalty { get; set; }
        //Add an enum for list of body parts i.e head, shoulder,
        //chest knee, heel
        public DateTime Time { get; set; }
    }
}
