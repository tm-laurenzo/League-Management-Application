using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace League_Management_Models
{
    public class Records
    {
        public Guid Id { get; set; }
        public ICollection<Match> MatchRecords { get; set; }
    }
}
