using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class Ad : BaseEntity
    {
        public string Name { get; set; }
        public string Script { get; set; }
        public string Func { get; set; }

        public ICollection<Code> Codes { get; set; }
        public ICollection<AdMaterialMapping> AdMaterialMappings { get; set; }
    }
}
