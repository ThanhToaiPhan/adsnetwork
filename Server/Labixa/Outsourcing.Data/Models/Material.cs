using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class Material: BaseEntity
    {
        public string UserId { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Link { get; set; }
        public int Price { get; set; }
        public string PriceType { get; set; }

        public virtual User User { get; set; }
        public ICollection<AdMaterialMapping> AdMaterialMappings { get; set; }
    }
}
