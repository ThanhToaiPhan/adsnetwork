using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class ProductSchedule : BaseEntity
    {
        [DisplayName(@"Giá")]
        public int Price { get; set; }

        [DisplayName(@"Sẵn sàng")]
        public bool IsAvailable { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductId { get; set; }

        [DisplayName(@"Số lượng tối đa")]
        public int MaxQuantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<ProductScheduleAttributeMapping> ProductScheduleAttributeMappings { get; set; }

        public virtual ICollection<ProductSchedulePictureMapping> ProductSchedulePictureMappings { get; set; }

        public ProductSchedule()
        {
            
        }
    }
}
