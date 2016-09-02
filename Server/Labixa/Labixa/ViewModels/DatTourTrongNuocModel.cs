using System.Collections.Generic;
using Outsourcing.Data.Models;

namespace Labixa.ViewModels
{
    public class DatTourTrongNuocModel
    {
        public DatTourTrongNuocModel()
        {
            productSchedule = new ProductSchedule();
        }
        public ProductSchedule productSchedule { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string note { get; set; }
        public int quantityAdult { get; set; }
        public int quantityChild { get; set; }
        public int quantityBaby { get; set; }
    }
}