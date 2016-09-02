using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Outsourcing.Data.Models
{
    public class Picture : BaseEntity
    {
        [DisplayName(@"Mã nhị phân")]
        public string Binary { get; set; }

        [DisplayName(@"Dạng hình")]
        public string MimeType { get; set; }

        [DisplayName(@"Đường dẫn")]
        public string Url { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Đã xóa")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductPictureMapping> ProductPictureMapping { get; set; }

        public virtual ICollection<ProductSchedulePictureMapping> ProductSchedulePictureMapping { get; set; }
    }
}
