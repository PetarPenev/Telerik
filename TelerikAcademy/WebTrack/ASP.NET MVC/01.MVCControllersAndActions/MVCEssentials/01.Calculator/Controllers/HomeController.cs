using _01.Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.Calculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new CalculatorModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string quantity, string type, int kilo)
        {
            var model = new CalculatorModel();
            var index = model.ValueOptions.IndexOf(type);
            if (index % 2 == 0)
            {
                model.DataValues[0] = Math.Pow(kilo, index/2) * int.Parse(quantity);
                model.DataValues[1] = model.DataValues[0] / 8;
            }
            else
            {
                model.DataValues[0] = Math.Pow(kilo, index / 2) * 8 * int.Parse(quantity);
                model.DataValues[1] = Math.Pow(kilo, index / 2) * int.Parse(quantity);
            }

            for (int i = 2; i < model.DataValues.Length; i++)
            {
                model.DataValues[i] = model.DataValues[i - 2] / kilo;
            }


            return View(model);
        }
    }
}