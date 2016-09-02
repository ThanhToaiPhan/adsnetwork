using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class Code : BaseEntity
    {
        public int AdId { get; set; }
        public int DomainId { get; set; }
        public string Value { get; set; }

        public virtual Ad Ad { get; set; }
        public virtual Domain Domain { get; set; }
    }
}
