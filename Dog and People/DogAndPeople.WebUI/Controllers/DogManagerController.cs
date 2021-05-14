using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogAndPeople.Core.Contracts;
using DogAndPeople.Core.Models;

namespace DogAndPeople.WebUI.Controllers
{
    public class DogManagerController : Controller
    {
        IRepository<Caes> context;

        public DogManagerController(IRepository<Caes> dogContext)
        {
            context = dogContext;
        }
        // GET: DogManager
        public ActionResult Index()
        {
            List<Caes> dogs = context.Collection().ToList();
            return View(dogs);
        }

        public ActionResult Create()
        {
            Caes dog = new Caes();
            return View(dog);
        }

        [HttpPost]
        public ActionResult Create(Caes dog)
        {
            if (!ModelState.IsValid)
            {
                return View(dog);
            }
            else
            {
                context.Insert(dog);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int Id)
        {
            Caes dog = context.Find(Id);
            if(dog == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(dog);
            }
        }

        [HttpPost]
        public ActionResult Edit(Caes dog, int Id)
        {
            Caes dogToEdit = context.Find(Id);

            if (dogToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(dog);
                }

                dogToEdit.Name = dog.Name;
                dogToEdit.Race = dog.Race;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            Caes dogToDelete = context.Find(Id);

            if (dogToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(dogToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Caes dogToDelete = context.Find(Id);

            if (dogToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}