using System.ComponentModel;
namespace Outsourcing.Data.Models
{
    public class ProductRelationship :BaseEntity
    {
        [DisplayName(@"ID Sản phẩm liên quan")]
        public int ProductRelateId { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductId { get; set; }

        [DisplayName(@"Sẵn sàng")]
        public bool IsAvailable { get; set; }

        //[ForeignKey("ProductRelateId")]
        //virtual public Product Product { get; set; }

        //[ForeignKey("ProductId")]
        //virtual public Product Product1 { get; set; }

    }
}
