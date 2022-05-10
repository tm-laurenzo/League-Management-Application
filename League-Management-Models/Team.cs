using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Email { get; set; }
        public Owner Owner { get; set; }
        public string ManagerId { get; set; }
        public Manager Manager { get; set; }

        public DateTime FoundedeAt { get; set; }
        public ICollection<Player> Players { get; set; }
        public string Logo { get; set; }
        public Decimal Valuation { get; set; }
    }
}
