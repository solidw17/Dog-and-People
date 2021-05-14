using DogAndPeople.Core.Contracts;
using DogAndPeople.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogAndPeople.WebUI.Controllers
{
    public class OwnerManagerController : Controller
    {
        IRepository<Donos> context;

        public OwnerManagerController(IRepository<Donos> ownerContext)
        {
            context = ownerContext;
        }
        // GET: OwnerManager
        public ActionResult Index()
        {
            List<Donos> owners = context.Collection().ToList();
            return View(owners);
        }

        public ActionResult Create()
        {
            Donos owner = new Donos();
            return View(owner);
        }

        [HttpPost]
        public ActionResult Create(Donos owner)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }
            else
            {
                context.Insert(owner);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int Id)
        {
            Donos owner = context.Find(Id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(owner);
            }
        }

        [HttpPost]
        public ActionResult Edit(Donos owner, int Id)
        {
            Donos ownerToEdit = context.Find(Id);

            if (ownerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(owner);
                }

                ownerToEdit.Name = owner.Name;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            Donos ownerToDelete = context.Find(Id);

            if (ownerToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ownerToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            Donos ownerToDelete = context.Find(Id);

            if (ownerToDelete == null)
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