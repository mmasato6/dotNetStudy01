using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BmiSample.Mvc.Models;
using BmiSample.Domain;

namespace BmiSample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Calculate(int? heightCm, int? weightKg)
        {
            //入力チェック
            if (!heightCm.HasValue)
            {
                return RedirectToAction("Index");
            }
            if (!weightKg.HasValue)
            {
                return RedirectToAction("Index");
            }
            BmiCalculator calculator = new BmiCalculator();
            double result = calculator.Calculate(heightCm.Value, weightKg.Value);
            var vm = new CalculatorViewModel() { HeightCm = heightCm.Value, WeightKg = weightKg.Value, BmiIndex = result };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
