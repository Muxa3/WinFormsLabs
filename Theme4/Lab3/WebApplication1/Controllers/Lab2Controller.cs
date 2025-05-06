using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class Lab2Controller : Controller
    {
        // GET: Lab2
        List<Tuple<string, string>> GetGenderList()
        {
            List<Tuple<string, string>> genders = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("F", "Женский"),
                new Tuple<string, string>("M", "Мужской")
            };
            return genders;
        }
        [HttpGet]
        public ActionResult CreatePerson()
        {
            ViewBag.Genders = new SelectList(GetGenderList(), "Item1", "Item2");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreatePerson(PersonVM newPerson)
        {
            if (ModelState.IsValid)
            {
                using (var context = new masterEntities())
                {
                    Person person = new Person
                    {
                        Id = Guid.NewGuid(),
                        LastName = newPerson.LastName,
                        FirstName = newPerson.FirstName,
                        Patronymic = newPerson.Patronymic,
                        Gender = newPerson.Gender,
                        Age = newPerson.Age,
                        HasJob = newPerson.HasJob,
                    };
                    context.Person.Add(person);
                    context.SaveChanges();
                }
                return RedirectToAction("ListOfPeople");
            }
            return View(newPerson);
        }
        public ActionResult ListOfPeople()
        {
            List<Person> people = new List<Person>();
            using (var db = new masterEntities())
            {
                people = db.Person.OrderByDescending(x => x.Age)
                    .ThenBy(x => x.LastName)
                    .ThenBy(x => x.FirstName).ToList();
            }
            return View(people);
        }

        [HttpGet] public ActionResult PersonDetails(Guid personId)
        { 
            Person model = new Person();
            using (var db = new masterEntities())
            {
                model = db.Person.Find(personId);
            }
            return View(model);
        }
    }
}