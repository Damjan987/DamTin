using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DamTin.Core.Contracts;
using DamTin.Core.Models;
using DamTin.DataAccess.InMemory;

namespace DamTin.WebUI.Controllers
{
    public class TouristManagerController : Controller
    {
        IRepository<Tourist> context;

        public TouristManagerController(IRepository<Tourist> touristContext)
        {
            context = touristContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Tourist tourist = new Tourist();
            return View(tourist);
        }

        [HttpPost]
        public ActionResult Create(Tourist tourist) {
            if (!ModelState.IsValid) {
                return View(tourist);
            }
            else
            {
                context.Insert(tourist);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id) {
            Tourist tourist = context.Find(Id);
            if (tourist == null) {
                return HttpNotFound();
            }
            else
            {
                return View(tourist);
            }
        }

        [HttpPost]
        public ActionResult Edit(Tourist tourist, string Id) {
            Tourist touristToEdit = context.Find(Id);

            if (touristToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid) {
                    return View(tourist);
                }

                touristToEdit.Name = tourist.Name;
                touristToEdit.Lastname = tourist.Lastname;
                touristToEdit.Email = tourist.Email;
                touristToEdit.NumberOfDays = tourist.NumberOfDays;
                touristToEdit.DateOfComming = tourist.DateOfComming;
                touristToEdit.DateOfLeaving = tourist.DateOfLeaving;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id) {
            Tourist touristToDelete = context.Find(Id);

            if (touristToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(touristToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id) {
            Tourist touristToDelete = context.Find(Id);

            if (touristToDelete == null)
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