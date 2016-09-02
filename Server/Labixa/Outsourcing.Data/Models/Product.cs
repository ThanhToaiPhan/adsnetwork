using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            LastEditedTime = DateCreated = DateTime.Now;
        }
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Đường dẫn")]
        public string Slug { get; set; }

        [DisplayName(@"Nội dung")]
        public string Content { get; set; }

        [DisplayName(@"Giá")]
        public int Price { get; set; }

        [DisplayName(@"Giá cũ")]
        public int OldPrice { get; set; }

        [DisplayName(@"Từ khóa tìm kiếm")]
        public string MetaKeywords { get; set; }

        [DisplayName(@"Tiêu đề tìm kiếm")]
        public string MetaTitle { get; set; }

        [DisplayName(@"Mô tả tìm kiếm")]
        public string MetaDescription { get; set; }

        [DisplayName(@"Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [DisplayName(@"Ngày chỉnh sửa")]
        public DateTime LastEditedTime { get; set; }

        [DisplayName(@"ID Thể loại")]
        public int ProductCategoryId { get; set; }

        [DisplayName(@"Hiển thị trang chủ")]
        public bool IsHomePage { get; set; }

        [DisplayName(@"Hiển thị công khai")]
        public bool IsPublic { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"Vị trí")]
        public int Position { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<ProductPictureMapping> ProductPictureMappings{ get; set; }

        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }

        public virtual ICollection<ProductSchedule> ProductSchedules { get; set; }
    }
}
