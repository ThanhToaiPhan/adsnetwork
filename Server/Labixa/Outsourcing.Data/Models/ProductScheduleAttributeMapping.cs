using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsourcing.Data.Models
{
    public class ProductScheduleAttributeMapping : BaseEntity
    {
        public ProductScheduleAttributeMapping()
        {
            Value = "Default";
            IsRequired = false;
            DisplayOrder = 0;
        }

        [DisplayName(@"Giá trị")]
        public string Value { get; set; }

        [DisplayName(@"Bắt buộc")]
        public bool IsRequired { get; set; }

        [DisplayName(@"Thứ tự hiển thị")]
        public int DisplayOrder { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductScheduleId { get; set; }

        [DisplayName(@"ID Thuộc tính sản phẩm")]
        public int ProductScheduleAttributeId { get; set; }

        public virtual ProductSchedule ProductSchedule { get; set; }

        public virtual ProductScheduleAttribute ProductScheduleAttribute { get; set; }
    }
}
