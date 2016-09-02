using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Outsourcing.Data.Models;
using System;
//using FluentValidation.Mvc;
//using FluentValidation.Validators;
//using FluentValidation;

namespace Labixa.Areas.Admin.ViewModel
{
    //[FluentValidation.Attributes.Validator(typeof(ProductValidator))]

    public class ProductFormModel
    {
        public ProductFormModel()
        {
            ListProductCategory = new List<SelectListItem>();
            ListProducts = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }

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

        [DisplayName(@"Từ khóa tìm kiếm")]
        public string MetaKeywords { get; set; }

        [DisplayName(@"Tiêu đề tìm kiếm")]
        public string MetaTitle { get; set; }

        [DisplayName(@"Mô tả tìm kiếm")]
        public string MetaDescription { get; set; }

        [DisplayName(@"ID Thể loại")]
        public int ProductCategoryId { get; set; }

        [DisplayName(@"Hiển thị trang chủ")]
        public bool IsHomePage { get; set; }

        [DisplayName(@"Hiển thị công khai")]
        public bool IsPublic { get; set; }

        [DisplayName(@"Danh mục")]
        public IEnumerable<SelectListItem> ListProductCategory { get; set; }

        [DisplayName(@"Thuộc tính sản phẩm")]
        public ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }

        [DisplayName(@"Hình ảnh sản phẩm")]
        public ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }

        [DisplayName(@"Sản Phẩm")]
        public IEnumerable<SelectListItem> ListProducts { get; set; }
    }
}