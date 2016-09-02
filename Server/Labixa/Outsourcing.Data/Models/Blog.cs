using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outsourcing.Data.Models
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            DateCreated = DateTime.Now;
            LastEditedTime = DateTime.Now;
        }
        [DisplayName(@"Tiêu đề")]
        public string Title { get; set; }

        [DisplayName(@"Đường dẫn")]
        public string Slug { get; set; }

        [DisplayName(@"Hình ảnh")]
        public string BlogImage { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Nội dung")]
        public string Content { get; set; }

        [DisplayName(@"Từ khóa tìm kiếm")]
        public string MetaKeywords { get; set; }

        [DisplayName(@"Tiêu đề tìm kiếm")]
        public string MetaTitle { get; set; }

        [DisplayName(@"Mô tả tìm kiếm")]
        public string MetaDescription { get; set; }

        [DisplayName(@"Sẵn sàng")]
        public bool IsAvailable { get; set; }

        [DisplayName(@"Hiển thị trang chủ")]
        public bool IsHomePage { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        [DisplayName(@"Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [DisplayName(@"Ngày chỉnh sửa")]
        public DateTime LastEditedTime { get; set; }

        [DisplayName(@"ID Hình")]
        public int PictureId { get; set; }

        [DisplayName(@"ID Thể loại")]
        public int BlogCategoryId { get; set; }

        [DisplayName(@"Vị trí")]
        public int Position { get; set; }

        [ForeignKey("BlogCategoryId")]
        virtual public BlogCategory BlogCategory { get; set; }

    }

}
