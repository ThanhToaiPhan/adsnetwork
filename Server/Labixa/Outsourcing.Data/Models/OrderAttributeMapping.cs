﻿using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class OrderAttributeMapping : BaseEntity
    {
        public OrderAttributeMapping()
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
        public int OrderId { get; set; }

        [DisplayName(@"ID Thuộc tính sản phẩm")]
        public int OrderAttributeId { get; set; }

        public virtual Order Order { get; set; }

        public virtual OrderAttribute OrderAttribute { get; set; }
    }
}
