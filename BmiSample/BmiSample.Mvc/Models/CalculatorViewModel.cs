using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmiSample.Mvc.Models
{
    public class CalculatorViewModel
    {
        public int HeightCm { get; set; }
        public int WeightKg { get; set; }
        public double BmiIndex { get; set; }
    }
}
