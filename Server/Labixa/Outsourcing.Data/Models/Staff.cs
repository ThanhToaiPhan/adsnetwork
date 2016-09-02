using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class Staff :BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Số điện thoại")]
        public string Phone { get; set; }

        [DisplayName(@"Hình ảnh")]
        public string Image { get; set; }

        [DisplayName(@"Đặt lại tên")]
        public string Rename { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Dạng")]
        public int Type { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"Yahoo")]
        public string Yahoo { get; set; }

        [DisplayName(@"Skype")]
        public string Skype { get; set; }
    }
}
