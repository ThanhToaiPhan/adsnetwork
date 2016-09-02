using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class Domain : BaseEntity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<Code> Codes { get; set; }
    }
}
