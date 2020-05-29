using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BmiSample.Mvc.Models
{
    public class IndexViewModel
    {
        [Display(Name="身長(cm)")]
        [Range(1,999)]
        public int HeightCm { get; set; }
        [Display(Name ="体重(kg)")]
        [Range(1,999)]
        public int WeightKg { get; set; }
    }
}
