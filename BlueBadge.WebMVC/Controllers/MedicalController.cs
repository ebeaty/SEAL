using BlueBadge.Models;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.WebMVC.Controllers
{
    public class MedicalController : Controller
    {
        // GET: Medical
        public ActionResult Index()
        {
            var service = new MedicalService();
            var model = service.GetMedicals();

            return View(model);
        }

        //GET Create
        public ActionResult Create()
        {
            return View();
        }

        //POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new MedicalService();

            if (service.CreateMedical(model))
            {
                TempData["SaveResult"] = "Medical Facility was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Medical Facility could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = new MedicalService();
            var model = svc.GetMedicalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = new MedicalService();
            var detail = service.GetMedicalById(id);
            var model =
                new MedicalEdit
                {
                    MedicalId = detail.MedicalId,
                    Name = detail.Name,
                    Location = detail.Location,
                    PhoneNumber = detail.PhoneNumber,
                    Website = detail.Website,
                    FinancialAid = detail.FinancialAid,
                    Details = detail.Details
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.MedicalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new MedicalService();

            if (service.UpdateMedical(model))
            {
                TempData["SaveResult"] = "Medical Facility was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Medical Facility could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = new MedicalService();
            var model = svc.GetMedicalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new MedicalService();

            service.DeleteMedical(id);

            TempData["SaveResult"] = "Medical Facility was deleted.";

            return RedirectToAction("Index");
        }
    }
}