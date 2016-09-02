using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class OrderAttribute : BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Kiểu kiểm soát")]
        public string ControlType { get; set; }

        [DisplayName(@"Dạng")]
        public string Type { get; set; }

        public virtual ICollection<OrderAttributeMapping> OrderAttributeMappings { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }
    }
}
