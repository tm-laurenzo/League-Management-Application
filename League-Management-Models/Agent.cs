using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Agent
    {
        [Key]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User User { get; set; }
    }
}
