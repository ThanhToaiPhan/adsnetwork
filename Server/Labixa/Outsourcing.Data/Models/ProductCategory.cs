using System.Collections.Generic;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class ProductCategory : BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Đường dẫn")]
        public string Slug { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
