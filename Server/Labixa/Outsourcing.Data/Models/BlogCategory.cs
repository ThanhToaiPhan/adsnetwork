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
    public class BlogCategory : BaseEntity
    {
        [DisplayName(@"Tên")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Tình trạng")]
        public bool Status { get; set; }

        [DisplayName(@"Đường dẫn")]
        public string Slug { get; set; }

        [DisplayName(@"ID Thể loại cha")]
        public int? CategoryParentId { get; set; }

        [DisplayName(@"Bố trí")]
        public int Layout { get; set; }

        [DisplayName(@"Thứ tự hiển thị")]
        public int DisplayOrder { get; set; }

        [DisplayName(@"Là trang tĩnh")]
        public bool IsStaticPage { get; set; }

        virtual public ICollection<Blog> Blogs { get; set; }
        
        [ForeignKey("CategoryParentId")]
        virtual public BlogCategory CategoryParent { get; set; }
    }

}
