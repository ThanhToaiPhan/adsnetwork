using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class Order : BaseEntity
    {
        public Order()
        {
            DateCreated = DateTime.Now;
        }
        [DisplayName(@"Tên")]
        public string CustomerName { get; set; }

        [DisplayName(@"Địa chỉ")]
        public string CustomerAddress { get; set; }

        [DisplayName(@"Số điện thoại")]
        public string CustomerPhone{ get; set; }

        [DisplayName(@"Email")]
        public string CustomerEmail{ get; set; }

        [DisplayName(@"Tổng tiền")]
        public int OrderTotal { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsHandled { get; set; }

        [DisplayName(@"Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [DisplayName(@"Ghi chú")]
        public string Note { get; set; }

        [DisplayName(@"Dạng")]
        public string Type { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductScheduleId { get; set; }

        public virtual ProductSchedule ProductSchedule { get; set; }

        public virtual ICollection<OrderAttributeMapping> OrderAttributeMappings { get; set; }
    }
}
