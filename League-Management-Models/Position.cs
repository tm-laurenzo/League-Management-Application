using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Position
    {
        [Key]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

    }
}
