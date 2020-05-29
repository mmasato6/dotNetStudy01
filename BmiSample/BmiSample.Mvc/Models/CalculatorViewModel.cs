using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BmiSample.Mvc.Models
{
    public class CalculatorViewModel
    {
        [Display(Name = "身長(cm)")]
        public int HeightCm { get; set; }
        [Display(Name = "体重(kg)")]
        public int WeightKg { get; set; }
        [Display(Name = "BMI指数")]
        public double BmiIndex { get; set; }
    }
}
