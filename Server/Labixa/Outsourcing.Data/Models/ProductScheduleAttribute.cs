using System.Collections.Generic;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class ProductScheduleAttribute : BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Kiểu kiểm soát")]
        public string ControlType { get; set; }

        [DisplayName(@"Dạng")]
        public string Type { get; set; }

        public virtual ICollection<ProductScheduleAttributeMapping> ProductScheduleAttributeMappings { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }
    }
}
