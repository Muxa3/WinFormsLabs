using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class Lab1Controller : Controller
    {
        // GET: Lab1
        public ActionResult FirstViewMethod()
        {
            List<string> vegetables = GetVegetableList();
            return View(vegetables);
        }
        public ActionResult SecondViewMethod()
        {
            return View(GetVegetableList().OrderBy(x => x).ToList());
        }

        public ActionResult ThirdViewMethod()
        {
            return View(GetVegetableList().OrderBy(x => x).ToList());
        }

        public List<string> GetVegetableList()
        {
            List<string> vegetables = new List<string>();
            vegetables.Add("Томат");
            vegetables.Add("Огурец");
            vegetables.Add("Картофель");
            vegetables.Add("Кабачок");
            vegetables.Add("Баклажан");
            vegetables.Add("Капуста");
            vegetables.Add("Брокколи");

            return vegetables;
        }
    }
}