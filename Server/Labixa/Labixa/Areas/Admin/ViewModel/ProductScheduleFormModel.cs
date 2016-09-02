using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Outsourcing.Data.Models;
using System;

namespace Labixa.Areas.Admin.ViewModel
{
    public class ProductScheduleFormModel
    {
        public ProductScheduleFormModel()
        {
            ListProduct = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayName(@"Giá")]
        public int Price { get; set; }

        [DisplayName(@"Sẵn sàng")]
        public bool IsAvailable { get; set; }

        [DisplayName(@"ID Sản phẩm")]
        public int ProductId { get; set; }

        [DisplayName(@"Số lượng tối đa")]
        public int MaxQuantity { get; set; }

        [DisplayName(@"Sản phẩm")]
        public IEnumerable<SelectListItem> ListProduct { get; set; }

        [DisplayName(@"Thuộc tính sản phẩm")]
        public ICollection<ProductScheduleAttributeMapping> ProductScheduleAttributeMappings { get; set; }

        [DisplayName(@"Hình ảnh sản phẩm")]
        public ICollection<ProductSchedulePictureMapping> ProductSchedulePictureMappings { get; set; }
    }
}