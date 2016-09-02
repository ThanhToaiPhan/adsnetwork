using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labixa.ViewModels
{
    public class DichVuVisaModel
    {
        public Blog currentBlog { get; set; }
        public List<Blog> listBlog { get; set; }

        public DichVuVisaModel()
        {
            listBlog = new List<Blog>();
        }
    }
}