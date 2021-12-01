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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime FoundedeAt { get; set; }
        public Manager Manager { get; set; }
        public ICollection<Player> Players { get; set; }
        public Double Valution { get; set; }
    }
}
