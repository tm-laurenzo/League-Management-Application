using League_Management_Models;
using System;
using System.Collections.Generic;

namespace League_Management_DTOs
{
    public class AddManagerDTO
    {
        public string UserId { get; set; } = new Guid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public string AgentId { get; set; }
        public Agent? Agent { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string? CurrentTeamId { get; set; }
       
        public Team? CurrentTeam { get; set; }
    
        public ICollection<Team>? ListOfPreviousTeams { get; set; }
    }
}