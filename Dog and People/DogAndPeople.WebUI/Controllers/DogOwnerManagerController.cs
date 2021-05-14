using DogAndPeople.Core.Contracts;
using DogAndPeople.Core.Models;
using DogAndPeople.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogAndPeople.WebUI.Controllers
{
    public class DogOwnerManagerController : Controller
    {
        IRepository<CaesDonos> dogOwnerContext;
        IRepository<Caes> dogContext;
        IRepository<Donos> ownerContext;

        public DogOwnerManagerController(IRepository<CaesDonos> dogOwnerContext, IRepository<Caes> dogContext, IRepository<Donos> ownerContext)
        {
            this.dogContext = dogContext;
            this.ownerContext = ownerContext;
            this.dogOwnerContext = dogOwnerContext;
        }

        // GET: DogOwnerManager
        public ActionResult Index()
        {
            //IndexCaesDonosViewModel viewModel = new IndexCaesDonosViewModel();
            //viewModel.CaesDonos = dogOwnerContext.Collection();
            //viewModel.Caes = dogContext.Collection();
            //viewModel.Donos = ownerContext.Collection();
            //return View(viewModel);

            List<CaesDonos> dogAndOwners = dogOwnerContext.Collection().ToList();
            return View(dogAndOwners);
        }

        public ActionResult Create()
        {
            CaesDonosViewModel viewModel = new CaesDonosViewModel();

            viewModel.Caes = dogContext.Collection();
            viewModel.Donos = ownerContext.Collection();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CaesDonosViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                viewModel.Caes = dogContext.Collection();
                viewModel.Donos = ownerContext.Collection();
                CaesDonos dogAndOwner = new CaesDonos();
                dogAndOwner.Id_dono = viewModel.Donos.FirstOrDefault(d => d.Name == viewModel.Dono).Id;
                dogAndOwner.Id_cao = viewModel.Caes.FirstOrDefault(d => d.Name == viewModel.Cao).Id;

                dogOwnerContext.Insert(dogAndOwner);
                dogOwnerContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int Id)
        {
            CaesDonos dogAndOwner = dogOwnerContext.Find(Id);
            if(dogAndOwner == null)
            {
                return HttpNotFound();
            }
            else
            {
                CaesDonosViewModel viewModel = new CaesDonosViewModel();
                viewModel.Id = dogAndOwner.Id;
                viewModel.Caes = dogContext.Collection();
                viewModel.Donos = ownerContext.Collection();
                viewModel.Dono = viewModel.Donos.FirstOrDefault(d => d.Id == dogAndOwner.Id_dono).Name;
                viewModel.Cao = viewModel.Caes.FirstOrDefault(d => d.Id == dogAndOwner.Id_cao).Name;
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(CaesDonosViewModel viewModel, int Id)
        {
            CaesDonos dogAndOwnerToEdit = dogOwnerContext.Find(Id);
            if(dogAndOwnerToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                viewModel.Caes = dogContext.Collection();
                viewModel.Donos = ownerContext.Collection();
                dogAndOwnerToEdit.Id_cao = viewModel.Caes.FirstOrDefault(d => d.Name == viewModel.Cao).Id;
                dogAndOwnerToEdit.Id_dono = viewModel.Donos.FirstOrDefault(d => d.Name == viewModel.Dono).Id;

                dogOwnerContext.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int Id)
        {
            CaesDonos dogAndOwnerToDelete = dogOwnerContext.Find(Id);

            if (dogAndOwnerToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(dogAndOwnerToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int Id)
        {
            CaesDonos dogAndOwnerToDelete = dogOwnerContext.Find(Id);

            if (dogAndOwnerToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                dogOwnerContext.Delete(Id);
                dogOwnerContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}