using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class AdMaterialMapping : BaseEntity
    {
        public int AdId { get; set; }
        public int MaterialId { get; set; }

        public virtual Ad Ad { get; set; }
        public virtual Material Material { get; set; }
    }
}
