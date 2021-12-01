using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public MatchStatistics HomeTeam { get; set; }
        public MatchStatistics AwayTeam { get; set; }


    }
}
