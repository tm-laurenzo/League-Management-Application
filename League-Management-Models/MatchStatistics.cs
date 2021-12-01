using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class MatchStatistics
    {
        [Key]
        public Guid Id { get; set; }
        public Team Team { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public int Throwings { get; set; }
        public int CornerKicks { get; set; }
        public int PenaltyKicks { get; set; }
        public int FreeKicks { get; set; }
        public int TeamSaves { get; set; }
        public double BallPossesion { get; set; }
        public ICollection<Card> ListOfCards { get; set; }
    }
}
