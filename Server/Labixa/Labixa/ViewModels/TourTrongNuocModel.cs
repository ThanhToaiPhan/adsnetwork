using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Outsourcing.Data.Models;
namespace Labixa.ViewModels
{
    public class TourTrongNuocModel
    {
        public List<Product> listTourInHot { get; set; }
        public List<Product> listTourInNew { get; set; }
        public List<Product> listTourIn { get; set; }
        public int totalPage { get; set; }
        public String viewType { get; set; }
        public String tourType { get; set; }
    }
}