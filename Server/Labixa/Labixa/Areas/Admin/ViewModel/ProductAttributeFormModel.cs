using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using FluentValidation.Mvc;
//using FluentValidation.Validators;
//using FluentValidation;

namespace Labixa.Areas.Admin.ViewModel
{
    public class ProductAttributeFormModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName(@"Tên thuộc tính")]
        public string Name { get; set; }

        [DisplayName(@"Cách điều khiển")]
        public string ControlType { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }
    }
}