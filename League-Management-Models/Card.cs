using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public Player Player { get; set; }
        //Get a way to set the maximum number to 2 and if a player 
        //has 2 yellow cards, set red card to one
        public bool YellowCard { get; set; }
        //Set Maximum to 1
        public bool RedCard { get; set; }
        public DateTime TimeOfCard { get; set; }
    }
}
