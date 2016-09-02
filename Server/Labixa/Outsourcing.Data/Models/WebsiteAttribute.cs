using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class WebsiteAttribute : BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Kiểu kiểm soát")]
        public string ControlType { get; set; }

        [DisplayName(@"Dạng")]
        public string Type { get; set; }

        [DisplayName(@"Giá trị")]
        public string Value { get; set; }

        [DisplayName(@"Hiển thị công khai")]
        public bool IsPublic { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

    }
}
