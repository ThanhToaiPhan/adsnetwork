using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class ProductAttributeMapping : BaseEntity
    {
        public ProductAttributeMapping()
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
        public int ProductId { get; set; }

        [DisplayName(@"ID Thuộc tính sản phẩm")]
        public int ProductAttributeId { get; set; }

        public virtual Product Product { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }

    }
}
