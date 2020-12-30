using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Models
{
    public class Club
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }
        [Display(Name = "Назва")]
        [UIHint("Назва")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        [UIHint("Опис")]
        public string Description { get; set; }
        [Display(Name = "Ціна")]
        [DataType(DataType.Currency)]
        [UIHint("Ціна")]
        public decimal Price { get; set; }
        [Display(Name = "Категорія")]
        [UIHint("Категорія")]
        public string Category { set; get; }
    }
}