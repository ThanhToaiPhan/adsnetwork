using Outsourcing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labixa.ViewModels
{
    public class TrangChuModel
    {
        public List<Product> listTourInHotHomePage { get; set; }
        public List<Product> listTourInNewHomePage { get; set; }
        public List<Product> listTourOutHotHomePage { get; set; }
        public List<Product> listTourOutNewHomePage { get; set; }
        public List<Product> listTourPromoHomePage { get; set; }
        public List<Blog> listNewBlog { get; set; }
    }
}