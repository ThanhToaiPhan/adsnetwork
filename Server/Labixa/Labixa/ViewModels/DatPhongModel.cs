using System.Collections.Generic;
using Outsourcing.Data.Models;
using System;

namespace Labixa.ViewModels
{
    public class DatPhongModel
    {
        public DatPhongModel()
        {
            productSchedule = new ProductSchedule();
            checkIn = DateTime.Now.Date.ToString();
            checkOut = DateTime.Now.Date.ToString();
        }
        public ProductSchedule productSchedule { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string customerPhone { get; set; }
        public string customerEmail { get; set; }
        public string note { get; set; }
        public int numberPerson { get; set; }
        public int numberRoom { get; set; }
        public int numberNight { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; } 
    }
}