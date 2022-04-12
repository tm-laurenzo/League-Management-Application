using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Manager
    {
        [Key]
        public string UserId { get; set; }
        public User User { get; set; }
        public string AgentId { get; set; }
        public Agent Agent { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        
        public ICollection<Team> ListOfTeams { get; set; }
    }
}
