using System.ComponentModel;

namespace Outsourcing.Data.Models
{
    public class ProductSchedulePictureMapping : BaseEntity
    {
        [DisplayName(@"Tiêu đề")]
        public string Title { get; set; }

        [DisplayName(@"Thứ tự hiển thị")]
        public int DisplayOrder { get; set; }

        [DisplayName(@"Hình đại diện")]
        public bool IsMainPicture { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductScheduleId { get; set; }

        [DisplayName(@"ID Hình")]
        public int PictureId { get; set; }

        public virtual ProductSchedule ProductSchedule { get; set; }

        public virtual Picture Picture { get; set; }

    }
}
