using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labixa;
using Outsourcing.Data.Models;
//using FluentValidation.Mvc;
//using FluentValidation.Validators;
//using FluentValidation;
using Labixa.App_Data;
namespace Labixa.Areas.Admin.ViewModel
{
    //[FluentValidation.Attributes.Validator(typeof(BlogValidator))]
    public class BlogFormModel
    {
        
        public BlogFormModel()
        {
            ListCategory = new List<SelectListItem>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string BlogImage { get; set; }

        public string Content { get; set; }

        public bool IsAvailable { get; set; }

        public int PictureId { get; set; }

        public int BlogCategoryId { get; set; }

        public IEnumerable<SelectListItem> ListCategory { get; set; }
    }
}