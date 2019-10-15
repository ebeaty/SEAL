using BlueBadge.Models;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.WebMVC.Controllers
{
    public class HotlineController : Controller
    {
        // GET: Hotline
        public ActionResult Index()
        {
            var service = new HotlineService();
            var model = service.GetHotlines();

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
        public ActionResult Create(HotlineCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new HotlineService();

            if (service.CreateHotline(model))
            {
                TempData["SaveResult"] = "Hotline was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Hotline could not be created.");

            return View(model);
        }

        //GET Details
        public ActionResult Details(int id)
        {
            var svc = new HotlineService();
            var model = svc.GetHotlineById(id);

            return View(model);
        }

        //GET Edit
        public ActionResult Edit(int id)
        {
            var service = new HotlineService();
            var detail = service.GetHotlineById(id);
            var model = new HotlineEdit
            {
                HotlineId = detail.HotlineId,
                Name = detail.Name,
                PhoneNumber = detail.PhoneNumber,
                Website = detail.Website,
                IsTextFriendly = detail.IsTextFriendly,
                IsMultilingual = detail.IsMultilingual,
                Details = detail.Details
            };
            return View(model);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HotlineEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.HotlineId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new HotlineService();

            if (service.UpdateHotline(model))
            {
                TempData["SaveResult"] = "Hotline was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Hotline could not be updated.");
            return View(model);
        }

        //GET Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = new HotlineService();
            var model = svc.GetHotlineById(id);

            return View(model);
        }

        //POST Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new HotlineService();

            service.DeleteHotline(id);

            TempData["SaveResult"] = "Hotline was deleted.";

            return RedirectToAction("Index");
        }

    }
}